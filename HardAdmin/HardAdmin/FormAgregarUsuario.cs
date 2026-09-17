using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace HardAdmin
{
    public partial class FormAgregarUsuario : Form
    {
        // Lee la conexión desde el App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Edad mínima requerida para dar de alta un usuario.
        private const int EDAD_MINIMA = 18;

        // Se crea por código para no depender de agregarlo desde el diseñador.
        private ErrorProvider errorProvider = new ErrorProvider();

        // Se van completando durante cada intento de guardar (ver Marcar()).
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        public FormAgregarUsuario()
        {
            InitializeComponent();

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Asignamos los eventos de validación y formato a los campos correspondientes.
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;
            txtNombre.Leave += CapitalizarTexto_Leave;
            txtApellido.Leave += CapitalizarTexto_Leave;

            txtDni.KeyPress += SoloNumeros_KeyPress;
            txtDni.MaxLength = 8;

            txtAltura.KeyPress += SoloNumeros_KeyPress;

            // No se puede seleccionar una fecha de nacimiento futura desde el propio control.
            dtpFechaNacimiento.MaxDate = DateTime.Today;

            // Largos máximos alineados a los varchar(n) de la tabla Usuario,
            // para no depender de que SQL Server tire el error de truncamiento.
            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtCalle.MaxLength = 100;
            txtDpto.MaxLength = 10;
            txtLocalidad.MaxLength = 100;
            txtAltura.MaxLength = 20;
            txtUsuario.MaxLength = 50;
            txtEmail.MaxLength = 100;

            // Arma la dirección completa a medida que se completan sus cuatro partes.
            txtCalle.TextChanged += ActualizarDireccionCompleta;
            txtAltura.TextChanged += ActualizarDireccionCompleta;
            txtDpto.TextChanged += ActualizarDireccionCompleta;
            txtLocalidad.TextChanged += ActualizarDireccionCompleta;

            // Muestra u oculta el contenido de las dos contraseñas.
            chkVerClave.CheckedChanged += chkVerClave_CheckedChanged;

            // Revalida cada campo al salir de él, así el error desaparece apenas se corrige
            // sin tener que volver a apretar Guardar.
            txtNombre.Leave += txtNombre_Leave;
            txtApellido.Leave += txtApellido_Leave;
            txtDni.Leave += txtDni_Leave;
            dtpFechaNacimiento.ValueChanged += dtpFechaNacimiento_ValueChanged;
            txtCalle.Leave += txtCalle_Leave;
            txtAltura.Leave += txtAltura_Leave;
            txtLocalidad.Leave += txtLocalidad_Leave;
            txtUsuario.Leave += txtUsuario_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtContrasena.Leave += txtContrasena_Leave;
            txtConfirmarContrasena.Leave += txtConfirmarContrasena_Leave;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;
        }

        private void FormAgregarUsuario_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Rol";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            cmbRol.DataSource = dt;
                            cmbRol.DisplayMember = "nombre_rol";
                            cmbRol.ValueMember = "id_rol";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDireccionCompleta(object sender, EventArgs e)
        {
            string calle = txtCalle.Text.Trim();
            string altura = txtAltura.Text.Trim();
            string dpto = txtDpto.Text.Trim();
            string localidad = txtLocalidad.Text.Trim();

            // Armamos la primera parte (Calle y Altura)
            string direccion = $"{calle} {altura}".Trim();

            // Si hay departamento, lo sumamos
            if (!string.IsNullOrWhiteSpace(dpto))
            {
                direccion += $" Dpto {dpto}";
            }

            // Agregamos la localidad si existe, separada por una coma
            if (!string.IsNullOrWhiteSpace(localidad))
            {
                // Si no se cargó calle ni altura antes, evitamos que arranque con una coma
                if (direccion.Length > 0)
                {
                    direccion += $", {localidad}";
                }
                else
                {
                    direccion = $"{localidad}";
                }
            }

            txtDireccionCompleta.Text = direccion;
        }

        // ---------- Helpers de formato ----------

        // Bloquea en tiempo real cualquier tecla que no sea letra, espacio o control (backspace, etc.)
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // Bloquea en tiempo real cualquier tecla que no sea número o control
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Al salir del campo, pone en mayúscula la primera letra de cada palabra
        // (ej: "juan carlos" -> "Juan Carlos")
        private void CapitalizarTexto_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text)) return;

            TextInfo textInfo = CultureInfo.GetCultureInfo("es-AR").TextInfo;
            txt.Text = textInfo.ToTitleCase(txt.Text.Trim().ToLower(CultureInfo.GetCultureInfo("es-AR")));
        }

        // Alterna entre mostrar y ocultar el contenido de los dos campos de contraseña
        private void chkVerClave_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
            txtConfirmarContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
        }

        // Solo letras (incluye acentos y ñ) y espacios, sin dejarlo vacío
        private bool EsSoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[\p{L}\s]+$");
        }

        // DNI: solo dígitos, entre 7 y 8 caracteres.
        private bool EsDniValido(string dni)
        {
            return Regex.IsMatch(dni, @"^\d{7,8}$");
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var direccion = new MailAddress(email);
                return direccion.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool CumpleEdadMinima(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;
            if (fechaNacimiento.Date > hoy) return false; // fecha futura

            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;

            return edad >= EDAD_MINIMA;
        }

        // Marca (o limpia) el error de un control puntual y actualiza el estado general
        // del formulario, sin cortar la ejecución. Así se revisan todos los campos de una.
        private void Marcar(Control control, bool condicionValida, string mensajeError)
        {
            if (condicionValida)
            {
                errorProvider.SetError(control, string.Empty);
                controlesInvalidos.Remove(control);
            }
            else
            {
                errorProvider.SetError(control, mensajeError);
                formularioValido = false;
                if (!controlesInvalidos.Contains(control))
                {
                    controlesInvalidos.Add(control);
                }
            }
        }

        // De todos los controles marcados como inválidos, devuelve el que corresponde
        // según el orden de tabulación (TabIndex) del formulario, no el orden del código.
        private void EnfocarPrimerInvalidoPorTabOrder()
        {
            Control primero = controlesInvalidos.OrderBy(c => c.TabIndex).FirstOrDefault();
            primero?.Focus();
        }

        // Verifica si ya existe un valor cargado en una columna de Usuario (usuario/email/dni)
        private bool ExisteEnUsuario(string columna, string valor)
        {
            string query = $"SELECT COUNT(1) FROM Usuario WHERE {columna} = @valor";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@valor", valor);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ---------- Validación por campo (se usan tanto al salir del campo como al guardar) ----------

        private bool ValidarNombre()
        {
            string valor = txtNombre.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor) && EsSoloLetras(valor);
            Marcar(txtNombre, ok, "El nombre es obligatorio y solo puede contener letras.");
            return ok;
        }

        private bool ValidarApellido()
        {
            string valor = txtApellido.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor) && EsSoloLetras(valor);
            Marcar(txtApellido, ok, "El apellido es obligatorio y solo puede contener letras.");
            return ok;
        }

        private bool ValidarDni()
        {
            string valor = txtDni.Text.Trim();
            if (string.IsNullOrWhiteSpace(valor) || !EsDniValido(valor))
            {
                Marcar(txtDni, false, "El DNI es obligatorio y debe tener entre 7 y 8 números, sin letras ni puntos.");
                return false;
            }

            bool disponible = !ExisteEnUsuario("dni", valor);
            Marcar(txtDni, disponible, "El DNI ya se encuentra registrado.");
            return disponible;
        }

        private bool ValidarFechaNacimiento()
        {
            bool ok = CumpleEdadMinima(dtpFechaNacimiento.Value);
            Marcar(dtpFechaNacimiento, ok, $"La fecha no puede ser futura y el usuario debe ser mayor de {EDAD_MINIMA} años.");
            return ok;
        }

        private bool ValidarCalle()
        {
            bool ok = !string.IsNullOrWhiteSpace(txtCalle.Text.Trim());
            Marcar(txtCalle, ok, "Debe ingresar la calle.");
            return ok;
        }

        private bool ValidarAltura()
        {
            string valor = txtAltura.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor) && Regex.IsMatch(valor, @"^\d+$");
            Marcar(txtAltura, ok, "El número de altura es obligatorio y debe ser numérico.");
            return ok;
        }

        private bool ValidarLocalidad()
        {
            bool ok = !string.IsNullOrWhiteSpace(txtLocalidad.Text.Trim());
            Marcar(txtLocalidad, ok, "Debe ingresar la localidad.");
            return ok;
        }

        private bool ValidarUsuario()
        {
            string valor = txtUsuario.Text.Trim();
            if (string.IsNullOrWhiteSpace(valor) || valor.Length < 4)
            {
                Marcar(txtUsuario, false, "El nombre de usuario es obligatorio y debe tener al menos 4 caracteres.");
                return false;
            }

            bool disponible = !ExisteEnUsuario("nombre_usuario", valor);
            Marcar(txtUsuario, disponible, "El nombre de usuario ya se encuentra registrado.");
            return disponible;
        }

        private bool ValidarEmail()
        {
            string valor = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(valor) || !EsEmailValido(valor))
            {
                Marcar(txtEmail, false, "Debe ingresar un email con formato válido.");
                return false;
            }

            bool disponible = !ExisteEnUsuario("email", valor);
            Marcar(txtEmail, disponible, "El email ya se encuentra registrado.");
            return disponible;
        }

        private bool ValidarContrasena()
        {
            string valor = txtContrasena.Text;
            bool ok = !string.IsNullOrWhiteSpace(valor) && valor.Length >= 6;
            Marcar(txtContrasena, ok, "La contraseña es obligatoria y debe tener al menos 6 caracteres.");
            return ok;
        }

        private bool ValidarConfirmarContrasena()
        {
            bool ok = txtContrasena.Text == txtConfirmarContrasena.Text;
            Marcar(txtConfirmarContrasena, ok, "Las contraseñas no coinciden.");
            return ok;
        }

        private bool ValidarRol()
        {
            bool ok = cmbRol.SelectedValue != null;
            Marcar(cmbRol, ok, "Debe seleccionar un rol.");
            return ok;
        }

        // ---------- Eventos Leave / Changed que disparan la revalidación de cada campo ----------

        private void txtNombre_Leave(object sender, EventArgs e) => ValidarNombre();
        private void txtApellido_Leave(object sender, EventArgs e) => ValidarApellido();
        private void txtDni_Leave(object sender, EventArgs e) => ValidarDni();
        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e) => ValidarFechaNacimiento();
        private void txtCalle_Leave(object sender, EventArgs e) => ValidarCalle();
        private void txtAltura_Leave(object sender, EventArgs e) => ValidarAltura();
        private void txtLocalidad_Leave(object sender, EventArgs e) => ValidarLocalidad();
        private void txtUsuario_Leave(object sender, EventArgs e) => ValidarUsuario();
        private void txtEmail_Leave(object sender, EventArgs e) => ValidarEmail();
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e) => ValidarRol();

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            ValidarContrasena();

            // Si ya había algo cargado en "Repetir", revisamos que siga coincidiendo.
            if (!string.IsNullOrEmpty(txtConfirmarContrasena.Text))
            {
                ValidarConfirmarContrasena();
            }
        }

        private void txtConfirmarContrasena_Leave(object sender, EventArgs e) => ValidarConfirmarContrasena();

        // ---------- Guardar ----------

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            formularioValido = true;
            controlesInvalidos.Clear();

            ValidarNombre();
            ValidarApellido();
            ValidarDni();
            ValidarFechaNacimiento();
            ValidarCalle();
            ValidarAltura();
            ValidarLocalidad();
            ValidarUsuario();
            ValidarEmail();
            ValidarContrasena();
            ValidarConfirmarContrasena();
            ValidarRol();

            if (!formularioValido)
            {
                EnfocarPrimerInvalidoPorTabOrder();
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();
            string calle = txtCalle.Text.Trim();
            string altura = txtAltura.Text.Trim();
            string dpto = txtDpto.Text.Trim();
            string localidad = txtLocalidad.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contrasena = txtContrasena.Text;

            // --- Inserción en la base de datos ---
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Usuario
                                     (nombre_usuario, email, contrasena, id_rol, baja,
                                      nombre, apellido, dni, fecha_nacimiento,
                                      calle, altura, dpto, localidad)
                                     VALUES
                                     (@usuario, @email, @contrasena, @idRol, 0,
                                      @nombre, @apellido, @dni, @fechaNacimiento,
                                      @calle, @altura, @dpto, @localidad)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Hasheamos la contraseña antes de guardarla en la base de datos
                        string contrasenaHasheada = Seguridad.HashearContrasena(contrasena);

                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@contrasena", contrasenaHasheada);
                        cmd.Parameters.AddWithValue("@idRol", (int)cmbRol.SelectedValue);

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@dni", dni);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", dtpFechaNacimiento.Value.Date);

                        cmd.Parameters.AddWithValue("@calle", calle);
                        cmd.Parameters.AddWithValue("@altura", altura);
                        cmd.Parameters.AddWithValue("@dpto", string.IsNullOrWhiteSpace(dpto) ? (object)DBNull.Value : dpto);
                        cmd.Parameters.AddWithValue("@localidad", localidad);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Esto es para el UNIQUE constraint violation (nombre_usuario, email o dni duplicados)
                {
                    MessageBox.Show("El nombre de usuario, email o DNI ya se encuentra registrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}