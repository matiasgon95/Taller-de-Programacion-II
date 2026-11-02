using HardAdmin.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HardAdmin
{
    public partial class FormReporteProductos : Form
    {
        private ProductoServicio productoServicio = new ProductoServicio();
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private static readonly CultureInfo CulturaMoneda = CultureInfo.GetCultureInfo("es-AR");

        public FormReporteProductos()
        {
            InitializeComponent();

            // Blindamos la grilla
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.RowHeadersVisible = false;
        }

        private void FormReporteProductos_Load(object sender, EventArgs e)
        {
            // 1. Configuramos los límites de fechas según los datos reales de la BD
            ConfigurarLimitesFechas();

            CargarCategorias();
            CargarReporte();
        }

        private void ConfigurarLimitesFechas()
        {
            try
            {
                // Obtenemos los años disponibles a través del servicio de productos
                List<int> aniosDisponibles = productoServicio.ObtenerAniosDisponibles();

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
            catch (Exception)
            {
                // Si ocurre algún error, dejamos valores por defecto seguros
                dtpDesde.Value = DateTime.Today.AddDays(-30);
                dtpHasta.Value = DateTime.Today;
            }
        }

        private void CargarCategorias()
        {
            try
            {
                DataTable dt = categoriaServicio.ObtenerParaCombo();
                DataRow filaTodas = dt.NewRow();
                filaTodas["id_categoria"] = 0;
                filaTodas["nombre_categoria"] = "Todas las categorías";
                dt.Rows.InsertAt(filaTodas, 0);

                cmbCategorias.DisplayMember = "nombre_categoria";
                cmbCategorias.ValueMember = "id_categoria";
                cmbCategorias.DataSource = dt;
                cmbCategorias.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int idCategoria = cmbCategorias.SelectedValue != null ? Convert.ToInt32(cmbCategorias.SelectedValue) : 0;
                int topN = 10; // Top 10 productos más vendidos

                DataTable dt = productoServicio.ObtenerTopProductos(topN, idCategoria, desde, hasta);

                dgvProductos.DataSource = dt;
                ConfigurarColumnasGrilla();

                int totalUnidades = 0;
                decimal totalRecaudadoProductos = 0m;

                foreach (DataRow row in dt.Rows)
                {
                    totalUnidades += Convert.ToInt32(row["unidades_vendidas"]);
                    totalRecaudadoProductos += Convert.ToDecimal(row["recaudacion_total"]);
                }

                // Actualizamos las tarjetas inferiores
                lblValorUnidades.Text = totalUnidades.ToString();
                lblValorRecaudacion.Text = totalRecaudadoProductos.ToString("C2", CulturaMoneda);

                // Configurar Gráfico de Pirámide
                chartProductos.Series.Clear();
                Series serie = new Series("Unidades")
                {
                    ChartType = SeriesChartType.Pyramid,
                    IsValueShownAsLabel = true
                };

                // Esto hace que las etiquetas salgan afuera con el nombre y valor para que no se encimen
                serie["PyramidLabelStyle"] = "Outside";

                // Recorremos la tabla de atrás para adelante: 
                // así el producto N° 1 (el más vendido) queda en la base (abajo) 
                // y el último queda en la punta (arriba).
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = dt.Rows[i];
                    string nombre = row["nombre_producto"].ToString();
                    int unidades = Convert.ToInt32(row["unidades_vendidas"]);

                    int index = serie.Points.AddXY(nombre, unidades);
                    serie.Points[index].LegendText = nombre;
                }

                chartProductos.Series.Add(serie);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrilla()
        {
            if (dgvProductos.Columns.Contains("codigo")) dgvProductos.Columns["codigo"].HeaderText = "Código";
            if (dgvProductos.Columns.Contains("nombre_producto")) dgvProductos.Columns["nombre_producto"].HeaderText = "Producto";
            if (dgvProductos.Columns.Contains("nombre_categoria")) dgvProductos.Columns["nombre_categoria"].HeaderText = "Categoría";
            if (dgvProductos.Columns.Contains("unidades_vendidas")) dgvProductos.Columns["unidades_vendidas"].HeaderText = "Unidades";
            if (dgvProductos.Columns.Contains("recaudacion_total"))
            {
                dgvProductos.Columns["recaudacion_total"].HeaderText = "Recaudación";
                dgvProductos.Columns["recaudacion_total"].DefaultCellStyle.Format = "C2";
            }
            if (dgvProductos.Columns.Contains("stock_actual")) dgvProductos.Columns["stock_actual"].HeaderText = "Stock";
        }
    }
}