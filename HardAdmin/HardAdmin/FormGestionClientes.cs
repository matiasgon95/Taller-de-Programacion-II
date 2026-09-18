using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace HardAdmin
{
    public partial class FormGestionClientes : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        public FormGestionClientes()
        {
            InitializeComponent();
        }

        private void FormGestionClientes_Load(object sender, EventArgs e)
        {
            // Cargar los clientes desde la base de datos
            CargarGrillaClientes();

            // Deseleccionar cualquier fila por defecto
            dgvClientes.ClearSelection();

            // ---------- DISEÑO VISUAL DE LA GRILLA ----------
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Centrar columnas específicas
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
            // Usamos ShowDialog para que cuando se cierre la ventana, podamos recargar la grilla
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

            // Descomentá esto cuando tengas creado tu FormModificarCliente
            
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                id_cliente, 
                                apellido + ', ' + nombre AS cliente,
                                dni, 
                                telefono,
                                email, 
                                calle + ' ' + numero + ISNULL(' Dpto ' + piso_depto, '') + ', ' + ciudad AS direccion,
                                CASE WHEN baja = 0 THEN 'Sí' ELSE 'No' END AS activo
                             FROM Cliente";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvClientes.AutoGenerateColumns = false;
                        dgvClientes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}