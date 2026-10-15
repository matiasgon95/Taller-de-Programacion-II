using HardAdmin.Entidades;
using HardAdmin.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormVentas : Form
    {
        private VentaServicio servicio = new VentaServicio();
        private DataTable dtVentas;

        public FormVentas()
        {
            InitializeComponent();

            dgvVentas.AutoGenerateColumns = true;
            dgvVentas.Columns.Clear();
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            dgvVentas.ReadOnly = true;

            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
            dtpDesde.ValueChanged += (s, e) => CargarVentas();
            dtpHasta.ValueChanged += (s, e) => CargarVentas();
            cmbVendedores.SelectedIndexChanged += (s, e) => AplicarFiltros();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            btnNuevaVenta.Visible = !SesionActual.EsAdmin;
            cmbVendedores.Visible = SesionActual.EsAdmin;
            lblVendedor.Visible = SesionActual.EsAdmin;

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            if (SesionActual.EsAdmin)
            {
                CargarVendedores();
            }

            CargarVentas();
        }

        private void CargarVentas()
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

                // Pasamos las fechas, el estado de administración y el ID del usuario al servicio
                dtVentas = servicio.ObtenerVentasResumen(desde, hasta, SesionActual.EsAdmin, SesionActual.IdUsuario);
                PrepararColumnaBusqueda();
                dgvVentas.DataSource = dtVentas;

                ConfigurarColumnasGrid();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVendedores()
        {
            try
            {
                List<string> vendedores = servicio.ObtenerVendedoresConVentas();

                cmbVendedores.Items.Clear();
                cmbVendedores.Items.Add("Todos");

                foreach (string vendedor in vendedores)
                {
                    cmbVendedores.Items.Add(vendedor);
                }

                if (cmbVendedores.Items.Count > 0)
                {
                    cmbVendedores.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vendedores: " + ex.Message, "Error");
            }
        }

        // Agrega a la tabla una columna auxiliar (no se muestra) con el texto buscable ya en
        // minúsculas y sin acentos, porque el filtro del DataView no sabe ignorar acentos.
        private void PrepararColumnaBusqueda()
        {
            if (!dtVentas.Columns.Contains("busqueda"))
            {
                dtVentas.Columns.Add("busqueda", typeof(string));
            }

            foreach (DataRow fila in dtVentas.Rows)
            {
                fila["busqueda"] = Busqueda.QuitarAcentos(
                    $"{fila["nro_factura"]} {fila["cliente"]} {fila["medio_pago"]}");
            }
        }

        private void AplicarFiltros()
        {
            if (dtVentas == null) return;

            List<string> filtros = new List<string>();

            string fechaDesde = dtpDesde.Value.Date.ToString("MM/dd/yyyy 00:00:00", CultureInfo.InvariantCulture);
            string fechaHasta = dtpHasta.Value.Date.ToString("MM/dd/yyyy 23:59:59", CultureInfo.InvariantCulture);
            filtros.Add($"fecha >= #{fechaDesde}# AND fecha <= #{fechaHasta}#");

            string textoBuscar = txtBuscar.Text.Trim();
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                // Normalizamos lo escrito igual que la columna "busqueda" para que "perez" encuentre "Pérez".
                string textoFiltro = Busqueda.EscaparParaFiltro(Busqueda.QuitarAcentos(textoBuscar));
                filtros.Add($"busqueda LIKE '%{textoFiltro}%'");
            }

            if (SesionActual.EsAdmin && cmbVendedores.SelectedIndex > 0)
            {
                string vendedor = cmbVendedores.Text.Replace("'", "''");
                filtros.Add($"vendedor = '{vendedor}'");
            }

            string filtroFinal = string.Join(" AND ", filtros);
            dtVentas.DefaultView.RowFilter = filtroFinal;

            ActualizarTotalVentas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            if (cmbVendedores.Items.Count > 0)
                cmbVendedores.SelectedIndex = 0;
        }

        private void ConfigurarColumnasGrid()
        {
            if (!dgvVentas.Columns.Contains("id_venta")) return;

            dgvVentas.Columns["id_venta"].Visible = false;
            dgvVentas.Columns["estado"].Visible = false;
            dgvVentas.Columns["busqueda"].Visible = false; // columna auxiliar del buscador

            dgvVentas.Columns["nro_factura"].HeaderText = "Nro. Factura";
            dgvVentas.Columns["fecha"].HeaderText = "Fecha";
            dgvVentas.Columns["cliente"].HeaderText = "Cliente";
            dgvVentas.Columns["vendedor"].HeaderText = "Vendedor";
            dgvVentas.Columns["medio_pago"].HeaderText = "Medio de Pago";
            dgvVentas.Columns["total"].HeaderText = "Total";

            dgvVentas.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvVentas.Columns["total"].DefaultCellStyle.Format = "C2";
            dgvVentas.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (!SesionActual.EsAdmin && dgvVentas.Columns.Contains("vendedor"))
            {
                dgvVentas.Columns["vendedor"].Visible = false;
            }
        }

        private void ActualizarTotalVentas()
        {
            if (dtVentas == null) return;

            object suma = dtVentas.Compute("SUM(total)", dtVentas.DefaultView.RowFilter);
            decimal total = (suma != DBNull.Value && suma != null) ? Convert.ToDecimal(suma) : 0m;

            lblTotalVentas.Text = total.ToString("C2");
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            using (FormNuevaVenta formNueva = new FormNuevaVenta())
            {
                if (formNueva.ShowDialog() == DialogResult.OK)
                {
                    CargarVentas();
                }
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            AbrirDetalleVenta();
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirDetalleVenta();
            }
        }

        private void AbrirDetalleVenta()
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una venta para ver el detalle.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["id_venta"].Value);

            using (FormDetalleVenta frm = new FormDetalleVenta(idVenta))
            {
                frm.ShowDialog();
            }
        }
    }
}