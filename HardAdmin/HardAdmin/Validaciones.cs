using System;
using System.Globalization;
using System.Net.Mail;
using System.Windows.Forms;

namespace HardAdmin
{
    public static class Validaciones
    {
        // Corta el tipeo de cualquier cosa que no sea una letra o espacio.
        public static void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        // Corta el tipeo de letras o símbolos en campos numéricos (como DNI o Teléfono).
        public static void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Pasa a mayúscula la primera letra de cada palabra al salir del campo.
        public static void CapitalizarTexto_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox txt && !string.IsNullOrWhiteSpace(txt.Text))
            {
                TextInfo textInfo = CultureInfo.GetCultureInfo("es-AR").TextInfo;
                txt.Text = textInfo.ToTitleCase(txt.Text.Trim().ToLower(CultureInfo.GetCultureInfo("es-AR")));
            }
        }

        // Valida que el texto tenga un formato de correo real.
        public static bool EsEmailValido(string email)
        {
            try
            {
                var direccion = new MailAddress(email);
                return direccion.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}