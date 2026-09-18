using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormNuevaVenta : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

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

            txtDni.KeyPress += SoloNumeros_KeyPress;
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

        // El número real lo define SQL Server al insertar (IDENTITY), pero mostramos
        // una vista previa tomando el próximo id_venta disponible.
        private void CargarProximoComprobante()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT ISNULL(MAX(id_venta), 0) + 1 FROM Venta";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int proximoId = (int)cmd.ExecuteScalar();
                        txtNroComprobante.Text = "F-" + proximoId.ToString().PadLeft(8, '0');
                    }
                }
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT id_metodo_pago, nombre_metodo FROM Metodo_pago WHERE baja = 0";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbMetodoPago.DisplayMember = "nombre_metodo";
                        cmbMetodoPago.ValueMember = "id_metodo_pago";
                        cmbMetodoPago.DataSource = dt;
                    }
                }
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT nombre, apellido, dni FROM Cliente WHERE id_cliente = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idCliente);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idClienteSeleccionado = idCliente;
                                txtCliente.Text = $"{reader["nombre"]} {reader["apellido"]}";
                                txtDni.Text = reader["dni"].ToString();
                            }
                        }
                    }
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

        // FormAgregarCliente todavía no expone el registro recién creado, así que lo
        // traemos buscando el id_cliente más alto. Si más adelante agregás una propiedad
        // pública en FormAgregarCliente con el id insertado, conviene usar esa en vez de esto.
        private void CargarUltimoClienteCreado()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 id_cliente FROM Cliente ORDER BY id_cliente DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null)
                        {
                            CargarClientePorId(Convert.ToInt32(resultado));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar el cliente recién creado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Busca el cliente por DNI apenas se sale del campo, sin pasar por el selector.
        private void txtDni_Leave(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni) || !Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT id_cliente, nombre, apellido FROM Cliente WHERE dni = @dni AND baja = 0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@dni", dni);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idClienteSeleccionado = Convert.ToInt32(reader["id_cliente"]);
                                txtCliente.Text = $"{reader["nombre"]} {reader["apellido"]}";
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún cliente con ese DNI. Podés buscarlo o darlo de alta con los botones de al lado.",
                                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el cliente por DNI: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT id_producto, codigo, nombre_producto, precio, stock FROM Producto WHERE codigo = @codigo AND baja = 0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CargarProductoEnPanel(
                                    Convert.ToInt32(reader["id_producto"]),
                                    reader["codigo"].ToString(),
                                    reader["nombre_producto"].ToString(),
                                    Convert.ToDecimal(reader["precio"]),
                                    Convert.ToInt32(reader["stock"]));
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún producto con ese código.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                LimpiarPanelCargaRapida();
                            }
                        }
                    }
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
            nudCantidad.Value = 1;
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
            nudCantidad.Value = 1;
        }

        // ---------- Grilla de detalle ----------

        // Suma la cantidad que ya está cargada en la grilla para un producto puntual,
        // para no dejar pasar un total que supere el stock entre varias líneas.
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