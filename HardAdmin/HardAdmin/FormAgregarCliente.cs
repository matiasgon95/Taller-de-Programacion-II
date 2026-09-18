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
    public partial class FormAgregarCliente : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Instanciamos el manejador de errores visuales (el ícono rojo de advertencia)
        private ErrorProvider errorProvider = new ErrorProvider();

        // Variables para controlar el estado de la validación general
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        public FormAgregarCliente()
        {
            InitializeComponent();

            // Configuración del ErrorProvider para que no titile y sea más agradable
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Bloqueamos el campo dirección para que se llene solo y el usuario no meta mano
            txtDireccion.ReadOnly = true;
            txtDireccion.TabStop = false;

            // Enganchamos las validaciones en tiempo real.
            // El evento 'Leave' salta apenas el usuario termina de escribir y cambia de campo.
            txtNombre.Leave += txtNombre_Leave;
            txtApellido.Leave += txtApellido_Leave;
            txtDNI.Leave += txtDNI_Leave;
            txtTelefono.Leave += txtTelefono_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtCalle.Leave += txtCalle_Leave;
            txtNumero.Leave += txtNumero_Leave;
            txtCiudad.Leave += txtCiudad_Leave;
            txtCodigoPostal.Leave += txtCodigoPostal_Leave;

            // Autocompletado de la dirección completa en tiempo real. Cada vez que tocan 
            // una letra en la calle o altura, se actualiza el campo final.
            txtCalle.TextChanged += ActualizarDireccionCompleta;
            txtNumero.TextChanged += ActualizarDireccionCompleta;
            txtPisoDpto.TextChanged += ActualizarDireccionCompleta;
            txtCiudad.TextChanged += ActualizarDireccionCompleta;

            // Eventos de teclado (KeyPress) para atajar ingresos inválidos mientras tipean.
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;
            txtCiudad.KeyPress += SoloLetras_KeyPress;
            txtCalle.KeyPress += SoloLetras_KeyPress;

            txtDNI.KeyPress += SoloNumeros_KeyPress;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            txtNumero.KeyPress += SoloNumeros_KeyPress;
            txtCodigoPostal.KeyPress += SoloNumeros_KeyPress;
            // Aclaración: txtPisoDpto queda libre por si ingresan letras como "PB" o "3B"

            // Autocapitalizado al salir del campo (Para que quede prolijo "Juan Perez")
            txtNombre.Leave += CapitalizarTexto_Leave;
            txtApellido.Leave += CapitalizarTexto_Leave;
            txtCiudad.Leave += CapitalizarTexto_Leave;
            txtCalle.Leave += CapitalizarTexto_Leave;
        }

        // ---------- HELPERS DE FORMATO Y TECLADO ----------

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

        // Pasa a mayúscula la primera letra de cada palabra
        private void CapitalizarTexto_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text)) return;

            TextInfo textInfo = CultureInfo.GetCultureInfo("es-AR").TextInfo;
            txt.Text = textInfo.ToTitleCase(txt.Text.Trim().ToLower(CultureInfo.GetCultureInfo("es-AR")));
        }

        // Concatena calle, número, departamento y ciudad en un solo string prolijo.
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

        // Comprueba si un valor ya existe en la base de datos (para no duplicar DNI o Email)
        private bool ExisteEnCliente(string columna, string valor)
        {
            string query = $"SELECT COUNT(1) FROM Cliente WHERE {columna} = @valor";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@valor", valor);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ---------- SISTEMA DE ERRORES VISUALES ----------

        // Método centralizador de errores. Si algo está mal, prende el ícono rojo. Si está bien, lo apaga.
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

                // Agregamos el control a la lista si no estaba, para saber cuáles fallaron
                if (!controlesInvalidos.Contains(control))
                {
                    controlesInvalidos.Add(control);
                }
            }
        }

        // Si fallan varios campos a la vez al dar Guardar, esto busca cuál está más arriba
        // en el formulario (según el TabIndex) y pone el cursor ahí.
        private void EnfocarPrimerInvalidoPorTabOrder()
        {
            Control primero = controlesInvalidos.OrderBy(c => c.TabIndex).FirstOrDefault();
            primero?.Focus();
        }

        // ---------- VALIDACIONES ESPECÍFICAS ----------
        // Todas estas funciones devuelven true o false, y llaman a Marcar() para prender/apagar el error.

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

            bool disponible = !ExisteEnCliente("dni", valor);
            Marcar(txtDNI, disponible, "El DNI/CUIT ya se encuentra registrado.");
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

            bool disponible = !ExisteEnCliente("email", valor);
            Marcar(txtEmail, disponible, "El email ya se encuentra registrado.");
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

        // Enganches limpios de los eventos Leave hacia los validadores
        private void txtNombre_Leave(object sender, EventArgs e) => ValidarNombre();
        private void txtApellido_Leave(object sender, EventArgs e) => ValidarApellido();
        private void txtDNI_Leave(object sender, EventArgs e) => ValidarDNI();
        private void txtTelefono_Leave(object sender, EventArgs e) => ValidarTelefono();
        private void txtEmail_Leave(object sender, EventArgs e) => ValidarEmail();
        private void txtCalle_Leave(object sender, EventArgs e) => ValidarCalle();
        private void txtNumero_Leave(object sender, EventArgs e) => ValidarNumero();
        private void txtCiudad_Leave(object sender, EventArgs e) => ValidarCiudad();
        private void txtCodigoPostal_Leave(object sender, EventArgs e) => ValidarCodigoPostal();

        // Estos los dejamos vacíos solo para que no salte error en el diseñador
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }
        private void txtPisoDpto_KeyPress(object sender, KeyPressEventArgs e) { }

        // ---------- BOTONES GUARDAR Y CANCELAR ----------

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Reseteamos el estado a "todo válido" antes del chequeo final.
            formularioValido = true;
            controlesInvalidos.Clear();

            // Ejecutamos TODAS las validaciones juntas. Si alguna falla, formularioValido pasa a false.
            ValidarNombre();
            ValidarApellido();
            ValidarDNI();
            ValidarTelefono();
            ValidarEmail();
            ValidarCalle();
            ValidarNumero();
            ValidarCiudad();
            ValidarCodigoPostal();

            // Cortamos acá nomás y ponemos el cursor en el error si algo falló
            if (!formularioValido)
            {
                EnfocarPrimerInvalidoPorTabOrder();
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Armamos el insert asegurándonos que arranca con baja = 0 (Activo)
                    string query = @"INSERT INTO Cliente 
                                     (nombre, apellido, dni, email, telefono, calle, numero, piso_depto, ciudad, codigo_postal, baja)
                                     VALUES 
                                     (@nombre, @apellido, @dni, @email, @telefono, @calle, @numero, @piso_depto, @ciudad, @codigo_postal, 0)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@dni", txtDNI.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
                        cmd.Parameters.AddWithValue("@numero", txtNumero.Text.Trim());
                        cmd.Parameters.AddWithValue("@ciudad", txtCiudad.Text.Trim());
                        cmd.Parameters.AddWithValue("@codigo_postal", txtCodigoPostal.Text.Trim());

                        // Si el departamento está vacío, le mandamos explícitamente un nulo a SQL Server.
                        cmd.Parameters.AddWithValue("@piso_depto", string.IsNullOrWhiteSpace(txtPisoDpto.Text) ? (object)DBNull.Value : txtPisoDpto.Text.Trim());

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Le avisamos a la grilla que se guardó bien
                this.Close();
            }
            catch (SqlException ex)
            {
                // Manejo de errores a nivel base de datos por si, justo antes de guardar, 
                // alguien más registró un DNI o Email repetido y la BD lo rebotó por UNIQUE KEY.
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