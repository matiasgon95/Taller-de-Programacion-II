using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardAdmin.Datos;
using HardAdmin.Entidades;

namespace HardAdmin.Negocio
{
    public class ProductoServicio
    {
        private ProductoRepositorio repositorio = new ProductoRepositorio();

        // Obtiene los productos para mostrarlos en la grilla.
        public DataTable ObtenerParaGrilla()
        {
            return repositorio.ObtenerParaGrilla();
        }


        // Obtiene un producto por su identificador.
        public Producto ObtenerPorId(int idProducto)
        {
            return repositorio.ObtenerPorId(idProducto);
        }

        // Comprueba que los datos básicos del producto sean válidos.
        private void ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Codigo))
                throw new Exception("El código del producto es obligatorio.");

            if (string.IsNullOrWhiteSpace(producto.NombreProducto))
                throw new Exception("El nombre del producto es obligatorio.");

            if (string.IsNullOrWhiteSpace(producto.Descripcion))
                throw new Exception("La descripción del producto es obligatoria.");

            if (producto.Precio <= 0)
                throw new Exception("El precio debe ser mayor a 0.");

            if (producto.Stock < 0)
                throw new Exception("El stock no puede ser negativo.");

            if (producto.StockMinimo < 0)
                throw new Exception("El stock mínimo no puede ser negativo.");

            if (producto.IdCategoria <= 0)
                throw new Exception("Debe seleccionar una categoría.");
        }


        // Modifica un producto luego de validar sus datos.
        public void Modificar(Producto producto)
        {
            ValidarProducto(producto);

            if (repositorio.ExisteProducto(producto.Codigo, producto.NombreProducto, producto.IdProducto))
            {
                throw new Exception("Ya existe otro producto con el mismo código o nombre.");
            }

            repositorio.Modificar(producto);
        }

        public bool ExisteCodigo(string codigo, int idExcluir)
        {
            return repositorio.ExisteCodigo(codigo, idExcluir);
        }

        // Valida y guarda un nuevo producto.
        public void Guardar(Producto producto)
        {
            ValidarProducto(producto);

            if (repositorio.ExisteCodigo(producto.Codigo, 0))
            {
                throw new Exception(
                    "El código del producto ya se encuentra registrado."
                );
            }

            repositorio.Guardar(producto);
        }

        public DataTable ObtenerProductoPorCodigo(string codigo) => repositorio.ObtenerProductoPorCodigo(codigo);

    }
}
