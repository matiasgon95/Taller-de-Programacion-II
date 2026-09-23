using System;
using System.Collections.Generic;
using System.Data;
using HardAdmin.Datos;
using HardAdmin.Entidades;

namespace HardAdmin.Negocio
{
    public class MetodoPagoServicio
    {
        private MetodoPagoRepositorio repo = new MetodoPagoRepositorio();

        public DataTable ObtenerParaGrilla()
        {
            return repo.ObtenerParaGrilla();
        }

        public void GuardarCambios(List<MetodoPago> listaMetodos)
        {
            // Usamos esto para recordar qué nombres vamos leyendo de la grilla
            HashSet<string> nombresEnGrilla = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var metodo in listaMetodos)
            {
                // 1. Control de vacíos
                if (string.IsNullOrWhiteSpace(metodo.NombreMetodo))
                {
                    throw new Exception("No se puede guardar un método de pago con el nombre vacío.");
                }

                // 2. Evitar que el usuario haya escrito dos veces el mismo nombre en la grilla nueva
                if (!nombresEnGrilla.Add(metodo.NombreMetodo.Trim()))
                {
                    throw new Exception($"Escribiste el método '{metodo.NombreMetodo}' más de una vez en la lista. Borrá el repetido.");
                }

                // 3. Control de nombres duplicados contra la base de datos
                if (repo.ExisteNombreMetodo(metodo.NombreMetodo, metodo.IdMetodoPago))
                {
                    throw new Exception($"El método '{metodo.NombreMetodo}' ya existe. Por favor, elegí otro nombre.");
                }
            }

            // Si pasó todas las validaciones sin lanzar error, mandamos a guardar a Datos
            repo.GuardarCambios(listaMetodos);
        }
    }
}