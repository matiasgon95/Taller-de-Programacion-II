using HardAdmin.Datos;
using HardAdmin.Entidades;
using System.Data;

namespace HardAdmin.Negocio
{
    public class ClienteServicio
    {
        private ClienteRepositorio repo = new ClienteRepositorio();

        // Validamos duplicidad delegando la pregunta a la capa de datos
        public bool DniDisponible(string dni, int? idExcluir = null)
        {
            return !repo.ExisteDni(dni, idExcluir);
        }

        public bool EmailDisponible(string email, int? idExcluir = null)
        {
            return !repo.ExisteEmail(email, idExcluir);
        }

        public void Registrar(Cliente cliente)
        {
            repo.Insertar(cliente);
        }

        public DataTable ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public Cliente ObtenerPorId(int id)
        {
            return repo.ObtenerPorId(id);
        }

        public void Modificar(Cliente cliente)
        {
            repo.Modificar(cliente);
        }
    }
}