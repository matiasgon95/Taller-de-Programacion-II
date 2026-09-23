namespace HardAdmin.Entidades
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }

        // 0 = Activa, 1 = Inactiva
        public int Baja { get; set; }
    }
}