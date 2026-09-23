namespace HardAdmin.Entidades
{
    public class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        public string NombreMetodo { get; set; }

        // 0 = Activo, 1 = Inactivo
        public int Baja { get; set; }
    }
}