using HardAdmin.Negocio;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HardAdmin
{
    public partial class FormReporteVentas : Form
    {
        private VentaServicio ventaServicio = new VentaServicio();
        private static readonly CultureInfo CulturaMoneda = CultureInfo.GetCultureInfo("es-AR");

        public FormReporteVentas()
        {
            InitializeComponent();

            // Blindamos la grilla para que no sea editable ni permita agregar filas
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.RowHeadersVisible = false;
        }

        private void FormReporteVentas_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            if (cmbAgrupacion.Items.Count == 0)
            {
                cmbAgrupacion.Items.Add("Día");
                cmbAgrupacion.Items.Add("Mes");
                cmbAgrupacion.Items.Add("Año");
                cmbAgrupacion.SelectedIndex = 0;
            }

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
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                string agrupacion = cmbAgrupacion.SelectedItem?.ToString() ?? "Día";

                DataTable dt = ventaServicio.ObtenerEvolucionVentas(desde, hasta, agrupacion);

                dgvVentas.DataSource = dt;
                ConfigurarColumnasGrilla();

                decimal totalRecaudado = 0m;
                int totalOperaciones = 0;

                foreach (DataRow row in dt.Rows)
                {
                    totalRecaudado += Convert.ToDecimal(row["total_recaudado"]);
                    totalOperaciones += Convert.ToInt32(row["cantidad_ventas"]);
                }

                decimal ticketPromedio = totalOperaciones > 0 ? totalRecaudado / totalOperaciones : 0m;

                // Asignamos los valores a las tarjetas de resumen
                lblValorRecaudado.Text = totalRecaudado.ToString("C2", CulturaMoneda);
                lblValorOperaciones.Text = totalOperaciones.ToString();
                lblValorTicket.Text = ticketPromedio.ToString("C2", CulturaMoneda);

                // Configurar Gráfico de Columnas
                chartVentas.Series.Clear();
                Series serie = new Series("Recaudación")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                serie.LabelFormat = "C0";
                chartVentas.ChartAreas[0].AxisX.Interval = 1;
                chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                foreach (DataRow row in dt.Rows)
                {
                    string periodo = row["periodo"].ToString();
                    decimal monto = Convert.ToDecimal(row["total_recaudado"]);
                    serie.Points.AddXY(periodo, monto);
                }

                chartVentas.Series.Add(serie);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrilla()
        {
            if (dgvVentas.Columns.Contains("periodo"))
                dgvVentas.Columns["periodo"].HeaderText = "Período";
            if (dgvVentas.Columns.Contains("cantidad_ventas"))
                dgvVentas.Columns["cantidad_ventas"].HeaderText = "Cant. Ventas";
            if (dgvVentas.Columns.Contains("total_recaudado"))
            {
                dgvVentas.Columns["total_recaudado"].HeaderText = "Recaudación";
                dgvVentas.Columns["total_recaudado"].DefaultCellStyle.Format = "C2";
            }
        }
    }
}