using System;

namespace HardAdmin.Entidades
{
    // Representa una fila de la tabla Usuario. Sin lógica, solo datos.
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
        public bool Baja { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Dpto { get; set; }
        public string Localidad { get; set; }
    }
}