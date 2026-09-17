namespace HardAdmin
{
    partial class FormModificarUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbActivoNo = new System.Windows.Forms.RadioButton();
            this.rbActivoSi = new System.Windows.Forms.RadioButton();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.grpDireccion = new System.Windows.Forms.GroupBox();
            this.txtDireccionCompleta = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblDpto = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.gbCredenciales = new System.Windows.Forms.GroupBox();
            this.chkCambiarClave = new System.Windows.Forms.CheckBox();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.chkVerClave = new System.Windows.Forms.CheckBox();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            this.grpDireccion.SuspendLayout();
            this.gbCredenciales.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbActivoNo
            // 
            this.rbActivoNo.AutoSize = true;
            this.rbActivoNo.Location = new System.Drawing.Point(125, 148);
            this.rbActivoNo.Name = "rbActivoNo";
            this.rbActivoNo.Size = new System.Drawing.Size(41, 19);
            this.rbActivoNo.TabIndex = 10;
            this.rbActivoNo.TabStop = true;
            this.rbActivoNo.Text = "No";
            this.rbActivoNo.UseVisualStyleBackColor = true;
            // 
            // rbActivoSi
            // 
            this.rbActivoSi.AutoSize = true;
            this.rbActivoSi.Location = new System.Drawing.Point(70, 148);
            this.rbActivoSi.Name = "rbActivoSi";
            this.rbActivoSi.Size = new System.Drawing.Size(34, 19);
            this.rbActivoSi.TabIndex = 9;
            this.rbActivoSi.TabStop = true;
            this.rbActivoSi.Text = "Sí";
            this.rbActivoSi.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(15, 150);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(44, 15);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Activo:";
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(564, 50);
            this.pnlTitulo.TabIndex = 10;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(182, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(198, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Modificar Usuario";
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.dtpFechaNacimiento);
            this.gbDatosPersonales.Controls.Add(this.txtDni);
            this.gbDatosPersonales.Controls.Add(this.txtApellido);
            this.gbDatosPersonales.Controls.Add(this.txtNombre);
            this.gbDatosPersonales.Controls.Add(this.lblFechaNac);
            this.gbDatosPersonales.Controls.Add(this.lblDni);
            this.gbDatosPersonales.Controls.Add(this.lblApellido);
            this.gbDatosPersonales.Controls.Add(this.lblNombre);
            this.gbDatosPersonales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosPersonales.Location = new System.Drawing.Point(15, 75);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(530, 115);
            this.gbDatosPersonales.TabIndex = 11;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Datos Personales";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(340, 70);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(165, 23);
            this.dtpFechaNacimiento.TabIndex = 3;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(85, 30);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(165, 23);
            this.txtDni.TabIndex = 0;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(340, 30);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(165, 23);
            this.txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(85, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(165, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(270, 73);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(72, 15);
            this.lblFechaNac.TabIndex = 3;
            this.lblFechaNac.Text = "Nacimiento:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(15, 33);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(30, 15);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(270, 33);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(54, 15);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(15, 73);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // grpDireccion
            // 
            this.grpDireccion.Controls.Add(this.txtDireccionCompleta);
            this.grpDireccion.Controls.Add(this.lblDireccion);
            this.grpDireccion.Controls.Add(this.txtLocalidad);
            this.grpDireccion.Controls.Add(this.txtDpto);
            this.grpDireccion.Controls.Add(this.txtAltura);
            this.grpDireccion.Controls.Add(this.txtCalle);
            this.grpDireccion.Controls.Add(this.lblLocalidad);
            this.grpDireccion.Controls.Add(this.lblDpto);
            this.grpDireccion.Controls.Add(this.lblAltura);
            this.grpDireccion.Controls.Add(this.lblCalle);
            this.grpDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDireccion.Location = new System.Drawing.Point(15, 200);
            this.grpDireccion.Name = "grpDireccion";
            this.grpDireccion.Size = new System.Drawing.Size(530, 155);
            this.grpDireccion.TabIndex = 12;
            this.grpDireccion.TabStop = false;
            this.grpDireccion.Text = "Dirección";
            // 
            // txtDireccionCompleta
            // 
            this.txtDireccionCompleta.Location = new System.Drawing.Point(85, 110);
            this.txtDireccionCompleta.Name = "txtDireccionCompleta";
            this.txtDireccionCompleta.ReadOnly = true;
            this.txtDireccionCompleta.Size = new System.Drawing.Size(420, 23);
            this.txtDireccionCompleta.TabIndex = 4;
            this.txtDireccionCompleta.TabStop = false;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(15, 113);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(60, 15);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(85, 70);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(220, 23);
            this.txtLocalidad.TabIndex = 7;
            // 
            // txtDpto
            // 
            this.txtDpto.Location = new System.Drawing.Point(465, 30);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.Size = new System.Drawing.Size(40, 23);
            this.txtDpto.TabIndex = 6;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(350, 30);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(60, 23);
            this.txtAltura.TabIndex = 5;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(85, 30);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(220, 23);
            this.txtCalle.TabIndex = 4;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(15, 73);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(61, 15);
            this.lblLocalidad.TabIndex = 3;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // lblDpto
            // 
            this.lblDpto.AutoSize = true;
            this.lblDpto.Location = new System.Drawing.Point(425, 33);
            this.lblDpto.Name = "lblDpto";
            this.lblDpto.Size = new System.Drawing.Size(36, 15);
            this.lblDpto.TabIndex = 2;
            this.lblDpto.Text = "Dpto:";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltura.Location = new System.Drawing.Point(325, 33);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(24, 15);
            this.lblAltura.TabIndex = 1;
            this.lblAltura.Text = "N°:";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(15, 33);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(36, 15);
            this.lblCalle.TabIndex = 0;
            this.lblCalle.Text = "Calle:";
            // 
            // gbCredenciales
            // 
            this.gbCredenciales.Controls.Add(this.chkCambiarClave);
            this.gbCredenciales.Controls.Add(this.txtConfirmarContrasena);
            this.gbCredenciales.Controls.Add(this.chkVerClave);
            this.gbCredenciales.Controls.Add(this.lblConfirmar);
            this.gbCredenciales.Controls.Add(this.rbActivoNo);
            this.gbCredenciales.Controls.Add(this.cmbRol);
            this.gbCredenciales.Controls.Add(this.txtContrasena);
            this.gbCredenciales.Controls.Add(this.rbActivoSi);
            this.gbCredenciales.Controls.Add(this.lblEstado);
            this.gbCredenciales.Controls.Add(this.txtEmail);
            this.gbCredenciales.Controls.Add(this.txtUsuario);
            this.gbCredenciales.Controls.Add(this.lblRol);
            this.gbCredenciales.Controls.Add(this.lblEmail);
            this.gbCredenciales.Controls.Add(this.lblUsuario);
            this.gbCredenciales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCredenciales.Location = new System.Drawing.Point(15, 370);
            this.gbCredenciales.Name = "gbCredenciales";
            this.gbCredenciales.Size = new System.Drawing.Size(530, 185);
            this.gbCredenciales.TabIndex = 13;
            this.gbCredenciales.TabStop = false;
            this.gbCredenciales.Text = "Credenciales de Acceso";
            // 
            // chkCambiarClave
            // 
            this.chkCambiarClave.AutoSize = true;
            this.chkCambiarClave.Location = new System.Drawing.Point(15, 113);
            this.chkCambiarClave.Name = "chkCambiarClave";
            this.chkCambiarClave.Size = new System.Drawing.Size(104, 19);
            this.chkCambiarClave.TabIndex = 14;
            this.chkCambiarClave.Text = "Cambiar clave:";
            this.chkCambiarClave.UseVisualStyleBackColor = true;
            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.Enabled = false;
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(355, 110);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(150, 23);
            this.txtConfirmarContrasena.TabIndex = 12;
            this.txtConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // chkVerClave
            // 
            this.chkVerClave.AutoSize = true;
            this.chkVerClave.Enabled = false;
            this.chkVerClave.Location = new System.Drawing.Point(345, 148);
            this.chkVerClave.Name = "chkVerClave";
            this.chkVerClave.Size = new System.Drawing.Size(135, 19);
            this.chkVerClave.TabIndex = 13;
            this.chkVerClave.Text = "Mostrar Contraseñas";
            this.chkVerClave.UseVisualStyleBackColor = true;
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.AutoSize = true;
            this.lblConfirmar.Location = new System.Drawing.Point(305, 113);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Size = new System.Drawing.Size(47, 15);
            this.lblConfirmar.TabIndex = 4;
            this.lblConfirmar.Text = "Repetir:";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(355, 30);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(150, 23);
            this.cmbRol.TabIndex = 9;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Enabled = false;
            this.txtContrasena.Location = new System.Drawing.Point(135, 110);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(150, 23);
            this.txtContrasena.TabIndex = 11;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(135, 70);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(370, 23);
            this.txtEmail.TabIndex = 10;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(135, 30);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(150, 23);
            this.txtUsuario.TabIndex = 8;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(305, 33);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(27, 15);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "Rol:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(15, 73);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(15, 33);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 15);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(340, 565);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 35);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(450, 565);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 35);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormModificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 611);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbCredenciales);
            this.Controls.Add(this.grpDireccion);
            this.Controls.Add(this.gbDatosPersonales);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModificarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HardAdmin - Modificar Usuario";
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.grpDireccion.ResumeLayout(false);
            this.grpDireccion.PerformLayout();
            this.gbCredenciales.ResumeLayout(false);
            this.gbCredenciales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.RadioButton rbActivoSi;
        private System.Windows.Forms.RadioButton rbActivoNo;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox grpDireccion;
        private System.Windows.Forms.TextBox txtDireccionCompleta;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblDpto;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.GroupBox gbCredenciales;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.CheckBox chkVerClave;
        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkCambiarClave;
    }
}