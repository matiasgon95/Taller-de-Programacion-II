using HardAdmin.Negocio;
using System;
using System.Collections.Generic;
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

            // --- DISEÑO LIMPIO DE LA GRILLA (Quitar líneas) ---
            dgvVentas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.GridColor = Color.White;
        }

        private void FormReporteVentas_Load(object sender, EventArgs e)
        {
            // 1. Configuramos los límites de fechas según la base de datos
            ConfigurarLimitesFechas();

            if (cmbAgrupacion.Items.Count == 0)
            {
                cmbAgrupacion.Items.Add("Día");
                cmbAgrupacion.Items.Add("Mes");
                cmbAgrupacion.Items.Add("Año");
                cmbAgrupacion.SelectedIndex = 0;
            }

            CargarReporte();
        }

        private void ConfigurarLimitesFechas()
        {
            try
            {
                List<int> aniosDisponibles = ventaServicio.ObtenerAniosDisponibles();

                if (aniosDisponibles.Count > 0)
                {
                    int anioMin = aniosDisponibles[0];
                    int anioMax = aniosDisponibles[aniosDisponibles.Count - 1];

                    DateTime fechaMinimaBD = new DateTime(anioMin, 1, 1);

                    // El tope máximo no puede superar el fin de año, y bajo ningún punto de vista puede ser mayor a la fecha de hoy
                    DateTime fechaMaximaBD = new DateTime(anioMax, 12, 31);
                    if (fechaMaximaBD > DateTime.Today)
                    {
                        fechaMaximaBD = DateTime.Today;
                    }

                    // Asignamos valores seguros PRIMERO para evitar conflictos de validación del control
                    dtpDesde.Value = DateTime.Today.AddDays(-30) >= fechaMinimaBD ? DateTime.Today.AddDays(-30) : fechaMinimaBD;
                    dtpHasta.Value = DateTime.Today <= fechaMaximaBD ? DateTime.Today : fechaMaximaBD;

                    // Configuramos los topes permitidos en los calendarios
                    dtpDesde.MinDate = fechaMinimaBD;
                    dtpDesde.MaxDate = fechaMaximaBD;

                    dtpHasta.MinDate = fechaMinimaBD;
                    dtpHasta.MaxDate = fechaMaximaBD;
                }
                else
                {
                    // Fallback por si la tabla está completamente vacía
                    dtpDesde.MinDate = new DateTime(2000, 1, 1);
                    dtpDesde.MaxDate = DateTime.Today;
                    dtpHasta.MinDate = new DateTime(2000, 1, 1);
                    dtpHasta.MaxDate = DateTime.Today;

                    dtpDesde.Value = DateTime.Today.AddDays(-30);
                    dtpHasta.Value = DateTime.Today;
                }
            }
            catch (Exception ex)
            {
                // Si ocurre algún error con la BD, dejamos valores por defecto seguros
                dtpDesde.Value = DateTime.Today.AddDays(-30);
                dtpHasta.Value = DateTime.Today;
            }
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

                // --- VALIDACIÓN DE RANGO EXCESIVO ---
                int diasDiferencia = (hasta - desde).Days;
                if (agrupacion == "Día" && diasDiferencia > 120)
                {
                    MessageBox.Show("Para una correcta visualización en el gráfico diario, el rango no puede superar los 120 días. Por favor, acote las fechas o agrupe por Mes.",
                        "Rango demasiado extenso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dt = ventaServicio.ObtenerEvolucionVentas(desde, hasta, agrupacion);

                // --- FORMATEAR LOS PERÍODOS PARA UNA VISTA AMIGABLE ---
                CultureInfo culturaEs = CultureInfo.GetCultureInfo("es-AR");
                foreach (DataRow row in dt.Rows)
                {
                    string periodoOriginal = row["periodo"].ToString();

                    if (agrupacion == "Día")
                    {
                        // Convierte "2026-09-02" a "2 de sep 2026"
                        if (DateTime.TryParse(periodoOriginal, out DateTime fecha))
                        {
                            string mesAbrev = fecha.ToString("MMM", culturaEs).Replace(".", "").ToLower();
                            row["periodo"] = $"{fecha.Day} de {mesAbrev} {fecha.Year}";
                        }
                    }
                    else if (agrupacion == "Mes")
                    {
                        // Convierte "2025-02" a "febrero 2025"
                        if (periodoOriginal.Length >= 7)
                        {
                            int anio = Convert.ToInt32(periodoOriginal.Substring(0, 4));
                            int mes = Convert.ToInt32(periodoOriginal.Substring(5, 2));
                            DateTime fechaMes = new DateTime(anio, mes, 1);
                            string nombreMes = fechaMes.ToString("MMMM", culturaEs).ToLower();
                            row["periodo"] = $"{nombreMes} {anio}";
                        }
                    }
                    // Si es "Año", se queda tal cual ("2025", "2026")
                }

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

                // --- CONFIGURACIÓN DEL GRÁFICO (COLUMNAS VERTICALES ESTABLES) ---
                chartVentas.Series.Clear();

                // 1. Quitar las líneas de la cuadrícula
                chartVentas.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartVentas.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                // 2. Ocultar por completo el Eje Y para que solo aparezca el valor arriba de la barra
                chartVentas.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
                chartVentas.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
                chartVentas.ChartAreas[0].AxisY.LineColor = Color.Transparent;

                chartVentas.ChartAreas[0].AxisX.Interval = 1;

                // 3. Control inteligente de zoom y scroll horizontal si hay muchos datos
                if (dt.Rows.Count > 12)
                {
                    chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -90; // Verticales para que entren bien
                    chartVentas.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                    chartVentas.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                    chartVentas.ChartAreas[0].AxisX.ScaleView.Size = 12; // Muestra de a 12 elementos visibles
                    chartVentas.ChartAreas[0].AxisX.ScaleView.Position = 1;
                    chartVentas.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                    chartVentas.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                }
                else
                {
                    chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                    chartVentas.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                }

                Series serie = new Series("Recaudación")
                {
                    ChartType = SeriesChartType.Column, // Volvemos a columnas verticales estables
                    IsValueShownAsLabel = true
                };

                serie.LabelFormat = "N0";

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