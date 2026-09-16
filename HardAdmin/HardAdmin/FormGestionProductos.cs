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
    public partial class FormGestionProductos : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        public FormGestionProductos()
        {
            InitializeComponent();

        }


        private void FormGestionProductos_Load(object sender, EventArgs e)
        {
            btnModificarFila.Visible = false;

            // Cargar los usuarios desde la base de datos
            CargarGrillaProductos();

            // Deseleccionar cualquier fila por defecto
            dgvProductos.ClearSelection();
            dgvProductos.CurrentCell = null;
            btnModificarFila.Visible = false;

            // Centrar los textos de los encabezados (títulos de las columnas)
            dgvProductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Alinear por defecto todos los datos de las celdas a la izquierda (centrados verticalmente)
            dgvProductos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Centrar solo el texto "Sí" / "No" de la columna Activo
            dgvProductos.Columns["colActivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            PosicionarBotonAccion();
        }

        private void dgvProductos_Scroll(object sender, ScrollEventArgs e)
        {
            PosicionarBotonAccion();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no haya hecho doble clic en el encabezado de la columna (fila -1)
            if (e.RowIndex >= 0)
            {
                //AbrirModificarProducto();
            }
        }

        private void PosicionarBotonAccion()
        {
            if (dgvProductos.CurrentCell == null || dgvProductos.SelectedRows.Count == 0)
            {
                btnModificarFila.Visible = false;
                return;
            }

            if (!dgvProductos.Controls.Contains(btnModificarFila))
            {
                dgvProductos.Controls.Add(btnModificarFila);
            }

            int rowIndex = dgvProductos.CurrentRow.Index;
            int columnIndex = dgvProductos.Columns["colAccion"].Index; // Nombre de la columna reservada

            // Obtener las coordenadas en pantalla de la celda de esa fila
            Rectangle cellRectangle = dgvProductos.GetCellDisplayRectangle(columnIndex, rowIndex, false);

            // Si la celda es visible dentro del área visible de la grilla
            if (cellRectangle.Width > 0 && cellRectangle.Height > 0)
            {
                btnModificarFila.Size = new Size(cellRectangle.Width - 4, cellRectangle.Height - 4);
                btnModificarFila.Location = new Point(cellRectangle.X + 2, cellRectangle.Y + 2);
                btnModificarFila.Visible = true;
            }
            else
            {
                btnModificarFila.Visible = false;
            }
        }

        private void AbrirModificarProducto()
        {

        }

        private void CargarGrillaProductos()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // CASE para transformar el bit de baja a 'Sí' / 'No' en la columna activo
                    string query = @"SELECT 
                    p.id_producto,
                    p.codigo,
                    p.nombre_producto,
                    p.descripcion,
                    p.precio,
                    p.stock,
                    p.stock_minimo,
                    c.nombre_categoria,
                    CASE WHEN p.baja = 0 THEN 'Sí' ELSE 'No' END AS activo FROM Producto p
                        INNER JOIN Categoria c ON p.id_categoria = c.id_categoria";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Evita que el DataGridView genere columnas automáticas extras
                        dgvProductos.AutoGenerateColumns = false;

                        dgvProductos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormAgregarProducto AgregarProducto = new FormAgregarProducto();
            AgregarProducto.Show();
        }

        private void btnModificarFila_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                //AbrirModificarProducto();
            }
        }
    }
}
