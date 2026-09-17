using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormVentas : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;
        public FormVentas()
        {
            InitializeComponent();

            dgvVentas.AutoGenerateColumns = true;
            dgvVentas.Columns.Clear(); // saca las columnas que hubiera definidas desde el diseñador
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            dgvVentas.ReadOnly = true;
        }

        private DataTable dtVentas;

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

                    // Filtramos las ventas según el rol del usuario
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
                ActualizarTotalVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Prolija el grid una vez que ya tiene los datos: oculta las columnas que solo
        // sirven internamente, pone encabezados en español y formatea fecha y total.
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

            // Ocultar columnas que no corresponden según el rol
            if (!SesionActual.EsAdmin && dgvVentas.Columns.Contains("vendedor"))
            {
                dgvVentas.Columns["vendedor"].Visible = false;
            }
        }

        private void ActualizarTotalVentas()
        {
            if (dtVentas == null) return;

            // Suma la columna 'total' únicamente de las filas visibles según los filtros aplicados
            object suma = dtVentas.Compute("SUM(total)", dtVentas.DefaultView.RowFilter);

            decimal total = (suma != DBNull.Value && suma != null) ? Convert.ToDecimal(suma) : 0m;
            lblTotalVentas.Text = $"Total de ventas: {total:C2}";
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // Ocultar filtro de vendedor si no es Admin
            cmbVendedores.Visible = SesionActual.EsAdmin;
            lblVendedor.Visible = SesionActual.EsAdmin;

            CargarVentas();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            using (FormNuevaVenta formNueva = new FormNuevaVenta())
            {
                // Se abre como diálogo modal bloqueando la ventana de fondo
                DialogResult resultado = formNueva.ShowDialog();

                // Si la venta se guardó correctamente, refrescamos la grilla de ventas
                if (resultado == DialogResult.OK)
                {
                    CargarVentas();
                }
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
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

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idVenta = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["id_venta"].Value);
                using (FormDetalleVenta frm = new FormDetalleVenta(idVenta))
                {
                    frm.ShowDialog();
                }
            }
        }
    }
}