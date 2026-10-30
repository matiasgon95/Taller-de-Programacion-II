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
            
            
                string query = @"INSERT INTO Cliente 
                                 (nombre, apellido, dni, email, telefono, calle, numero, piso_depto, id_localidad, baja)
                                 VALUES 
                                 (@nombre, @apellido, @dni, @email, @telefono, @calle, @numero, @piso_depto, @id_localidad, 0)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("@dni", obj.Dni);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@calle", obj.Calle);
                    cmd.Parameters.AddWithValue("@numero", obj.Numero);

                    // Manejo seguro de nulos para la base de datos
                    cmd.Parameters.AddWithValue("@piso_depto", string.IsNullOrWhiteSpace(obj.PisoDpto) ? (object)DBNull.Value : obj.PisoDpto);

                    cmd.Parameters.AddWithValue("@id_localidad", obj.IdLocalidad);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            
        }

        public DataTable ObtenerTodos()
        {
                string query = @"SELECT 
                                 c.id_cliente,
                                    c.apellido + ', ' + c.nombre AS cliente,
                                    c.dni,
                                    c.telefono,
                                    c.email,
                                    CONCAT(
                                        c.calle, ' ', c.numero,
                                        ISNULL(' Dpto ' + c.piso_depto, ''),
                                        ', ', l.nombre_localidad,
                                        ' (CP ', l.codigo_postal, ')'
                                    ) AS direccion,
                                    CASE WHEN c.baja = 0 THEN 'Sí' ELSE 'No' END AS activo
                                FROM Cliente c
                                INNER JOIN Localidad l
                                    ON c.id_localidad = l.id_localidad";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            
        }

        public Cliente ObtenerPorId(int id)
        {
            string query = @"
                SELECT
                    id_cliente, nombre, apellido, dni, email, telefono,
                    calle, numero, piso_depto, id_localidad, baja
                FROM Cliente
                WHERE id_cliente = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new Cliente
                    {
                        IdCliente = Convert.ToInt32(reader["id_cliente"]),
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString(),
                        Dni = reader["dni"].ToString(),
                        Email = reader["email"] != DBNull.Value ? reader["email"].ToString(): "",
                        Telefono = reader["telefono"] != DBNull.Value ? reader["telefono"].ToString(): "",
                        Calle = reader["calle"] != DBNull.Value ? reader["calle"].ToString(): "",
                        Numero = reader["numero"] != DBNull.Value ? reader["numero"].ToString(): "",
                        PisoDpto = reader["piso_depto"] != DBNull.Value ? reader["piso_depto"].ToString(): "",
                        IdLocalidad = Convert.ToInt32(reader["id_localidad"]),
                        Baja = reader["baja"] != DBNull.Value ? (Convert.ToBoolean(reader["baja"]) ? 1 : 0): 0
                    };
                }
            }
        }

        public void Modificar(Cliente obj)
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
                             id_localidad = @id_localidad,
                             baja = @baja
                         WHERE id_cliente = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
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
                    cmd.Parameters.AddWithValue("@id_localidad", obj.IdLocalidad);
                    cmd.Parameters.AddWithValue("@baja", obj.Baja);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            
        }

        public DataTable ObtenerClientePorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_cliente, nombre, apellido, dni FROM Cliente WHERE id_cliente = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable ObtenerClientePorDni(string dni, int? idExcluir = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_cliente, nombre, apellido FROM Cliente WHERE dni = @dni AND baja = 0";
                if (idExcluir.HasValue) query += " AND id_cliente <> @idExcluir";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    if (idExcluir.HasValue) cmd.Parameters.AddWithValue("@idExcluir", idExcluir.Value);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int ObtenerUltimoId()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 id_cliente FROM Cliente ORDER BY id_cliente DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : 0;
                }
            }
        }

        public DataTable ObtenerClientesParaSeleccion(string filtro = null, int? idExcluir = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_cliente, nombre, apellido, dni, telefono FROM Cliente WHERE baja = 0";

                if (idExcluir.HasValue)
                {
                    query += " AND id_cliente <> @idExcluir";
                }

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    query += " AND (nombre LIKE @filtro OR apellido LIKE @filtro OR dni LIKE @filtro)";
                }

                query += " ORDER BY apellido, nombre";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");
                    }

                    if (idExcluir.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir.Value);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable ObtenerParaGrilla(int? idExcluir = null)
        {
                string query = @"SELECT 
                            c.id_cliente,
                            c.apellido + ', ' + c.nombre AS cliente,
                            c.dni,
                            c.telefono,
                            c.email,
                            CONCAT(
                                c.calle, ' ', c.numero,
                                ISNULL(' Dpto ' + c.piso_depto, ''),
                                ', ', l.nombre_localidad,
                                ' (CP ', l.codigo_postal, ')'
                            ) AS direccion,
                            CASE WHEN c.baja = 0 THEN 'Sí' ELSE 'No' END AS activo
                        FROM Cliente c
                        INNER JOIN Localidad l
                            ON c.id_localidad = l.id_localidad";

                if (idExcluir.HasValue)
                {
                    query += " WHERE id_cliente <> @idExcluir";
                }

                using (SqlConnection con = new SqlConnection(connectionString))            
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (idExcluir.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir.Value);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            
        }

    }
}