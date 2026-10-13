using System;
using System.Data;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HardAdmin.Negocio
{
    // Arma el comprobante de una venta en PDF. Los datos los trae de VentaServicio;
    // dónde se guarda el archivo y cómo se abre lo decide la pantalla que lo pida.
    public class ComprobanteServicio
    {
        private VentaServicio ventaServicio = new VentaServicio();

        // Los importes se muestran siempre con formato argentino, igual que en las pantallas.
        private static readonly CultureInfo CulturaMoneda = CultureInfo.GetCultureInfo("es-AR");

        public void GenerarPdf(int idVenta, string rutaArchivo)
        {
            DataTable cabecera = ventaServicio.ObtenerCabeceraVenta(idVenta);
            if (cabecera.Rows.Count == 0)
            {
                throw new InvalidOperationException("No se encontró la venta solicitada.");
            }

            DataRow datos = cabecera.Rows[0];
            DataTable detalle = ventaServicio.ObtenerDetalleVenta(idVenta);

            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Font fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            Font fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            Font fuenteAviso = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.GRAY);

            string direccion = ArmarDireccion(
                TextoONulo(datos["calle"]),
                TextoONulo(datos["numero"]),
                TextoONulo(datos["piso_depto"]),
                TextoONulo(datos["ciudad"]));

            // El FileStream va en un using para que el archivo quede liberado aunque algo falle;
            // si no, el visor de PDF no podría abrirlo después.
            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Create))
            {
                Document documento = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter.GetInstance(documento, archivo);
                documento.Open();

                documento.Add(new Paragraph("HardAdmin", fuenteTitulo) { Alignment = Element.ALIGN_CENTER });
                documento.Add(new Paragraph("COMPROBANTE DE VENTA", fuenteSubtitulo) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 4f });
                documento.Add(new Paragraph("Comprobante de demostración - sin validez fiscal", fuenteAviso) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 15f });

                // Datos de la venta en dos columnas, sin bordes, para que quede como la pantalla de detalle.
                PdfPTable tablaDatos = new PdfPTable(2) { WidthPercentage = 100, SpacingAfter = 15f };
                tablaDatos.AddCell(CeldaInfo("Comprobante: ", datos["nro_factura"].ToString(), fuenteNegrita, fuenteNormal));
                tablaDatos.AddCell(CeldaInfo("Fecha: ", Convert.ToDateTime(datos["fecha"]).ToString("dd/MM/yyyy HH:mm"), fuenteNegrita, fuenteNormal));
                tablaDatos.AddCell(CeldaInfo("Cliente: ", datos["cliente_nombre"] + " " + datos["cliente_apellido"], fuenteNegrita, fuenteNormal));
                tablaDatos.AddCell(CeldaInfo("DNI: ", datos["dni"].ToString(), fuenteNegrita, fuenteNormal));
                tablaDatos.AddCell(CeldaInfo("Dirección: ", direccion, fuenteNegrita, fuenteNormal));
                tablaDatos.AddCell(CeldaInfo("Estado: ", datos["estado"].ToString(), fuenteNegrita, fuenteNormal));
                tablaDatos.AddCell(CeldaInfo("Vendedor: ", datos["vendedor"].ToString(), fuenteNegrita, fuenteNormal));
                tablaDatos.AddCell(CeldaInfo("Método de pago: ", datos["medio_pago"].ToString(), fuenteNegrita, fuenteNormal));
                documento.Add(tablaDatos);

                // Tabla de productos. iTextSharp la corta solo en otra página si hay muchas líneas.
                PdfPTable tablaProductos = new PdfPTable(5) { WidthPercentage = 100, SpacingAfter = 10f };
                tablaProductos.SetWidths(new float[] { 15f, 40f, 10f, 17f, 18f });
                tablaProductos.AddCell(CeldaEncabezado("Código", fuenteNegrita));
                tablaProductos.AddCell(CeldaEncabezado("Descripción", fuenteNegrita));
                tablaProductos.AddCell(CeldaEncabezado("Cant.", fuenteNegrita));
                tablaProductos.AddCell(CeldaEncabezado("Precio Unit.", fuenteNegrita));
                tablaProductos.AddCell(CeldaEncabezado("Subtotal", fuenteNegrita));

                // El total se suma de las mismas líneas que se imprimen, así el PDF siempre cierra.
                decimal total = 0m;
                foreach (DataRow fila in detalle.Rows)
                {
                    decimal subtotal = Convert.ToDecimal(fila["subtotal"]);
                    total += subtotal;

                    tablaProductos.AddCell(CeldaDato(fila["codigo"].ToString(), fuenteNormal, Element.ALIGN_LEFT));
                    tablaProductos.AddCell(CeldaDato(fila["nombre_producto"].ToString(), fuenteNormal, Element.ALIGN_LEFT));
                    tablaProductos.AddCell(CeldaDato(fila["cantidad"].ToString(), fuenteNormal, Element.ALIGN_CENTER));
                    tablaProductos.AddCell(CeldaDato(Convert.ToDecimal(fila["precio_unitario"]).ToString("C2", CulturaMoneda), fuenteNormal, Element.ALIGN_RIGHT));
                    tablaProductos.AddCell(CeldaDato(subtotal.ToString("C2", CulturaMoneda), fuenteNormal, Element.ALIGN_RIGHT));
                }
                documento.Add(tablaProductos);

                documento.Add(new Paragraph("TOTAL: " + total.ToString("C2", CulturaMoneda), fuenteSubtitulo) { Alignment = Element.ALIGN_RIGHT });

                documento.Close();
            }
        }

        // Mismo criterio que usamos en las pantallas: calle y número, depto si lo hay y ciudad al final.
        private string ArmarDireccion(string calle, string numero, string pisoDepto, string ciudad)
        {
            string direccion = (calle + " " + numero).Trim();

            if (!string.IsNullOrWhiteSpace(pisoDepto))
            {
                direccion += " Dpto " + pisoDepto;
            }

            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                direccion = direccion.Length > 0 ? direccion + ", " + ciudad : ciudad;
            }

            return direccion;
        }

        // Los datos de dirección del cliente son opcionales en la base, así que pueden venir NULL.
        private string TextoONulo(object valor)
        {
            return valor == DBNull.Value ? string.Empty : valor.ToString();
        }

        private PdfPCell CeldaInfo(string etiqueta, string valor, Font fuenteEtiqueta, Font fuenteValor)
        {
            Phrase texto = new Phrase();
            texto.Add(new Chunk(etiqueta, fuenteEtiqueta));
            texto.Add(new Chunk(valor, fuenteValor));

            return new PdfPCell(texto) { Border = Rectangle.NO_BORDER, PaddingBottom = 6f };
        }

        private PdfPCell CeldaEncabezado(string texto, Font fuente)
        {
            return new PdfPCell(new Phrase(texto, fuente))
            {
                BackgroundColor = BaseColor.LIGHT_GRAY,
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5f
            };
        }

        private PdfPCell CeldaDato(string texto, Font fuente, int alineacion)
        {
            return new PdfPCell(new Phrase(texto, fuente))
            {
                HorizontalAlignment = alineacion,
                Padding = 4f
            };
        }
    }
}