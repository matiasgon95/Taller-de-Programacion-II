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
            FormReportesVentas frm = new FormReportesVentas();
            frm.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormReportesProductos frm = new FormReportesProductos();
            frm.ShowDialog();
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            FormReportesFinanzas frm = new FormReportesFinanzas();
            frm.ShowDialog();
        }
    }
}
