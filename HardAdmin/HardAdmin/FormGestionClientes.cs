using System;
using System.Data;
using System.Windows.Forms;
using HardAdmin.Negocio;

namespace HardAdmin
{
    public partial class FormGestionClientes : Form
    {
        private ClienteServicio servicio = new ClienteServicio();

        public FormGestionClientes()
        {
            InitializeComponent();
        }

        private void FormGestionClientes_Load(object sender, EventArgs e)
        {
            CargarGrillaClientes();

            dgvClientes.ClearSelection();

            // ---------- DISEÑO VISUAL DE LA GRILLA ----------
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvClientes.Columns["colActivo"] != null)
                dgvClientes.Columns["colActivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvClientes.Columns["colNroCliente"] != null)
                dgvClientes.Columns["colNroCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // ---------- EVENTOS DE ACCIÓN ----------

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirModificarCliente();
            }
        }

        private void btnModificarFila_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                AbrirModificarCliente();
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FormAgregarCliente frm = new FormAgregarCliente())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarGrillaClientes();
                }
            }
        }

        // ---------- LÓGICA DE FORMULARIOS ----------

        private void AbrirModificarCliente()
        {
            if (dgvClientes.CurrentRow == null || dgvClientes.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccioná un cliente de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRowView filaSeleccionada = (DataRowView)dgvClientes.CurrentRow.DataBoundItem;
            int idCliente = Convert.ToInt32(filaSeleccionada["id_cliente"]);

            using (FormModificarCliente frm = new FormModificarCliente(idCliente))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarGrillaClientes();
                }
            }
        }

        // ---------- CONEXIÓN A BASE DE DATOS ----------

        private void CargarGrillaClientes()
        {
            try
            {
                // Ahora la UI solo pide los datos al servicio
                DataTable dt = servicio.ObtenerParaGrilla();

                dgvClientes.AutoGenerateColumns = false;
                dgvClientes.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}