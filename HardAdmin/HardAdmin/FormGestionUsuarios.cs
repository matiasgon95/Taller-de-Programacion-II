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
    public partial class FormGestionUsuarios : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            // Vamos a la base de datos y llenamos la tabla.
            CargarGrillaUsuarios();

            // Apenas arranca, quitamos la selección azul por defecto de la primera fila
            dgvUsuarios.ClearSelection();

            // ---------- DISEÑO VISUAL DE LA GRILLA ----------

            // Bloqueamos que el usuario pueda estirar el alto de las filas y arruinar el diseño.
            dgvUsuarios.AllowUserToResizeRows = false;

            // Centramos los textos de los encabezados (los títulos de las columnas).
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Por defecto, todos los datos de las celdas van alineados a la izquierda y centrados verticalmente.
            dgvUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Excepción: la columna "Activo" (que dice Sí/No) queda mejor si está bien centrada.
            // Agregamos un condicional por si llegás a borrar la columna desde el diseñador.
            if (dgvUsuarios.Columns["colActivo"] != null)
            {
                dgvUsuarios.Columns["colActivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ---------- EVENTOS VACÍOS (PARA NO ROMPER EL DISEÑADOR) ----------
        // Dejamos estos métodos vacíos. Si los borramos, la vista de diseño tira error. 
        // Si querés, después podés desenlazarlos desde el rayito amarillo (Propiedades) y ahí sí borrarlos.

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dgvUsuarios_Scroll(object sender, ScrollEventArgs e)
        {
        }

        // ---------- EVENTOS DE ACCIÓN (MODIFICAR) ----------

        // Permite abrir la edición haciendo doble clic en cualquier parte de la fila.
        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirModificarUsuario();
            }
        }

        // Evento Click del botón que ahora va a estar fijo en la pantalla.
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
            // Por las dudas, validamos que haya una fila real seleccionada.
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                u.id_usuario, 
                                u.dni AS dni,
                                u.apellido + ', ' + u.nombre AS nombre_completo,
                                u.nombre_usuario, 
                                u.email, 
                                r.nombre_rol, 
                                u.fecha_nacimiento AS fecha_nac,
                                u.calle + ' ' + u.altura + ISNULL(' Dpto ' + u.dpto, '') + ', ' + u.localidad AS direccion,
                                CASE WHEN u.baja = 0 THEN 'Sí' ELSE 'No' END AS activo
                             FROM Usuario u
                             INNER JOIN Rol r ON u.id_rol = r.id_rol";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvUsuarios.AutoGenerateColumns = false;
                        dgvUsuarios.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}