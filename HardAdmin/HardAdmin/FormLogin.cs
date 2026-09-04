using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HardAdmin
{
    public partial class FormLogin : Form
    {
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
            // 1. Conexión al servidor SQL Server
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HardAdmin;Integrated Security=True";

            // 2. Consulta buscando que coincidan los datos y que el usuario no esté dado de baja
            string query = "SELECT id_usuario, id_rol FROM Usuario WHERE nombre_usuario = @usuario AND contrasena = @contrasena AND baja = 0";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Parámetros para evitar inyección SQL
                    comando.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    comando.Parameters.AddWithValue("@contrasena", txtContrasena.Text.Trim());

                    try
                    {
                        conexion.Open();
                        SqlDataReader reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Se guarda el id del usuario y el rol en variables si es necesario
                            int idRol = Convert.ToInt32(reader["id_rol"]);

                            // Abrir el sistema
                            FormMenuPrincipal formMenu = new FormMenuPrincipal(txtUsuario.Text.Trim());
                            formMenu.Show();

                            // Ocultar el formulario de login
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos, o el usuario está inactivo.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                    }
                }
            }
        }
    }
}
