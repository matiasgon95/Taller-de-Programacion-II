using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin.Entidades
{

    // Representa un producto registrado en el sistema.
    public class Producto
    {
        public int IdProducto { get; set; }

        public string Codigo { get; set; }

        public string NombreProducto { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int StockMinimo { get; set; }

        public string FotoProducto { get; set; }

        public int Baja { get; set; }

        public int IdCategoria { get; set; }
    }
}
