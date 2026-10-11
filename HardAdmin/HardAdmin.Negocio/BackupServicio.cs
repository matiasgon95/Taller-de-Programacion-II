using HardAdmin.Datos;
using HardAdmin.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin.Negocio
{
    public class BackupServicio
    {
        private readonly BackupRepositorio repositorio;

        // Inicializa el servicio y su repositorio de datos.
        public BackupServicio()
        {
            repositorio = new BackupRepositorio();
        }


        // Coordina la creación de una copia de seguridad.
        public void CrearBackup(string rutaArchivo)
        {
            // Verifica que se haya seleccionado una ruta.
            if (string.IsNullOrWhiteSpace(rutaArchivo))
                throw new ArgumentException(
                    "Debe seleccionar dónde guardar la copia de seguridad.");

            // Comprueba que el archivo tenga la extensión correcta.
            if (!string.Equals(
                Path.GetExtension(rutaArchivo),
                ".bak",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "La copia de seguridad debe tener la extensión .bak.");
            }

            // Verifica que la carpeta de destino exista.
            string carpeta = Path.GetDirectoryName(rutaArchivo);

            if (string.IsNullOrWhiteSpace(carpeta) ||
                !Directory.Exists(carpeta))
            {
                throw new DirectoryNotFoundException(
                    "La carpeta seleccionada no existe.");
            }

            // La capa Datos se encarga de ejecutar el comando SQL.
            repositorio.CrearBackup(rutaArchivo);
        }



        // Coordina la restauración de una copia de seguridad.
        public void RestaurarBackup(string rutaArchivo)
        {
            // Aqui se llamara luego al repositorio para realizar el restore.
        }

    }
}
