using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HardAdmin.Entidades;
using HardAdmin.Negocio;

namespace HardAdmin
{
    public partial class FormModificarUsuario : Form
    {
        private UsuarioServicio servicio = new UsuarioServicio();
        private int idUsuario;
        private const int edadRequerida = UsuarioServicio.EDAD_MINIMA;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        public FormModificarUsuario(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtNombre.KeyPress += Validaciones.SoloLetras_KeyPress;
            txtApellido.KeyPress += Validaciones.SoloLetras_KeyPress;
            txtNombre.Leave += Validaciones.CapitalizarTexto_Leave;
            txtApellido.Leave += Validaciones.CapitalizarTexto_Leave;

            txtDni.KeyPress += Validaciones.SoloNumeros_KeyPress;
            txtDni.MaxLength = 8;
            txtAltura.KeyPress += Validaciones.SoloNumeros_KeyPress;

            dtpFechaNacimiento.MaxDate = DateTime.Today;

            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtCalle.MaxLength = 100;
            txtDpto.MaxLength = 10;
            txtLocalidad.MaxLength = 100;
            txtAltura.MaxLength = 20;
            txtUsuario.MaxLength = 50;
            txtEmail.MaxLength = 100;

            txtCalle.TextChanged += ActualizarDireccionCompleta;
            txtAltura.TextChanged += ActualizarDireccionCompleta;
            txtDpto.TextChanged += ActualizarDireccionCompleta;
            txtLocalidad.TextChanged += ActualizarDireccionCompleta;

            chkCambiarClave.CheckedChanged += chkCambiarClave_CheckedChanged;
            chkVerClave.CheckedChanged += chkVerClave_CheckedChanged;

            txtNombre.Leave += txtNombre_Leave;
            txtApellido.Leave += txtApellido_Leave;
            txtDni.Leave += txtDni_Leave;
            dtpFechaNacimiento.ValueChanged += dtpFechaNacimiento_ValueChanged;
            txtCalle.Leave += txtCalle_Leave;
            txtAltura.Leave += txtAltura_Leave;
            txtLocalidad.Leave += txtLocalidad_Leave;
            txtUsuario.Leave += txtNombreUsuario_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtContrasena.Leave += txtContrasena_Leave;
            txtConfirmarContrasena.Leave += txtConfirmarContrasena_Leave;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;

            txtContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
            chkVerClave.Enabled = false;

            CargarRoles();
            CargarDatosUsuario();
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

        private void CargarDatosUsuario()
        {
            try
            {
                Usuario usuario = servicio.ObtenerPorId(this.idUsuario);

                if (usuario != null)
                {
                    txtUsuario.Text = usuario.NombreUsuario;
                    txtEmail.Text = usuario.Email;
                    cmbRol.SelectedValue = usuario.IdRol;

                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtDni.Text = usuario.Dni;
                    dtpFechaNacimiento.Value = usuario.FechaNacimiento;

                    txtCalle.Text = usuario.Calle;
                    txtAltura.Text = usuario.Altura;
                    txtDpto.Text = usuario.Dpto;
                    txtLocalidad.Text = usuario.Localidad;

                    if (usuario.Baja)
                        rbActivoNo.Checked = true;
                    else
                        rbActivoSi.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDireccionCompleta(object sender, EventArgs e)
        {
            string calle = txtCalle.Text.Trim();
            string altura = txtAltura.Text.Trim();
            string dpto = txtDpto.Text.Trim();
            string localidad = txtLocalidad.Text.Trim();

            string direccion = $"{calle} {altura}".Trim();
            if (!string.IsNullOrWhiteSpace(dpto)) direccion += $" Dpto {dpto}";
            if (!string.IsNullOrWhiteSpace(localidad))
            {
                direccion = direccion.Length > 0 ? direccion + $", {localidad}" : localidad;
            }
            txtDireccionCompleta.Text = direccion;
        }

        private void chkCambiarClave_CheckedChanged(object sender, EventArgs e)
        {
            bool cambiar = chkCambiarClave.Checked;
            txtContrasena.Enabled = cambiar;
            txtConfirmarContrasena.Enabled = cambiar;
            chkVerClave.Enabled = cambiar;

            if (!cambiar)
            {
                txtContrasena.Clear();
                txtConfirmarContrasena.Clear();
                chkVerClave.Checked = false;
                Marcar(txtContrasena, true, "");
                Marcar(txtConfirmarContrasena, true, "");
            }
        }

        private void chkVerClave_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
            txtConfirmarContrasena.UseSystemPasswordChar = !chkVerClave.Checked;
        }

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
                if (!controlesInvalidos.Contains(control)) controlesInvalidos.Add(control);
            }
        }

        private void EnfocarPrimerInvalidoPorTabOrder()
        {
            Control primero = controlesInvalidos.OrderBy(c => c.TabIndex).FirstOrDefault();
            primero?.Focus();
        }

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
                Marcar(txtDni, false, "El DNI es obligatorio y debe tener entre 7 y 8 números.");
                return false;
            }

