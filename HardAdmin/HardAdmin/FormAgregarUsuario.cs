using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HardAdmin.Entidades;
using HardAdmin.Negocio;

namespace HardAdmin
{
    public partial class FormAgregarUsuario : Form
    {
        // Única dependencia hacia afuera de la UI: la capa de Negocio.
        // Este formulario ya no sabe que existe SQL Server.
        private UsuarioServicio servicio = new UsuarioServicio();

        // Edad mínima requerida para dar de alta un usuario.
        private const int edadRequerida = UsuarioServicio.EDAD_MINIMA;

        // Se crea por código para no depender de agregarlo desde el diseñador.
        private ErrorProvider errorProvider = new ErrorProvider();

        // Se van completando durante cada intento de guardar (ver Marcar()).
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        public FormAgregarUsuario()
        {
            InitializeComponent();

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Asignamos los eventos de validación y formato a los campos correspondientes.
            txtNombre.KeyPress += Validaciones.SoloLetras_KeyPress;
            txtApellido.KeyPress += Validaciones.SoloLetras_KeyPress;
            txtNombre.Leave += Validaciones.CapitalizarTexto_Leave;
            txtApellido.Leave += Validaciones.CapitalizarTexto_Leave;

            txtDni.KeyPress += Validaciones.SoloNumeros_KeyPress;
            txtDni.MaxLength = 8;

            txtAltura.KeyPress += Validaciones.SoloNumeros_KeyPress;

            // No se puede seleccionar una fecha de nacimiento futura desde el propio control.
            dtpFechaNacimiento.MaxDate = DateTime.Today;

            // Largos máximos alineados a los varchar(n) de la tabla Usuario,
            // para no depender de que SQL Server tire el error de truncamiento.
            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtCalle.MaxLength = 100;
            txtDpto.MaxLength = 10;
            txtLocalidad.MaxLength = 100;
            txtAltura.MaxLength = 20;
            txtUsuario.MaxLength = 50;
            txtEmail.MaxLength = 100;

            // Arma la dirección completa a medida que se completan sus cuatro partes.
            txtCalle.TextChanged += ActualizarDireccionCompleta;
            txtAltura.TextChanged += ActualizarDireccionCompleta;
            txtDpto.TextChanged += ActualizarDireccionCompleta;
            txtLocalidad.TextChanged += ActualizarDireccionCompleta;

            // Muestra u oculta el contenido de las dos contraseñas.
            chkVerClave.CheckedChanged += chkVerClave_CheckedChanged;

            // Revalida cada campo al salir de él, así el error desaparece apenas se corrige
            // sin tener que volver a apretar Guardar.
            txtNombre.Leave += txtNombre_Leave;
            txtApellido.Leave += txtApellido_Leave;
            txtDni.Leave += txtDni_Leave;
            dtpFechaNacimiento.ValueChanged += dtpFechaNacimiento_ValueChanged;
            txtCalle.Leave += txtCalle_Leave;
            txtAltura.Leave += txtAltura_Leave;
            txtLocalidad.Leave += txtLocalidad_Leave;
            txtUsuario.Leave += txtUsuario_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtContrasena.Leave += txtContrasena_Leave;
            txtConfirmarContrasena.Leave += txtConfirmarContrasena_Leave;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;
        }

