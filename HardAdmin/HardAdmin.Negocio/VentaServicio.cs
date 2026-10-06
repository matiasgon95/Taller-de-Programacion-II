using System.Collections.Generic;
using System.Data;
using HardAdmin.Datos;

namespace HardAdmin.Negocio
{
    public class VentaServicio
    {
        private VentaRepositorio repo = new VentaRepositorio();

        public DataTable ObtenerVentasResumen(bool esAdmin, int idUsuario)
        {
            // Regla de negocio: Si es admin no filtramos (null), si es vendedor pasamos su ID
            int? parametroId = esAdmin ? (int?)null : idUsuario;

            return repo.ObtenerVentas(parametroId);
        }

        public List<string> ObtenerVendedoresConVentas()
        {
            return repo.ObtenerVendedoresConVentas();
        }
    }
}