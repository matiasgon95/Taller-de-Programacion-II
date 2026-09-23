using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HardAdmin.Entidades;
using HardAdmin.Negocio;

namespace HardAdmin
{
    public partial class FormGestionMetodosPago : Form
    {
        private MetodoPagoServicio servicio = new MetodoPagoServicio();
        private DataTable dtMetodos;

        public FormGestionMetodosPago()
        {
            InitializeComponent();
            dgvMetodos.AllowUserToAddRows = false;
        }

        private void FormGestionMetodosPago_Load(object sender, EventArgs e)
        {
            CargarGrilla();

            dgvMetodos.ClearSelection();
            dgvMetodos.AllowUserToResizeRows = false;
            dgvMetodos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarGrilla()
        {
            try
            {
                dtMetodos = servicio.ObtenerParaGrilla();

                dgvMetodos.AutoGenerateColumns = false;
                dgvMetodos.DataSource = dtMetodos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtMetodos != null)
            {
                dtMetodos.Rows.Add(DBNull.Value, "", true);

                int ultimaFila = dgvMetodos.Rows.Count - 1;
                dgvMetodos.CurrentCell = dgvMetodos.Rows[ultimaFila].Cells["colNombre"];
                dgvMetodos.BeginEdit(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Forzamos a la grilla a guardar cualquier texto que el usuario haya dejado a medio escribir
            dgvMetodos.EndEdit();

            List<MetodoPago> listaAguardar = new List<MetodoPago>();

            // Recorremos la grilla validando y armando la lista de entidades
            foreach (DataGridViewRow fila in dgvMetodos.Rows)
            {
                if (fila.IsNewRow) continue;

                string nombre = fila.Cells["colNombre"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("No se pueden guardar métodos con el nombre vacío. Revisá la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvMetodos.CurrentCell = fila.Cells["colNombre"];
                    return;
                }

                // Extraemos el ID (si es nuevo, va a estar nulo y le ponemos 0)
                int id = 0;
                if (fila.Cells["colIdMetodoPago"].Value != DBNull.Value && fila.Cells["colIdMetodoPago"].Value != null)
                {
                    id = Convert.ToInt32(fila.Cells["colIdMetodoPago"].Value);
                }

                // El checkbox nos devuelve true o false. Lo pasamos al formato Baja (0 o 1)
                bool activo = Convert.ToBoolean(fila.Cells["colActiva"].Value);

                listaAguardar.Add(new MetodoPago
                {
                    IdMetodoPago = id,
                    NombreMetodo = nombre.Trim(),
                    Baja = activo ? 0 : 1
                });
            }

            // Mandamos todo a la capa de Negocio
            try
            {
                servicio.GuardarCambios(listaAguardar);
                MessageBox.Show("Métodos de pago guardados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}