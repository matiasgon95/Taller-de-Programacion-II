using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardAdmin.Entidades;

namespace HardAdmin.Datos
{
    public class ProductoRepositorio
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;


        // Obtiene los productos necesarios para mostrar en la grilla.
        public DataTable ObtenerParaGrilla()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Hacemos el SELECT uniendo Producto y Categoria.
                // Usamos un CASE para transformar el 'bit' (0 o 1) de la columna baja a un 'Sí' o 'No' más amigable.
                string query = @"SELECT 
                                    p.id_producto,
                                    p.codigo,
                                    p.nombre_producto,
                                    p.descripcion,
                                    p.precio,
                                    p.stock,
                                    p.stock_minimo,
                                    p.foto_producto,
                                    p.id_categoria,
                                    c.nombre_categoria,
                                    CASE WHEN p.baja = 0 THEN 'Sí' ELSE 'No' END AS activo
                                 FROM Producto p
                                 INNER JOIN Categoria c 
                                    ON p.id_categoria = c.id_categoria";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
        }

        // Obtiene un producto a partir de su identificador.
        public Producto ObtenerPorId(int idProducto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT
                id_producto,
                codigo,
                nombre_producto,
                descripcion,
                precio,
                stock,
                stock_minimo,
                foto_producto,
                baja,
                id_categoria
            FROM Producto
            WHERE id_producto = @idProducto";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Producto producto = new Producto
                            {
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                Codigo = reader["codigo"].ToString(),
                                NombreProducto = reader["nombre_producto"].ToString(),
                                Descripcion = reader["descripcion"] == DBNull.Value ? null : reader["descripcion"].ToString(),
                                Precio = Convert.ToDecimal(reader["precio"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                StockMinimo = Convert.ToInt32(reader["stock_minimo"]),
                                FotoProducto = reader["foto_producto"] == DBNull.Value ? null : reader["foto_producto"].ToString(),
                                Baja = Convert.ToInt32(reader["baja"]),
                                IdCategoria = Convert.ToInt32(reader["id_categoria"])
                            };

                            return producto;
                        }
                    }
                }
            }

            return null;
        }


        // Actualiza los datos de un producto existente.
        public void Modificar(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE Producto
            SET
                codigo = @codigo,
                nombre_producto = @nombre,
                descripcion = @descripcion,
                precio = @precio,
                stock = @stock,
                stock_minimo = @stockMinimo,
                foto_producto = @foto,
                baja = @baja,
                id_categoria = @idCategoria
            WHERE id_producto = @idProducto";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", producto.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", producto.NombreProducto);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = producto.Precio;
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@foto",
                        producto.FotoProducto == null
                            ? (object)DBNull.Value
                            : producto.FotoProducto);
                    cmd.Parameters.AddWithValue("@baja", producto.Baja);
                    cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@idProducto", producto.IdProducto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Verifica si ya existe un valor cargado en una columna de Producto (nombre/codigo)
        // Y tambien descarta el codigo actualmente usado para la modificacion actual.
        public bool ExisteProducto(string codigo, string nombre, int idExcluir)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(1) FROM Producto WHERE (codigo = @codigo OR nombre_producto = @nombre) AND id_producto <> @idExcluir";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idExcluir", idExcluir);

                    con.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ExisteCodigo(string codigo, int idExcluir)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @" SELECT COUNT(1) FROM Producto WHERE codigo = @codigo AND id_producto <> @idExcluir";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@idExcluir", idExcluir);

                    con.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }


        // Guarda un nuevo producto en la base de datos.
        public void Guardar(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO Producto
            (
                codigo,
                nombre_producto,
                descripcion,
                precio,
                stock,
                stock_minimo,
                foto_producto,
                baja,
                id_categoria
            )
            VALUES
            (
                @codigo,
                @nombre,
                @descripcion,
                @precio,
                @stock,
                @stockMinimo,
                @foto,
                @baja,
                @idCategoria
            )";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", producto.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", producto.NombreProducto);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);

                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value =
                        producto.Precio;

                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo);

                    // Si el producto no tiene imagen, se guarda NULL.
                    cmd.Parameters.AddWithValue(
                        "@foto",
                        (object)producto.FotoProducto ?? DBNull.Value
                    );

                    cmd.Parameters.AddWithValue("@baja", producto.Baja);
                    cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerProductoPorCodigo(string codigo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_producto, codigo, nombre_producto, precio, stock FROM Producto WHERE codigo = @codigo AND baja = 0";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}
