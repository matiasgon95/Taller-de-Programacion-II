using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormGestionUsuarios : Form
    {
        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.Controls.Add(btnModificarFila);

            // Limpiar filas por si acaso
            dgvUsuarios.Rows.Clear();

            // dgvUsuarios.Rows.Add(colUsuario, colEmail, colRol, colActivo, colAccion);
            dgvUsuarios.Rows.Add("admin", "admin@hardadmin.com", "Administrador", "Sí", "");
            dgvUsuarios.Rows.Add("operador_stock", "operador@hardadmin.com", "Operador", "Sí", "");
            dgvUsuarios.Rows.Add("vendedor_centro", "vendedor1@hardadmin.com", "Vendedor", "No", "");
            dgvUsuarios.Rows.Add("matias_g", "matias@hardadmin.com", "Administrador", "Sí", "");

            // Deseleccionar cualquier fila por defecto
            dgvUsuarios.ClearSelection();
            btnModificarFila.Visible = false;
        }

        // Evento que se dispara al cambiar la fila seleccionada
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            PosicionarBotonAccion();
        }

        // Eventos para actualizar la posición si el usuario hace scroll
        private void dgvUsuarios_Scroll(object sender, ScrollEventArgs e)
        {
            PosicionarBotonAccion();
        }

        private void PosicionarBotonAccion()
        {
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.Index < 0)
            {
                btnModificarFila.Visible = false;
                return;
            }

            int rowIndex = dgvUsuarios.CurrentRow.Index;
            int columnIndex = dgvUsuarios.Columns["colAccion"].Index; // Nombre de la columna reservada

            // Obtener las coordenadas en pantalla de la celda de esa fila
            Rectangle cellRectangle = dgvUsuarios.GetCellDisplayRectangle(columnIndex, rowIndex, false);

            // Si la celda es visible dentro del área visible de la grilla
            if (cellRectangle.Width > 0 && cellRectangle.Height > 0)
            {
                btnModificarFila.Size = new Size(cellRectangle.Width - 4, cellRectangle.Height - 4);
                btnModificarFila.Location = new Point(cellRectangle.X + 2, cellRectangle.Y + 2);
                btnModificarFila.Visible = true;
            }
            else
            {
                btnModificarFila.Visible = false;
            }
        }

        // Evento Click del botón flotante
        private void btnModificarFila_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                string usuario = dgvUsuarios.CurrentRow.Cells["colUsuario"].Value.ToString();

                MessageBox.Show($"Modificando usuario: {usuario}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
