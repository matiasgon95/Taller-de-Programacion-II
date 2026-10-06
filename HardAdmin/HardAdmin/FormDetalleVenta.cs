using HardAdmin.Negocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormDetalleVenta : Form
    {
        private VentaServicio servicio = new VentaServicio();
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
                // Le pedimos a la capa de Negocio la cabecera de la factura
                DataTable dt = servicio.ObtenerCabeceraVenta(idVenta);

                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];

                    string nroFactura = fila["nro_factura"].ToString();
                    DateTime fecha = Convert.ToDateTime(fila["fecha"]);
                    string estado = fila["estado"].ToString();
                    string clienteNombre = fila["cliente_nombre"].ToString();
                    string clienteApellido = fila["cliente_apellido"].ToString();
                    string dni = fila["dni"].ToString();

                    // Validamos los nulos de la dirección por si el cliente no los tiene cargados
                    string calle = fila["calle"] == DBNull.Value ? "" : fila["calle"].ToString();
                    string numero = fila["numero"] == DBNull.Value ? "" : fila["numero"].ToString();
                    string pisoDepto = fila["piso_depto"] == DBNull.Value ? "" : fila["piso_depto"].ToString();
                    string ciudad = fila["ciudad"] == DBNull.Value ? "" : fila["ciudad"].ToString();

                    string vendedor = fila["vendedor"].ToString();
                    string medioPago = fila["medio_pago"].ToString();

                    // Asignamos todo a los labels de la pantalla dándole un formato prolijo
                    lblComprobante.Text = "Comprobante: " + nroFactura;
                    lblFecha.Text = "Fecha: " + fecha.ToString("dd/MM/yyyy HH:mm");
                    lblEstado.Text = "Estado: " + estado;
                    lblCliente.Text = "Cliente: " + $"{clienteNombre} {clienteApellido}";
                    lblDni.Text = "DNI: " + dni;

                    // Usamos nuestra función especial para armar la dirección completa
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Función auxiliar visual para concatenar la dirección
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

                // Le pedimos a la capa de Negocio los productos de esta factura
                DataTable dt = servicio.ObtenerDetalleVenta(idVenta);
                decimal total = 0m;

                foreach (DataRow fila in dt.Rows)
                {
                    int idProducto = Convert.ToInt32(fila["id_producto"]);
                    string codigo = fila["codigo"].ToString();
                    string nombreProducto = fila["nombre_producto"].ToString();
                    int cantidad = Convert.ToInt32(fila["cantidad"]);
                    decimal precioUnitario = Convert.ToDecimal(fila["precio_unitario"]);
                    decimal subtotal = Convert.ToDecimal(fila["subtotal"]);

                    // Agregamos la fila a la grilla y le damos formato de moneda ("C2") a los precios
                    dgvDetalleVenta.Rows.Add(idProducto, codigo, nombreProducto,
                        cantidad, precioUnitario.ToString("C2"), subtotal.ToString("C2"));

                    total += subtotal;
                }

                lblTotal.Text = total.ToString("C2");

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
            MessageBox.Show("Funcionalidad de impresión no implementada aún.", "Información");
        }
    }
}