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





    }
}
