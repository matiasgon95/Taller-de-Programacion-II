using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin
{
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static int IdRol { get; set; }
        public static string Rol { get; set; } // "Administrador", "Vendedor", "Operador"

        // Propiedades de ayuda para consultar rápido
        public static bool EsAdmin => Rol != null && Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        public static bool EsVendedor => Rol != null && Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase);
        public static bool EsOperador => Rol != null && Rol.Equals("Operador", StringComparison.OrdinalIgnoreCase);
    }
}