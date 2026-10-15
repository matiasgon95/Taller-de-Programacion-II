using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HardAdmin.Entidades;

namespace HardAdmin.Datos
{
    public class VentaRepositorio
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Trae la tabla con las ventas. Si le pasamos un ID, filtra; si le pasamos null, trae todas.
        // Trae la tabla con las ventas filtrada por rango de fechas y opcionalmente por usuario.
        public DataTable ObtenerVentas(DateTime desde, DateTime hasta, int? idUsuarioLogueado)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                           v.id_venta,
                           'F-' + RIGHT('00000000' + CAST(v.id_venta AS VARCHAR(8)), 8) AS nro_factura,
                           v.fecha,
                           CASE WHEN ISNULL(LTRIM(RTRIM(c.nombre)), '') = '' THEN c.apellido
                                 ELSE c.apellido + ', ' + c.nombre END AS cliente,
                           u.nombre_usuario AS vendedor,
                           mp.nombre_metodo AS medio_pago,
                           v.estado,
                           v.total
                       FROM Venta v
                       INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                       INNER JOIN Usuario u ON v.id_usuario = u.id_usuario
                       INNER JOIN Metodo_pago mp ON v.id_metodo_pago = mp.id_metodo_pago
                       WHERE v.fecha >= @desde AND v.fecha <= @hasta";

                if (idUsuarioLogueado.HasValue)
                {
                    query += " AND v.id_usuario = @idUsuario";
                }

                query += " ORDER BY v.fecha DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);

