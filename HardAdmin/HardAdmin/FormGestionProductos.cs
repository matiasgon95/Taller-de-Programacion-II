using HardAdmin.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormGestionProductos : Form
    {
        // Traemos la cadena de conexión desde el archivo de la capa de Servcio de producto.
        private ProductoServicio servicio = new ProductoServicio();

        // Llamamos al servicio encargado de las categorías.
        private CategoriaServicio servicioCategoria = new CategoriaServicio();

        private DataTable dtProductos;

        public FormGestionProductos()
        {
            InitializeComponent();
        }

        private void FormGestionProductos_Load(object sender, EventArgs e)
        {
            // Cargamos las categorias para el filtro de busqueda
            CargarCategoriasFiltro();
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


            using (FormModificarProducto frm = new FormModificarProducto(idProducto))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarGrillaProductos();
                }
            }
        }

        // ---------- CONEXIÓN A BASE DE DATOS ----------

        private void CargarGrillaProductos()
        {
            try
            {
                //Obtenemos la grilla llamando al servicio de dicha capa.
                dtProductos = servicio.ObtenerParaGrilla();

                // Esta propiedad en false es CLAVE: le dice a la grilla que no invente columnas nuevas 
                // basándose en SQL, sino que acomode los datos en las columnas visuales que nosotros armamos.
                dgvProductos.AutoGenerateColumns = false;
                dgvProductos.DataSource = dtProductos;

                // Si hay texto en el buscador, volvemos a aplicar el filtro.
                FiltrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Busca la imagen del producto a partir de la ruta almacenada
        // en la base de datos y la muestra en el PictureBox.
        private void CargarImagenProducto(string rutaFoto)
        {
            if (string.IsNullOrWhiteSpace(rutaFoto))
                return;

            DirectoryInfo directorioActual =
                new DirectoryInfo(Application.StartupPath);

            DirectoryInfo carpetaImagenes = null;

            while (directorioActual != null)
            {
                string posibleRuta = Path.Combine(
                    directorioActual.FullName,
                    "ImagenesProductos"
                );

                if (Directory.Exists(posibleRuta))
                {
                    carpetaImagenes = new DirectoryInfo(posibleRuta);
                    break;
                }

                directorioActual = directorioActual.Parent;
            }

            if (carpetaImagenes == null)
            {
                LimpiarImagenProducto();
                return;
            }

            string nombreArchivo = Path.GetFileName(rutaFoto);

            string rutaCompleta = Path.Combine(
                carpetaImagenes.FullName,
                nombreArchivo
            );

            if (!File.Exists(rutaCompleta))
            {
                LimpiarImagenProducto();
                return;
            }

            try
            {
                if (pbImagen.Image != null)
                {
                    pbImagen.Image.Dispose();
                    pbImagen.Image = null;
                }

                using (FileStream stream = new FileStream(
                    rutaCompleta,
                    FileMode.Open,
                    FileAccess.Read))
                {
                    using (Image imagenTemporal = Image.FromStream(stream))
                    {
                        pbImagen.Image = new Bitmap(imagenTemporal);
                    }
                }

                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                LimpiarImagenProducto();

                MessageBox.Show(
                    "No se pudo cargar la imagen del producto: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Limpia la imagen mostrada en el panel de detalle
        // cuando el producto seleccionado no posee una imagen.
        private void LimpiarImagenProducto()
        {
            if (pbImagen.Image != null)
            {
                pbImagen.Image.Dispose();
                pbImagen.Image = null;
            }

            pbImagen.Image = null;
        }

        // Segun la casilla seleccionada en el DataGrindView
        // aparece una informacion mas detallada en la seccion inferior en el GroupBox
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
                return;

            DataRowView filaSeleccionada =
                (DataRowView)dgvProductos.CurrentRow.DataBoundItem;

            if (filaSeleccionada == null)
                return;

            lbCodigoInfo.Text = filaSeleccionada["codigo"].ToString();
            lbNombreInfo.Text = filaSeleccionada["nombre_producto"].ToString();
            lbCategoriaInfo.Text = filaSeleccionada["nombre_categoria"].ToString();

            lbStockInfo.Text =
                filaSeleccionada["stock"].ToString();

            lbStockMinimoInfo.Text =
                filaSeleccionada["stock_minimo"].ToString();

            lbPrecioInfo.Text =
                "$ " + Convert.ToDecimal(filaSeleccionada["precio"])
                    .ToString("N2");

            lbDescripcionInfo.Text =
                filaSeleccionada["descripcion"] == DBNull.Value
                    ? "Sin descripción."
                    : filaSeleccionada["descripcion"].ToString();

            if (filaSeleccionada["foto_producto"] == DBNull.Value ||
                string.IsNullOrWhiteSpace(
                    filaSeleccionada["foto_producto"].ToString()))
            {
                LimpiarImagenProducto();
            }
            else
            {
                string rutaFoto =
                    filaSeleccionada["foto_producto"].ToString();

                CargarImagenProducto(rutaFoto);
            }
        }

        // Filtra los productos mostrados en la grilla según el texto ingresado en el buscador.
        private void FiltrarProductos()
        {
            // Si todavía no tenemos productos cargados, no hacemos nada.
            if (dtProductos == null)
                return;

            List<string> filtros = new List<string>();

            string texto = txtBuscarProducto.Text.Trim();

            // Si el buscador está vacío, mostramos todos los productos.
            if (!string.IsNullOrWhiteSpace(texto))
            {
                // Escapamos caracteres especiales para evitar problemas
                // al utilizar el texto dentro del filtro.
                string textoFiltro = texto
                    .Replace("'", "''")
                    .Replace("[", "[[]")
                    .Replace("%", "[%]")
                    .Replace("*", "[*]");

                // Filtro por código o nombre.
                filtros.Add(
                    $"(codigo LIKE '%{textoFiltro}%' " +
                    $"OR nombre_producto LIKE '%{textoFiltro}%')"
                );
            }

            // Filtro por categoría.
            if (cmbFiltroCategoria.SelectedValue != null)
            {
                int idCategoria = Convert.ToInt32(
                    cmbFiltroCategoria.SelectedValue
                );

                // ID 0 significa "Todas las categorías".
                if (idCategoria != 0)
                {
                    filtros.Add($"id_categoria = {idCategoria}");
                }
            }

            // Si hay filtros, los combinamos utilizando AND.
            // Si no hay ninguno, mostramos todos los productos.
            dtProductos.DefaultView.RowFilter =
                string.Join(" AND ", filtros);
        }

        //Carga las categorias para las opciones de filtrado.
        private void CargarCategoriasFiltro()
        {
            try
            {
                DataTable dtCategorias = servicioCategoria.ObtenerParaGrilla();

                DataView vista = new DataView(dtCategorias);
                vista.RowFilter = "activa = true";

                DataTable dtFiltrado = vista.ToTable();

                DataRow filaTodas = dtFiltrado.NewRow();
                filaTodas["id_categoria"] = 0;
                filaTodas["nombre_categoria"] = "Todas las categorías";
                filaTodas["activa"] = true;

                dtFiltrado.Rows.InsertAt(filaTodas, 0);

                cmbFiltroCategoria.DataSource = dtFiltrado;
                cmbFiltroCategoria.DisplayMember = "nombre_categoria";
                cmbFiltroCategoria.ValueMember = "id_categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las categorías: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }


        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            FormMovimientosStock frm = new FormMovimientosStock();
            frm.ShowDialog();
        }






        // Dejamos vacíos estos métodos temporales para que no se rompa el diseñador si había quedado algún rastro.
        // Después podés borrar estas dos líneas tranquilamente.

        private void dgvProductos_Scroll(object sender, ScrollEventArgs e) { }

    }
}