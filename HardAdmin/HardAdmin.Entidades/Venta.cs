using System;
using System.Collections.Generic;

namespace HardAdmin.Entidades
{
    // Cabecera de la venta junto con sus líneas de detalle. Solo transporta datos.
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdMetodoPago { get; set; }

        // Se inicializa vacía para poder hacer venta.Detalles.Add(...) sin chequear null.
        public List<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();
    }
}