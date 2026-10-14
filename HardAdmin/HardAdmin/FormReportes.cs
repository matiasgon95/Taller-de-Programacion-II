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
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            using (FormReporteVentas frm = new FormReporteVentas())
            {
                frm.ShowDialog();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            using (FormReporteProductos frm = new FormReporteProductos())
            {
                frm.ShowDialog();
            }
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de finanzas en desarrollo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
