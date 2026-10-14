using HardAdmin.Negocio;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HardAdmin
{
    public partial class FormReporteFinanzas : Form
    {
        private VentaServicio ventaServicio = new VentaServicio();
        private static readonly CultureInfo CulturaMoneda = CultureInfo.GetCultureInfo("es-AR");

        public FormReporteFinanzas()
        {
            InitializeComponent();

            dgvFinanzas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinanzas.MultiSelect = false;
            dgvFinanzas.ReadOnly = true;
            dgvFinanzas.AllowUserToAddRows = false;
            dgvFinanzas.AllowUserToDeleteRows = false;
            dgvFinanzas.RowHeadersVisible = false;
        }

        private void FormReporteFinanzas_Load(object sender, EventArgs e)
        {
            // Período 1 (Actual): Mes corriente
            dtpDesde1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta1.Value = DateTime.Today;

            // Período 2 (Comparación): Mes anterior
            dtpDesde2.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            dtpHasta2.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);

            CargarReporte();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarReporte()
        {
            try
            {
                DateTime desde1 = dtpDesde1.Value.Date;
                DateTime hasta1 = dtpHasta1.Value.Date.AddDays(1).AddSeconds(-1);
                DateTime desde2 = dtpDesde2.Value.Date;
                DateTime hasta2 = dtpHasta2.Value.Date.AddDays(1).AddSeconds(-1);

                DataTable dt = ventaServicio.ObtenerComparativaFinanciera(desde1, hasta1, desde2, hasta2);

                dgvFinanzas.DataSource = dt;
                ConfigurarColumnasGrilla();

                decimal totalPeriodo1 = 0m;
                decimal totalPeriodo2 = 0m;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["monto_periodo1"] != DBNull.Value) totalPeriodo1 += Convert.ToDecimal(row["monto_periodo1"]);
                    if (row["monto_periodo2"] != DBNull.Value) totalPeriodo2 += Convert.ToDecimal(row["monto_periodo2"]);
                }

                decimal diferencia = totalPeriodo2 - totalPeriodo1;
                decimal variacionPct = totalPeriodo2 > 0 ? (diferencia / totalPeriodo2) * 100 : (totalPeriodo1 > 0 ? 100 : 0);

                // Actualizamos las tarjetas KPI gerenciales
                lblValorAcumulado.Text = totalPeriodo1.ToString("C2", CulturaMoneda);
                lblValorOperaciones.Text = totalPeriodo2.ToString("C2", CulturaMoneda);
                lblValorTicket.Text = $"{variacionPct:+0.0;-0.0;0.0}% ({diferencia:C2})";

                // Configurar Gráfico de Líneas / Curvas Financieras
                chartFinanzas.Series.Clear();

                Series serie1 = new Series("Período 1")
                {
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3,
                    Color = Color.ForestGreen
                };

                Series serie2 = new Series("Período 2")
                {
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 2,
                    Color = Color.SteelBlue
                };

                chartFinanzas.ChartAreas[0].AxisX.Interval = 1;

                int index = 1;
                foreach (DataRow row in dt.Rows)
                {
                    decimal m1 = row["monto_periodo1"] != DBNull.Value ? Convert.ToDecimal(row["monto_periodo1"]) : 0m;
                    decimal m2 = row["monto_periodo2"] != DBNull.Value ? Convert.ToDecimal(row["monto_periodo2"]) : 0m;

                    serie1.Points.AddXY($"Día {index}", m1);
                    serie2.Points.AddXY($"Día {index}", m2);
                    index++;
                }

                chartFinanzas.Series.Add(serie1);
                chartFinanzas.Series.Add(serie2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la comparativa financiera: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrilla()
        {
            if (dgvFinanzas.Columns.Contains("nro_orden")) dgvFinanzas.Columns["nro_orden"].Visible = false;

            if (dgvFinanzas.Columns.Contains("fecha_periodo1"))
            {
                dgvFinanzas.Columns["fecha_periodo1"].HeaderText = "F. Actual";
                dgvFinanzas.Columns["fecha_periodo1"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvFinanzas.Columns.Contains("monto_periodo1"))
            {
                dgvFinanzas.Columns["monto_periodo1"].HeaderText = "Monto P.1";
                dgvFinanzas.Columns["monto_periodo1"].DefaultCellStyle.Format = "C2";
            }
            if (dgvFinanzas.Columns.Contains("fecha_periodo2"))
            {
                dgvFinanzas.Columns["fecha_periodo2"].HeaderText = "F. Anterior";
                dgvFinanzas.Columns["fecha_periodo2"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvFinanzas.Columns.Contains("monto_periodo2"))
            {
                dgvFinanzas.Columns["monto_periodo2"].HeaderText = "Monto P.2";
                dgvFinanzas.Columns["monto_periodo2"].DefaultCellStyle.Format = "C2";
            }
        }
    }
}