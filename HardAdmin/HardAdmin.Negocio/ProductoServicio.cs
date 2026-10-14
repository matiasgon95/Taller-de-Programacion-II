using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public DataTable ObtenerParaGrilla()
        {
            return repositorio.ObtenerParaGrilla();
        }

        public Producto ObtenerPorId(int idProducto)
        {
            return repositorio.ObtenerPorId(idProducto);
        }

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

        public void Modificar(Producto producto)
        {
            ValidarProducto(producto);

            if (repositorio.ExisteProducto(producto.Codigo, producto.NombreProducto, producto.IdProducto))
            {
                throw new Exception("Ya existe otro producto con el mismo código o nombre.");
            }

            try
            {
                repositorio.Modificar(producto);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("El código del producto ya se encuentra registrado.");
                }
                throw new Exception("Error de base de datos: " + ex.Message);
            }
        }

        public bool ExisteCodigo(string codigo, int idExcluir)
        {
            return repositorio.ExisteCodigo(codigo, idExcluir);
        }

        // Valida y guarda un producto nuevo, registrando también su
        // ingreso inicial de stock cuando corresponde.
        public void Guardar(Producto producto, int idUsuario)
        {
            // Comprueba las reglas de negocio del producto.
            ValidarProducto(producto);

            if (idUsuario <= 0)
            {
                throw new Exception(
                    "No se pudo identificar al usuario que registra el producto.");
            }

            // Evita registrar un código que ya pertenece a otro producto.
            if (repositorio.ExisteCodigo(producto.Codigo, 0))
            {
                throw new Exception(
                    "El código del producto ya se encuentra registrado.");
            }

            try
            {
                // El repositorio guarda el producto y su movimiento inicial
                // dentro de una única transacción.
                repositorio.Guardar(producto, idUsuario);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception(
                        "El código del producto ya se encuentra registrado.");
                }

                throw new Exception(
                    "Error de base de datos: " + ex.Message);
            }
        }

        public DataTable ObtenerProductoPorCodigo(string codigo) => repositorio.ObtenerProductoPorCodigo(codigo);

        public DataTable ObtenerProductosParaSeleccion(string filtro = null)
        {
            return repositorio.ObtenerProductosParaSeleccion(filtro);
        }

        // Obtiene los productos más vendidos en un rango de fechas, filtrando por categoría si se indica.
        public DataTable ObtenerTopProductos(int topN, int idCategoria, DateTime desde, DateTime hasta)
        {
            return repositorio.ObtenerTopProductos(topN, idCategoria, desde, hasta);
        }

    }
}