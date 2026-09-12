using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormAgregarProducto : Form
    {
        public FormAgregarProducto()
        {
            InitializeComponent();
        }

        private void LB_Codigo_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar el codigo de producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripcion del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            // Mensaje de ejemplo hasta que se implemente su base de datos corresopndiente.
            MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
