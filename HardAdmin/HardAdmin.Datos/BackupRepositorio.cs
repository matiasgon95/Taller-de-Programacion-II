using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin.Datos
{
    public class BackupRepositorio
    {
        private readonly string connectionString;

        // Obtiene la cadena de conexión configurada en App.config.
        public BackupRepositorio()
        {
            connectionString =
                ConfigurationManager
                .ConnectionStrings["HardAdminConnection"]
                .ConnectionString;
        }

        // Crea una copia de seguridad de la base de datos en la ruta indicada.
        public void CrearBackup(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
                throw new ArgumentException(
                    "Debe indicar la ruta del archivo de backup.");

            if (!string.Equals(
                Path.GetExtension(rutaArchivo),
                ".bak",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El archivo de backup debe tener la extensión .bak.");
            }

            string carpeta = Path.GetDirectoryName(rutaArchivo);

            if (string.IsNullOrWhiteSpace(carpeta) ||
                !Directory.Exists(carpeta))
            {
                throw new DirectoryNotFoundException(
                    "La carpeta seleccionada no existe.");
            }

            // Se obtiene el nombre de la base de datos desde la conexión.
            SqlConnectionStringBuilder constructor =
                new SqlConnectionStringBuilder(connectionString);

            string nombreBase = constructor.InitialCatalog;

            if (string.IsNullOrWhiteSpace(nombreBase))
                throw new InvalidOperationException(
                    "No se encontró el nombre de la base de datos.");

            // BACKUP DATABASE se ejecuta en SQL Server, no en el formulario.
            string consulta =
                "BACKUP DATABASE " +
                "[" + nombreBase.Replace("]", "]]") + "] " +
                "TO DISK = @ruta WITH INIT";

            using (SqlConnection conexion =
                   new SqlConnection(connectionString))
            using (SqlCommand comando =
                   new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@ruta", rutaArchivo);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }



        // Restaura la base de datos desde un archivo de respaldo.
        public void RestaurarBackup(string rutaArchivo)
        {
            // Aqui se realizara las instrucciones del restore.
        }

    }
}
