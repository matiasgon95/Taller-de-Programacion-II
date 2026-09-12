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
    public partial class FormGestionClientes : Form
    {
        public FormGestionClientes()
        {
            InitializeComponent();
        }

        // Evento que se dispara al cambiar la fila seleccionada
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            PosicionarBotonAccion();
        }

        // Eventos para actualizar la posición si el usuario hace scroll
        private void dgvClientes_Scroll(object sender, ScrollEventArgs e)
        {
            PosicionarBotonAccion();
        }

        private void PosicionarBotonAccion()
        {
            if (dgvClientes.CurrentRow == null || dgvClientes.CurrentRow.Index < 0)
            {
                btnModificarFila.Visible = false;
                return;
            }

            int rowIndex = dgvClientes.CurrentRow.Index;
            int columnIndex = dgvClientes.Columns["colAccion"].Index; // Nombre de la columna reservada

            // Obtener las coordenadas en pantalla de la celda de esa fila
            Rectangle cellRectangle = dgvClientes.GetCellDisplayRectangle(columnIndex, rowIndex, false);

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

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FormAgregarCliente AgregarCliente = new FormAgregarCliente();
            AgregarCliente.Show();
        }
    }


    }
