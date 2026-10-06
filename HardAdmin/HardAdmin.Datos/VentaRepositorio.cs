using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HardAdmin.Datos
{
    public class VentaRepositorio
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Trae la tabla con las ventas. Si le pasamos un ID, filtra; si le pasamos null, trae todas.
        public DataTable ObtenerVentas(int? idUsuarioLogueado)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                     v.id_venta,
                                     'F-' + RIGHT('00000000' + CAST(v.id_venta AS VARCHAR(8)), 8) AS nro_factura,
                                     v.fecha,
                                     (c.apellido + ', ' + c.nombre) AS cliente,
                                     u.nombre_usuario AS vendedor,
                                     mp.nombre_metodo AS medio_pago,
                                     v.estado,
                                     v.total
                                 FROM Venta v
                                 INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                                 INNER JOIN Usuario u ON v.id_usuario = u.id_usuario
                                 INNER JOIN Metodo_pago mp ON v.id_metodo_pago = mp.id_metodo_pago";

                if (idUsuarioLogueado.HasValue)
                {
                    query += " WHERE v.id_usuario = @idUsuario";
                }

                query += " ORDER BY v.fecha DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (idUsuarioLogueado.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuarioLogueado.Value);
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

        // Trae solo los nombres de los vendedores que tienen ventas registradas
        public List<string> ObtenerVendedoresConVentas()
        {
            List<string> vendedores = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT u.nombre_usuario FROM Venta v INNER JOIN Usuario u ON v.id_usuario = u.id_usuario ORDER BY u.nombre_usuario";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendedores.Add(reader["nombre_usuario"].ToString());
                        }
                    }
                }
            }
            return vendedores;
        }

        public int ObtenerProximoId()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(id_venta), 0) + 1 FROM Venta";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public DataTable ObtenerMetodosPagoActivos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_metodo_pago, nombre_metodo FROM Metodo_pago WHERE baja = 0";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

    }
}