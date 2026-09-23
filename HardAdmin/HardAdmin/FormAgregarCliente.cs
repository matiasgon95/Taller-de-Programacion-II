using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HardAdmin.Entidades;
using HardAdmin.Negocio;

namespace HardAdmin
{
    public partial class FormAgregarCliente : Form
    {
        // Instanciamos el servicio (nuestro puente a las reglas de negocio)
        private ClienteServicio servicio = new ClienteServicio();
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        public FormAgregarCliente()
        {
            InitializeComponent();

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtDireccion.ReadOnly = true;
            txtDireccion.TabStop = false;

            // Enganches de eventos Leave para validar al salir
            txtNombre.Leave += txtNombre_Leave;
            txtApellido.Leave += txtApellido_Leave;
            txtDNI.Leave += txtDNI_Leave;
            txtTelefono.Leave += txtTelefono_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtCalle.Leave += txtCalle_Leave;
            txtNumero.Leave += txtNumero_Leave;
            txtCiudad.Leave += txtCiudad_Leave;
            txtCodigoPostal.Leave += txtCodigoPostal_Leave;

            txtCalle.TextChanged += ActualizarDireccionCompleta;
            txtNumero.TextChanged += ActualizarDireccionCompleta;
            txtPisoDpto.TextChanged += ActualizarDireccionCompleta;
            txtCiudad.TextChanged += ActualizarDireccionCompleta;

            // ACA USAMOS LA CLASE ESTATICA: Cero código repetido.
            txtNombre.KeyPress += Validaciones.SoloLetras_KeyPress;
            txtApellido.KeyPress += Validaciones.SoloLetras_KeyPress;
            txtCiudad.KeyPress += Validaciones.SoloLetras_KeyPress;
            txtCalle.KeyPress += Validaciones.SoloLetras_KeyPress;

            txtDNI.KeyPress += Validaciones.SoloNumeros_KeyPress;
            txtTelefono.KeyPress += Validaciones.SoloNumeros_KeyPress;
            txtNumero.KeyPress += Validaciones.SoloNumeros_KeyPress;
            txtCodigoPostal.KeyPress += Validaciones.SoloNumeros_KeyPress;

            txtNombre.Leave += Validaciones.CapitalizarTexto_Leave;
            txtApellido.Leave += Validaciones.CapitalizarTexto_Leave;
            txtCiudad.Leave += Validaciones.CapitalizarTexto_Leave;
            txtCalle.Leave += Validaciones.CapitalizarTexto_Leave;
        }

        private void ActualizarDireccionCompleta(object sender, EventArgs e)
        {
            string calle = txtCalle.Text.Trim();
            string numero = txtNumero.Text.Trim();
            string dpto = txtPisoDpto.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();

            string direccion = $"{calle} {numero}".Trim();
            if (!string.IsNullOrWhiteSpace(dpto)) direccion += $" Dpto {dpto}";
            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                direccion = direccion.Length > 0 ? direccion + $", {ciudad}" : ciudad;
            }

            txtDireccion.Text = direccion;
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
                if (!controlesInvalidos.Contains(control)) controlesInvalidos.Add(control);
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
            bool ok = !string.IsNullOrWhiteSpace(txtNombre.Text.Trim());
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
            bool ok = !string.IsNullOrWhiteSpace(txtApellido.Text.Trim());
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

            // Preguntamos a la capa de negocio si está disponible
            bool disponible = servicio.DniDisponible(valor);
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
            if (!Validaciones.EsEmailValido(valor))
            {
                Marcar(txtEmail, false, "Debe ingresar un correo electrónico válido.");
                return false;
            }

            bool disponible = servicio.EmailDisponible(valor);
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

        private void txtNombre_Leave(object sender, EventArgs e) => ValidarNombre();
        private void txtApellido_Leave(object sender, EventArgs e) => ValidarApellido();
        private void txtDNI_Leave(object sender, EventArgs e) => ValidarDNI();
        private void txtTelefono_Leave(object sender, EventArgs e) => ValidarTelefono();
        private void txtEmail_Leave(object sender, EventArgs e) => ValidarEmail();
        private void txtCalle_Leave(object sender, EventArgs e) => ValidarCalle();
        private void txtNumero_Leave(object sender, EventArgs e) => ValidarNumero();
        private void txtCiudad_Leave(object sender, EventArgs e) => ValidarCiudad();
        private void txtCodigoPostal_Leave(object sender, EventArgs e) => ValidarCodigoPostal();

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

            try
            {
                // Llenamos la entidad
                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = txtDNI.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Calle = txtCalle.Text.Trim(),
                    Numero = txtNumero.Text.Trim(),
                    PisoDpto = txtPisoDpto.Text.Trim(),
                    Ciudad = txtCiudad.Text.Trim(),
                    CodigoPostal = txtCodigoPostal.Text.Trim()
                };

                // Delegamos a Negocio
                servicio.Registrar(nuevoCliente);

                MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("El DNI o Email ya se encuentra registrado en otro cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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