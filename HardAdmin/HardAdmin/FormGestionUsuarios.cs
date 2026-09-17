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
        // Traemos la cadena de conexión desde el archivo de configuración (App.config).
        // Así, si cambiamos de servidor, no hace falta recompilar todo el código.
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            // EL TRUCO DEL BOTÓN FLOTANTE: 
            // Agregamos el botón físicamente "adentro" de los controles de la grilla.
            // Esto permite que el botón se mueva junto con el scroll en lugar de quedar flotando afuera.
            dgvUsuarios.Controls.Add(btnModificarFila);

            // Vamos a la base de datos y llenamos la tabla.
            CargarGrillaUsuarios();

            // Apenas arranca, quitamos la selección azul por defecto de la primera fila
            // y ocultamos el botón para que la pantalla se vea limpia.
            dgvUsuarios.ClearSelection();
            btnModificarFila.Visible = false;

            // ---------- DISEÑO VISUAL DE LA GRILLA ----------

            // Bloqueamos que el usuario pueda estirar el alto de las filas y arruinar el diseño.
            dgvUsuarios.AllowUserToResizeRows = false;

            // Centramos los textos de los encabezados (los títulos de las columnas).
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Por defecto, todos los datos de las celdas van alineados a la izquierda y centrados verticalmente.
            dgvUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Excepción: la columna "Activo" (que dice Sí/No) queda mejor si está bien centrada.
            dgvUsuarios.Columns["colActivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // ---------- EVENTOS DE MOVIMIENTO EN LA GRILLA ----------

        // Se dispara cada vez que el usuario hace clic en una fila distinta o se mueve con las flechas del teclado.
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            PosicionarBotonAccion();
        }

        // Se dispara cuando el usuario mueve la barra de desplazamiento (scroll) vertical u horizontal.
        private void dgvUsuarios_Scroll(object sender, ScrollEventArgs e)
        {
            PosicionarBotonAccion();

            // Esta línea es la magia que evita el efecto "fantasma":
            // Fuerza a la grilla a redibujarse al instante y borra cualquier rastro visual que haya dejado el botón al moverse.
            dgvUsuarios.Invalidate();
        }

        // ---------- EVENTOS DE ACCIÓN (MODIFICAR) ----------

        // Permite abrir la edición haciendo doble clic en cualquier parte de la fila,
        // no hace falta que le den sí o sí al botón.
        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que e.RowIndex sea >= 0 para asegurarnos de que no hicieron doble clic 
            // en los títulos de las columnas (eso sería el RowIndex -1 y daría error).
            if (e.RowIndex >= 0)
            {
                AbrirModificarUsuario();
            }
        }

        // Evento Click exclusivo del botón flotante de la columna "Acción".
        private void btnModificarFila_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                AbrirModificarUsuario();
            }
        }

        // ---------- LÓGICA DEL BOTÓN FLOTANTE ----------

        // Este método calcula las coordenadas exactas de la celda "Acción" de la fila seleccionada
        // y mueve el botón ahí, dándole el tamaño justo para que parezca que es parte de la grilla.
        private void PosicionarBotonAccion()
        {
            // 1. Ocultamos el botón PRIMERO para que no deje un rastro visual al cambiar de posición.
            btnModificarFila.Visible = false;

            // Si no hay nada seleccionado (ej: grilla vacía), salimos y el botón queda oculto.
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.Index < 0)
            {
                return;
            }

            // Averiguamos en qué fila estamos parados y qué número de índice tiene nuestra columna de botones.
            int rowIndex = dgvUsuarios.CurrentRow.Index;
            int columnIndex = dgvUsuarios.Columns["colAccion"].Index;

            // Obtenemos el rectángulo (coordenadas X, Y, Ancho y Alto) de esa celda en particular.
            Rectangle cellRectangle = dgvUsuarios.GetCellDisplayRectangle(columnIndex, rowIndex, false);

            // Si la celda está visible en la pantalla (ancho y alto mayores a 0)
            if (cellRectangle.Width > 0 && cellRectangle.Height > 0)
            {
                // Le damos al botón el mismo tamaño que la celda, pero le restamos 4 píxeles 
                // para que quede un pequeño margen y no toque los bordes.
                btnModificarFila.Size = new Size(cellRectangle.Width - 4, cellRectangle.Height - 4);

                // Lo movemos a las coordenadas de la celda, sumando 2 píxeles para centrar ese margen que dejamos.
                btnModificarFila.Location = new Point(cellRectangle.X + 2, cellRectangle.Y + 2);

                // 2. Lo volvemos a mostrar recién cuando ya está posicionado correctamente.
                btnModificarFila.Visible = true;
            }
        }

        // ---------- APERTURA DE FORMULARIOS ----------

        // Centraliza la lógica para abrir la ventana de edición. 
        // Se llama tanto desde el doble clic como desde el botón flotante.
        private void AbrirModificarUsuario()
        {
            // Por las dudas, validamos que haya una fila real seleccionada.
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccioná un usuario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // CRÍTICO: Como la grilla está enlazada a un DataTable (DataSource = dt), 
            // la fila que seleccionamos no es una fila común, es un DataRowView.
            // Lo casteamos para poder leer el dato invisible del ID del usuario.
            DataRowView filaSeleccionada = (DataRowView)dgvUsuarios.CurrentRow.DataBoundItem;
            int idUsuario = Convert.ToInt32(filaSeleccionada["id_usuario"]);

            // Abrimos el formulario pasándole el ID al constructor.
            using (FormModificarUsuario frm = new FormModificarUsuario(idUsuario))
            {
                // Usamos ShowDialog para que la pantalla de atrás quede bloqueada.
                // Si el usuario guardó los cambios y cerró (DialogResult.OK), actualizamos la tabla para reflejarlo.
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
                    // Recargamos la grilla para que aparezca el nuevo usuario inmediatamente.
                    CargarGrillaUsuarios();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra toda la aplicación.
            Application.Exit();
        }

        // ---------- CONEXIÓN A BASE DE DATOS ----------

        private void CargarGrillaUsuarios()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Usamos AS para asignarles a las columnas de SQL el mismo nombre (DataPropertyName) 
                    // que configuramos visualmente en el DataGridView.
                    // Además, concatenamos Apellido/Nombre y la Dirección completa directo acá 
                    // para que el programa no tenga que hacer cálculos extra.
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

                        // Esta propiedad evita que la grilla genere columnas automáticas extras por cada campo de SQL,
                        // asegurando que respete el diseño visual, anchos y el orden que le dimos en el diseñador.
                        dgvUsuarios.AutoGenerateColumns = false;

                        // Enlazamos los datos procesados a la tabla.
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