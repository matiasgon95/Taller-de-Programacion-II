using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HardAdmin.Entidades;

namespace HardAdmin.Datos
{
    public class ClienteRepositorio
    {
        // Centralizamos la conexión. Ningún formulario vuelve a ver esto.
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Se usa para verificar si un DNI ya existe. El parámetro idExcluir nos salva al modificar
        // para que el cliente no choque contra su propio DNI.
        public bool ExisteDni(string dni, int? idExcluir = null)
        {
            string query = "SELECT COUNT(1) FROM Cliente WHERE dni = @dni";
            if (idExcluir.HasValue) query += " AND id_cliente != @idExcluir";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                if (idExcluir.HasValue) cmd.Parameters.AddWithValue("@idExcluir", idExcluir.Value);

                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool ExisteEmail(string email, int? idExcluir = null)
        {
            string query = "SELECT COUNT(1) FROM Cliente WHERE email = @email";
            if (idExcluir.HasValue) query += " AND id_cliente != @idExcluir";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@email", email);
                if (idExcluir.HasValue) cmd.Parameters.AddWithValue("@idExcluir", idExcluir.Value);

                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void Insertar(Cliente obj)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Cliente 
                                 (nombre, apellido, dni, email, telefono, calle, numero, piso_depto, ciudad, codigo_postal, baja)
                                 VALUES 
                                 (@nombre, @apellido, @dni, @email, @telefono, @calle, @numero, @piso_depto, @ciudad, @codigo_postal, 0)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("@dni", obj.Dni);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@calle", obj.Calle);
                    cmd.Parameters.AddWithValue("@numero", obj.Numero);
                    cmd.Parameters.AddWithValue("@ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@codigo_postal", obj.CodigoPostal);

                    // Manejo seguro de nulos para la base de datos
                    cmd.Parameters.AddWithValue("@piso_depto", string.IsNullOrWhiteSpace(obj.PisoDpto) ? (object)DBNull.Value : obj.PisoDpto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerTodos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    id_cliente, 
                                    apellido + ', ' + nombre AS cliente,
                                    dni, 
                                    telefono,
                                    email, 
                                    calle + ' ' + numero + ISNULL(' Dpto ' + piso_depto, '') + ', ' + ciudad AS direccion,
                                    CASE WHEN baja = 0 THEN 'Sí' ELSE 'No' END AS activo
                                 FROM Cliente";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public Cliente ObtenerPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cliente WHERE id_cliente = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),
                                Dni = reader["dni"].ToString(),
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "",
                                Telefono = reader["telefono"] != DBNull.Value ? reader["telefono"].ToString() : "",
                                Calle = reader["calle"] != DBNull.Value ? reader["calle"].ToString() : "",
                                Numero = reader["numero"] != DBNull.Value ? reader["numero"].ToString() : "",
                                PisoDpto = reader["piso_depto"] != DBNull.Value ? reader["piso_depto"].ToString() : "",
                                Ciudad = reader["ciudad"] != DBNull.Value ? reader["ciudad"].ToString() : "",
                                CodigoPostal = reader["codigo_postal"] != DBNull.Value ? reader["codigo_postal"].ToString() : "",
                                Baja = reader["baja"] != DBNull.Value ? (Convert.ToBoolean(reader["baja"]) ? 1 : 0) : 0
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void Modificar(Cliente obj)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Cliente 
                         SET nombre = @nombre, 
                             apellido = @apellido, 
                             dni = @dni, 
                             email = @email, 
                             telefono = @telefono, 
                             calle = @calle, 
                             numero = @numero, 
                             piso_depto = @piso_depto, 
                             ciudad = @ciudad, 
                             codigo_postal = @codigo_postal, 
                             baja = @baja
                         WHERE id_cliente = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("@dni", obj.Dni);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@calle", obj.Calle);
                    cmd.Parameters.AddWithValue("@numero", obj.Numero);
                    cmd.Parameters.AddWithValue("@piso_depto", string.IsNullOrWhiteSpace(obj.PisoDpto) ? (object)DBNull.Value : obj.PisoDpto);
                    cmd.Parameters.AddWithValue("@ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@codigo_postal", obj.CodigoPostal);
                    cmd.Parameters.AddWithValue("@baja", obj.Baja);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}