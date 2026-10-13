using HardAdmin.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin.Negocio
{
    public class MovimientoStockServicio
    {
        private readonly MovimientoStockRepositorio repositorio = new MovimientoStockRepositorio();

        // Obtiene los movimientos de stock aplicando los filtros
        // seleccionados por el usuario.
        public DataTable ObtenerParaGrilla(
            int idCategoria,
            int idProducto,
            DateTime desde,
            DateTime hasta)
        {
            // Verifica que el rango de fechas sea válido.
            if (desde.Date > hasta.Date)
            {
                throw new ArgumentException(
                    "La fecha inicial no puede ser posterior a la fecha final.");
            }

            // Delega la consulta a la capa de Datos.
            return repositorio.ObtenerParaGrilla(
                idCategoria,
                idProducto,
                desde,
                hasta);
        }




    }
}
