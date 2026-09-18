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

            // Configuraciones iniciales de la grilla para que se vea prolija y no la puedan editar
            dgvVentas.AutoGenerateColumns = true;
            dgvVentas.Columns.Clear(); // Saca las columnas que hubiera definidas desde el diseñador
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecciona toda la fila
            dgvVentas.MultiSelect = false;
            dgvVentas.ReadOnly = true;
        }

        // Variable para guardar los datos en memoria y poder hacer cálculos rápidos (como la suma)
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

                    // Regla de negocio: si no es admin, solo puede ver sus propias ventas
                    if (!SesionActual.EsAdmin)
                    {
                        query += " WHERE v.id_usuario = @idUsuario";
                    }

                    // Ordenamos para que las ventas más nuevas salgan arriba de todo
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

                // Llamamos a los métodos que acomodan la vista y calculan los totales
                ConfigurarColumnasGrid();
                ActualizarTotalVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Prolija el grid una vez que ya tiene los datos: oculta las columnas que solo
        // sirven internamente, pone encabezados legibles y formatea la plata y la fecha.
        private void ConfigurarColumnasGrid()
        {
            if (!dgvVentas.Columns.Contains("id_venta")) return;

            // Ocultamos el ID real y el estado si no nos hace falta mostrarlo directo en la grilla
            dgvVentas.Columns["id_venta"].Visible = false;
            dgvVentas.Columns["estado"].Visible = false;

            dgvVentas.Columns["nro_factura"].HeaderText = "Nro. Factura";
            dgvVentas.Columns["fecha"].HeaderText = "Fecha";
            dgvVentas.Columns["cliente"].HeaderText = "Cliente";
            dgvVentas.Columns["vendedor"].HeaderText = "Vendedor";
            dgvVentas.Columns["medio_pago"].HeaderText = "Medio de Pago";
            dgvVentas.Columns["total"].HeaderText = "Total";

            // Formatos específicos
            dgvVentas.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvVentas.Columns["total"].DefaultCellStyle.Format = "C2"; // Formato moneda
            dgvVentas.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Ocultar la columna vendedor si el usuario no es Admin (total, todas las ventas serían de él mismo)
            if (!SesionActual.EsAdmin && dgvVentas.Columns.Contains("vendedor"))
            {
                dgvVentas.Columns["vendedor"].Visible = false;
            }
        }

        private void ActualizarTotalVentas()
        {
            if (dtVentas == null) return;

            // Suma la columna 'total' mágicamente directo desde el DataTable. 
            // Respeta los filtros que haya activos (RowFilter)
            object suma = dtVentas.Compute("SUM(total)", dtVentas.DefaultView.RowFilter);

            decimal total = (suma != DBNull.Value && suma != null) ? Convert.ToDecimal(suma) : 0m;
            lblTotalVentas.Text = $"Total de ventas: {total:C2}";
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // Ocultar filtro de vendedor si no es Admin, porque no le corresponde ver al resto
            cmbVendedores.Visible = SesionActual.EsAdmin;
            lblVendedor.Visible = SesionActual.EsAdmin;

            CargarVentas();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            using (FormNuevaVenta formNueva = new FormNuevaVenta())
            {
                // Se abre como diálogo modal bloqueando la ventana de fondo para evitar macanas
                DialogResult resultado = formNueva.ShowDialog();

                // Si la venta se guardó correctamente, refrescamos la grilla para que aparezca la nueva
                if (resultado == DialogResult.OK)
                {
                    CargarVentas();
                }
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            // Validamos que realmente haya tocado una fila antes de intentar abrir el detalle
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
            // Verificamos que no haya hecho doble clic en los títulos de las columnas (eso es e.RowIndex = -1)
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