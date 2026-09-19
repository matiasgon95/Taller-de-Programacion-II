using System;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormConfiguracion : Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FormGestionCategorias frm = new FormGestionCategorias();
            frm.ShowDialog();
        }

        private void btnMetodosPago_Click(object sender, EventArgs e)
        {
            // TODO: Abrir el formulario de gestión de métodos de pago
            // FormGestionMetodosPago frm = new FormGestionMetodosPago();
            // frm.ShowDialog();

            MessageBox.Show("Módulo de Métodos de Pago en desarrollo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}