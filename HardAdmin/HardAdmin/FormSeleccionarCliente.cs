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
    // Formulario chico y de solo lectura: sirve únicamente para elegir un cliente
    // y devolvérselo a quien lo abrió (FormNuevaVenta). No da de alta ni modifica nada,
    // para eso ya está FormGestionClientes.
    public partial class FormSeleccionarCliente : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        public int IdClienteSeleccionado { get; private set; }
        public string NombreClienteSeleccionado { get; private set; }
        public string ApellidoClienteSeleccionado { get; private set; }
        public string DniClienteSeleccionado { get; private set; }

        public FormSeleccionarCliente()
        {
            InitializeComponent();

            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.Columns.Clear();
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
        }

        private void FormSeleccionarCliente_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla(string filtro = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT id_cliente, nombre, apellido, dni, telefono FROM Cliente WHERE baja = 0";

                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += " AND (nombre LIKE @filtro OR apellido LIKE @filtro OR dni LIKE @filtro)";
                    }

                    query += " ORDER BY apellido, nombre";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvClientes.DataSource = dt;
                        }
                    }
                }

                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (!dgvClientes.Columns.Contains("id_cliente")) return;

            dgvClientes.Columns["id_cliente"].Visible = false;
            dgvClientes.Columns["nombre"].HeaderText = "Nombre";
            dgvClientes.Columns["apellido"].HeaderText = "Apellido";
            dgvClientes.Columns["dni"].HeaderText = "DNI";
            dgvClientes.Columns["telefono"].HeaderText = "Teléfono";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text);
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un cliente de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IdClienteSeleccionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells["id_cliente"].Value);
            NombreClienteSeleccionado = dgvClientes.CurrentRow.Cells["nombre"].Value.ToString();
            ApellidoClienteSeleccionado = dgvClientes.CurrentRow.Cells["apellido"].Value.ToString();
            DniClienteSeleccionado = dgvClientes.CurrentRow.Cells["dni"].Value.ToString();

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