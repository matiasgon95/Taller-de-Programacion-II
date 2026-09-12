using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormAgregarCliente : Form
    {
        public FormAgregarCliente()
        {
            InitializeComponent();
        }

        // Funcion para comprobar que los emails sean correctos.
        private bool EmailValido(string email)
        {
            try
            {
                MailAddress direccion = new MailAddress(email);

                return direccion.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de campos vacíos
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // Comprueba que el campo nombre y apellido no sean iguales.
            if (string.Equals(txtNombre.Text.Trim(), txtApellido.Text.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El nombre y el apellido no pueden ser iguales.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("Debe ingresar el DNI o CUIT del cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Debe ingresar el numero de telefono o celular del cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Debe ingresar un email.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Comprueba que el email tenga la forma correcta, ejemplo: juan@gmail.com
            if (!EmailValido(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar un correo electrónico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                MessageBox.Show("Debe ingresar la calle.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("Debe ingresar el numero de la calle.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPisoDpto.Text))
            {
                MessageBox.Show("Debe ingresar el numero de piso o departamento de la residencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPisoDpto.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Debe ingresar la direccion de la residencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MessageBox.Show("Debe ingresar la ciudad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCiudad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoPostal.Text))
            {
                MessageBox.Show("Debe ingresar el codigo postal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoPostal.Focus();
                return;
            }


            // Mensaje de ejemplo hasta que se implemente su base de datos correspondiente.
            MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();

        }


        // Restricciones mas especificas.
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPisoDpto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
