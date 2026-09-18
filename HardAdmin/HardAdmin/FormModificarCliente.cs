using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormModificarCliente : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Guardamos el ID del cliente que estamos tocando
        private int idCliente;

        private ErrorProvider errorProvider = new ErrorProvider();
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        public FormModificarCliente(int idCliente)
        {
            InitializeComponent();

            this.idCliente = idCliente;

            // Configuramos el ErrorProvider
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Bloqueamos la dirección
            txtDireccion.ReadOnly = true;
            txtDireccion.TabStop = false;

            // Enganchamos las validaciones en tiempo real
            txtNombre.Leave += txtNombre_Leave;
            txtApellido.Leave += txtApellido_Leave;
            txtDNI.Leave += txtDNI_Leave;
            txtTelefono.Leave += txtTelefono_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtCalle.Leave += txtCalle_Leave;
            txtNumero.Leave += txtNumero_Leave;
            txtCiudad.Leave += txtCiudad_Leave;
            txtCodigoPostal.Leave += txtCodigoPostal_Leave;

            // Autocompletado de la dirección
            txtCalle.TextChanged += ActualizarDireccionCompleta;
            txtNumero.TextChanged += ActualizarDireccionCompleta;
            txtPisoDpto.TextChanged += ActualizarDireccionCompleta;
            txtCiudad.TextChanged += ActualizarDireccionCompleta;

            // Autocapitalizado al salir del campo
            txtNombre.Leave += CapitalizarTexto_Leave;
            txtApellido.Leave += CapitalizarTexto_Leave;
            txtCiudad.Leave += CapitalizarTexto_Leave;
            txtCalle.Leave += CapitalizarTexto_Leave;

            // Traemos los datos cuando arranca
            this.Load += FormModificarCliente_Load;
        }

        private void FormModificarCliente_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();
        }

        // ---------- CARGA DE DATOS DESDE SQL ----------

        private void CargarDatosCliente()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Cliente WHERE id_cliente = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", this.idCliente);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["nombre"].ToString();
                                txtApellido.Text = reader["apellido"].ToString();
                                txtDNI.Text = reader["dni"].ToString();

                                // Validamos uno por uno si son DBNull para que no explote la lectura
                                txtEmail.Text = reader["email"] != DBNull.Value ? reader["email"].ToString() : "";
                                txtTelefono.Text = reader["telefono"] != DBNull.Value ? reader["telefono"].ToString() : "";
                                txtCalle.Text = reader["calle"] != DBNull.Value ? reader["calle"].ToString() : "";
                                txtNumero.Text = reader["numero"] != DBNull.Value ? reader["numero"].ToString() : "";
                                txtPisoDpto.Text = reader["piso_depto"] != DBNull.Value ? reader["piso_depto"].ToString() : "";
                                txtCiudad.Text = reader["ciudad"] != DBNull.Value ? reader["ciudad"].ToString() : "";
                                txtCodigoPostal.Text = reader["codigo_postal"] != DBNull.Value ? reader["codigo_postal"].ToString() : "";

                                // Manejo de los radiobuttons según el campo 'baja'
                                bool deBaja = reader["baja"] != DBNull.Value && Convert.ToBoolean(reader["baja"]);
                                if (deBaja)
                                    rbActivoNo.Checked = true;
                                else
                                    rbActivoSi.Checked = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // ---------- EVENTOS KEYPRESS ----------

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void txtPisoDpto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Libre
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Bloqueado
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void labCalle_Click(object sender, EventArgs e) { }
        private void labEmail_Click(object sender, EventArgs e) { }

        // ---------- HELPERS DE FORMATO Y VALIDACIÓN ----------

        private void ActualizarDireccionCompleta(object sender, EventArgs e)
        {
            string calle = txtCalle.Text.Trim();
            string numero = txtNumero.Text.Trim();
            string dpto = txtPisoDpto.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();

            string direccion = $"{calle} {numero}".Trim();

            if (!string.IsNullOrWhiteSpace(dpto))
            {
                direccion += $" Dpto {dpto}";
            }

            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                if (direccion.Length > 0)
                    direccion += $", {ciudad}";
                else
                    direccion = $"{ciudad}";
            }

            txtDireccion.Text = direccion;
        }

        private void CapitalizarTexto_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text)) return;

            TextInfo textInfo = CultureInfo.GetCultureInfo("es-AR").TextInfo;
            txt.Text = textInfo.ToTitleCase(txt.Text.Trim().ToLower(CultureInfo.GetCultureInfo("es-AR")));
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

        // CRÍTICO PARA MODIFICACIÓN: Chequea repetidos pero ignora el ID de este mismo cliente.
        // Si no hacemos esto, siempre rebotaría sus propios datos al querer guardar otra cosa.
        private bool ExisteEnClienteModificacion(string columna, string valor)
        {
            string query = $"SELECT COUNT(1) FROM Cliente WHERE {columna} = @valor AND id_cliente != @idActual";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@idActual", this.idCliente);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ---------- SISTEMA DE ERRORES VISUALES ----------

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

        // ---------- VALIDACIONES ESPECÍFICAS ----------

        private bool ValidarNombre()
        {
            string valor = txtNombre.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor);
            Marcar(txtNombre, ok, "Debe ingresar el nombre.");

            if (ok && txtNombre.Text.Trim().Equals(txtApellido.Text.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                Marcar(txtNombre, false, "El nombre y el apellido no pueden ser iguales.");
                return false;
            }
            return ok;
        }

        private bool ValidarApellido()
        {
            string valor = txtApellido.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor);
            Marcar(txtApellido, ok, "Debe ingresar el apellido.");
            return ok;
        }

        private bool ValidarDNI()
        {
            string valor = txtDNI.Text.Trim();
            if (string.IsNullOrWhiteSpace(valor) || valor.Length < 7)
            {
                Marcar(txtDNI, false, "El DNI/CUIT es obligatorio y debe tener al menos 7 números.");
                return false;
            }

            bool disponible = !ExisteEnClienteModificacion("dni", valor);
            Marcar(txtDNI, disponible, "El DNI/CUIT ya está registrado en otro cliente.");
            return disponible;
        }

        private bool ValidarTelefono()
        {
            bool ok = !string.IsNullOrWhiteSpace(txtTelefono.Text.Trim());
            Marcar(txtTelefono, ok, "Debe ingresar el número de teléfono o celular.");
            return ok;
        }

        private bool ValidarEmail()
        {
            string valor = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(valor))
            {
                Marcar(txtEmail, false, "Debe ingresar un email.");
                return false;
            }
            if (!EsEmailValido(valor))
            {
                Marcar(txtEmail, false, "Debe ingresar un correo electrónico válido.");
                return false;
            }

            bool disponible = !ExisteEnClienteModificacion("email", valor);
            Marcar(txtEmail, disponible, "El email ya se encuentra registrado en otro cliente.");
            return disponible;
        }

        private bool ValidarCalle()
        {
            bool ok = !string.IsNullOrWhiteSpace(txtCalle.Text.Trim());
            Marcar(txtCalle, ok, "Debe ingresar la calle.");
            return ok;
        }

        private bool ValidarNumero()
        {
            bool ok = !string.IsNullOrWhiteSpace(txtNumero.Text.Trim());
            Marcar(txtNumero, ok, "Debe ingresar el número de la calle.");
            return ok;
        }

        private bool ValidarCiudad()
        {
            bool ok = !string.IsNullOrWhiteSpace(txtCiudad.Text.Trim());
            Marcar(txtCiudad, ok, "Debe ingresar la ciudad.");
            return ok;
        }

        private bool ValidarCodigoPostal()
        {
            bool ok = !string.IsNullOrWhiteSpace(txtCodigoPostal.Text.Trim());
            Marcar(txtCodigoPostal, ok, "Debe ingresar el código postal.");
            return ok;
        }

        private void txtNombre_Leave(object sender, EventArgs e) => ValidarNombre();
        private void txtApellido_Leave(object sender, EventArgs e) => ValidarApellido();
        private void txtDNI_Leave(object sender, EventArgs e) => ValidarDNI();
        private void txtTelefono_Leave(object sender, EventArgs e) => ValidarTelefono();
        private void txtEmail_Leave(object sender, EventArgs e) => ValidarEmail();
        private void txtCalle_Leave(object sender, EventArgs e) => ValidarCalle();
        private void txtNumero_Leave(object sender, EventArgs e) => ValidarNumero();
        private void txtCiudad_Leave(object sender, EventArgs e) => ValidarCiudad();
        private void txtCodigoPostal_Leave(object sender, EventArgs e) => ValidarCodigoPostal();

        // ---------- BOTONES GUARDAR Y CANCELAR ----------

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            formularioValido = true;
            controlesInvalidos.Clear();

            ValidarNombre();
            ValidarApellido();
            ValidarDNI();
            ValidarTelefono();
            ValidarEmail();
            ValidarCalle();
            ValidarNumero();
            ValidarCiudad();
            ValidarCodigoPostal();

            if (!formularioValido)
            {
                EnfocarPrimerInvalidoPorTabOrder();
                return;
            }

            // Traducimos el radio button a un bit
            int baja = rbActivoSi.Checked ? 0 : 1;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Cliente 
                                     SET nombre = @nombre, 
                                         apellido = @apellido, 
                                         dni = @dni, 
                                         email = @email, 
                                         telefono = @telefono, 
                                         calle = @calle, 
                                         numero = @numero, 
                                         piso_depto = @piso_depto, 
                                         ciudad = @ciudad, 
                                         codigo_postal = @codigo_postal, 
                                         baja = @baja
                                     WHERE id_cliente = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", this.idCliente);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@dni", txtDNI.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
                        cmd.Parameters.AddWithValue("@numero", txtNumero.Text.Trim());
                        cmd.Parameters.AddWithValue("@ciudad", txtCiudad.Text.Trim());
                        cmd.Parameters.AddWithValue("@codigo_postal", txtCodigoPostal.Text.Trim());
                        cmd.Parameters.AddWithValue("@baja", baja);

                        // Null explícito para evitar problemas en DB
                        cmd.Parameters.AddWithValue("@piso_depto", string.IsNullOrWhiteSpace(txtPisoDpto.Text) ? (object)DBNull.Value : txtPisoDpto.Text.Trim());

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("El DNI o Email ya se encuentra registrado en otro cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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