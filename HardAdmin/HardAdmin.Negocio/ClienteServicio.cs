using HardAdmin.Datos;
using HardAdmin.Entidades;
using System.Data;

namespace HardAdmin.Negocio
{
    public class ClienteServicio
    {
        private ClienteRepositorio repositorio = new ClienteRepositorio();

        // Validamos duplicidad delegando la pregunta a la capa de datos
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
            repositorio.Insertar(cliente);
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
            repositorio.Modificar(cliente);
        }

        public DataTable ObtenerClientePorId(int id) => repositorio.ObtenerClientePorId(id);
        public DataTable ObtenerClientePorDni(string dni) => repositorio.ObtenerClientePorDni(dni);
        public int ObtenerUltimoId() => repositorio.ObtenerUltimoId();

    }
}