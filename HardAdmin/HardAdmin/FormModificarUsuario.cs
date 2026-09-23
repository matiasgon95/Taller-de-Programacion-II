using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

namespace HardAdmin
{
    public partial class FormModificarUsuario : Form
    {
        // Traemos la cadena de conexión desde el App.config para no tenerla hardcodeada en el código.
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Acá guardamos el ID del usuario que vamos a modificar. Lo recibimos al abrir el formulario.
        private int idUsuario;

        // Variables para la validación del formulario.
        private const int EDAD_MINIMA = 18;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>(); // Guarda qué campos tienen errores para hacerles foco después.

        public FormModificarUsuario(int idUsuario)
        {
            InitializeComponent();

            // Asignamos el ID que viene de la pantalla anterior (seguramente una grilla) a nuestra variable global.
            this.idUsuario = idUsuario;

            // Configuramos el ícono de error para que aparezca pegado a los controles y no titile (molesta menos a la vista).
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // ---------- ENGANCHE DE EVENTOS ----------
            // Bloqueos de teclado en tiempo real (para que no metan números en el nombre, etc.)
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;

            // Cuando salen del campo, les ponemos la primera letra en mayúscula automáticamente.
            txtNombre.Leave += CapitalizarTexto_Leave;
            txtApellido.Leave += CapitalizarTexto_Leave;

            txtDni.KeyPress += SoloNumeros_KeyPress;
            txtDni.MaxLength = 8;
            txtAltura.KeyPress += SoloNumeros_KeyPress;

            // Evitamos que elijan una fecha en el futuro.
            dtpFechaNacimiento.MaxDate = DateTime.Today;

            // Limitamos el largo de los textos para que coincida exacto con la base de datos y no explote el SQL.
            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtCalle.MaxLength = 100;
            txtDpto.MaxLength = 10;
            txtLocalidad.MaxLength = 100;
            txtAltura.MaxLength = 20;
            txtUsuario.MaxLength = 50;
            txtEmail.MaxLength = 100;

            // Cada vez que escriben una letra en la dirección, armamos la "Dirección Completa" al vuelo.
            txtCalle.TextChanged += ActualizarDireccionCompleta;
            txtAltura.TextChanged += ActualizarDireccionCompleta;
            txtDpto.TextChanged += ActualizarDireccionCompleta;
            txtLocalidad.TextChanged += ActualizarDireccionCompleta;

            // Lógica visual de las contraseñas.
            chkCambiarClave.CheckedChanged += chkCambiarClave_CheckedChanged;
            chkVerClave.CheckedChanged += chkVerClave_CheckedChanged;

            // Enganchamos la validación de cada campo al evento Leave. 
            // Así, apenas el usuario sale de un campo, le avisamos si está mal sin tener que esperar a que apriete Guardar.
            txtNombre.Leave += txtNombre_Leave;
            txtApellido.Leave += txtApellido_Leave;
            txtDni.Leave += txtDni_Leave;
            dtpFechaNacimiento.ValueChanged += dtpFechaNacimiento_ValueChanged;
            txtCalle.Leave += txtCalle_Leave;
            txtAltura.Leave += txtAltura_Leave;
            txtLocalidad.Leave += txtLocalidad_Leave;
            txtUsuario.Leave += txtNombreUsuario_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtContrasena.Leave += txtContrasena_Leave;
            txtConfirmarContrasena.Leave += txtConfirmarContrasena_Leave;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;

            // Por defecto, como estamos editando un usuario, bloqueamos los campos de contraseña 
            // para no obligar a cambiarla si solo querían arreglar un error en el nombre.
            txtContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
            chkVerClave.Enabled = false;

            // Vamos a buscar la información a la base de datos para llenar los campos.
            CargarRoles();
            CargarDatosUsuario();
        }

