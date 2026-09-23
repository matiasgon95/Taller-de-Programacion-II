using System;
using HardAdmin.Entidades;

namespace HardAdmin.Negocio
{
    public static class PermisosSistema
    {
        public static bool TienePermisoModulo(string modulo)
        {
            // El Administrador gestiona el sistema y audita, pero no opera.
            if (SesionActual.EsAdmin)
            {
                return modulo == "Usuarios"
                    || modulo == "Configuracion"
                    || modulo == "Reportes"
                    || modulo == "Ventas";
            }

            // El Operador mantiene el inventario y la base de clientes.
            if (SesionActual.EsOperador)
            {
                return modulo == "Productos"
                    || modulo == "Clientes";
            }

            // El Vendedor solo atiende el mostrador.
            if (SesionActual.EsVendedor)
            {
                return modulo == "Ventas";
            }

            return false;
        }
    }
}