using HardAdmin.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization; // Necesario para el formato de las fechas del filtro
using System.Linq;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormVentas : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;
        private DataTable dtVentas;

        public FormVentas()
        {
            InitializeComponent();

            // Configuraciones de la grilla
            dgvVentas.AutoGenerateColumns = true;
            dgvVentas.Columns.Clear();
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            dgvVentas.ReadOnly = true;

            // Enganchamos los eventos de los filtros para que reaccionen al instante
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
            dtpDesde.ValueChanged += (s, e) => AplicarFiltros();
            dtpHasta.ValueChanged += (s, e) => AplicarFiltros();
            cmbVendedores.SelectedIndexChanged += (s, e) => AplicarFiltros();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // CRÍTICO DE SEGURIDAD: El Administrador entra como auditor, no como operador.
            btnNuevaVenta.Visible = !SesionActual.EsAdmin;
            cmbVendedores.Visible = SesionActual.EsAdmin;
            lblVendedor.Visible = SesionActual.EsAdmin;

            // Configuramos las fechas por defecto (últimos 30 días)
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            // Si es Admin, cargamos los vendedores para el filtro
            if (SesionActual.EsAdmin)
            {
                CargarVendedores();
            }

            CargarVentas();
        }

        // ---------- CONEXIÓN A BASE DE DATOS ----------

        private void CargarVentas()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                        v.id_venta,
                                        'F-' + RIGHT('00000000' + CAST(v.id_venta AS VARCHAR(8)), 8) AS nro_factura,
                                        v.fecha,
                                        (c.apellido + ', ' + c.nombre) AS cliente,
                                        u.nombre_usuario AS vendedor,
                                        mp.nombre_metodo AS medio_pago,
                                        v.estado,
                                        v.total
                                    FROM Venta v
                                    INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                                    INNER JOIN Usuario u ON v.id_usuario = u.id_usuario
                                    INNER JOIN Metodo_pago mp ON v.id_metodo_pago = mp.id_metodo_pago";

                    // Si no es admin, filtramos directo desde SQL para que solo baje sus propias ventas
                    if (!SesionActual.EsAdmin)
                    {
                        query += " WHERE v.id_usuario = @idUsuario";
                    }

                    query += " ORDER BY v.fecha DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!SesionActual.EsAdmin)
                        {
                            cmd.Parameters.AddWithValue("@idUsuario", SesionActual.IdUsuario);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtVentas = new DataTable();
                            da.Fill(dtVentas);
                            dgvVentas.DataSource = dtVentas;
                        }
                    }
                }

                ConfigurarColumnasGrid();
                AplicarFiltros(); // Aplicamos los filtros iniciales (fechas)
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Buscamos solo los usuarios que tengan al menos una venta para no ensuciar el combo
                    string query = "SELECT DISTINCT u.nombre_usuario FROM Venta v INNER JOIN Usuario u ON v.id_usuario = u.id_usuario ORDER BY u.nombre_usuario";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbVendedores.Items.Clear();
                            cmbVendedores.Items.Add("Todos"); // Opción 0: Sin filtro

                            while (reader.Read())
                            {
                                cmbVendedores.Items.Add(reader["nombre_usuario"].ToString());
                            }

                            if (cmbVendedores.Items.Count > 0)
                                cmbVendedores.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vendedores: " + ex.Message, "Error");
            }
        }

        // ---------- LÓGICA DE FILTROS EN MEMORIA ----------

        private void AplicarFiltros()
        {
            if (dtVentas == null) return;

            List<string> filtros = new List<string>();

            // 1. Filtro por Rango de Fechas (Desde las 00:00:00 hasta las 23:59:59)
            // Se usa InvariantCulture para que el filtro interno de DataView lo entienda siempre igual
            string fechaDesde = dtpDesde.Value.Date.ToString("MM/dd/yyyy 00:00:00", CultureInfo.InvariantCulture);
            string fechaHasta = dtpHasta.Value.Date.ToString("MM/dd/yyyy 23:59:59", CultureInfo.InvariantCulture);
            filtros.Add($"fecha >= #{fechaDesde}# AND fecha <= #{fechaHasta}#");

            // 2. Filtro de Texto Dinámico (Busca en Factura, Cliente o Medio de Pago)
            string textoBuscar = txtBuscar.Text.Trim().Replace("'", "''"); // Replace evita errores si escriben una comilla simple
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                filtros.Add($"(nro_factura LIKE '%{textoBuscar}%' OR cliente LIKE '%{textoBuscar}%' OR medio_pago LIKE '%{textoBuscar}%')");
            }

            // 3. Filtro por Vendedor (Solo aplicable si es Admin y seleccionó alguien distinto de "Todos")
            if (SesionActual.EsAdmin && cmbVendedores.SelectedIndex > 0)
            {
                string vendedor = cmbVendedores.Text.Replace("'", "''");
                filtros.Add($"vendedor = '{vendedor}'");
            }

            // Unimos todos los filtros con un "AND" y se los aplicamos a la vista del DataTable
            string filtroFinal = string.Join(" AND ", filtros);
            dtVentas.DefaultView.RowFilter = filtroFinal;

            // Como cambiaron las filas visibles, recalculamos la plata
            ActualizarTotalVentas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Reseteamos los controles a sus valores por defecto
            txtBuscar.Clear();
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            if (cmbVendedores.Items.Count > 0)
                cmbVendedores.SelectedIndex = 0;

            // La limpieza dispara los eventos Changed automáticamente, así que la grilla se refresca sola.
        }

        // ---------- VISUAL Y TOTALES ----------

        private void ConfigurarColumnasGrid()
        {
            if (!dgvVentas.Columns.Contains("id_venta")) return;

            dgvVentas.Columns["id_venta"].Visible = false;
            dgvVentas.Columns["estado"].Visible = false;

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

            // La magia del RowFilter: Compute solo suma las filas que sobrevivieron a los filtros visibles
            object suma = dtVentas.Compute("SUM(total)", dtVentas.DefaultView.RowFilter);
            decimal total = (suma != DBNull.Value && suma != null) ? Convert.ToDecimal(suma) : 0m;

            lblTotalVentas.Text = $"Total de ventas: {total:C2}";
        }

        // ---------- EVENTOS DE ACCIÓN ----------

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            using (FormNuevaVenta formNueva = new FormNuevaVenta())
            {
                if (formNueva.ShowDialog() == DialogResult.OK)
                {
                    CargarVentas(); // Recargamos para que traiga la nueva venta a la memoria
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