        // Busca los roles disponibles y los mete en el ComboBox.
        private void CargarRoles()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT id_rol, nombre_rol FROM Rol";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbRol.DisplayMember = "nombre_rol"; // Lo que lee la persona
                        cmbRol.ValueMember = "id_rol";       // El número que guardamos por atrás
                        cmbRol.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Trae toda la información del usuario seleccionado usando el ID y completa el formulario.
        private void CargarDatosUsuario()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT nombre_usuario, email, id_rol, baja, 
                                            nombre, apellido, dni, fecha_nacimiento, 
                                            calle, altura, dpto, localidad 
                                     FROM Usuario WHERE id_usuario = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", this.idUsuario);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Llenamos los datos de acceso
                                txtUsuario.Text = reader["nombre_usuario"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                cmbRol.SelectedValue = Convert.ToInt32(reader["id_rol"]);

                                // Llenamos los datos personales
                                txtNombre.Text = reader["nombre"].ToString();
                                txtApellido.Text = reader["apellido"].ToString();
                                txtDni.Text = reader["dni"].ToString();

                                // Como la fecha permite nulos en la BD, comprobamos que tenga algo antes de asignarla.
                                if (reader["fecha_nacimiento"] != DBNull.Value)
                                    dtpFechaNacimiento.Value = Convert.ToDateTime(reader["fecha_nacimiento"]);

                                // Llenamos la dirección
                                txtCalle.Text = reader["calle"].ToString();
                                txtAltura.Text = reader["altura"].ToString();
                                txtDpto.Text = reader["dpto"].ToString();
                                txtLocalidad.Text = reader["localidad"].ToString();

                                // Manejamos los radio buttons. Si baja es 0 está activo, si es 1 está inactivo.
                                int baja = Convert.ToInt32(reader["baja"]);
                                if (baja == 0)
                                {
                                    rbActivoSi.Checked = true;
                                }
                                else
                                {
                                    rbActivoNo.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Concatena calle, altura, departamento y localidad en un solo string prolijo.
        private void ActualizarDireccionCompleta(object sender, EventArgs e)
        {
            string calle = txtCalle.Text.Trim();
            string altura = txtAltura.Text.Trim();
            string dpto = txtDpto.Text.Trim();
            string localidad = txtLocalidad.Text.Trim();

            string direccion = $"{calle} {altura}".Trim();

            if (!string.IsNullOrWhiteSpace(dpto))
            {
                direccion += $" Dpto {dpto}";
            }

            if (!string.IsNullOrWhiteSpace(localidad))
            {
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

        // ---------- HELPERS DE FORMATO ----------

        // Corta el tipeo de cualquier cosa que no sea una letra o espacio.
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // Corta el tipeo de letras o símbolos en los campos numéricos.
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Pasa a mayúscula la primera letra de cada palabra. Ej: "matias gonzalez" -> "Matias Gonzalez".
        private void CapitalizarTexto_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text)) return;

            TextInfo textInfo = CultureInfo.GetCultureInfo("es-AR").TextInfo;
            txt.Text = textInfo.ToTitleCase(txt.Text.Trim().ToLower(CultureInfo.GetCultureInfo("es-AR")));
        }

        // Se ejecuta cuando tildan o destildan "Modificar contraseña".
        private void chkCambiarClave_CheckedChanged(object sender, EventArgs e)
        {
            bool cambiar = chkCambiarClave.Checked;

            // Habilitamos o bloqueamos las cajas de texto según el tilde.
            txtContrasena.Enabled = cambiar;
            txtConfirmarContrasena.Enabled = cambiar;
            chkVerClave.Enabled = cambiar;

            // Si se arrepienten y destildan, limpiamos lo que habían escrito y borramos los íconos de error.
            if (!cambiar)
            {
                txtContrasena.Clear();
                txtConfirmarContrasena.Clear();
                chkVerClave.Checked = false;

                Marcar(txtContrasena, true, "");
                Marcar(txtConfirmarContrasena, true, "");
            }
        }

        // Alterna entre mostrar asteriscos o el texto real en las claves.
        private void chkVerClave_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
            txtConfirmarContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
        }

