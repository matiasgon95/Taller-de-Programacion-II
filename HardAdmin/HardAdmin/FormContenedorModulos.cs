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
    public partial class FormContenedorModulos : Form
    {
        private string usuarioActual; // Guardamos el usuario logueado
        private string moduloInicial; // Guardamos el módulo solicitado
        private Form formularioActivo = null;

        public FormContenedorModulos(string usuario, string moduloInicial = "Usuarios")
        {
            InitializeComponent();
            this.usuarioActual = usuario;
            this.moduloInicial = moduloInicial;
        }

        private void FormContenedorModulos_Load(object sender, EventArgs e)
        {
            lblUsuarioLogueado.Text = $"Usuario: {usuarioActual}";
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            AbrirModulo(this.moduloInicial);
        }


        // Método central para incrustar formularios dentro de pnlContenedor
        public void AbrirFormularioEnPanel(Form formularioHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close(); // Cierra el anterior para liberar memoria
            }

            formularioActivo = formularioHijo;

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            pnlContenedor.Controls.Clear();
            pnlContenedor.Controls.Add(formularioHijo);
            pnlContenedor.Tag = formularioHijo;

            formularioHijo.BringToFront();
            formularioHijo.Show();

            // Líneas necesarias para forzar el cálculo de los Anchors de inmediato:
            formularioHijo.Size = pnlContenedor.ClientSize;
            formularioHijo.PerformLayout();
            pnlContenedor.PerformLayout();
        }

        private void AbrirModulo(string modulo)
        {
            switch (modulo)
            {
                case "Usuarios":
                    AbrirFormularioEnPanel(new FormGestionUsuarios());
                    break;
                case "Productos":
                 
                    //AbrirFormularioEnPanel(new FormGestionProductos());
                    MessageBox.Show("Módulo Productos en desarrollo.");
                    break;
                case "Ventas":
                    //AbrirFormularioEnPanel(new FormGestionVentas());
                    MessageBox.Show("Módulo Ventas en desarrollo.");
                    break;
                case "Reportes":
                    //AbrirFormularioEnPanel(new FormReportes());
                    MessageBox.Show("Módulo Reportes en desarrollo.");
                    break;
                case "Configuracion":
                    //AbrirFormularioEnPanel(new FormConfiguracion());
                    MessageBox.Show("Módulo Configuración en desarrollo.");
                    break;
                default:
                    AbrirFormularioEnPanel(new FormGestionUsuarios());
                    break;
            }
        }

        // Eventos de los botones del menú lateral
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirModulo("Usuarios");
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirModulo("Productos");
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirModulo("Ventas");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirModulo("Reportes");
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirModulo("Configuracion");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}