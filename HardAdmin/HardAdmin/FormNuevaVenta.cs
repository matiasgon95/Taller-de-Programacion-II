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

        // Cliente real elegido para la venta. Queda en null cuando todavía no se eligió ninguno;
        // las ventas a Consumidor Final no pasan por acá, se resuelven con el checkbox.
        private int? idClienteSeleccionado;

        // Mientras cargamos un cliente por código (selector, DNI o alta) el TextChanged del DNI
        // no tiene que interpretarlo como que el usuario está escribiendo el DNI a mano.
        private bool asignandoCliente;

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
            txtDni.TextChanged += txtDni_TextChanged;

            chkConsumidorFinal.CheckedChanged += chkConsumidorFinal_CheckedChanged;

            txtCodigo.Leave += txtCodigo_Leave;

            nudCantidad.Minimum = 0;
            nudCantidad.Maximum = 99999; // Le damos un límite alto para que no nos baje el número solo
            nudCantidad.KeyPress += Validaciones.SoloNumeros_KeyPress; // Bloquea escribir negativos o símbolos

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

            // Toda venta arranca como Consumidor Final. Llamamos al método a mano porque, si el
            // checkbox ya viene tildado desde el diseñador, no se dispara el evento CheckedChanged.
            chkConsumidorFinal.Checked = true;
            AplicarModoConsumidorFinal();
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

        // Con el checkbox tildado la venta es a Consumidor Final: no se busca ni se da de alta
        // ningún cliente. Destildado, hay que elegir un cliente real.
        private void chkConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            AplicarModoConsumidorFinal();

            if (!chkConsumidorFinal.Checked)
            {
                txtDni.Focus();
            }
        }

        private void AplicarModoConsumidorFinal()
        {
            bool esConsumidorFinal = chkConsumidorFinal.Checked;

            txtDni.Enabled = !esConsumidorFinal;
            btnBuscarCliente.Enabled = !esConsumidorFinal;
            btnNuevoCliente.Enabled = !esConsumidorFinal;

            if (esConsumidorFinal)
            {
                AsignarCliente(ClienteServicio.ID_CLIENTE_CONSUMIDOR_FINAL, string.Empty, "Consumidor Final");
            }
            else
            {
                // Al destildar arrancamos sin cliente: hay que buscarlo por DNI, elegirlo o darlo de alta.
                AsignarCliente(null, string.Empty, string.Empty);
            }
        }

        // Es el único lugar donde se carga un cliente en pantalla, así el id guardado
        // y lo que se ve (DNI y nombre) siempre coinciden.
        private void AsignarCliente(int? idCliente, string dni, string nombreCompleto)
        {
            asignandoCliente = true;

            idClienteSeleccionado = idCliente;
            txtDni.Text = dni;
            txtCliente.Text = nombreCompleto;

            asignandoCliente = false;
        }

        private void CargarClientePorId(int idCliente)
        {
            try
            {
                DataTable dt = clienteServicio.ObtenerClientePorId(idCliente);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    AsignarCliente(idCliente, fila["dni"].ToString(), $"{fila["nombre"]} {fila["apellido"]}".Trim());
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
                    AsignarCliente(frm.IdClienteSeleccionado, frm.DniClienteSeleccionado,
                        $"{frm.NombreClienteSeleccionado} {frm.ApellidoClienteSeleccionado}".Trim());
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

        // Si el usuario modifica el DNI a mano, el cliente que estaba cargado deja de corresponder:
        // lo limpiamos para no registrar la venta a un cliente distinto del DNI que se ve en pantalla.
        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (asignandoCliente) return;

            idClienteSeleccionado = null;
            txtCliente.Clear();
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
                    AsignarCliente(Convert.ToInt32(fila["id_cliente"]), dni, $"{fila["nombre"]} {fila["apellido"]}".Trim());
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

            int disponible = stock - CantidadYaCargada(idProducto);

            txtCodigo.Text = codigo;
            lblNombreProducto.Text = nombre;
            txtPrecio.Text = precio.ToString("C2", CulturaMoneda);
            lblStock.Text = "Stock: " + Math.Max(disponible, 0);


            if (stock == 0)
            {
                nudCantidad.Value = 1;
                nudCantidad.Enabled = false;
                MessageBox.Show("Este producto no tiene stock disponible.", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (disponible <= 0)
            {
                nudCantidad.Value = 1;
                nudCantidad.Enabled = false;
                MessageBox.Show("Ya agregaste toda la cantidad disponible de este producto a la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                nudCantidad.Enabled = true;
                // No tocamos el Maximum acá. Dejamos que el usuario escriba, 
                // así el btnAgregar ataja el error y muestra el mensaje.
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
            nudCantidad.Maximum = 99999;
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
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad a agregar debe ser mayor a 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return;
            }
            int cantidadYaCargada = CantidadYaCargada(idProductoActual.Value);

            if (cantidadYaCargada + cantidad > stockProductoActual)
            {
                int disponible = stockProductoActual - cantidadYaCargada;
                MessageBox.Show($"No hay stock suficiente. Solo quedan {Math.Max(disponible, 0)} unidad(es) disponibles.",
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

            // Si no es Consumidor Final, tiene que haber un cliente real elegido.
            if (!chkConsumidorFinal.Checked && idClienteSeleccionado == null)
            {
                MessageBox.Show("Buscá un cliente por DNI, elegilo de la lista o marcá Consumidor Final.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            // Armamos la entidad con lo que hay en pantalla. Los importes de la grilla son texto
            // formateado ("$ 1.234,56"), por eso se vuelven a parsear igual que en ActualizarTotales.
            // El subtotal y el total no los mandamos: los calcula la capa de Negocio.
            Venta venta = new Venta
            {
                IdCliente = chkConsumidorFinal.Checked ? ClienteServicio.ID_CLIENTE_CONSUMIDOR_FINAL : idClienteSeleccionado.Value,
                IdUsuario = SesionActual.IdUsuario,
                IdMetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue)
            };

            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (fila.IsNewRow) continue;

                venta.Detalles.Add(new VentaDetalle
                {
                    IdProducto = Convert.ToInt32(fila.Cells["colIdProducto"].Value),
                    Cantidad = Convert.ToInt32(fila.Cells["colCantidad"].Value),
                    PrecioUnitario = decimal.Parse(fila.Cells["colPrecio"].Value.ToString(), NumberStyles.Currency, CulturaMoneda)
                });
            }

            int idVenta;

            try
            {
                idVenta = ventaServicio.RegistrarVenta(venta);
            }
            catch (InvalidOperationException ex)
            {
                // Reglas de negocio incumplidas (por ejemplo, falta de stock): es un aviso, no un fallo del sistema.
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Desde acá la venta ya está guardada. Preguntamos por el comprobante fuera del try de arriba
            // para que un problema al generar el PDF nunca parezca que falló el registro de la venta.
            DialogResult imprimir = MessageBox.Show(
                "Venta registrada con éxito.\nComprobante: F-" + idVenta.ToString().PadLeft(8, '0') + "\n\n¿Desea imprimir el comprobante?",
                "Venta registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (imprimir == DialogResult.Yes)
            {
                ImpresionComprobante.Imprimir(this, idVenta);
            }

            // FormVentas recarga su grilla cuando este formulario cierra con OK.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}