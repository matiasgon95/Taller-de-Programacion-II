using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAdmin.Datos
{
    public class MovimientoStockRepositorio
    {
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Obtiene los movimientos de stock aplicando los filtros
        // de categoría, producto y rango de fechas.
        public DataTable ObtenerParaGrilla(
            int idCategoria,
            int idProducto,
            DateTime desde,
            DateTime hasta)
        {
            DataTable tablaMovimientos = new DataTable();

            string consulta = @"
                SELECT
                    CASE
                        WHEN COUNT(DISTINCT p.id_categoria) > 1
                            THEN 'Varios'
                        ELSE MAX(c.nombre_categoria)
                    END AS Categoria,

                    STUFF((
                        SELECT
                            CHAR(13) + CHAR(10)
                            + p2.nombre_producto
                            + ' (x' + CAST(SUM(ms2.cantidad) AS VARCHAR(10)) + ')'
                        FROM Movimiento_stock ms2
                        INNER JOIN Producto p2
                            ON ms2.id_producto = p2.id_producto
                        WHERE
                            ms2.id_venta = ms.id_venta
                            AND (@idCategoria IN (0, -1)
                                 OR p2.id_categoria = @idCategoria)
                            AND (@idProducto = 0
                                 OR ms2.id_producto = @idProducto)
                        GROUP BY
                            p2.id_producto,
                            p2.nombre_producto
                        ORDER BY
                            p2.nombre_producto
                        FOR XML PATH(''), TYPE
                    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Producto,

                    MAX(ms.fecha) AS Fecha,
                    MAX(u.nombre + ' ' + u.apellido) AS Usuario,
                    MAX(tm.nombre_tipo) AS TipoMovimiento

                FROM Movimiento_stock ms
                INNER JOIN Producto p
                    ON ms.id_producto = p.id_producto
                INNER JOIN Categoria c
                    ON p.id_categoria = c.id_categoria
                INNER JOIN Usuario u
                    ON ms.id_usuario = u.id_usuario
                INNER JOIN Tipo_movimiento tm
                    ON ms.id_tipo_movimiento = tm.id_tipo_movimiento

                WHERE
                    ms.id_venta IS NOT NULL
                    AND (
                        @idCategoria = 0
                        OR (@idCategoria = -1 AND ms.id_venta IN (
                            SELECT ms2.id_venta
                            FROM Movimiento_stock ms2
                            INNER JOIN Producto p2
                                ON ms2.id_producto = p2.id_producto
                            GROUP BY ms2.id_venta
                            HAVING COUNT(DISTINCT p2.id_categoria) > 1
                        ))
                        OR (@idCategoria > 0 AND p.id_categoria = @idCategoria)
                    )
                    AND (@idProducto = 0 OR ms.id_producto = @idProducto)
                    AND ms.fecha >= @desde
                    AND ms.fecha < @hastaExclusivo

                GROUP BY
                    ms.id_venta

                UNION ALL

                SELECT
                    c.nombre_categoria AS Categoria,
                    p.nombre_producto AS Producto,
                    ms.fecha AS Fecha,
                    u.nombre + ' ' + u.apellido AS Usuario,
                    tm.nombre_tipo AS TipoMovimiento

                FROM Movimiento_stock ms
                INNER JOIN Producto p
                    ON ms.id_producto = p.id_producto
                INNER JOIN Categoria c
                    ON p.id_categoria = c.id_categoria
                INNER JOIN Usuario u
                    ON ms.id_usuario = u.id_usuario
                INNER JOIN Tipo_movimiento tm
                    ON ms.id_tipo_movimiento = tm.id_tipo_movimiento

                WHERE
                    ms.id_venta IS NULL
                    AND @idCategoria >= 0
                    AND (@idCategoria = 0 OR p.id_categoria = @idCategoria)
                    AND (@idProducto = 0 OR ms.id_producto = @idProducto)
                    AND ms.fecha >= @desde
                    AND ms.fecha < @hastaExclusivo

                ORDER BY Fecha DESC;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // Filtros de categoría y producto.
                comando.Parameters.Add("@idCategoria", SqlDbType.Int).Value =
                    idCategoria;

                comando.Parameters.Add("@idProducto", SqlDbType.Int).Value =
                    idProducto;

                // Se incluye el día completo de la fecha inicial.
                comando.Parameters.Add("@desde", SqlDbType.DateTime).Value =
                    desde.Date;

                // Se usa el día siguiente como límite exclusivo para
                // incluir también los movimientos de cualquier hora
                // de la fecha final seleccionada.
                comando.Parameters.Add("@hastaExclusivo", SqlDbType.DateTime).Value =
                    hasta.Date.AddDays(1);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tablaMovimientos);
                }
            }

            return tablaMovimientos;
        }
    }


}

