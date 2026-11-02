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
                                l.nombre_localidad AS localidad,
                                u.nombre_usuario AS vendedor,
                                mp.nombre_metodo AS medio_pago
                            FROM Venta v
                            INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
                            LEFT JOIN Localidad l ON c.id_localidad = l.id_localidad
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

        // Registra la venta y sus detalles en la base de datos, usando un procedimiento almacenado.
        public int InsertarVenta(Venta venta, int idTipoMovimiento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("id_producto", typeof(int));
                dtDetalles.Columns.Add("cantidad", typeof(int));
                dtDetalles.Columns.Add("precio_unitario", typeof(decimal));
                dtDetalles.Columns.Add("subtotal", typeof(decimal));

                foreach (VentaDetalle detalle in venta.Detalles)
                {
                    dtDetalles.Rows.Add(detalle.IdProducto, detalle.Cantidad, detalle.PrecioUnitario, detalle.Subtotal);
                }

                using (SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@total", venta.Total);
                    cmd.Parameters.AddWithValue("@estado", venta.Estado);
                    cmd.Parameters.AddWithValue("@id_cliente", venta.IdCliente);
                    cmd.Parameters.AddWithValue("@id_usuario", venta.IdUsuario);
                    cmd.Parameters.AddWithValue("@id_metodo_pago", venta.IdMetodoPago);
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", idTipoMovimiento);

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@detalles", dtDetalles);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.DetalleVentaType";

                    SqlParameter outParam = new SqlParameter("@id_venta", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return (int)outParam.Value;
                    }
                    catch (SqlException ex)
                    {
                        throw new InvalidOperationException(ex.Message);
                    }
                }
            }
        }

        // Trae la evolución de ventas entre dos fechas, agrupando de forma optimizada.
        public DataTable ObtenerEvolucionVentas(DateTime desde, DateTime hasta, string agrupacion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "";

                if (agrupacion == "Mes")
                {
                    // OPTIMIZADO: Evita el uso lento de FORMAT row-by-row y usa funciones nativas rápidas
                    query = @"SELECT CAST(YEAR(fecha) AS VARCHAR(4)) + '-' + RIGHT('0' + CAST(MONTH(fecha) AS VARCHAR(2)), 2) AS periodo, 
                            COUNT(id_venta) AS cantidad_ventas, 
                            SUM(total) AS total_recaudado
                      FROM Venta
                      WHERE fecha >= @desde AND fecha <= @hasta
                      GROUP BY YEAR(fecha), MONTH(fecha)
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

        // Trae el cierre financiero agrupado por mes con su respectivo mes anterior para comparar
        public DataTable ObtenerCierreFinanciero(DateTime desde, DateTime hasta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"WITH VentasMensuales AS (
                            SELECT 
                                YEAR(fecha) AS anio,
                                MONTH(fecha) AS mes,
                                COUNT(id_venta) AS cantidad_ventas,
                                SUM(total) AS recaudacion_total
                            FROM Venta
                            WHERE fecha >= @desde AND fecha <= @hasta
                            GROUP BY YEAR(fecha), MONTH(fecha)
                        )
                        SELECT 
                            anio,
                            mes,
                            cantidad_ventas,
                            recaudacion_total,
                            LAG(recaudacion_total, 1) OVER (ORDER BY anio ASC, mes ASC) AS recaudacion_anterior
                        FROM VentasMensuales
                        ORDER BY anio ASC, mes ASC";

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

        public DataTable ObtenerComparativaInteranual(int anio1, int anio2)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                            m.nro_mes,
                            m.nombre_mes,
                            ISNULL(v1.cantidad_ventas, 0) as ventas_anio1,
                            ISNULL(v1.recaudacion, 0) AS recaudacion_anio1,
                            ISNULL(v2.cantidad_ventas, 0) as ventas_anio2,
                            ISNULL(v2.recaudacion, 0) AS recaudacion_anio2,
                            CASE 
                                WHEN ISNULL(v1.recaudacion, 0) > 0 
                                THEN ((ISNULL(v2.recaudacion, 0) - v1.recaudacion) / v1.recaudacion) * 100 
                                ELSE 0 
                            END AS variacion_interanual
                        FROM (
                            VALUES (1, 'enero'), (2, 'febrero'), (3, 'marzo'), (4, 'abril'), 
                                   (5, 'mayo'), (6, 'junio'), (7, 'julio'), (8, 'agosto'), 
                                   (9, 'septiembre'), (10, 'octubre'), (11, 'noviembre'), (12, 'diciembre')
                        ) AS m(nro_mes, nombre_mes)
                        LEFT JOIN (
                            SELECT MONTH(fecha) AS mes, COUNT(id_venta) AS cantidad_ventas, SUM(total) AS recaudacion
                            FROM Venta
                            WHERE YEAR(fecha) = @anio1
                            GROUP BY MONTH(fecha)
                        ) v1 ON m.nro_mes = v1.mes
                        LEFT JOIN (
                            SELECT MONTH(fecha) AS mes, COUNT(id_venta) AS cantidad_ventas, SUM(total) AS recaudacion
                            FROM Venta
                            WHERE YEAR(fecha) = @anio2
                            GROUP BY MONTH(fecha)
                        ) v2 ON m.nro_mes = v2.mes
                        ORDER BY m.nro_mes;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@anio1", anio1);
                    cmd.Parameters.AddWithValue("@anio2", anio2);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Obtiene los años distintos en los que se registraron ventas, para poblar un ComboBox.
        public List<int> ObtenerAniosDisponibles()
        {
            List<int> anios = new List<int>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT YEAR(fecha) AS anio FROM Venta ORDER BY anio ASC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            anios.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            return anios;
        }
    }
}