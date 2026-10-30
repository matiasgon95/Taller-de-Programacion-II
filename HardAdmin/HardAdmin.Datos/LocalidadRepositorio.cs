using HardAdmin.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin.Datos
{
    public class LocalidadRepositorio
    {
        // Centralizamos la conexión. Ningún formulario vuelve a ver esto.
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Obtiene las localidades registradas en la base de datos.
        public List<Localidad> ObtenerTodas()
        {
            List<Localidad> localidades = new List<Localidad>();

            string consulta = @"
                SELECT id_localidad, nombre_localidad, codigo_postal
                FROM Localidad
                ORDER BY nombre_localidad;";

            using (SqlConnection conexion =
                   new SqlConnection(connectionString))
            using (SqlCommand comando =
                   new SqlCommand(consulta, conexion))
            {
                conexion.Open();

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Localidad localidad = new Localidad
                        {
                            IdLocalidad = Convert.ToInt32(
                                lector["id_localidad"]),

                            NombreLocalidad = lector["nombre_localidad"]
                                .ToString(),

                            CodigoPostal = Convert.ToInt32(
                                lector["codigo_postal"])
                        };

                        localidades.Add(localidad);
                    }
                }
            }

            return localidades;
        }

    }
}
