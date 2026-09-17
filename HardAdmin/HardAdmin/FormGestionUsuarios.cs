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
            dgvUsuarios.Controls.Add(btnModificarFila);
           
            // Cargar los usuarios desde la base de datos
            CargarGrillaUsuarios();

            // Deseleccionar cualquier fila por defecto
            dgvUsuarios.ClearSelection();
            btnModificarFila.Visible = false;

            // Centrar los textos de los encabezados (títulos de las columnas)
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Alinear por defecto todos los datos de las celdas a la izquierda (centrados verticalmente)
            dgvUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Centrar solo el texto "Sí" / "No" de la columna Activo
            dgvUsuarios.Columns["colActivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // Evento que se dispara al cambiar la fila seleccionada
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            PosicionarBotonAccion();
        }

        // Evento para actualizar la posición si el usuario hace scroll
        private void dgvUsuarios_Scroll(object sender, ScrollEventArgs e)
        {
            PosicionarBotonAccion();

            // Esta línea es la magia: fuerza a la grilla a redibujarse 
            // y borra cualquier rastro fantasma que haya dejado el botón
            dgvUsuarios.Invalidate();
        }

        //Evento CellDoubleClick del DataGridView
        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no haya hecho doble clic en el encabezado de la columna (fila -1)
            if (e.RowIndex >= 0)
            {
                AbrirModificarUsuario();
            }
        }

        private void PosicionarBotonAccion()
        {
            // 1. Ocultamos el botón PRIMERO para que no deje rastro al moverse
            btnModificarFila.Visible = false;

            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.Index < 0)
            {
                return; // Queda oculto y salimos
            }

            int rowIndex = dgvUsuarios.CurrentRow.Index;
            int columnIndex = dgvUsuarios.Columns["colAccion"].Index;

            // Obtener las coordenadas en pantalla de la celda de esa fila
            Rectangle cellRectangle = dgvUsuarios.GetCellDisplayRectangle(columnIndex, rowIndex, false);

            // Si la celda es visible dentro del área visible de la grilla
            if (cellRectangle.Width > 0 && cellRectangle.Height > 0)
            {
                btnModificarFila.Size = new Size(cellRectangle.Width - 4, cellRectangle.Height - 4);
                btnModificarFila.Location = new Point(cellRectangle.X + 2, cellRectangle.Y + 2);

                // 2. Lo volvemos a mostrar recién cuando ya está en sus coordenadas nuevas
                btnModificarFila.Visible = true;
            }
        }

        // Evento Click del botón flotante
        private void btnModificarFila_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                AbrirModificarUsuario();
            }
        }

        // Método común para abrir la edición
        private void AbrirModificarUsuario()
        {
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccioná un usuario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtenemos la fila de datos subyacente (DataRowView) del DataTable
            DataRowView filaSeleccionada = (DataRowView)dgvUsuarios.CurrentRow.DataBoundItem;
            int idUsuario = Convert.ToInt32(filaSeleccionada["id_usuario"]);

            using (FormModificarUsuario frm = new FormModificarUsuario(idUsuario))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Recargamos la grilla para reflejar los cambios
                    CargarGrillaUsuarios();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CargarGrillaUsuarios()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Usamos AS para asignarles el alias exacto que pusimos en el DataPropertyName de la grilla.
                    // Concatenamos Apellido/Nombre y la Dirección completa directo desde el motor SQL.
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

                        // Evita que el DataGridView genere columnas automáticas extras
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

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            using (FormAgregarUsuario frm = new FormAgregarUsuario())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Recargar la grilla para que aparezca el nuevo usuario
                    CargarGrillaUsuarios();
                }
            }
        }
    }
}
