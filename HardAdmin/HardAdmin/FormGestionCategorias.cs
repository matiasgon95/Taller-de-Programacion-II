using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HardAdmin.Entidades;
using HardAdmin.Negocio;

namespace HardAdmin
{
    public partial class FormGestionCategorias : Form
    {
        private CategoriaServicio servicio = new CategoriaServicio();
        private DataTable dtCategorias;

        public FormGestionCategorias()
        {
            InitializeComponent();
            dgvCategorias.AllowUserToAddRows = false;
        }

        private void FormGestionCategorias_Load(object sender, EventArgs e)
        {
            CargarGrilla();

            dgvCategorias.ClearSelection();
            dgvCategorias.AllowUserToResizeRows = false;
            dgvCategorias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarGrilla()
        {
            try
            {
                dtCategorias = servicio.ObtenerParaGrilla();

                dgvCategorias.AutoGenerateColumns = false;
                dgvCategorias.DataSource = dtCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtCategorias != null)
            {
                dtCategorias.Rows.Add(DBNull.Value, "", true);

                int ultimaFila = dgvCategorias.Rows.Count - 1;
                dgvCategorias.CurrentCell = dgvCategorias.Rows[ultimaFila].Cells["colNombre"];
                dgvCategorias.BeginEdit(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obligamos a la grilla a confirmar el texto si el usuario dejó el cursor titilando adentro
            dgvCategorias.EndEdit();

            List<Categoria> listaAguardar = new List<Categoria>();

            foreach (DataGridViewRow fila in dgvCategorias.Rows)
            {
                if (fila.IsNewRow) continue;

                string nombre = fila.Cells["colNombre"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("No se pueden guardar categorías con el nombre vacío. Por favor revisá la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvCategorias.CurrentCell = fila.Cells["colNombre"];
                    return;
                }

                // Capturamos el ID. Si es una fila recién agregada, el ID es null y le pasamos un 0
                int id = 0;
                if (fila.Cells["colIdCategoria"].Value != DBNull.Value && fila.Cells["colIdCategoria"].Value != null)
                {
                    id = Convert.ToInt32(fila.Cells["colIdCategoria"].Value);
                }

                // Pasamos el CheckBox a estado de baja (true = 0, false = 1)
                bool activa = Convert.ToBoolean(fila.Cells["colActiva"].Value);

                listaAguardar.Add(new Categoria
                {
                    IdCategoria = id,
                    NombreCategoria = nombre.Trim(),
                    Baja = activa ? 0 : 1
                });
            }

            try
            {
                servicio.GuardarCambios(listaAguardar);
                MessageBox.Show("Categorías guardadas con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}