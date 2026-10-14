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

        // Guardamos la tabla cargada para poder filtrarla desde el buscador sin volver a consultar la base.
        private DataTable dtUsuarios;

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

        // ---------- BUSCADOR ----------

        // Cada letra que se escribe vuelve a filtrar la grilla.
        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            FiltrarUsuarios();
        }

        // Muestra solo los usuarios que coinciden con el texto en alguna de las columnas que
        // el usuario espera poder buscar. Filtramos la vista de la tabla en memoria, así que
        // no hace falta ir a la base de datos en cada tecla.
        private void FiltrarUsuarios()
        {
            // Si todavía no se cargó la tabla, no hay nada que filtrar.
            if (dtUsuarios == null)
                return;

            string texto = txtBuscarUsuario.Text.Trim();

            // Con el buscador vacío mostramos todos los usuarios.
            if (string.IsNullOrWhiteSpace(texto))
            {
                dtUsuarios.DefaultView.RowFilter = string.Empty;
                return;
            }

            // Normalizamos lo escrito igual que la columna "busqueda", así "perez" encuentra "Pérez".
            string textoFiltro = Busqueda.EscaparParaFiltro(Busqueda.QuitarAcentos(texto));

            dtUsuarios.DefaultView.RowFilter = $"busqueda LIKE '%{textoFiltro}%'";
        }

        // Agrega a la tabla una columna que no se muestra en la grilla, con DNI, nombre, usuario y
        // email juntos, en minúsculas y sin acentos. El DataView no sabe ignorar acentos al
        // filtrar, por eso dejamos el texto ya normalizado y comparamos contra esa columna.
        private void PrepararColumnaBusqueda()
        {
            if (!dtUsuarios.Columns.Contains("busqueda"))
            {
                dtUsuarios.Columns.Add("busqueda", typeof(string));
            }

            foreach (DataRow fila in dtUsuarios.Rows)
            {
                fila["busqueda"] = Busqueda.QuitarAcentos(
                    $"{fila["dni"]} {fila["nombre_completo"]} {fila["nombre_usuario"]} {fila["email"]}");
            }
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
                dtUsuarios = servicio.ObtenerParaGrilla();
                PrepararColumnaBusqueda();

                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.DataSource = dtUsuarios;

                // Si había algo escrito en el buscador (por ejemplo al volver de modificar un
                // usuario), volvemos a aplicar el filtro sobre los datos recién cargados.
                FiltrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}