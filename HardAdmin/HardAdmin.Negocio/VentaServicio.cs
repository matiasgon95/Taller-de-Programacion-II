using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HardAdmin.Datos;
using HardAdmin.Entidades;

namespace HardAdmin.Negocio
{
    public class VentaServicio
    {
        private VentaRepositorio repositorio = new VentaRepositorio();

        // Estado con el que nace toda venta registrada desde el mostrador.
        // La base maneja solo 'Pendiente', 'Pagado' y 'Anulado'.
        private const string ESTADO_VENTA_REGISTRADA = "Pagado";

        // id_tipo_movimiento de "Egreso por Venta" en la tabla Tipo_movimiento.
        private const int ID_TIPO_MOVIMIENTO_EGRESO_POR_VENTA = 2;

        public DataTable ObtenerVentasResumen(bool esAdmin, int idUsuario)
        {
            // Regla de negocio: Si es admin no filtramos (null), si es vendedor pasamos su ID
            int? parametroId = esAdmin ? (int?)null : idUsuario;

            return repositorio.ObtenerVentas(parametroId);
        }

        public List<string> ObtenerVendedoresConVentas()
        {
            return repositorio.ObtenerVendedoresConVentas();
        }

        public int ObtenerProximoId() => repositorio.ObtenerProximoId();
        public DataTable ObtenerMetodosPagoActivos() => repositorio.ObtenerMetodosPagoActivos();

        public DataTable ObtenerCabeceraVenta(int idVenta) => repositorio.ObtenerCabeceraVenta(idVenta);
        public DataTable ObtenerDetalleVenta(int idVenta) => repositorio.ObtenerDetalleVenta(idVenta);

        // Valida las reglas de la venta, completa lo que decide el sistema (fecha, estado,
        // subtotales y total) y la manda a guardar. Devuelve el id_venta generado.
        public int RegistrarVenta(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            if (venta.Detalles == null || venta.Detalles.Count == 0)
                throw new InvalidOperationException("La venta debe tener al menos un producto.");

            if (venta.IdCliente <= 0)
                throw new InvalidOperationException("Debe haber un cliente asociado a la venta.");

            if (venta.IdUsuario <= 0)
                throw new InvalidOperationException("No hay un usuario logueado para registrar la venta.");

            if (venta.IdMetodoPago <= 0)
                throw new InvalidOperationException("Debe seleccionar un método de pago.");

            foreach (VentaDetalle detalle in venta.Detalles)
            {
                if (detalle.Cantidad <= 0)
                    throw new InvalidOperationException("La cantidad de cada producto debe ser mayor a 0.");

                if (detalle.PrecioUnitario < 0)
                    throw new InvalidOperationException("El precio de un producto no puede ser negativo.");

                // Recalculamos acá en vez de confiar en lo que llegue desde la pantalla,
                // así el total guardado siempre coincide con las líneas.
                detalle.Subtotal = detalle.PrecioUnitario * detalle.Cantidad;
            }

            venta.Total = venta.Detalles.Sum(d => d.Subtotal);
            venta.Fecha = DateTime.Now;
            venta.Estado = ESTADO_VENTA_REGISTRADA;

            return repositorio.InsertarVenta(venta, ID_TIPO_MOVIMIENTO_EGRESO_POR_VENTA);
        }
    }
}