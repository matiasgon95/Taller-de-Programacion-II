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
        // Traemos la cadena de conexión desde el archivo de configuración (App.config).
        // Es mejor tenerla ahí centralizada por si el día de mañana cambiamos de servidor.
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        public FormGestionProductos()
        {
            InitializeComponent();
        }

        private void FormGestionProductos_Load(object sender, EventArgs e)
        {
            // Vamos a la base de datos y llenamos la grilla apenas arranca la pantalla.
            CargarGrillaProductos();

            // Quitamos la selección azul por defecto de la primera fila para que la pantalla se vea más limpia.
            dgvProductos.ClearSelection();
            dgvProductos.CurrentCell = null;

            // ---------- DISEÑO VISUAL DE LA GRILLA ----------

            // Bloqueamos que el usuario pueda estirar el alto de las filas y nos arruine el diseño visual.
            dgvProductos.AllowUserToResizeRows = false;

            // Centramos los textos de los encabezados (los títulos de las columnas).
            dgvProductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Por defecto, todos los datos de las celdas van alineados a la izquierda y centrados verticalmente.
            dgvProductos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Excepción: la columna "Activo" (que dice Sí/No) queda mucho más prolija si está bien centrada.
            if (dgvProductos.Columns["colActivo"] != null)
            {
                dgvProductos.Columns["colActivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ---------- EVENTOS DE ACCIÓN ----------

        // Evento que salta si el usuario hace doble clic en cualquier celda de la fila
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que e.RowIndex sea >= 0 para asegurarnos de que no hicieron doble clic 
            // en los títulos de las columnas (eso sería la fila -1 y haría explotar el programa).
            if (e.RowIndex >= 0)
            {
                AbrirModificarProducto();
            }
        }

        // Evento Click del botón que ahora está fijo en la parte inferior de la pantalla
        private void btnModificarFila_Click(object sender, EventArgs e)
        {
            // Verificamos que realmente haya tocado una fila antes de intentar modificar algo
            if (dgvProductos.CurrentRow != null)
            {
                AbrirModificarProducto();
            }
            else
            {
                MessageBox.Show("Seleccioná un producto de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Usamos ShowDialog() para que la ventana de agregar bloquee esta pantalla.
            // Así, cuando cierren la ventana de agregar, el código sigue acá y recarga la grilla.
            FormAgregarProducto AgregarProducto = new FormAgregarProducto();
            if (AgregarProducto.ShowDialog() == DialogResult.OK)
            {
                CargarGrillaProductos();
            }
        }

        // ---------- LÓGICA DE FORMULARIOS ----------

        // Centralizamos la apertura del formulario de modificación para no repetir código
        // en el doble clic y en el botón.
        private void AbrirModificarProducto()
        {
            if (dgvProductos.CurrentRow == null || dgvProductos.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccioná un producto de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Casteamos la fila a DataRowView porque la grilla está enlazada a un DataTable.
            // Esto nos permite leer la columna oculta "id_producto" que trajimos de SQL.
            DataRowView filaSeleccionada = (DataRowView)dgvProductos.CurrentRow.DataBoundItem;
            int idProducto = Convert.ToInt32(filaSeleccionada["id_producto"]);

            // TODO: Descomentar y adaptar cuando esté creado el FormModificarProducto
            /*
            using (FormModificarProducto frm = new FormModificarProducto(idProducto))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarGrillaProductos();
                }
            }
            */

            MessageBox.Show("Se abrirá la modificación para el producto ID: " + idProducto, "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------- CONEXIÓN A BASE DE DATOS ----------

        private void CargarGrillaProductos()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Hacemos el SELECT uniendo Producto y Categoria.
                    // Usamos un CASE para transformar el 'bit' (0 o 1) de la columna baja a un 'Sí' o 'No' más amigable.
                    string query = @"SELECT 
                                        p.id_producto,
                                        p.codigo,
                                        p.nombre_producto,
                                        p.descripcion,
                                        p.precio,
                                        p.stock,
                                        p.stock_minimo,
                                        c.nombre_categoria,
                                        CASE WHEN p.baja = 0 THEN 'Sí' ELSE 'No' END AS activo 
                                     FROM Producto p
                                     INNER JOIN Categoria c ON p.id_categoria = c.id_categoria";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Esta propiedad en false es CLAVE: le dice a la grilla que no invente columnas nuevas 
                        // basándose en SQL, sino que acomode los datos en las columnas visuales que nosotros armamos.
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

        // Dejamos vacíos estos métodos temporales para que no se rompa el diseñador si había quedado algún rastro.
        // Después podés borrar estas dos líneas tranquilamente.
        private void dgvProductos_SelectionChanged(object sender, EventArgs e) { }
        private void dgvProductos_Scroll(object sender, ScrollEventArgs e) { }
    }
}