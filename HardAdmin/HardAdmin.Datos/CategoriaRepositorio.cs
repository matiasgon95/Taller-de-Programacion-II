using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HardAdmin.Entidades;

namespace HardAdmin.Datos
{
    public class CategoriaRepositorio
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        public DataTable ObtenerParaGrilla()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    id_categoria, 
                                    nombre_categoria, 
                                    CAST(CASE WHEN baja = 0 THEN 1 ELSE 0 END AS BIT) AS activa 
                                 FROM Categoria";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void GuardarCambios(List<Categoria> listaCategorias)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Usamos una transacción: si algo explota a la mitad, no se guarda nada roto.
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        foreach (var cat in listaCategorias)
                        {
                            // Si el ID es 0, es una fila nueva que agregó el usuario
                            if (cat.IdCategoria == 0)
                            {
                                string query = "INSERT INTO Categoria (nombre_categoria, baja) VALUES (@nombre, @baja)";
                                using (SqlCommand cmd = new SqlCommand(query, con, tran))
                                {
                                    cmd.Parameters.AddWithValue("@nombre", cat.NombreCategoria);
                                    cmd.Parameters.AddWithValue("@baja", cat.Baja);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else // Si ya tiene ID, la actualizamos
                            {
                                string query = "UPDATE Categoria SET nombre_categoria = @nombre, baja = @baja WHERE id_categoria = @id";
                                using (SqlCommand cmd = new SqlCommand(query, con, tran))
                                {
                                    cmd.Parameters.AddWithValue("@id", cat.IdCategoria);
                                    cmd.Parameters.AddWithValue("@nombre", cat.NombreCategoria);
                                    cmd.Parameters.AddWithValue("@baja", cat.Baja);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Si todo el bucle salió bien, confirmamos los cambios
                        tran.Commit();
                    }
                    catch
                    {
                        // Si hubo error, deshacemos todo lo de este bloque
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        // Revisa si hay algún producto que use esta categoría y que no esté dado de baja
        public bool TieneProductosActivos(int idCategoria)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Producto WHERE id_categoria = @idCategoria AND baja = 0";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    con.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // Revisa si el nombre ya existe, ignorando el ID de la fila que estamos editando
        public bool ExisteNombreCategoria(string nombre, int idExcluir)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Categoria WHERE nombre_categoria = @nombre AND id_categoria != @idExcluir";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                    con.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}