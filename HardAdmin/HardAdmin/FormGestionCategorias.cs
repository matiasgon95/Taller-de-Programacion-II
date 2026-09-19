using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormGestionCategorias : Form
    {
        // Traemos la conexión a la base de datos desde el App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Usamos un DataTable global para mantener los datos en memoria. 
        // Esto permite que la grilla sea interactiva y podamos agregar filas nuevas sin guardar al instante.
        private DataTable dtCategorias;

        public FormGestionCategorias()
        {
            InitializeComponent();

            // Bloqueamos que se agreguen filas solas con el asterisco (*) al final de la grilla.
            // Nosotros lo vamos a manejar de forma más controlada con el botón "Agregar Categoría".
            dgvCategorias.AllowUserToAddRows = false;
        }

        private void FormGestionCategorias_Load(object sender, EventArgs e)
        {
            // Apenas abre la ventana, traemos los datos de SQL
            CargarGrilla();

            // Configuramos un poco el diseño visual de la tabla
            dgvCategorias.ClearSelection();
            dgvCategorias.AllowUserToResizeRows = false;
            dgvCategorias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // ---------- LECTURA DE BASE DE DATOS ----------

        private void CargarGrilla()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Hacemos el SELECT. 
                    // El truco acá es convertir la columna 'baja' (donde 0 es activo y 1 inactivo) 
                    // a una columna temporal 'activa' (1 o 0) para que el CheckBox de la grilla lo entienda directo.
                    string query = @"SELECT 
                                        id_categoria, 
                                        nombre_categoria, 
                                        CAST(CASE WHEN baja = 0 THEN 1 ELSE 0 END AS BIT) AS activa 
                                     FROM Categoria";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        dtCategorias = new DataTable();
                        da.Fill(dtCategorias);

                        // Enlazamos nuestra tabla en memoria con la grilla visual
                        dgvCategorias.AutoGenerateColumns = false;
                        dgvCategorias.DataSource = dtCategorias;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- EVENTOS DE BOTONES ----------

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Cuando hacen clic en agregar, creamos una fila en blanco en nuestra tabla de memoria.
            // Automáticamente va a aparecer en la grilla visual.
            if (dtCategorias != null)
            {
                // Agregamos un registro: ID nulo (se genera en la base después), Nombre vacío, Activa en true.
                dtCategorias.Rows.Add(DBNull.Value, "", true);

                // Hacemos scroll hasta el final y seleccionamos la nueva celda para que el usuario escriba
                int ultimaFila = dgvCategorias.Rows.Count - 1;
                dgvCategorias.CurrentCell = dgvCategorias.Rows[ultimaFila].Cells["colNombre"];
                dgvCategorias.BeginEdit(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones previas
            // Recorremos la grilla para asegurar que no nos dejen categorías con el nombre vacío.
            foreach (DataGridViewRow fila in dgvCategorias.Rows)
            {
                // Ignoramos filas nuevas no confirmadas (si quedara alguna)
                if (fila.IsNewRow) continue;

                string nombre = fila.Cells["colNombre"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("No se pueden guardar categorías con el nombre vacío. Por favor revisá la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Seleccionamos la celda con error para que el usuario la vea
                    dgvCategorias.CurrentCell = fila.Cells["colNombre"];
                    return; // Cortamos el guardado
                }
            }

            // 2. Simulación de guardado (Requisito actual)
            // Cuando implementes la lógica real, acá vas a tener que recorrer el DataTable (dtCategorias),
            // separar las filas nuevas (las que no tienen id_categoria) para hacer INSERT, 
            // y las filas modificadas para hacer UPDATE.

            MessageBox.Show("Las validaciones pasaron correctamente. Por el momento el guardado en la base de datos está deshabilitado.", "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Si la funcionalidad estuviera lista, haríamos:
            // this.DialogResult = DialogResult.OK;
            // this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerramos la ventana sin guardar nada
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}