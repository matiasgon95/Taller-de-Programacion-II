using HardAdmin.Datos;
using HardAdmin.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HardAdmin.Negocio
{
    public class ClienteServicio
    {
        private ClienteRepositorio repositorio = new ClienteRepositorio();

        public bool DniDisponible(string dni, int? idExcluir = null)
        {
            return !repositorio.ExisteDni(dni, idExcluir);
        }

        public bool EmailDisponible(string email, int? idExcluir = null)
        {
            return !repositorio.ExisteEmail(email, idExcluir);
        }

        public void Registrar(Cliente cliente)
        {
            try
            {
                repositorio.Insertar(cliente);
            }
            catch (SqlException ex)
            {
                // 2627 y 2601 son los códigos de error de SQL Server para claves duplicadas (Unique)
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("El DNI o Email ingresado ya se encuentra registrado en otro cliente.");
                }
                throw new Exception("Error de base de datos: " + ex.Message);
            }
        }

        public DataTable ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }

        public Cliente ObtenerPorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public void Modificar(Cliente cliente)
        {
            try
            {
                repositorio.Modificar(cliente);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("El DNI o Email ingresado ya se encuentra registrado en otro cliente.");
                }
                throw new Exception("Error de base de datos: " + ex.Message);
            }
        }

        public DataTable ObtenerClientePorId(int id) => repositorio.ObtenerClientePorId(id);
        public DataTable ObtenerClientePorDni(string dni) => repositorio.ObtenerClientePorDni(dni);
        public int ObtenerUltimoId() => repositorio.ObtenerUltimoId();

        public DataTable ObtenerClientesParaSeleccion(string filtro = null)
        {
            return repositorio.ObtenerClientesParaSeleccion(filtro);
        }
    }
}