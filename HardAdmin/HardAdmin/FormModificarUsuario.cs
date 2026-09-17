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
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;
        private int idUsuario;

        private const int EDAD_MINIMA = 18;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        public FormModificarUsuario(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Asignamos los eventos de validación y formato
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;
            txtNombre.Leave += CapitalizarTexto_Leave;
            txtApellido.Leave += CapitalizarTexto_Leave;

            txtDni.KeyPress += SoloNumeros_KeyPress;
            txtDni.MaxLength = 8;
            txtAltura.KeyPress += SoloNumeros_KeyPress;

            dtpFechaNacimiento.MaxDate = DateTime.Today;

            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtCalle.MaxLength = 100;
            txtDpto.MaxLength = 10;
            txtLocalidad.MaxLength = 100;
            txtAltura.MaxLength = 20;
            txtUsuario.MaxLength = 50;
            txtEmail.MaxLength = 100;

            txtCalle.TextChanged += ActualizarDireccionCompleta;
            txtAltura.TextChanged += ActualizarDireccionCompleta;
            txtDpto.TextChanged += ActualizarDireccionCompleta;
            txtLocalidad.TextChanged += ActualizarDireccionCompleta;

            chkCambiarClave.CheckedChanged += chkCambiarClave_CheckedChanged;
            chkVerClave.CheckedChanged += chkVerClave_CheckedChanged;

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

            // Estado inicial de las contraseñas
            txtContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
            chkVerClave.Enabled = false;

            // Cargamos los datos directo en el constructor como lo tenías originalmente
            CargarRoles();
            CargarDatosUsuario();
        }

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

                        cmbRol.DisplayMember = "nombre_rol";
                        cmbRol.ValueMember = "id_rol";
                        cmbRol.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                                // Datos de acceso
                                txtUsuario.Text = reader["nombre_usuario"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                cmbRol.SelectedValue = Convert.ToInt32(reader["id_rol"]);

                                // Datos personales
                                txtNombre.Text = reader["nombre"].ToString();
                                txtApellido.Text = reader["apellido"].ToString();
                                txtDni.Text = reader["dni"].ToString();

                                if (reader["fecha_nacimiento"] != DBNull.Value)
                                    dtpFechaNacimiento.Value = Convert.ToDateTime(reader["fecha_nacimiento"]);

                                // Dirección
                                txtCalle.Text = reader["calle"].ToString();
                                txtAltura.Text = reader["altura"].ToString();
                                txtDpto.Text = reader["dpto"].ToString();
                                txtLocalidad.Text = reader["localidad"].ToString();

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

        // ---------- Helpers de formato ----------

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CapitalizarTexto_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text)) return;

            TextInfo textInfo = CultureInfo.GetCultureInfo("es-AR").TextInfo;
            txt.Text = textInfo.ToTitleCase(txt.Text.Trim().ToLower(CultureInfo.GetCultureInfo("es-AR")));
        }

        private void chkCambiarClave_CheckedChanged(object sender, EventArgs e)
        {
            bool cambiar = chkCambiarClave.Checked;
            txtContrasena.Enabled = cambiar;
            txtConfirmarContrasena.Enabled = cambiar;

            // Habilita o deshabilita el checkbox de mostrar contraseñas
            chkVerClave.Enabled = cambiar;

            if (!cambiar)
            {
                txtContrasena.Clear();
                txtConfirmarContrasena.Clear();

                // Destildamos el mostrar clave por si lo había dejado marcado
                chkVerClave.Checked = false;

                Marcar(txtContrasena, true, "");
                Marcar(txtConfirmarContrasena, true, "");
            }
        }

        private void chkVerClave_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
            txtConfirmarContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
        }

        private bool EsSoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[\p{L}\s]+$");
        }

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
            if (fechaNacimiento.Date > hoy) return false;

            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;

            return edad >= EDAD_MINIMA;
        }

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

        private void EnfocarPrimerInvalidoPorTabOrder()
        {
            Control primero = controlesInvalidos.OrderBy(c => c.TabIndex).FirstOrDefault();
            primero?.Focus();
        }

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

        // ---------- Validación por campo ----------

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

        // ---------- Eventos Leave / Changed ----------

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
                if (!string.IsNullOrEmpty(txtConfirmarContrasena.Text))
                {
                    ValidarConfirmarContrasena();
                }
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

            int baja = rbActivoSi.Checked ? 0 : 1;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
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

                    if (chkCambiarClave.Checked)
                    {
                        query += ", contrasena = @contrasena";
                    }

                    query += " WHERE id_usuario = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
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
                        cmd.Parameters.AddWithValue("@dpto", string.IsNullOrWhiteSpace(txtDpto.Text) ? (object)DBNull.Value : txtDpto.Text.Trim());
                        cmd.Parameters.AddWithValue("@localidad", txtLocalidad.Text.Trim());

                        if (chkCambiarClave.Checked)
                        {
                            string nuevaContrasenaHash = Seguridad.HashearContrasena(txtContrasena.Text);
                            cmd.Parameters.AddWithValue("@contrasena", nuevaContrasenaHash);
                        }

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
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