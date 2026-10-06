using System.Collections.Generic;
using System.Data;
using HardAdmin.Datos;

namespace HardAdmin.Negocio
{
    public class VentaServicio
    {
        private VentaRepositorio repositorio = new VentaRepositorio();

        public DataTable ObtenerVentasResumen(bool esAdmin, int idUsuario)
        {
            // Regla de negocio: Si es admin no filtramos (null), si es vendedor pasamos su ID
            int? parametroId = esAdmin ? (int?)null : idUsuario;

            return repositorio.ObtenerVentas(parametroId);
        }

        public List<string> ObtenerVendedoresConVentas()
        {
            return repositorio.ObtenerVendedoresConVentas();
        }

        public int ObtenerProximoId() => repositorio.ObtenerProximoId();
        public DataTable ObtenerMetodosPagoActivos() => repositorio.ObtenerMetodosPagoActivos();

        public DataTable ObtenerCabeceraVenta(int idVenta) => repositorio.ObtenerCabeceraVenta(idVenta);
        public DataTable ObtenerDetalleVenta(int idVenta) => repositorio.ObtenerDetalleVenta(idVenta);
    }


}