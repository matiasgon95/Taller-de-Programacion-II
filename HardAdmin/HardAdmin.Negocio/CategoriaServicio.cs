using System;
using System.Collections.Generic;
using System.Data;
using HardAdmin.Datos;
using HardAdmin.Entidades;

namespace HardAdmin.Negocio
{
    public class CategoriaServicio
    {
        private CategoriaRepositorio repo = new CategoriaRepositorio();

        public DataTable ObtenerParaGrilla()
        {
            return repo.ObtenerParaGrilla();
        }

        public void GuardarCambios(List<Categoria> listaCategorias)
        {
            foreach (var cat in listaCategorias)
            {
                // 1. Control de vacíos
                if (string.IsNullOrWhiteSpace(cat.NombreCategoria))
                {
                    throw new Exception("No se puede guardar una categoría con el nombre vacío.");
                }

                // 2. Control de nombres duplicados
                if (repo.ExisteNombreCategoria(cat.NombreCategoria, cat.IdCategoria))
                {
                    throw new Exception($"El nombre '{cat.NombreCategoria}' ya existe en otra categoría. Por favor, elegí otro.");
                }

                // 3. Control de integridad al dar de baja
                if (cat.Baja == 1 && cat.IdCategoria != 0)
                {
                    if (repo.TieneProductosActivos(cat.IdCategoria))
                    {
                        throw new Exception($"No podés dar de baja la categoría '{cat.NombreCategoria}' porque tiene productos activos vinculados.");
                    }
                }
            }

            // Si pasó todos los controles sin lanzar errores, guardamos tranquilo.
            repo.GuardarCambios(listaCategorias);
        }
    }
}