using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using HardAdmin.Datos;
using HardAdmin.Entidades;

namespace HardAdmin.Negocio
{
    // Acá viven las reglas: qué es un nombre válido, cuál es la edad mínima, etc.
    // No sabe que existe un TextBox ni un ErrorProvider, ni cómo se guarda en SQL.
    public class UsuarioServicio
    {
        private UsuarioRepositorio repositorio = new UsuarioRepositorio();
        private const int EDAD_MINIMA = 18;

        public System.Collections.Generic.List<Rol> ObtenerRoles()
        {
            return repositorio.ObtenerRoles();
        }

        // ---------- Reglas de formato ----------

        public bool EsNombreValido(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && Regex.IsMatch(valor, @"^[\p{L}\s]+$");
        }

        public bool EsApellidoValido(string valor)
        {
            return EsNombreValido(valor);
        }

        public bool EsDniValido(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && Regex.IsMatch(valor, @"^\d{7,8}$");
        }

        public bool EsFechaNacimientoValida(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;
            if (fechaNacimiento.Date > hoy) return false; // fecha futura

            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;

            return edad >= EDAD_MINIMA;
        }

        public bool EsCalleValida(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor);
        }

        public bool EsAlturaValida(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && Regex.IsMatch(valor, @"^\d+$");
        }

        public bool EsLocalidadValida(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor);
        }

        public bool EsNombreUsuarioValido(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && valor.Length >= 4;
        }

        public bool EsEmailValido(string valor)
        {
            try
            {
                var direccion = new MailAddress(valor);
                return direccion.Address == valor;
            }
            catch
            {
                return false;
            }
        }

        public bool EsContrasenaValida(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && valor.Length >= 6;
        }

        // ---------- Unicidad contra la base ----------

        public bool DniDisponible(string dni) => !repositorio.ExisteUsuario("dni", dni);
        public bool NombreUsuarioDisponible(string usuario) => !repositorio.ExisteUsuario("nombre_usuario", usuario);
        public bool EmailDisponible(string email) => !repositorio.ExisteUsuario("email", email);

        // ---------- Alta ----------

        public void Registrar(Usuario usuario, string contrasenaPlano)
        {
            string contrasenaHasheada = Seguridad.HashearContrasena(contrasenaPlano);
            repositorio.Insertar(usuario, contrasenaHasheada);
        }
    }
}