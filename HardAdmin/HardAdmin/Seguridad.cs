using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HardAdmin
{
    public static class Seguridad
    {
        public static string HashearContrasena(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoPlano);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Convierte a hexadecimal en minúsculas
                }
                return sb.ToString();
            }
        }
    }
}