        private void FormAgregarUsuario_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            try
            {
                List<Rol> roles = servicio.ObtenerRoles();

                cmbRol.DisplayMember = "NombreRol";
                cmbRol.ValueMember = "IdRol";
                cmbRol.DataSource = roles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDireccionCompleta(object sender, EventArgs e)
        {
            string calle = txtCalle.Text.Trim();
            string altura = txtAltura.Text.Trim();
            string dpto = txtDpto.Text.Trim();
            string localidad = txtLocalidad.Text.Trim();

            // Armamos la primera parte (Calle y Altura)
            string direccion = $"{calle} {altura}".Trim();

            // Si hay departamento, lo sumamos
            if (!string.IsNullOrWhiteSpace(dpto))
            {
                direccion += $" Dpto {dpto}";
            }

            // Agregamos la localidad si existe, separada por una coma
            if (!string.IsNullOrWhiteSpace(localidad))
            {
                // Si no se cargó calle ni altura antes, evitamos que arranque con una coma
                if (direccion.Length > 0)
                {
                    direccion += $", {localidad}";
                }
                else
                {
                    direccion = $"{localidad}";
                }
            }

            txtDireccionCompleta.Text = direccion;
        }

        // Alterna entre mostrar y ocultar el contenido de los dos campos de contraseña
        private void chkVerClave_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
            txtConfirmarContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
        }

        // Marca (o limpia) el error de un control puntual y actualiza el estado general
        // del formulario, sin cortar la ejecución. Así se revisan todos los campos de una.
        private void Marcar(Control control, bool condicionValida, string mensajeError)
        {
            if (condicionValida)
            {
                errorProvider.SetError(control, string.Empty);
                controlesInvalidos.Remove(control);
            }
            else
            {
                errorProvider.SetError(control, mensajeError);
                formularioValido = false;
                if (!controlesInvalidos.Contains(control))
                {
                    controlesInvalidos.Add(control);
                }
            }
        }

        // De todos los controles marcados como inválidos, devuelve el que corresponde
        // según el orden de tabulación (TabIndex) del formulario, no el orden del código.
        private void EnfocarPrimerInvalidoPorTabOrder()
        {
            Control primero = controlesInvalidos.OrderBy(c => c.TabIndex).FirstOrDefault();
            primero?.Focus();
        }

        // ---------- Validación por campo: la UI arma el mensaje y prende/apaga el ícono,
        // pero quién decide si el valor es válido es siempre UsuarioServicio (capa de Negocio) ----------

        private bool ValidarNombre()
        {
            string valor = txtNombre.Text.Trim();
            bool ok = servicio.EsNombreValido(valor);
            Marcar(txtNombre, ok, "El nombre es obligatorio y solo puede contener letras.");
            return ok;
        }

        private bool ValidarApellido()
        {
            string valor = txtApellido.Text.Trim();
            bool ok = servicio.EsApellidoValido(valor);
            Marcar(txtApellido, ok, "El apellido es obligatorio y solo puede contener letras.");
            return ok;
        }

        private bool ValidarDni()
        {
            string valor = txtDni.Text.Trim();
            if (!servicio.EsDniValido(valor))
            {
                Marcar(txtDni, false, "El DNI es obligatorio y debe tener entre 7 y 8 números, sin letras ni puntos.");
                return false;
            }

            bool disponible = servicio.DniDisponible(valor);
            Marcar(txtDni, disponible, "El DNI ya se encuentra registrado.");
            return disponible;
        }

        private bool ValidarFechaNacimiento()
        {
            bool ok = servicio.EsFechaNacimientoValida(dtpFechaNacimiento.Value);
            Marcar(dtpFechaNacimiento, ok, $"La fecha no puede ser futura y el usuario debe ser mayor de {edadRequerida} años.");
            return ok;
        }

        private bool ValidarCalle()
        {
            bool ok = servicio.EsCalleValida(txtCalle.Text.Trim());
            Marcar(txtCalle, ok, "Debe ingresar la calle.");
            return ok;
        }

        private bool ValidarAltura()
        {
            bool ok = servicio.EsAlturaValida(txtAltura.Text.Trim());
            Marcar(txtAltura, ok, "El número de altura es obligatorio y debe ser numérico.");
            return ok;
        }

        private bool ValidarLocalidad()
        {
            bool ok = servicio.EsLocalidadValida(txtLocalidad.Text.Trim());
            Marcar(txtLocalidad, ok, "Debe ingresar la localidad.");
            return ok;
        }

