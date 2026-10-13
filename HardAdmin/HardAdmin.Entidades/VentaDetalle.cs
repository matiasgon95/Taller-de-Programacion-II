namespace HardAdmin.Entidades
{
    // Una línea de la venta (un producto con su cantidad). Solo transporta datos.
    public class VentaDetalle
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}