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
                    (@idCategoria = 0 OR p.id_categoria = @idCategoria)
                    AND (@idProducto = 0 OR ms.id_producto = @idProducto)
                    AND ms.fecha >= @desde
                    AND ms.fecha < @hastaExclusivo
                ORDER BY
                    ms.fecha DESC,
                    ms.id_movimiento DESC;";

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

