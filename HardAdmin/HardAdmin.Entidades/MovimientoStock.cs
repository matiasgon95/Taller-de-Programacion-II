using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin.Entidades
{
    public class MovimientoStock
    {
        public int IdMovimiento { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public int IdProducto { get; set; }

        public int IdUsuario { get; set; }

        public int IdTipoMovimiento { get; set; }
    }
}
