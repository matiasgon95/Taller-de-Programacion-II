using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HardAdmin.Negocio;

namespace HardAdmin
{
    public partial class FormMovimientosStock : Form
    {
        // Servicios utilizados para consultar los movimientos,
        // las categorías y los productos.
        private readonly MovimientoStockServicio servicioMovimientos =
            new MovimientoStockServicio();

        private readonly CategoriaServicio servicioCategorias =
            new CategoriaServicio();

        private readonly ProductoServicio servicioProductos =
            new ProductoServicio();

        // Indica si los filtros se encuentran en proceso de carga.
        private bool cargandoFiltros = false;

        public FormMovimientosStock()
        {
            InitializeComponent();
        }

        private void FormMovimientosStock_Load(object sender, EventArgs e)
        {
            try
            {
                cargandoFiltros = true;

                // Define un período inicial de consulta: el último mes.
                dtpFechaDesde.Value = DateTime.Today.AddMonths(-1);
                dtpFechaHasta.Value = DateTime.Today;

                // Carga las categorías y los productos disponibles.
                CargarCategorias();
                CargarProductos();

                // Las columnas ya están definidas en el diseñador.
                dgvMovimientos.AutoGenerateColumns = false;
                dgvMovimientos.ClearSelection();

                // Muestra el historial correspondiente a los filtros iniciales.
                MostrarMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar el historial de movimientos.\n\n"
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargandoFiltros = false;
            }
        }

        // Carga las categorías en el combo y agrega la opción
        // para consultar todas las categorías.
        private void CargarCategorias()
        {
            DataTable tablaCategorias = servicioCategorias.ObtenerParaGrilla();

            // Crea una tabla independiente para el combobox.
            DataTable categoriasCombo = tablaCategorias.Clone();

            // Agrega la opción general.
            DataRow filaTodas = categoriasCombo.NewRow();
            filaTodas["id_categoria"] = 0;
            filaTodas["nombre_categoria"] = "Todas las categorías";

            // Si la tabla incluye la columna "activa", completa su valor.
            if (categoriasCombo.Columns.Contains("activa"))
            {
                filaTodas["activa"] = true;
            }

            categoriasCombo.Rows.Add(filaTodas);

            // Copia las categorías existentes.
            foreach (DataRow fila in tablaCategorias.Rows)
            {
                categoriasCombo.ImportRow(fila);
            }

            cmbCategoria.DataSource = categoriasCombo;
            cmbCategoria.DisplayMember = "nombre_categoria";
            cmbCategoria.ValueMember = "id_categoria";
            cmbCategoria.SelectedValue = 0;
        }

        // Carga los productos en el combobox según la categoría seleccionada.
        // Si se seleccionan todas las categorías, muestra todos los productos.
        private void CargarProductos()
        {
            DataTable tablaProductos = servicioProductos.ObtenerParaGrilla();

            // Crea una tabla independiente para el combo.
            DataTable productosCombo = tablaProductos.Clone();

            // Agrega la opción para consultar todos los productos.
            DataRow filaTodos = productosCombo.NewRow();
            filaTodos["id_producto"] = 0;
            filaTodos["nombre_producto"] = "Todos los productos";
            productosCombo.Rows.Add(filaTodos);

            int idCategoria = 0;

            if (cmbCategoria.SelectedValue != null)
            {
                int.TryParse(
                    cmbCategoria.SelectedValue.ToString(),
                    out idCategoria);
            }

            // Copia los productos que corresponden a la categoría elegida.
            foreach (DataRow fila in tablaProductos.Rows)
            {
                int idCategoriaProducto =
                    Convert.ToInt32(fila["id_categoria"]);

                if (idCategoria == 0 || idCategoriaProducto == idCategoria)
                {
                    productosCombo.ImportRow(fila);
                }
            }

            cmbProducto.DataSource = productosCombo;
            cmbProducto.DisplayMember = "nombre_producto";
            cmbProducto.ValueMember = "id_producto";
            cmbProducto.SelectedValue = 0;
        }

        // Actualiza el combobox de productos al cambiar la categoría.
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoFiltros)
            {
                return;
            }

            CargarProductos();
        }

        // Consulta los movimientos aplicando los filtros seleccionados
        // y actualiza el DataGridView.
        private void MostrarMovimientos()
        {
            int idCategoria = 0;
            int idProducto = 0;

            if (cmbCategoria.SelectedValue != null)
            {
                int.TryParse(
                    cmbCategoria.SelectedValue.ToString(),
                    out idCategoria);
            }

            if (cmbProducto.SelectedValue != null)
            {
                int.TryParse(
                    cmbProducto.SelectedValue.ToString(),
                    out idProducto);
            }

            // El servicio valida el rango de fechas y delega la consulta.
            DataTable movimientos = servicioMovimientos.ObtenerParaGrilla(
                idCategoria,
                idProducto,
                dtpFechaDesde.Value,
                dtpFechaHasta.Value);

            dgvMovimientos.DataSource = movimientos;

            // Evita que quede una fila seleccionada automáticamente.
            dgvMovimientos.ClearSelection();
        }

        // Ejecuta la consulta del historial cuando se presiona Mostrar.
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarMovimientos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Rango de fechas inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo consultar el historial de movimientos.\n\n"
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }





        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