                    if (idUsuarioLogueado.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuarioLogueado.Value);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Trae solo los nombres de los vendedores que tienen ventas registradas
        public List<string> ObtenerVendedoresConVentas()
        {
            List<string> vendedores = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT u.nombre_usuario FROM Venta v INNER JOIN Usuario u ON v.id_usuario = u.id_usuario ORDER BY u.nombre_usuario";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendedores.Add(reader["nombre_usuario"].ToString());
                        }
                    }
                }
            }
            return vendedores;
        }

        public int ObtenerProximoId()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(id_venta), 0) + 1 FROM Venta";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public DataTable ObtenerMetodosPagoActivos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_metodo_pago, nombre_metodo FROM Metodo_pago WHERE baja = 0";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Trae los datos principales de la venta y del cliente
        public DataTable ObtenerCabeceraVenta(int idVenta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                            'F-' + RIGHT('00000000' + CAST(v.id_venta AS VARCHAR(8)), 8) AS nro_factura,
                            v.fecha,
                            v.estado,
                            c.nombre AS cliente_nombre,
                            c.apellido AS cliente_apellido,
                            c.dni,
                            c.calle,
                            c.numero,
                            c.piso_depto,
                            c.ciudad,
                            u.nombre_usuario AS vendedor,
                            mp.nombre_metodo AS medio_pago
                        FROM Venta v
                        INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                        INNER JOIN Usuario u ON v.id_usuario = u.id_usuario
                        INNER JOIN Metodo_pago mp ON v.id_metodo_pago = mp.id_metodo_pago
                        WHERE v.id_venta = @idVenta";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Trae los productos específicos que componen el detalle de la venta
        public DataTable ObtenerDetalleVenta(int idVenta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                            vd.id_producto,
                            p.codigo,
                            p.nombre_producto,
                            vd.cantidad,
                            vd.precio_unitario,
                            vd.subtotal
                        FROM Venta_detalle vd
                        INNER JOIN Producto p ON vd.id_producto = p.id_producto
                        WHERE vd.id_venta = @idVenta";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Guarda la cabecera, las líneas, el descuento de stock y su movimiento de stock
        // como una sola operación. Usamos una transacción para que, si algo falla a mitad
        // de camino (por ejemplo un producto sin stock), no quede una venta cargada a medias.
        // El tipo de movimiento lo decide la capa de Negocio; acá solo se persiste.
        public int InsertarVenta(Venta venta, int idTipoMovimiento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlTransaction transaccion = con.BeginTransaction())
                {
                    try
                    {
                        // SCOPE_IDENTITY nos devuelve el id_venta recién generado, que necesitamos
                        // para enlazar cada línea del detalle con su cabecera.
                        string queryVenta = @"INSERT INTO Venta (fecha, total, estado, id_cliente, id_usuario, id_metodo_pago)
                                              VALUES (@fecha, @total, @estado, @idCliente, @idUsuario, @idMetodoPago);
                                              SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int idVenta;
                        using (SqlCommand cmd = new SqlCommand(queryVenta, con, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                            cmd.Parameters.AddWithValue("@total", venta.Total);
                            cmd.Parameters.AddWithValue("@estado", venta.Estado);
                            cmd.Parameters.AddWithValue("@idCliente", venta.IdCliente);
                            cmd.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);
                            cmd.Parameters.AddWithValue("@idMetodoPago", venta.IdMetodoPago);

                            idVenta = (int)cmd.ExecuteScalar();
                        }

                        string queryDetalle = @"INSERT INTO Venta_detalle (cantidad, precio_unitario, subtotal, id_venta, id_producto)
                                                VALUES (@cantidad, @precioUnitario, @subtotal, @idVenta, @idProducto)";

                        // La condición "stock >= @cantidad" hace que el descuento sea seguro aunque
                        // otra venta haya consumido stock mientras armábamos esta: si no alcanza,
                        // no se actualiza ninguna fila y cortamos con error.
                        string queryStock = @"UPDATE Producto
                                              SET stock = stock - @cantidad
                                              WHERE id_producto = @idProducto AND stock >= @cantidad";

                        // Dejamos registro en el historial de stock de cada producto que salió.
                        string queryMovimiento = @"INSERT INTO Movimiento_stock (cantidad, fecha, id_producto, id_usuario, id_tipo_movimiento)
                                                   VALUES (@cantidad, @fecha, @idProducto, @idUsuario, @idTipoMovimiento)";

                        foreach (VentaDetalle detalle in venta.Detalles)
                        {
                            using (SqlCommand cmd = new SqlCommand(queryDetalle, con, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                                cmd.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                                cmd.Parameters.AddWithValue("@subtotal", detalle.Subtotal);
                                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                                cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand(queryStock, con, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                                cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    throw new InvalidOperationException(
                                        "No hay stock suficiente para uno de los productos de la venta. No se registró nada.");
                                }
                            }

                            // La cantidad se guarda en positivo: que sea una salida lo indica el tipo de movimiento.
                            using (SqlCommand cmd = new SqlCommand(queryMovimiento, con, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                                cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                                cmd.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                                cmd.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);
                                cmd.Parameters.AddWithValue("@idTipoMovimiento", idTipoMovimiento);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                        return idVenta;
                    }
                    catch
                    {
                        // Deshacemos todo y relanzamos el error original para que la capa de
                        // arriba lo muestre; no lo silenciamos.
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        // Trae la evolución de ventas entre dos fechas, agrupando por día y sumando totales.
        public DataTable ObtenerEvolucionVentas(DateTime desde, DateTime hasta, string agrupacion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "";

                if (agrupacion == "Mes")
                {
                    query = @"SELECT FORMAT(fecha, 'yyyy-MM') AS periodo, 
                            COUNT(id_venta) AS cantidad_ventas, 
                            SUM(total) AS total_recaudado
                      FROM Venta
                      WHERE fecha >= @desde AND fecha <= @hasta
                      GROUP BY FORMAT(fecha, 'yyyy-MM')
                      ORDER BY periodo ASC";
                }
                else if (agrupacion == "Año")
                {
                    query = @"SELECT CAST(YEAR(fecha) AS VARCHAR(4)) AS periodo, 
                            COUNT(id_venta) AS cantidad_ventas, 
                            SUM(total) AS total_recaudado
                      FROM Venta
                      WHERE fecha >= @desde AND fecha <= @hasta
                      GROUP BY YEAR(fecha)
                      ORDER BY periodo ASC";
                }
                else // Por defecto: Día
                {
                    query = @"SELECT CONVERT(VARCHAR(10), fecha, 120) AS periodo, 
                            COUNT(id_venta) AS cantidad_ventas, 
                            SUM(total) AS total_recaudado
                      FROM Venta
                      WHERE fecha >= @desde AND fecha <= @hasta
                      GROUP BY CONVERT(VARCHAR(10), fecha, 120)
                      ORDER BY periodo ASC";
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Compara dos períodos de tiempo y devuelve un DataTable con las fechas y montos de cada período lado a lado.
        public DataTable ObtenerComparativaFinanciera(DateTime desde1, DateTime hasta1, DateTime desde2, DateTime hasta2)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"WITH VentasPeriodo1 AS (
                            SELECT 
                                DATEDIFF(day, @desde1, CAST(fecha AS DATE)) AS dia_offset,
                                CAST(fecha AS DATE) AS fecha_dia,
                                SUM(total) AS total_dia
                            FROM venta 
                            WHERE fecha >= @desde1 AND fecha <= @hasta1
                            GROUP BY CAST(fecha AS DATE)
                        ),
                        VentasPeriodo2 AS (
                            SELECT 
                                DATEDIFF(day, @desde2, CAST(fecha AS DATE)) AS dia_offset,
                                CAST(fecha AS DATE) AS fecha_dia,
                                SUM(total) AS total_dia
                            FROM venta 
                            WHERE fecha >= @desde2 AND fecha <= @hasta2
                            GROUP BY CAST(fecha AS DATE)
                        ),
                        TodosLosOffsets AS (
                            SELECT dia_offset FROM VentasPeriodo1
                            UNION
                            SELECT dia_offset FROM VentasPeriodo2
                        )
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY t.dia_offset ASC) AS nro_orden,
                            ISNULL(p1.fecha_dia, DATEADD(day, t.dia_offset, @desde1)) AS fecha_periodo1,
                            ISNULL(p1.total_dia, 0) AS monto_periodo1,
                            ISNULL(p2.fecha_dia, DATEADD(day, t.dia_offset, @desde2)) AS fecha_periodo2,
                            ISNULL(p2.total_dia, 0) AS monto_periodo2
                        FROM TodosLosOffsets t
                        LEFT JOIN VentasPeriodo1 p1 ON t.dia_offset = p1.dia_offset
                        LEFT JOIN VentasPeriodo2 p2 ON t.dia_offset = p2.dia_offset
                        ORDER BY t.dia_offset ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@desde1", desde1);
                    cmd.Parameters.AddWithValue("@hasta1", hasta1);
                    cmd.Parameters.AddWithValue("@desde2", desde2);
                    cmd.Parameters.AddWithValue("@hasta2", hasta2);

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