        private bool ValidarUsuario()
        {
            string valor = txtUsuario.Text.Trim();
            if (!servicio.EsNombreUsuarioValido(valor))
            {
                Marcar(txtUsuario, false, "El nombre de usuario es obligatorio y debe tener al menos 4 caracteres.");
                return false;
            }

            bool disponible = servicio.NombreUsuarioDisponible(valor);
            Marcar(txtUsuario, disponible, "El nombre de usuario ya se encuentra registrado.");
            return disponible;
        }

        private bool ValidarEmail()
        {
            string valor = txtEmail.Text.Trim();
            if (!servicio.EsEmailValido(valor))
            {
                Marcar(txtEmail, false, "Debe ingresar un email con formato válido.");
                return false;
            }

            bool disponible = servicio.EmailDisponible(valor);
            Marcar(txtEmail, disponible, "El email ya se encuentra registrado.");
            return disponible;
        }

        private bool ValidarContrasena()
        {
            bool ok = servicio.EsContrasenaValida(txtContrasena.Text);
            Marcar(txtContrasena, ok, "La contraseña es obligatoria y debe tener al menos 6 caracteres.");
            return ok;
        }

        private bool ValidarConfirmarContrasena()
        {
            bool ok = txtContrasena.Text == txtConfirmarContrasena.Text;
            Marcar(txtConfirmarContrasena, ok, "Las contraseñas no coinciden.");
            return ok;
        }

        private bool ValidarRol()
        {
            bool ok = cmbRol.SelectedValue != null;
            Marcar(cmbRol, ok, "Debe seleccionar un rol.");
            return ok;
        }

        // ---------- Eventos Leave / Changed que disparan la revalidación de cada campo ----------

        private void txtNombre_Leave(object sender, EventArgs e) => ValidarNombre();
        private void txtApellido_Leave(object sender, EventArgs e) => ValidarApellido();
        private void txtDni_Leave(object sender, EventArgs e) => ValidarDni();
        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e) => ValidarFechaNacimiento();
        private void txtCalle_Leave(object sender, EventArgs e) => ValidarCalle();
        private void txtAltura_Leave(object sender, EventArgs e) => ValidarAltura();
        private void txtLocalidad_Leave(object sender, EventArgs e) => ValidarLocalidad();
        private void txtUsuario_Leave(object sender, EventArgs e) => ValidarUsuario();
        private void txtEmail_Leave(object sender, EventArgs e) => ValidarEmail();
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e) => ValidarRol();

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            ValidarContrasena();

            // Si ya había algo cargado en "Repetir", revisamos que siga coincidiendo.
            if (!string.IsNullOrEmpty(txtConfirmarContrasena.Text))
            {
                ValidarConfirmarContrasena();
            }
        }

        private void txtConfirmarContrasena_Leave(object sender, EventArgs e) => ValidarConfirmarContrasena();

        // ---------- Guardar ----------

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            formularioValido = true;
            controlesInvalidos.Clear();

            ValidarNombre();
            ValidarApellido();
            ValidarDni();
            ValidarFechaNacimiento();
            ValidarCalle();
            ValidarAltura();
            ValidarLocalidad();
            ValidarUsuario();
            ValidarEmail();
            ValidarContrasena();
            ValidarConfirmarContrasena();
            ValidarRol();

            if (!formularioValido)
            {
                EnfocarPrimerInvalidoPorTabOrder();
                return;
            }

            // Armamos la entidad con lo que hay en pantalla. De acá para abajo,
            // el formulario no vuelve a tocar ninguna regla de negocio ni SQL.
            Usuario usuario = new Usuario
            {
                NombreUsuario = txtUsuario.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                IdRol = (int)cmbRol.SelectedValue,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Calle = txtCalle.Text.Trim(),
                Altura = txtAltura.Text.Trim(),
                Dpto = txtDpto.Text.Trim(),
                Localidad = txtLocalidad.Text.Trim()
            };

            try
            {
                servicio.Registrar(usuario, txtContrasena.Text);

                MessageBox.Show("Usuario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}