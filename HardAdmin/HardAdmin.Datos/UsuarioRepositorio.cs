using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using HardAdmin.Entidades;

namespace HardAdmin.Datos
{
    // Toda la conversación con SQL Server para Usuario vive acá y solo acá.
    // No conoce reglas de negocio (edad mínima, formato de DNI, etc.) ni nada de la UI.
    public class UsuarioRepositorio
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        public List<Rol> ObtenerRoles()
        {
            var roles = new List<Rol>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT id_rol, nombre_rol FROM Rol", con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Rol
                        {
                            IdRol = Convert.ToInt32(reader["id_rol"]),
                            NombreRol = reader["nombre_rol"].ToString()
                        });
                    }
                }
            }

            return roles;
        }

        public bool ExisteUsuario(string columna, string valor)
        {
            string query = $"SELECT COUNT(1) FROM Usuario WHERE {columna} = @valor";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@valor", valor);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void Insertar(Usuario usuario, string contrasenaHasheada)
        {
            string query = @"INSERT INTO Usuario
                             (nombre_usuario, email, contrasena, id_rol, baja,
                              nombre, apellido, dni, fecha_nacimiento,
                              calle, altura, dpto, localidad)
                             VALUES
                             (@usuario, @email, @contrasena, @idRol, 0,
                              @nombre, @apellido, @dni, @fechaNacimiento,
                              @calle, @altura, @dpto, @localidad)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@contrasena", contrasenaHasheada);
                cmd.Parameters.AddWithValue("@idRol", usuario.IdRol);

                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@fechaNacimiento", usuario.FechaNacimiento);

                cmd.Parameters.AddWithValue("@calle", usuario.Calle);
                cmd.Parameters.AddWithValue("@altura", usuario.Altura);
                cmd.Parameters.AddWithValue("@dpto", string.IsNullOrWhiteSpace(usuario.Dpto) ? (object)DBNull.Value : usuario.Dpto);
                cmd.Parameters.AddWithValue("@localidad", usuario.Localidad);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}