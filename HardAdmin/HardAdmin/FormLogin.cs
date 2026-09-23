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
using System.Configuration;
using HardAdmin.Entidades;

namespace HardAdmin
{
    public partial class FormLogin : Form
    {
        // Conexión al servidor SQL Server
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;
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
            // Hash de la contraseña ingresada
            string contrasenaIngresadaHash = HardAdmin.Negocio.Seguridad.HashearContrasena(txtContrasena.Text);

            // Consulta con JOIN a Rol para traer el nombre del rol además de los IDs
            string query = @"SELECT u.id_usuario, u.id_rol, r.nombre_rol 
                     FROM Usuario u 
                     INNER JOIN Rol r ON u.id_rol = r.id_rol 
                     WHERE u.nombre_usuario = @usuario 
                       AND u.contrasena = @contrasena 
                       AND u.baja = 0";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    comando.Parameters.AddWithValue("@contrasena", contrasenaIngresadaHash);

                    try
                    {
                        conexion.Open();
                        SqlDataReader reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Guardamos la información en la clase estática
                            SesionActual.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
                            SesionActual.NombreUsuario = txtUsuario.Text.Trim();
                            SesionActual.IdRol = Convert.ToInt32(reader["id_rol"]);
                            SesionActual.Rol = reader["nombre_rol"].ToString();

                            // Abrir el sistema
                            FormMenuPrincipal formMenu = new FormMenuPrincipal(txtUsuario.Text.Trim());
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
                        MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                    }
                }
            }
        }
    }
}
