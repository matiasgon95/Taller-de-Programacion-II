using HardAdmin.Negocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace HardAdmin
{
    // Mismo criterio que FormSeleccionarCliente: solo lectura, solo para elegir
    // un producto y devolverlo a FormNuevaVenta.
    public partial class FormSeleccionarProducto : Form
    {
        private ProductoServicio servicio = new ProductoServicio();

        public int IdProductoSeleccionado { get; private set; }
        public string CodigoProductoSeleccionado { get; private set; }
        public string NombreProductoSeleccionado { get; private set; }
        public decimal PrecioProductoSeleccionado { get; private set; }
        public int StockProductoSeleccionado { get; private set; }

        public FormSeleccionarProducto()
        {
            InitializeComponent();

            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.Columns.Clear();
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
        }

        private void FormSeleccionarProducto_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla(string filtro = null)
        {
            try
            {
                // Le pedimos los datos limpios a la capa de Negocio
                DataTable dt = servicio.ObtenerProductosParaSeleccion(filtro);
                dgvProductos.DataSource = dt;

                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (!dgvProductos.Columns.Contains("id_producto")) return;

            dgvProductos.Columns["id_producto"].Visible = false;
            dgvProductos.Columns["codigo"].HeaderText = "Código";
            dgvProductos.Columns["nombre_producto"].HeaderText = "Nombre";
            dgvProductos.Columns["precio"].HeaderText = "Precio";
            dgvProductos.Columns["precio"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["stock"].HeaderText = "Stock";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text);
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ConfirmarSeleccion();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void ConfirmarSeleccion()
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un producto de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IdProductoSeleccionado = Convert.ToInt32(dgvProductos.CurrentRow.Cells["id_producto"].Value);
            CodigoProductoSeleccionado = dgvProductos.CurrentRow.Cells["codigo"].Value.ToString();
            NombreProductoSeleccionado = dgvProductos.CurrentRow.Cells["nombre_producto"].Value.ToString();
            PrecioProductoSeleccionado = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["precio"].Value);
            StockProductoSeleccionado = Convert.ToInt32(dgvProductos.CurrentRow.Cells["stock"].Value);

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