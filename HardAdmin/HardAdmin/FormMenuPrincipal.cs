using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormMenuPrincipal : Form
    {
        private string usuarioActual;

        // Constructor que recibe el nombre del usuario logueado
        public FormMenuPrincipal(string nombreUsuario)
        {
            InitializeComponent();
            this.usuarioActual = nombreUsuario;
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            // Cargar datos en la interfaz
            lblBienvenida.Text = $"¡Bienvenido, {usuarioActual}!";
            lblUsuarioLogueado.Text = $"Usuario: {usuarioActual}";
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormContenedorModulos contenedor = new FormContenedorModulos(this.usuarioActual, "Usuarios");
            contenedor.Show();
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            // Próximo formulario a implementar
            MessageBox.Show("Módulo Productos en desarrollo.");
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo Ventas en desarrollo.");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo Reportes en desarrollo.");
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo Configuración en desarrollo.");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Si cierran la ventana con la 'X', cerrar toda la aplicación
        private void FormMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormMenuPrincipal_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null; // Quita el foco de cualquier control
        }

        
    }
}