            bool disponible = servicio.DniDisponible(valor, this.idUsuario);
            Marcar(txtDni, disponible, "El DNI ya se encuentra registrado en otro usuario.");
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
            string valor = txtAltura.Text.Trim();
            bool ok = servicio.EsAlturaValida(valor);
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

            bool disponible = servicio.NombreUsuarioDisponible(valor, this.idUsuario);
            Marcar(txtUsuario, disponible, "El nombre de usuario ya se encuentra registrado.");
            return disponible;
        }

        private bool ValidarEmail()
        {
            string valor = txtEmail.Text.Trim();
            if (!Validaciones.EsEmailValido(valor))
            {
                Marcar(txtEmail, false, "Debe ingresar un email con formato válido.");
                return false;
            }

            bool disponible = servicio.EmailDisponible(valor, this.idUsuario);
            Marcar(txtEmail, disponible, "El email ya se encuentra registrado en otro usuario.");
            return disponible;
        }

        private bool ValidarContrasena()
        {
            if (!chkCambiarClave.Checked) return true;

            bool ok = servicio.EsContrasenaValida(txtContrasena.Text);
            Marcar(txtContrasena, ok, "La contraseña debe tener al menos 6 caracteres.");
            return ok;
        }

        private bool ValidarConfirmarContrasena()
        {
            if (!chkCambiarClave.Checked) return true;

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

        private void txtNombre_Leave(object sender, EventArgs e) => ValidarNombre();
        private void txtApellido_Leave(object sender, EventArgs e) => ValidarApellido();
        private void txtDni_Leave(object sender, EventArgs e) => ValidarDni();
        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e) => ValidarFechaNacimiento();
        private void txtCalle_Leave(object sender, EventArgs e) => ValidarCalle();
        private void txtAltura_Leave(object sender, EventArgs e) => ValidarAltura();
        private void txtLocalidad_Leave(object sender, EventArgs e) => ValidarLocalidad();
        private void txtNombreUsuario_Leave(object sender, EventArgs e) => ValidarUsuario();
        private void txtEmail_Leave(object sender, EventArgs e) => ValidarEmail();
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e) => ValidarRol();

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (chkCambiarClave.Checked)
            {
                ValidarContrasena();
                if (!string.IsNullOrEmpty(txtConfirmarContrasena.Text))
                {
                    ValidarConfirmarContrasena();
                }
            }
        }

        private void txtConfirmarContrasena_Leave(object sender, EventArgs e) => ValidarConfirmarContrasena();

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

            try
            {
                Usuario usuarioEditado = new Usuario
                {
                    IdUsuario = this.idUsuario,
                    NombreUsuario = txtUsuario.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    IdRol = (int)cmbRol.SelectedValue,
                    Baja = rbActivoSi.Checked ? false : true,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = txtDni.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Value.Date,
                    Calle = txtCalle.Text.Trim(),
                    Altura = txtAltura.Text.Trim(),
                    Dpto = txtDpto.Text.Trim(),
                    Localidad = txtLocalidad.Text.Trim()
                };

                // Si no se marcó la casilla, enviamos null y la capa de negocio sabe que no debe actualizarla
                string nuevaClave = chkCambiarClave.Checked ? txtContrasena.Text : null;

                servicio.Modificar(usuarioEditado, nuevaClave);

                MessageBox.Show("Usuario modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}