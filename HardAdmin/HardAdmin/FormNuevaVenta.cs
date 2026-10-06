using HardAdmin.Entidades;
using HardAdmin.Negocio;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormNuevaVenta : Form
    {
        // Instancias de la capa de Negocio
        private VentaServicio ventaServicio = new VentaServicio();
        private ClienteServicio clienteServicio = new ClienteServicio();
        private ProductoServicio productoServicio = new ProductoServicio();

        // Cultura usada para dar formato y para volver a parsear los importes que
        // se muestran en la grilla (columnas de texto, no numéricas).
        private static readonly CultureInfo CulturaMoneda = CultureInfo.GetCultureInfo("es-AR");

        // id_cliente fijo para las ventas sin un cliente puntual asociado.
        private const int ID_CLIENTE_CONSUMIDOR_FINAL = 1;

        // Cliente elegido para la venta. Arranca en Consumidor Final hasta que se busca o se crea otro.
        private int? idClienteSeleccionado;

        // Producto que está cargado en el panel "Carga rápida", listo para agregarse a la grilla.
        private int? idProductoActual;
        private decimal precioProductoActual;
        private int stockProductoActual;

        public FormNuevaVenta()
        {
            InitializeComponent();

            txtNroComprobante.ReadOnly = true;
            txtPrecio.ReadOnly = true;

            // Reutilizamos el método centralizado de la clase Validaciones
            txtDni.KeyPress += Validaciones.SoloNumeros_KeyPress;
            txtDni.MaxLength = 8;
            txtDni.Leave += txtDni_Leave;

            txtCodigo.Leave += txtCodigo_Leave;

            nudCantidad.Minimum = 1;

            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;

            if (dgvDetalle.Columns.Contains("colIdProducto"))
            {
                dgvDetalle.Columns["colIdProducto"].Visible = false;
            }

            LimpiarPanelCargaRapida();
        }

        private void FormNuevaVenta_Load(object sender, EventArgs e)
        {
            CargarMetodosPago();
            CargarProximoComprobante();
            CargarClienteConsumidorFinal();
            ActualizarTotales();
        }

        // ---------- Comprobante ----------

        private void CargarProximoComprobante()
        {
            try
            {
                int proximoId = ventaServicio.ObtenerProximoId();
                txtNroComprobante.Text = "F-" + proximoId.ToString().PadLeft(8, '0');
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el próximo comprobante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Método de pago ----------

        private void CargarMetodosPago()
        {
            try
            {
                DataTable dt = ventaServicio.ObtenerMetodosPagoActivos();

                cmbMetodoPago.DisplayMember = "nombre_metodo";
                cmbMetodoPago.ValueMember = "id_metodo_pago";
                cmbMetodoPago.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Cliente ----------

        private void CargarClienteConsumidorFinal()
        {
            CargarClientePorId(ID_CLIENTE_CONSUMIDOR_FINAL);
        }

        private void CargarClientePorId(int idCliente)
        {
            try
            {
                DataTable dt = clienteServicio.ObtenerClientePorId(idCliente);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    idClienteSeleccionado = idCliente;
                    txtCliente.Text = $"{fila["nombre"]} {fila["apellido"]}";
                    txtDni.Text = fila["dni"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (FormSeleccionarCliente frm = new FormSeleccionarCliente())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idClienteSeleccionado = frm.IdClienteSeleccionado;
                    txtDni.Text = frm.DniClienteSeleccionado;
                    txtCliente.Text = $"{frm.NombreClienteSeleccionado} {frm.ApellidoClienteSeleccionado}";
                }
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FormAgregarCliente frm = new FormAgregarCliente())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarUltimoClienteCreado();
                }
            }
        }

        private void CargarUltimoClienteCreado()
        {
            try
            {
                int ultimoId = clienteServicio.ObtenerUltimoId();
                if (ultimoId > 0)
                {
                    CargarClientePorId(ultimoId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar el cliente recién creado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDni_Leave(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni) || !Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                return;
            }

            try
            {
                DataTable dt = clienteServicio.ObtenerClientePorDni(dni);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    idClienteSeleccionado = Convert.ToInt32(fila["id_cliente"]);
                    txtCliente.Text = $"{fila["nombre"]} {fila["apellido"]}";
                }
                else
                {
                    MessageBox.Show("No se encontró ningún cliente con ese DNI. Podés buscarlo o darlo de alta con los botones de al lado.",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el cliente por DNI: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Producto ----------

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (FormSeleccionarProducto frm = new FormSeleccionarProducto())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarProductoEnPanel(frm.IdProductoSeleccionado, frm.CodigoProductoSeleccionado,
                        frm.NombreProductoSeleccionado, frm.PrecioProductoSeleccionado, frm.StockProductoSeleccionado);
                }
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return;
            }

            try
            {
                DataTable dt = productoServicio.ObtenerProductoPorCodigo(codigo);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    CargarProductoEnPanel(
                        Convert.ToInt32(fila["id_producto"]),
                        fila["codigo"].ToString(),
                        fila["nombre_producto"].ToString(),
                        Convert.ToDecimal(fila["precio"]),
                        Convert.ToInt32(fila["stock"]));
                }
                else
                {
                    MessageBox.Show("No se encontró ningún producto con ese código.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarPanelCargaRapida();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductoEnPanel(int idProducto, string codigo, string nombre, decimal precio, int stock)
        {
            idProductoActual = idProducto;
            precioProductoActual = precio;
            stockProductoActual = stock;

            txtCodigo.Text = codigo;
            lblNombreProducto.Text = nombre;
            txtPrecio.Text = precio.ToString("C2", CulturaMoneda);
            lblStock.Text = "Stock: " + stock;

            int disponible = stock - CantidadYaCargada(idProducto);

            if (disponible <= 0)
            {
                nudCantidad.Maximum = 1;
                nudCantidad.Value = 1;
                nudCantidad.Enabled = false;
                MessageBox.Show("Ya tenés cargada toda la cantidad disponible de este producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                nudCantidad.Enabled = true;
                nudCantidad.Maximum = disponible;
                nudCantidad.Value = 1;
            }
        }

        private void LimpiarPanelCargaRapida()
        {
            idProductoActual = null;
            precioProductoActual = 0m;
            stockProductoActual = 0;

            txtCodigo.Text = string.Empty;
            lblNombreProducto.Text = "Seleccione producto...";
            txtPrecio.Text = 0m.ToString("C2", CulturaMoneda);
            lblStock.Text = "Stock: -";
            nudCantidad.Enabled = true;
            nudCantidad.Maximum = 1;
            nudCantidad.Value = 1;
        }

        // ---------- Grilla de detalle ----------

        private int CantidadYaCargada(int idProducto)
        {
            int cantidad = 0;

            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (fila.IsNewRow) continue;

                int idProductoFila = Convert.ToInt32(fila.Cells["colIdProducto"].Value);
                if (idProductoFila == idProducto)
                {
                    cantidad += Convert.ToInt32(fila.Cells["colCantidad"].Value);
                }
            }

            return cantidad;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (idProductoActual == null)
            {
                MessageBox.Show("Buscá un producto por código o desde la lista antes de agregarlo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            int cantidadYaCargada = CantidadYaCargada(idProductoActual.Value);

            if (cantidadYaCargada + cantidad > stockProductoActual)
            {
                int disponible = stockProductoActual - cantidadYaCargada;
                MessageBox.Show($"No hay stock suficiente. Disponible: {Math.Max(disponible, 0)} unidad(es).",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = precioProductoActual * cantidad;

            dgvDetalle.Rows.Add(idProductoActual, txtCodigo.Text, lblNombreProducto.Text,
                cantidad, precioProductoActual.ToString("C2", CulturaMoneda), subtotal.ToString("C2", CulturaMoneda));

            ActualizarTotales();
            LimpiarPanelCargaRapida();
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una fila de la grilla para quitarla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            decimal total = 0m;

            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (fila.IsNewRow) continue;

                string subtotalTexto = fila.Cells["colSubtotal"].Value?.ToString() ?? "0";
                total += decimal.Parse(subtotalTexto, NumberStyles.Currency, CulturaMoneda);
            }

            lblCantidadItems.Text = "Items agregados: " + dgvDetalle.Rows.Count;
            lblMontoTotal.Text = total.ToString("C2", CulturaMoneda);
        }

        // ---------- Registrar / Cancelar ----------

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Agregá al menos un producto antes de registrar la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná un método de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMetodoPago.Focus();
                return;
            }

            string cliente = string.IsNullOrWhiteSpace(txtCliente.Text) ? "Consumidor Final" : txtCliente.Text;
            string medioPago = cmbMetodoPago.Text;

            // Todavía no se persiste en la base de datos: esto es solo una vista previa
            // de lo que se va a registrar cuando conectemos el INSERT.
            MessageBox.Show(
                $"Comprobante: {txtNroComprobante.Text}\nCliente: {cliente}\nMétodo de pago: {medioPago}\nItems: {dgvDetalle.Rows.Count}\nTotal: {lblMontoTotal.Text}\n\n(Simulación: todavía no se guardó nada en la base de datos)",
                "Vista previa de la venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}