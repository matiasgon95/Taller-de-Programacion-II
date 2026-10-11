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
        // La operación reemplaza los datos actuales de la base.
        public void RestaurarBackup(string rutaArchivo)
        {
            // Verifica que el archivo seleccionado exista.
            if (string.IsNullOrWhiteSpace(rutaArchivo) ||
                !File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException(
                    "No se encontró el archivo de backup seleccionado.");
            }

            // Comprueba que el archivo tenga la extensión esperada.
            if (!string.Equals(
                Path.GetExtension(rutaArchivo),
                ".bak",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "Debe seleccionar un archivo con extensión .bak.");
            }

            // Obtiene la base de datos configurada en App.config.
            SqlConnectionStringBuilder constructor =
                new SqlConnectionStringBuilder(connectionString);

            string nombreBase = constructor.InitialCatalog;

            if (string.IsNullOrWhiteSpace(nombreBase))
            {
                throw new InvalidOperationException(
                    "No se encontró el nombre de la base de datos.");
            }

            // Escapa el nombre para utilizarlo como identificador SQL.
            string baseSql = "[" + nombreBase.Replace("]", "]]") + "]";

            // La restauración se realiza conectado a master,
            // no a la misma base que queremos restaurar.
            constructor.InitialCatalog = "master";
            string conexionMaster = constructor.ConnectionString;

            using (SqlConnection conexion = new SqlConnection(conexionMaster))
            {
                conexion.Open();

                try
                {
                    // Desconecta las sesiones activas para permitir la restauración.
                    using (SqlCommand comando = new SqlCommand(
                        "ALTER DATABASE " + baseSql +
                        " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;",
                        conexion))
                    {
                        comando.CommandTimeout = 0;
                        comando.ExecuteNonQuery();
                    }

                    // Reemplaza la base actual por el contenido del backup.
                    using (SqlCommand comando = new SqlCommand(
                        "RESTORE DATABASE " + baseSql +
                        " FROM DISK = @ruta WITH REPLACE;",
                        conexion))
                    {
                        comando.Parameters.AddWithValue("@ruta", rutaArchivo);
                        comando.CommandTimeout = 0;
                        comando.ExecuteNonQuery();
                    }
                }
                finally
                {
                    // Intenta dejar la base habilitada para conexiones normales,
                    // incluso si ocurre un error durante la restauración.
                    using (SqlCommand comando = new SqlCommand(
                        "IF DB_ID(@nombreBase) IS NOT NULL " +
                        "BEGIN " +
                        "ALTER DATABASE " + baseSql +
                        " SET MULTI_USER WITH ROLLBACK IMMEDIATE; " +
                        "END;",
                        conexion))
                    {
                        comando.Parameters.AddWithValue("@nombreBase", nombreBase);
                        comando.CommandTimeout = 0;
                        comando.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
