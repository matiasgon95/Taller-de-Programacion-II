using HardAdmin.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormGestionBackups : Form
    {
        // Servicio encargado de gestionar las copias de seguridad.
        private readonly BackupServicio servicio = new BackupServicio();

        public FormGestionBackups()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        // Permite elegir la ubicación y crear una copia de seguridad
        // de la base de datos HardAdmin.
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Prepara una carpeta sugerida dentro de Documentos.
                string carpetaBackups = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments),
                    "BackupsHardAdmin");

                // Si la carpeta todavía no existe, la crea.
                Directory.CreateDirectory(carpetaBackups);

                // Configura el selector para guardar el archivo .bak.
                using (SaveFileDialog dialogo = new SaveFileDialog())
                {
                    dialogo.Title = "Crear copia de seguridad";
                    dialogo.Filter = "Archivo de backup (*.bak)|*.bak";
                    dialogo.DefaultExt = "bak";
                    dialogo.AddExtension = true;
                    dialogo.InitialDirectory = carpetaBackups;
                    dialogo.FileName =
                        "HardAdmin_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
                    dialogo.OverwritePrompt = true;

                    // Si el usuario cancela, no se realiza ninguna operación.
                    if (dialogo.ShowDialog() != DialogResult.OK)
                        return;

                    // Solicita al servicio que cree la copia de seguridad.
                    servicio.CrearBackup(dialogo.FileName);
                }

                MessageBox.Show(
                    "La copia de seguridad se creó correctamente.",
                    "Backup completado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo crear la copia de seguridad.\n\n" + ex.Message,
                    "Error al crear el backup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Permite seleccionar un backup y restaurar la base de datos.
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            // Advierte al usuario antes de seleccionar el archivo.
            DialogResult confirmacion = MessageBox.Show(
                "La restauración reemplazará los datos actuales de HardAdmin " +
                "por los que contiene la copia de seguridad.\n\n" +
                "Se recomienda crear un backup de los datos actuales antes de continuar.\n\n" +
                "¿Desea seleccionar una copia para restaurar?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
                return;

            // Permite buscar un archivo de backup existente.
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar copia de seguridad";
                dialogo.Filter = "Archivos de backup (*.bak)|*.bak";
                dialogo.Multiselect = false;
                dialogo.CheckFileExists = true;

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                // Segunda confirmación para evitar restauraciones accidentales.
                DialogResult confirmacionFinal = MessageBox.Show(
                    "Se restaurará el siguiente archivo:\n\n" +
                    dialogo.FileName +
                    "\n\nLos datos actuales de la base pueden perderse. " +
                    "¿Está seguro de que desea continuar?",
                    "Confirmar restauración definitiva",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacionFinal != DialogResult.Yes)
                    return;

                try
                {
                    // Ejecuta la restauración a través de la capa de Negocio.
                    servicio.RestaurarBackup(dialogo.FileName);

                    MessageBox.Show(
                        "La restauración finalizó correctamente.\n\n" +
                        "Se recomienda cerrar y volver a abrir los módulos " +
                        "para cargar los datos restaurados.",
                        "Restauración completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo restaurar la copia de seguridad.\n\n" +
                        ex.Message +
                        "\n\nLa base de datos podría requerir una revisión " +
                        "si el error ocurrió durante la restauración.",
                        "Error al restaurar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }





    }
}
