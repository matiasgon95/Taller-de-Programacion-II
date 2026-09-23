using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HardAdmin.Entidades;

namespace HardAdmin.Datos
{
    public class MetodoPagoRepositorio
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Trae los datos formateados especialmente para que el CheckBox de la grilla los entienda
        public DataTable ObtenerParaGrilla()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    id_metodo_pago, 
                                    nombre_metodo, 
                                    CAST(CASE WHEN baja = 0 THEN 1 ELSE 0 END AS BIT) AS activa 
                                 FROM Metodo_pago";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Recibe la lista completa y procesa qué es nuevo y qué es modificación
        public void GuardarCambios(List<MetodoPago> listaMetodos)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Iniciamos la transacción para evitar guardados fantasma
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        foreach (var metodo in listaMetodos)
                        {
                            if (metodo.IdMetodoPago == 0)
                            {
                                string query = "INSERT INTO Metodo_pago (nombre_metodo, baja) VALUES (@nombre, @baja)";
                                using (SqlCommand cmd = new SqlCommand(query, con, tran)) // Pasamos el 'tran'
                                {
                                    cmd.Parameters.AddWithValue("@nombre", metodo.NombreMetodo);
                                    cmd.Parameters.AddWithValue("@baja", metodo.Baja);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string query = "UPDATE Metodo_pago SET nombre_metodo = @nombre, baja = @baja WHERE id_metodo_pago = @id";
                                using (SqlCommand cmd = new SqlCommand(query, con, tran)) // Pasamos el 'tran'
                                {
                                    cmd.Parameters.AddWithValue("@id", metodo.IdMetodoPago);
                                    cmd.Parameters.AddWithValue("@nombre", metodo.NombreMetodo);
                                    cmd.Parameters.AddWithValue("@baja", metodo.Baja);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Si guardó todas las filas sin errores, confirmamos todo junto
                        tran.Commit();
                    }
                    catch
                    {
                        // Si explotó algo, borramos lo que se haya intentado guardar en este intento
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        // Método para verificar si ya existe un nombre de método de pago, excluyendo un ID específico (para evitar conflictos al editar o agregar)
        public bool ExisteNombreMetodo(string nombre, int idExcluir)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Metodo_pago WHERE nombre_metodo = @nombre AND id_metodo_pago != @idExcluir";
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