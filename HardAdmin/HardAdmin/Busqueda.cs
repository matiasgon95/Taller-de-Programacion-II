using System.Globalization;
using System.Text;

namespace HardAdmin
{
    // Ayudas compartidas por los buscadores de las pantallas de gestión,
    // para no repetir esta lógica en cada formulario.
    public static class Busqueda
    {
        // Devuelve el texto en minúsculas y sin acentos, para poder comparar
        // "Pérez" con "perez". La ñ también pierde su tilde ("peña" coincide con "pena").
        public static string QuitarAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            // Al descomponer, cada letra acentuada queda como letra + marca de acento;
            // después descartamos esas marcas y recomponemos el resto.
            string descompuesto = texto.Normalize(NormalizationForm.FormD);
            StringBuilder resultado = new StringBuilder();

            foreach (char c in descompuesto)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();
        }

        // El texto del buscador se arma dentro de la expresión del filtro del DataView, así que hay
        // que neutralizar los caracteres con significado especial; si no, escribir una comilla
        // o un corchete haría fallar el filtro.
        public static string EscaparParaFiltro(string texto)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (char c in texto)
            {
                if (c == '\'')
                {
                    resultado.Append("''");
                }
                else if (c == '[' || c == ']' || c == '*' || c == '%')
                {
                    resultado.Append('[').Append(c).Append(']');
                }
                else
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }
    }
}