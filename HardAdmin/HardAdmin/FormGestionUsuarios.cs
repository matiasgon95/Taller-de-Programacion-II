using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HardAdmin.Negocio; // Agregamos la referencia a Negocio

namespace HardAdmin
{
    public partial class FormGestionUsuarios : Form
    {
        // Instanciamos el servicio en lugar de la cadena de conexión
        private UsuarioServicio servicio = new UsuarioServicio();

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarGrillaUsuarios();

            dgvUsuarios.ClearSelection();

            // ---------- DISEÑO VISUAL DE LA GRILLA ----------

            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvUsuarios.Columns["colActivo"] != null)
            {
                dgvUsuarios.Columns["colActivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ---------- EVENTOS VACÍOS (PARA NO ROMPER EL DISEÑADOR) ----------
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dgvUsuarios_Scroll(object sender, ScrollEventArgs e)
        {
        }

        // ---------- EVENTOS DE ACCIÓN (MODIFICAR) ----------

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirModificarUsuario();
            }
        }

        private void btnModificarFila_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                AbrirModificarUsuario();
            }
        }

        // ---------- APERTURA DE FORMULARIOS ----------

        private void AbrirModificarUsuario()
        {
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccioná un usuario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRowView filaSeleccionada = (DataRowView)dgvUsuarios.CurrentRow.DataBoundItem;
            int idUsuario = Convert.ToInt32(filaSeleccionada["id_usuario"]);

            using (FormModificarUsuario frm = new FormModificarUsuario(idUsuario))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarGrillaUsuarios();
                }
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            using (FormAgregarUsuario frm = new FormAgregarUsuario())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarGrillaUsuarios();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ---------- CONEXIÓN A BASE DE DATOS ----------

        private void CargarGrillaUsuarios()
        {
            try
            {
                // Pedimos los datos a la capa de Negocio
                DataTable dt = servicio.ObtenerParaGrilla();

                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}