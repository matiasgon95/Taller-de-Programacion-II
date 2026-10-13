using System;
using System.Diagnostics;
using System.Windows.Forms;
using HardAdmin.Negocio;

namespace HardAdmin
{
    // Lo usan FormNuevaVenta y FormDetalleVenta, así el flujo de "elegir dónde guardar,
    // generar y abrir el PDF" está escrito una sola vez.
    public static class ImpresionComprobante
    {
        private static ComprobanteServicio servicio = new ComprobanteServicio();

        public static void Imprimir(IWin32Window ventana, int idVenta)
        {
            string nroComprobante = "F-" + idVenta.ToString().PadLeft(8, '0');

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Guardar comprobante";
                dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
                dialogo.FileName = "Comprobante_" + nroComprobante + ".pdf";

                // Si cierra el cuadro sin elegir ubicación, no hay nada que generar.
                if (dialogo.ShowDialog(ventana) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    servicio.GenerarPdf(idVenta, dialogo.FileName);

                    // Lo abrimos con el visor de PDF del sistema; desde ahí se puede imprimir de verdad.
                    Process.Start(new ProcessStartInfo(dialogo.FileName) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    // Suele pasar si el mismo PDF ya está abierto en otro programa y no se puede sobrescribir.
                    MessageBox.Show("No se pudo generar el comprobante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}