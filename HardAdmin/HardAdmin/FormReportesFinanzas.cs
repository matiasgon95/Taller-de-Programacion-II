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
    public partial class FormReportesFinanzas : Form
    {
        private VentaServicio ventaServicio = new VentaServicio();
        private static readonly CultureInfo CulturaMoneda = CultureInfo.GetCultureInfo("es-AR");
        private bool cargando = true;

        public FormReportesFinanzas()
        {
            InitializeComponent();

            // Configuración visual de la grilla
            dgvFinanzas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinanzas.MultiSelect = false;
            dgvFinanzas.ReadOnly = true;
            dgvFinanzas.AllowUserToAddRows = false;
            dgvFinanzas.AllowUserToDeleteRows = false;
            dgvFinanzas.RowHeadersVisible = false;
            dgvFinanzas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvFinanzas.BackgroundColor = Color.White;
            dgvFinanzas.GridColor = Color.White;

            // Inicializamos todo directamente al construir el formulario
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            cargando = true;

            try
            {
                // 1. Cargamos el tipo de reporte
                cmbTipoReporte.Items.Clear();
                cmbTipoReporte.Items.Add("Evolución Intermensual (Mes a Mes)");
                cmbTipoReporte.Items.Add("Comparativa Interanual (Año vs Año)");

                // 2. Poblamos los años reales desde la base de datos
                List<int> aniosDisponibles = ventaServicio.ObtenerAniosDisponibles();
                cmbAnio1.Items.Clear();
                cmbAnio2.Items.Clear();

                if (aniosDisponibles.Count > 0)
                {
                    foreach (int anio in aniosDisponibles)
                    {
                        cmbAnio1.Items.Add(anio);
                        cmbAnio2.Items.Add(anio);
                    }

                    cmbAnio1.SelectedIndex = aniosDisponibles.Count > 1 ? aniosDisponibles.Count - 2 : 0;
                    cmbAnio2.SelectedIndex = aniosDisponibles.Count - 1;
                }
                else
                {
                    int anioActual = DateTime.Today.Year;
                    cmbAnio1.Items.Add(anioActual);
                    cmbAnio2.Items.Add(anioActual);
                    cmbAnio1.SelectedIndex = 0;
                    cmbAnio2.SelectedIndex = 0;
                }

                // 3. Configuramos los selectores de mes y sus límites según la BD
                ConfigurarDateTimePickerComoMes(dtpMesDesde);
                ConfigurarDateTimePickerComoMes(dtpMesHasta);

                if (aniosDisponibles.Count > 0)
                {
                    int anioMin = aniosDisponibles[0];
                    int anioMax = aniosDisponibles[aniosDisponibles.Count - 1];
                    DateTime mesTopeMaximo = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);

                    // Por defecto en el intermensual, seleccionamos SOLAMENTE el último año (desde enero hasta el último mes cerrado)
                    DateTime fechaInicioAnioUltimo = new DateTime(anioMax, 1, 1);
                    DateTime fechaFinUltimoCerrado = mesTopeMaximo.Year == anioMax ? mesTopeMaximo : new DateTime(anioMax, 12, 31);

                    if (fechaInicioAnioUltimo > fechaFinUltimoCerrado) fechaInicioAnioUltimo = fechaFinUltimoCerrado;

                    dtpMesDesde.Value = fechaInicioAnioUltimo;
                    dtpMesHasta.Value = fechaFinUltimoCerrado;

                    dtpMesDesde.MinDate = new DateTime(anioMin, 1, 1);
                    dtpMesDesde.MaxDate = mesTopeMaximo;

                    dtpMesHasta.MinDate = new DateTime(anioMin, 1, 1);
                    dtpMesHasta.MaxDate = mesTopeMaximo;
                }
                else
                {
                    int anioActual = DateTime.Today.Year;
                    dtpMesDesde.Value = new DateTime(anioActual, 1, 1);
                    dtpMesHasta.Value = DateTime.Today;
                }

                // 4. Seleccionamos el primer modo por defecto
                cmbTipoReporte.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }

            ActualizarVisibilidadControles();
            CargarReporte();
        }

        private void ConfigurarDateTimePickerComoMes(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "MMMM yyyy";
            dtp.ShowUpDown = true;
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;

            ActualizarVisibilidadControles();
            CargarReporte();
        }

        private void ActualizarVisibilidadControles()
        {
            bool esIntermensual = cmbTipoReporte.SelectedIndex == 0;

            dtpMesDesde.Visible = esIntermensual;
            dtpMesHasta.Visible = esIntermensual;
            lblDesde.Visible = esIntermensual;
            lblHasta.Visible = esIntermensual;

            lblAnio1.Visible = !esIntermensual;
            cmbAnio1.Visible = !esIntermensual;
            lblAnio2.Visible = !esIntermensual;
            cmbAnio2.Visible = !esIntermensual;
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
            if (cargando) return;

            try
            {
                bool esIntermensual = cmbTipoReporte.SelectedIndex == 0;

                if (esIntermensual)
                {
                    DateTime desde = new DateTime(dtpMesDesde.Value.Year, dtpMesDesde.Value.Month, 1);
                    DateTime hasta = new DateTime(dtpMesHasta.Value.Year, dtpMesHasta.Value.Month, 1).AddMonths(1).AddSeconds(-1);

                    DataTable dt = ventaServicio.ObtenerCierreFinanciero(desde, hasta);
                    ProcesarYMostrarIntermensual(dt);
                }
                else
                {
                    int anio1 = cmbAnio1.SelectedItem != null ? Convert.ToInt32(cmbAnio1.SelectedItem) : DateTime.Today.Year - 1;
                    int anio2 = cmbAnio2.SelectedItem != null ? Convert.ToInt32(cmbAnio2.SelectedItem) : DateTime.Today.Year;

                    DataTable dt = ventaServicio.ObtenerComparativaInteranual(anio1, anio2);
                    ProcesarYMostrarInteranual(dt, anio1, anio2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte financiero: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcesarYMostrarIntermensual(DataTable dt)
        {
            int anioActual = DateTime.Today.Year;
            int mesActual = DateTime.Today.Month;

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                int anioFila = Convert.ToInt32(dt.Rows[i]["anio"]);
                int mesFila = Convert.ToInt32(dt.Rows[i]["mes"]);
                if (anioFila == anioActual && mesFila == mesActual)
                {
                    dt.Rows.RemoveAt(i);
                }
            }

            dt.Columns.Add("periodo_formateado", typeof(string));
            dt.Columns.Add("crecimiento_intermensual", typeof(decimal));

            CultureInfo culturaEs = CultureInfo.GetCultureInfo("es-AR");

            foreach (DataRow row in dt.Rows)
            {
                int anio = Convert.ToInt32(row["anio"]);
                int mes = Convert.ToInt32(row["mes"]);
                decimal recaudacion = Convert.ToDecimal(row["recaudacion_total"]);

                DateTime fechaMes = new DateTime(anio, mes, 1);
                string nombreMes = fechaMes.ToString("MMMM", culturaEs).ToLower();
                row["periodo_formateado"] = nombreMes + " " + anio;

                if (row["recaudacion_anterior"] != DBNull.Value)
                {
                    decimal recaudacionAnterior = Convert.ToDecimal(row["recaudacion_anterior"]);
                    if (recaudacionAnterior > 0)
                    {
                        decimal diferencia = recaudacion - recaudacionAnterior;
                        row["crecimiento_intermensual"] = (diferencia / recaudacionAnterior) * 100;
                    }
                    else
                    {
                        row["crecimiento_intermensual"] = 0m;
                    }
                }
                else
                {
                    row["crecimiento_intermensual"] = DBNull.Value;
                }
            }

            dgvFinanzas.DataSource = dt;
            ConfigurarColumnasGrillaIntermensual();

            // Limpieza de etiquetas inferiores obsoletas
            lblValorAcumulado.Text = "";
            lblValorOperaciones.Text = "";
            lblValorTicket.Text = "";

            ActualizarGraficoIntermensual(dt);
        }

        private void ProcesarYMostrarInteranual(DataTable dt, int anio1, int anio2)
        {
            int anioActual = DateTime.Today.Year;
            int mesActual = DateTime.Today.Month;

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                int nroMes = Convert.ToInt32(dt.Rows[i]["nro_mes"]);

                bool anio2EsActualYFuturo = (anio2 == anioActual && nroMes >= mesActual);
                bool anio1EsActualYFuturo = (anio1 == anioActual && nroMes >= mesActual);

                if (anio2EsActualYFuturo || anio1EsActualYFuturo)
                {
                    dt.Rows.RemoveAt(i);
                }
            }

            dt.DefaultView.Sort = "nro_mes ASC";
            dt = dt.DefaultView.ToTable();

            decimal totalAnio1 = 0m;
            decimal totalAnio2 = 0m;

            foreach (DataRow row in dt.Rows)
            {
                totalAnio1 += Convert.ToDecimal(row["recaudacion_anio1"]);
                totalAnio2 += Convert.ToDecimal(row["recaudacion_anio2"]);
            }

            dgvFinanzas.DataSource = dt;
            ConfigurarColumnasGrillaInteranual(anio1, anio2);

            decimal diferenciaGlobal = totalAnio2 - totalAnio1;
            decimal variacionGlobal = totalAnio1 > 0 ? (diferenciaGlobal / totalAnio1) * 100 : 0;

            lblValorAcumulado.Text = "";
            lblValorOperaciones.Text = "";
            lblValorTicket.Text = "Variación Global: " + variacionGlobal.ToString("+0.0;-0.0;0.0") + "% (vs " + anio1 + ")";

            ActualizarGraficoInteranual(dt, anio1, anio2);
        }

        private void ConfigurarColumnasGrillaIntermensual()
        {
            if (dgvFinanzas.Columns.Contains("anio")) dgvFinanzas.Columns["anio"].Visible = false;
            if (dgvFinanzas.Columns.Contains("mes")) dgvFinanzas.Columns["mes"].Visible = false;
            if (dgvFinanzas.Columns.Contains("recaudacion_anterior")) dgvFinanzas.Columns["recaudacion_anterior"].Visible = false;

            if (dgvFinanzas.Columns.Contains("periodo_formateado"))
            {
                dgvFinanzas.Columns["periodo_formateado"].HeaderText = "Período";
                dgvFinanzas.Columns["periodo_formateado"].DisplayIndex = 0;
            }
            if (dgvFinanzas.Columns.Contains("cantidad_ventas")) dgvFinanzas.Columns["cantidad_ventas"].HeaderText = "Cant. Ventas";
            if (dgvFinanzas.Columns.Contains("recaudacion_total"))
            {
                dgvFinanzas.Columns["recaudacion_total"].HeaderText = "Recaudación Total";
                dgvFinanzas.Columns["recaudacion_total"].DefaultCellStyle.Format = "C2";
            }
            if (dgvFinanzas.Columns.Contains("crecimiento_intermensual"))
            {
                dgvFinanzas.Columns["crecimiento_intermensual"].HeaderText = "Var. Intermensual";
                dgvFinanzas.Columns["crecimiento_intermensual"].DefaultCellStyle.Format = "+0.0;-0.0;0.0\"%\"";
            }
        }

        private void ConfigurarColumnasGrillaInteranual(int anio1, int anio2)
        {
            if (dgvFinanzas.Columns.Contains("nro_mes")) dgvFinanzas.Columns["nro_mes"].Visible = false;

            if (dgvFinanzas.Columns.Contains("nombre_mes")) dgvFinanzas.Columns["nombre_mes"].HeaderText = "Mes";
            if (dgvFinanzas.Columns.Contains("ventas_anio1")) dgvFinanzas.Columns["ventas_anio1"].HeaderText = "Ventas (" + anio1 + ")";
            if (dgvFinanzas.Columns.Contains("recaudacion_anio1"))
            {
                dgvFinanzas.Columns["recaudacion_anio1"].HeaderText = "Recaudación (" + anio1 + ")";
                dgvFinanzas.Columns["recaudacion_anio1"].DefaultCellStyle.Format = "C2";
            }
            if (dgvFinanzas.Columns.Contains("ventas_anio2")) dgvFinanzas.Columns["ventas_anio2"].HeaderText = "Ventas (" + anio2 + ")";
            if (dgvFinanzas.Columns.Contains("recaudacion_anio2"))
            {
                dgvFinanzas.Columns["recaudacion_anio2"].HeaderText = "Recaudación (" + anio2 + ")";
                dgvFinanzas.Columns["recaudacion_anio2"].DefaultCellStyle.Format = "C2";
            }
            if (dgvFinanzas.Columns.Contains("variacion_interanual"))
            {
                dgvFinanzas.Columns["variacion_interanual"].HeaderText = "Var. Interanual";
                dgvFinanzas.Columns["variacion_interanual"].DefaultCellStyle.Format = "+0.0;-0.0;0.0\"%\"";
            }
        }

        private void ActualizarGraficoIntermensual(DataTable dt)
        {
            chartFinanzas.Series.Clear();
            chartFinanzas.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartFinanzas.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chartFinanzas.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;

            chartFinanzas.ChartAreas[0].AxisX.Interval = 1;
            chartFinanzas.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chartFinanzas.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            chartFinanzas.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chartFinanzas.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chartFinanzas.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            Series serieArea = new Series("Recaudación Total")
            {
                ChartType = SeriesChartType.SplineArea,
                BorderWidth = 3,
                Color = Color.FromArgb(80, 70, 130, 180),
                BorderColor = Color.SteelBlue,
                IsValueShownAsLabel = true
            };
            serieArea.LabelFormat = "N0";

            Series serieCrecimiento = new Series("Var. Intermensual (%)")
            {
                ChartType = SeriesChartType.Spline,
                YAxisType = AxisType.Secondary,
                BorderWidth = 3,
                Color = Color.DarkOrange,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 7,
                IsValueShownAsLabel = true
            };
            serieCrecimiento.LabelFormat = "+0.0;-0.0;0.0'%'";

            int index = 1;
            foreach (DataRow row in dt.Rows)
            {
                string periodo = row["periodo_formateado"].ToString();
                decimal monto = Convert.ToDecimal(row["recaudacion_total"]);

                serieArea.Points.AddXY(index, monto);
                serieArea.Points[serieArea.Points.Count - 1].AxisLabel = periodo;

                decimal crecimiento = (row["crecimiento_intermensual"] != DBNull.Value) ? Convert.ToDecimal(row["crecimiento_intermensual"]) : 0m;
                serieCrecimiento.Points.AddXY(index, crecimiento);
                serieCrecimiento.Points[serieCrecimiento.Points.Count - 1].AxisLabel = periodo;

                index++;
            }

            chartFinanzas.Series.Add(serieArea);
            chartFinanzas.Series.Add(serieCrecimiento);

            int totalPuntos = dt.Rows.Count;
            if (totalPuntos > 12)
            {
                chartFinanzas.ChartAreas[0].AxisX.ScaleView.Size = 12;
                chartFinanzas.ChartAreas[0].AxisX.ScaleView.Position = totalPuntos - 11;
            }
            else
            {
                chartFinanzas.ChartAreas[0].AxisX.ScaleView.Size = totalPuntos > 0 ? totalPuntos : 1;
            }
        }

        private void ActualizarGraficoInteranual(DataTable dt, int anio1, int anio2)
        {
            chartFinanzas.Series.Clear();
            chartFinanzas.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartFinanzas.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

            chartFinanzas.ChartAreas[0].AxisX.Interval = 1;
            chartFinanzas.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chartFinanzas.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            chartFinanzas.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chartFinanzas.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chartFinanzas.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            Series serieAnio1 = new Series("Recaudación " + anio1)
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 2,
                Color = Color.Gray,
                MarkerStyle = MarkerStyle.Square,
                MarkerSize = 5,
                IsValueShownAsLabel = true
            };
            serieAnio1.LabelFormat = "N0";

            Series serieAnio2 = new Series("Recaudación " + anio2)
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                Color = Color.ForestGreen,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 7,
                IsValueShownAsLabel = true
            };
            serieAnio2.LabelFormat = "N0";

            int index = 1;
            foreach (DataRow row in dt.Rows)
            {
                string mes = row["nombre_mes"].ToString();
                decimal monto1 = Convert.ToDecimal(row["recaudacion_anio1"]);
                decimal monto2 = Convert.ToDecimal(row["recaudacion_anio2"]);

                serieAnio1.Points.AddXY(index, monto1);
                serieAnio1.Points[serieAnio1.Points.Count - 1].AxisLabel = mes;

                serieAnio2.Points.AddXY(index, monto2);
                serieAnio2.Points[serieAnio2.Points.Count - 1].AxisLabel = mes;

                index++;
            }

            chartFinanzas.Series.Add(serieAnio1);
            chartFinanzas.Series.Add(serieAnio2);

            int totalPuntos = dt.Rows.Count;
            if (totalPuntos > 12)
            {
                chartFinanzas.ChartAreas[0].AxisX.ScaleView.Size = 12;
                chartFinanzas.ChartAreas[0].AxisX.ScaleView.Position = totalPuntos - 11;
            }
            else
            {
                chartFinanzas.ChartAreas[0].AxisX.ScaleView.Size = totalPuntos > 0 ? totalPuntos : 1;
            }
        }
    }
}