        // Revisa que el string tenga únicamente letras y espacios (permite ñ y tildes).
        private bool EsSoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[\p{L}\s]+$");
        }

        // Valida que sean exactamente entre 7 y 8 números consecutivos.
        private bool EsDniValido(string dni)
        {
            return Regex.IsMatch(dni, @"^\d{7,8}$");
        }

        // Valida que el texto tenga formato de correo usando las librerías propias de C#.
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

        // Calcula la edad real (teniendo en cuenta meses y días) y valida contra el mínimo.
        private bool CumpleEdadMinima(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;
            if (fechaNacimiento.Date > hoy) return false;

            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;

            return edad >= EDAD_MINIMA;
        }

        // Método centralizador de errores. Si algo está mal, prende el ErrorProvider rojo.
        // Si está bien, lo apaga. Además lleva un registro de cuántos controles están mal.
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

        // Si fallan varios campos a la vez al dar Guardar, esto busca cuál está más arriba
        // en el formulario (según el TabIndex) y pone el cursor ahí para que el usuario empiece a corregir.
        private void EnfocarPrimerInvalidoPorTabOrder()
        {
            Control primero = controlesInvalidos.OrderBy(c => c.TabIndex).FirstOrDefault();
            primero?.Focus();
        }

        // CRÍTICO PARA MODIFICACIÓN: Comprueba si un DNI/Email/User ya existe, pero 
        // IGNORA al propio usuario que estamos editando. Si no hacemos esto, tiraría error
        // por encontrar sus propios datos en la base.
        private bool ExisteEnUsuarioModificacion(string columna, string valor)
        {
            string query = $"SELECT COUNT(1) FROM Usuario WHERE {columna} = @valor AND id_usuario != @idActual";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@idActual", this.idUsuario);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ---------- VALIDACIÓN POR CAMPO ----------
        // Todas estas funciones devuelven true o false, y llaman a Marcar() para prender/apagar el error.

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
                Marcar(txtDni, false, "El DNI es obligatorio y debe tener entre 7 y 8 números.");
                return false;
            }

            bool disponible = !ExisteEnUsuarioModificacion("dni", valor);
            Marcar(txtDni, disponible, "El DNI ya se encuentra registrado en otro usuario.");
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

            bool disponible = !ExisteEnUsuarioModificacion("nombre_usuario", valor);
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

