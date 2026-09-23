using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HardAdmin.Entidades;
using HardAdmin.Negocio; // Importamos la capa de negocio

namespace HardAdmin
{
    public partial class FormModificarCliente : Form
    {
        private ClienteServicio servicio = new ClienteServicio();
        private int idCliente;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        public FormModificarCliente(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtDireccion.ReadOnly = true;
            txtDireccion.TabStop = false;

            // Enganches de eventos Leave
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

            // Uso de la clase estática Validaciones
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

            this.Load += FormModificarCliente_Load;
        }

        private void FormModificarCliente_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            try
            {
                // Pedimos el cliente a la Capa de Negocio
                Cliente cliente = servicio.ObtenerPorId(this.idCliente);

                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtDNI.Text = cliente.Dni;
                    txtEmail.Text = cliente.Email;
                    txtTelefono.Text = cliente.Telefono;
                    txtCalle.Text = cliente.Calle;
                    txtNumero.Text = cliente.Numero;
                    txtPisoDpto.Text = cliente.PisoDpto;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCodigoPostal.Text = cliente.CodigoPostal;

                    if (cliente.Baja == 1)
                        rbActivoNo.Checked = true;
                    else
                        rbActivoSi.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txtPisoDpto_KeyPress(object sender, KeyPressEventArgs e) { }
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }
        private void labCalle_Click(object sender, EventArgs e) { }
        private void labEmail_Click(object sender, EventArgs e) { }

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

            // Validamos contra la BD usando la capa de Negocio (pasando el ID actual para no chocar con sí mismo)
            bool disponible = servicio.DniDisponible(valor, this.idCliente);
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

            if (!Validaciones.EsEmailValido(valor))
            {
                Marcar(txtEmail, false, "Debe ingresar un correo electrónico válido.");
                return false;
            }

            bool disponible = servicio.EmailDisponible(valor, this.idCliente);
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
                Cliente clienteEditado = new Cliente
                {
                    IdCliente = this.idCliente,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = txtDNI.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Calle = txtCalle.Text.Trim(),
                    Numero = txtNumero.Text.Trim(),
                    PisoDpto = txtPisoDpto.Text.Trim(),
                    Ciudad = txtCiudad.Text.Trim(),
                    CodigoPostal = txtCodigoPostal.Text.Trim(),
                    Baja = rbActivoSi.Checked ? 0 : 1
                };

                // Enviamos el objeto a la Capa de Negocio
                servicio.Modificar(clienteEditado);

                MessageBox.Show("Cliente modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
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