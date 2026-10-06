using System;
using System.Data;
using System.Windows.Forms;
using HardAdmin.Entidades;
using HardAdmin.Negocio;

namespace HardAdmin
{
    public partial class FormLogin : Form
    {
        private UsuarioServicio servicio = new UsuarioServicio();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string contrasena = txtContrasena.Text;

                // Llamamos a la capa de Negocio para que haga todo el trabajo duro
                DataTable dtResultado = servicio.AutenticarLogin(usuario, contrasena);

                if (dtResultado.Rows.Count > 0)
                {
                    DataRow fila = dtResultado.Rows[0];

                    // Guardamos la información en la clase estática
                    SesionActual.IdUsuario = Convert.ToInt32(fila["id_usuario"]);
                    SesionActual.NombreUsuario = usuario;
                    SesionActual.IdRol = Convert.ToInt32(fila["id_rol"]);
                    SesionActual.Rol = fila["nombre_rol"].ToString();

                    // Abrir el sistema
                    FormMenuPrincipal formMenu = new FormMenuPrincipal(usuario);
                    formMenu.Show();

                    // Ocultar el formulario de login
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas o el usuario está inactivo.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}