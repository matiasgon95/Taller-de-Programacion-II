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

            AplicarPermisos();

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
        }

        private void AbrirModulo(string modulo)
        {
            if (!PermisosSistema.TienePermisoModulo(modulo))
            {
                MessageBox.Show(
                    "No tiene permisos para acceder a este módulo.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            switch (modulo)
            {
                case "Usuarios":
                    AbrirFormularioEnPanel(new FormGestionUsuarios());
                    break;
                case "Productos":
                    AbrirFormularioEnPanel(new FormGestionProductos());
                    break;
                case "Clientes":
                    AbrirFormularioEnPanel(new FormGestionClientes());
                    break;
                case "Ventas":
                    AbrirFormularioEnPanel(new FormVentas());
                    break;
                case "Reportes":
                    AbrirFormularioEnPanel(new FormReportes());
                    break;
                case "Configuracion":
                    AbrirFormularioEnPanel(new FormConfiguracion());
                    break;
                default:
                    MessageBox.Show(
                        "El módulo seleccionado no existe.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    break;
            }
        }

        // Habilita o deshabilita los botones del menú
        // según los permisos del usuario actual.
        private void AplicarPermisos()
        {
            btnUsuarios.Enabled =
                PermisosSistema.TienePermisoModulo("Usuarios");

            btnProductos.Enabled =
                PermisosSistema.TienePermisoModulo("Productos");

            btnClientes.Enabled =
                PermisosSistema.TienePermisoModulo("Clientes");

            btnVentas.Enabled =
                PermisosSistema.TienePermisoModulo("Ventas");

            btnReportes.Enabled =
                PermisosSistema.TienePermisoModulo("Reportes");

            btnConfiguración.Enabled =
                PermisosSistema.TienePermisoModulo("Configuracion");
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirModulo("Clientes");
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