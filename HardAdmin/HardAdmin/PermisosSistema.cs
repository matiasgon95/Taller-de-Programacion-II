using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin
{
    internal class PermisosSistema
    {
        //Determina segun el tipo de rol a que funciones tiene acceso el usuario que ingresa al sistema.
        public static bool TienePermisoModulo(string modulo)
        {
            // El Administrador tiene acceso a todos los módulos.
            if (SesionActual.EsAdmin)
                return true;

            // El Operador puede trabajar con productos,
            // clientes y reportes.
            if (SesionActual.EsOperador)
            {
                return modulo == "Productos"
                    || modulo == "Clientes"
                    || modulo == "Reportes";
            }

            // El Vendedor puede trabajar con clientes y ventas.
            if (SesionActual.EsVendedor)
            {
                return modulo == "Clientes"
                    || modulo == "Ventas";
            }

            // Si el rol no coincide con ninguno conocido,
            // se deniega el acceso.
            return false;
        }
    }
}