            bool disponible = !ExisteEnUsuarioModificacion("email", valor);
            Marcar(txtEmail, disponible, "El email ya se encuentra registrado en otro usuario.");
            return disponible;
        }

        private bool ValidarContrasena()
        {
            // Si no está tildado el checkbox de modificar, siempre da "válido" porque no se toca.
            if (!chkCambiarClave.Checked) return true;

            string valor = txtContrasena.Text;
            bool ok = !string.IsNullOrWhiteSpace(valor) && valor.Length >= 6;
            Marcar(txtContrasena, ok, "La contraseña debe tener al menos 6 caracteres.");
            return ok;
        }

        private bool ValidarConfirmarContrasena()
        {
            if (!chkCambiarClave.Checked) return true;

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

        // ---------- EVENTOS LEAVE ----------
        // Vinculan la salida del campo con su función de validación.
        private void txtNombre_Leave(object sender, EventArgs e) => ValidarNombre();
        private void txtApellido_Leave(object sender, EventArgs e) => ValidarApellido();
        private void txtDni_Leave(object sender, EventArgs e) => ValidarDni();
        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e) => ValidarFechaNacimiento();
        private void txtCalle_Leave(object sender, EventArgs e) => ValidarCalle();
        private void txtAltura_Leave(object sender, EventArgs e) => ValidarAltura();
        private void txtLocalidad_Leave(object sender, EventArgs e) => ValidarLocalidad();
        private void txtNombreUsuario_Leave(object sender, EventArgs e) => ValidarUsuario();
        private void txtEmail_Leave(object sender, EventArgs e) => ValidarEmail();
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e) => ValidarRol();

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (chkCambiarClave.Checked)
            {
                ValidarContrasena();
                // Si el segundo campo ya tiene texto, lo validamos también para ver si coinciden.
                if (!string.IsNullOrEmpty(txtConfirmarContrasena.Text))
                {
                    ValidarConfirmarContrasena();
                }
            }
        }

        private void txtConfirmarContrasena_Leave(object sender, EventArgs e) => ValidarConfirmarContrasena();

        // ---------- BOTÓN GUARDAR ----------

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Reseteamos el estado a "todo válido" antes de hacer el chequeo final.
            formularioValido = true;
            controlesInvalidos.Clear();

            // Ejecutamos TODAS las validaciones juntas. Si alguna falla, formularioValido pasa a false.
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

            // Si hay algo mal, cortamos acá nomás y ponemos el cursor en el error.
            if (!formularioValido)
            {
                EnfocarPrimerInvalidoPorTabOrder();
                return;
            }

            // Mapeamos qué guardar de los radio buttons.
            int baja = rbActivoSi.Checked ? 0 : 1;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Armamos un UPDATE dinámico. Arrancamos con los campos que se actualizan siempre.
                    string query = @"UPDATE Usuario 
                                     SET nombre_usuario = @usuario, 
                                         email = @email, 
                                         id_rol = @idRol, 
                                         baja = @baja,
                                         nombre = @nombre, 
                                         apellido = @apellido, 
                                         dni = @dni, 
                                         fecha_nacimiento = @fechaNacimiento,
                                         calle = @calle, 
                                         altura = @altura, 
                                         dpto = @dpto, 
                                         localidad = @localidad";

                    // Si decidieron cambiar la clave, sumamos la columna al UPDATE.
                    if (chkCambiarClave.Checked)
                    {
                        query += ", contrasena = @contrasena";
                    }

                    // Cerramos la instrucción.
                    query += " WHERE id_usuario = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Carga masiva de los parámetros limpios al comando SQL.
                        cmd.Parameters.AddWithValue("@id", this.idUsuario);
                        cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@idRol", (int)cmbRol.SelectedValue);
                        cmd.Parameters.AddWithValue("@baja", baja);

                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@dni", txtDni.Text.Trim());
                        cmd.Parameters.AddWithValue("@fechaNacimiento", dtpFechaNacimiento.Value.Date);
                        cmd.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
                        cmd.Parameters.AddWithValue("@altura", txtAltura.Text.Trim());

                        // El depto lo mandamos como NULL explícito a la base si está vacío.
                        cmd.Parameters.AddWithValue("@dpto", string.IsNullOrWhiteSpace(txtDpto.Text) ? (object)DBNull.Value : txtDpto.Text.Trim());
                        cmd.Parameters.AddWithValue("@localidad", txtLocalidad.Text.Trim());

                        // Si marcamos el tilde de cambiar clave, hacemos el hash y lo agregamos como parámetro.
                        if (chkCambiarClave.Checked)
                        {
                            string nuevaContrasenaHash = HardAdmin.Negocio.Seguridad.HashearContrasena(txtContrasena.Text);
                            cmd.Parameters.AddWithValue("@contrasena", nuevaContrasenaHash);
                        }

                        // Abrimos conexión y tiramos el UPDATE.
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Le avisamos a la grilla que se modificó algo y cerramos.
                this.Close();
            }
            catch (SqlException ex)
            {
                // Manejo de errores a nivel base de datos por si, justo antes de guardar, 
                // alguien más registró un DNI/User/Email repetido y la BD lo rebotó por UNIQUE KEY.
                if (ex.Number == 2627 || ex.Number == 2601)
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