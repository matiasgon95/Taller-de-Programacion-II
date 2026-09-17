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
    public partial class FormDetalleVenta : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;
        private int idVenta;

        public FormDetalleVenta(int idVenta)
        {
            InitializeComponent();
            this.idVenta = idVenta;

            CargarDatosVenta();
            CargarDetalleProductos();
        }

        private void CargarDatosVenta()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                        'F-' + RIGHT('00000000' + CAST(v.id_venta AS VARCHAR(8)), 8) AS nro_factura,
                                        v.fecha,
                                        v.estado,
                                        c.nombre AS cliente_nombre,
                                        c.apellido AS cliente_apellido,
                                        c.dni,
                                        c.calle,
                                        c.numero,
                                        c.piso_depto,
                                        c.ciudad,
                                        u.nombre_usuario AS vendedor,
                                        mp.nombre_metodo AS medio_pago
                                     FROM Venta v
                                     INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                                     INNER JOIN Usuario u ON v.id_usuario = u.id_usuario
                                     INNER JOIN Metodo_pago mp ON v.id_metodo_pago = mp.id_metodo_pago
                                     WHERE v.id_venta = @idVenta";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nroFactura = reader["nro_factura"].ToString();
                                DateTime fecha = Convert.ToDateTime(reader["fecha"]);
                                string estado = reader["estado"].ToString();
                                string clienteNombre = reader["cliente_nombre"].ToString();
                                string clienteApellido = reader["cliente_apellido"].ToString();
                                string dni = reader["dni"].ToString();
                                string calle = reader["calle"] == DBNull.Value ? "" : reader["calle"].ToString();
                                string numero = reader["numero"] == DBNull.Value ? "" : reader["numero"].ToString();
                                string pisoDepto = reader["piso_depto"] == DBNull.Value ? "" : reader["piso_depto"].ToString();
                                string ciudad = reader["ciudad"] == DBNull.Value ? "" : reader["ciudad"].ToString();
                                string vendedor = reader["vendedor"].ToString();
                                string medioPago = reader["medio_pago"].ToString();

                                lblComprobante.Text = "Comprobante: " + nroFactura;
                                lblFecha.Text = "Fecha: " + fecha.ToString("dd/MM/yyyy HH:mm");
                                lblEstado.Text = "Estado: " + estado;
                                lblCliente.Text = "Cliente: " + $"{clienteNombre} {clienteApellido}";
                                lblDni.Text = "DNI: " + dni;
                                lblDireccion.Text = "Dirección: " + ArmarDireccion(calle, numero, pisoDepto, ciudad);
                                lblVendedor.Text = "Vendedor: " + vendedor;
                                lblMetodoPago.Text = "Método de Pago: " + medioPago;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la venta solicitada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Misma lógica que usamos para armar la dirección completa en el alta de Usuario,
        // adaptada a los nombres de columna de Cliente (numero y piso_depto).
        private string ArmarDireccion(string calle, string numero, string pisoDepto, string ciudad)
        {
            string direccion = $"{calle} {numero}".Trim();

            if (!string.IsNullOrWhiteSpace(pisoDepto))
            {
                direccion += $" Dpto {pisoDepto}";
            }

            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                direccion = direccion.Length > 0 ? direccion + $", {ciudad}" : ciudad;
            }

            return direccion;
        }

        private void CargarDetalleProductos()
        {
            try
            {
                dgvDetalleVenta.Rows.Clear();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                        vd.id_producto,
                                        p.codigo,
                                        p.nombre_producto,
                                        vd.cantidad,
                                        vd.precio_unitario,
                                        vd.subtotal
                                     FROM Venta_detalle vd
                                     INNER JOIN Producto p ON vd.id_producto = p.id_producto
                                     WHERE vd.id_venta = @idVenta";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            decimal total = 0m;

                            while (reader.Read())
                            {
                                int idProducto = Convert.ToInt32(reader["id_producto"]);
                                string codigo = reader["codigo"].ToString();
                                string nombreProducto = reader["nombre_producto"].ToString();
                                int cantidad = Convert.ToInt32(reader["cantidad"]);
                                decimal precioUnitario = Convert.ToDecimal(reader["precio_unitario"]);
                                decimal subtotal = Convert.ToDecimal(reader["subtotal"]);

                                dgvDetalleVenta.Rows.Add(idProducto, codigo, nombreProducto,
                                    cantidad, precioUnitario.ToString("C2"), subtotal.ToString("C2"));

                                total += subtotal;
                            }

                            lblTotal.Text = total.ToString("C2");
                        }
                    }
                }

                if (dgvDetalleVenta.Columns.Contains("colIdProducto"))
                {
                    dgvDetalleVenta.Columns["colIdProducto"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Queda pendiente de definir cómo se va a resolver la impresión del comprobante.
            MessageBox.Show("Funcionalidad de impresión no implementada aún.", "Información");
        }
    }
}