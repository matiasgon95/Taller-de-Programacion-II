namespace HardAdmin
{
    partial class FormModificarCliente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbActivoNo = new System.Windows.Forms.RadioButton();
            this.rbActivoSi = new System.Windows.Forms.RadioButton();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtPisoDpto = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.labActivo = new System.Windows.Forms.Label();
            this.labCodigoPostal = new System.Windows.Forms.Label();
            this.labCiudad = new System.Windows.Forms.Label();
            this.labDireccion = new System.Windows.Forms.Label();
            this.labPisoDpto = new System.Windows.Forms.Label();
            this.labNumero = new System.Windows.Forms.Label();
            this.labCalle = new System.Windows.Forms.Label();
            this.labEmail = new System.Windows.Forms.Label();
            this.labTelefono = new System.Windows.Forms.Label();
            this.labDNI = new System.Windows.Forms.Label();
            this.labNombre = new System.Windows.Forms.Label();
            this.labApellido = new System.Windows.Forms.Label();
            this.labDatos = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.gbContacto = new System.Windows.Forms.GroupBox();
            this.gbDireccion = new System.Windows.Forms.GroupBox();
            this.gbEstado = new System.Windows.Forms.GroupBox();
            this.pnlTitulo.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            this.gbContacto.SuspendLayout();
            this.gbDireccion.SuspendLayout();
            this.gbEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modificar Cliente";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 99;
            this.panel1.Visible = false;
            // 
            // rbActivoNo
            // 
            this.rbActivoNo.AutoSize = true;
            this.rbActivoNo.Location = new System.Drawing.Point(125, 28);
            this.rbActivoNo.Name = "rbActivoNo";
            this.rbActivoNo.Size = new System.Drawing.Size(41, 19);
            this.rbActivoNo.TabIndex = 11;
            this.rbActivoNo.TabStop = true;
            this.rbActivoNo.Text = "No";
            this.rbActivoNo.UseVisualStyleBackColor = true;
            // 
            // rbActivoSi
            // 
            this.rbActivoSi.AutoSize = true;
            this.rbActivoSi.Location = new System.Drawing.Point(75, 28);
            this.rbActivoSi.Name = "rbActivoSi";
            this.rbActivoSi.Size = new System.Drawing.Size(34, 19);
            this.rbActivoSi.TabIndex = 10;
            this.rbActivoSi.TabStop = true;
            this.rbActivoSi.Text = "Sí";
            this.rbActivoSi.UseVisualStyleBackColor = true;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(320, 110);
            this.txtCodigoPostal.MaxLength = 5;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(70, 23);
            this.txtCodigoPostal.TabIndex = 9;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(70, 110);
            this.txtCiudad.MaxLength = 50;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(200, 23);
            this.txtCiudad.TabIndex = 8;
            this.txtCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCiudad_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(80, 70);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(405, 23);
            this.txtDireccion.TabIndex = 21;
            this.txtDireccion.TabStop = false;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // txtPisoDpto
            // 
            this.txtPisoDpto.Location = new System.Drawing.Point(415, 30);
            this.txtPisoDpto.MaxLength = 5;
            this.txtPisoDpto.Name = "txtPisoDpto";
            this.txtPisoDpto.Size = new System.Drawing.Size(70, 23);
            this.txtPisoDpto.TabIndex = 7;
            this.txtPisoDpto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPisoDpto_KeyPress);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(280, 30);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(50, 23);
            this.txtNumero.TabIndex = 6;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(55, 30);
            this.txtCalle.MaxLength = 10;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(150, 23);
            this.txtCalle.TabIndex = 5;
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalle_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(60, 30);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(335, 30);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(150, 23);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(395, 30);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(90, 23);
            this.txtDNI.TabIndex = 2;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(75, 30);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 23);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(245, 30);
            this.txtApellido.MaxLength = 30;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 23);
            this.txtApellido.TabIndex = 1;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // labActivo
            // 
            this.labActivo.AutoSize = true;
            this.labActivo.Location = new System.Drawing.Point(15, 30);
            this.labActivo.Name = "labActivo";
            this.labActivo.Size = new System.Drawing.Size(44, 15);
            this.labActivo.TabIndex = 12;
            this.labActivo.Text = "Activo:";
            // 
            // labCodigoPostal
            // 
            this.labCodigoPostal.AutoSize = true;
            this.labCodigoPostal.Location = new System.Drawing.Point(290, 113);
            this.labCodigoPostal.Name = "labCodigoPostal";
            this.labCodigoPostal.Size = new System.Drawing.Size(25, 15);
            this.labCodigoPostal.TabIndex = 11;
            this.labCodigoPostal.Text = "CP:";
            // 
            // labCiudad
            // 
            this.labCiudad.AutoSize = true;
            this.labCiudad.Location = new System.Drawing.Point(15, 113);
            this.labCiudad.Name = "labCiudad";
            this.labCiudad.Size = new System.Drawing.Size(48, 15);
            this.labCiudad.TabIndex = 10;
            this.labCiudad.Text = "Ciudad:";
            // 
            // labDireccion
            // 
            this.labDireccion.AutoSize = true;
            this.labDireccion.Location = new System.Drawing.Point(15, 73);
            this.labDireccion.Name = "labDireccion";
            this.labDireccion.Size = new System.Drawing.Size(60, 15);
            this.labDireccion.TabIndex = 9;
            this.labDireccion.Text = "Dirección:";
            // 
            // labPisoDpto
            // 
            this.labPisoDpto.AutoSize = true;
            this.labPisoDpto.Location = new System.Drawing.Point(345, 33);
            this.labPisoDpto.Name = "labPisoDpto";
            this.labPisoDpto.Size = new System.Drawing.Size(63, 15);
            this.labPisoDpto.TabIndex = 8;
            this.labPisoDpto.Text = "Piso/Dpto:";
            // 
            // labNumero
            // 
            this.labNumero.AutoSize = true;
            this.labNumero.Location = new System.Drawing.Point(220, 33);
            this.labNumero.Name = "labNumero";
            this.labNumero.Size = new System.Drawing.Size(54, 15);
            this.labNumero.TabIndex = 7;
            this.labNumero.Text = "Número:";
            // 
            // labCalle
            // 
            this.labCalle.AutoSize = true;
            this.labCalle.Location = new System.Drawing.Point(15, 33);
            this.labCalle.Name = "labCalle";
            this.labCalle.Size = new System.Drawing.Size(36, 15);
            this.labCalle.TabIndex = 6;
            this.labCalle.Text = "Calle:";
            this.labCalle.Click += new System.EventHandler(this.labCalle_Click);
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.Location = new System.Drawing.Point(15, 33);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(39, 15);
            this.labEmail.TabIndex = 5;
            this.labEmail.Text = "Email:";
            this.labEmail.Click += new System.EventHandler(this.labEmail_Click);
            // 
            // labTelefono
            // 
            this.labTelefono.AutoSize = true;
            this.labTelefono.Location = new System.Drawing.Point(280, 33);
            this.labTelefono.Name = "labTelefono";
            this.labTelefono.Size = new System.Drawing.Size(47, 15);
            this.labTelefono.TabIndex = 4;
            this.labTelefono.Text = "Tel/Cel:";
            // 
            // labDNI
            // 
            this.labDNI.AutoSize = true;
            this.labDNI.Location = new System.Drawing.Point(360, 33);
            this.labDNI.Name = "labDNI";
            this.labDNI.Size = new System.Drawing.Size(30, 15);
            this.labDNI.TabIndex = 3;
            this.labDNI.Text = "DNI:";
            // 
            // labNombre
            // 
            this.labNombre.AutoSize = true;
            this.labNombre.Location = new System.Drawing.Point(15, 33);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(54, 15);
            this.labNombre.TabIndex = 2;
            this.labNombre.Text = "Nombre:";
            // 
            // labApellido
            // 
            this.labApellido.AutoSize = true;
            this.labApellido.Location = new System.Drawing.Point(185, 33);
            this.labApellido.Name = "labApellido";
            this.labApellido.Size = new System.Drawing.Size(54, 15);
            this.labApellido.TabIndex = 1;
            this.labApellido.Text = "Apellido:";
            // 
            // labDatos
            // 
            this.labDatos.Location = new System.Drawing.Point(0, 0);
            this.labDatos.Name = "labDatos";
            this.labDatos.Size = new System.Drawing.Size(0, 0);
            this.labDatos.TabIndex = 98;
            this.labDatos.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(310, 480);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 35);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(410, 480);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 35);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(534, 50);
            this.pnlTitulo.TabIndex = 10;
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.labNombre);
            this.gbDatosPersonales.Controls.Add(this.txtNombre);
            this.gbDatosPersonales.Controls.Add(this.labApellido);
            this.gbDatosPersonales.Controls.Add(this.txtApellido);
            this.gbDatosPersonales.Controls.Add(this.labDNI);
            this.gbDatosPersonales.Controls.Add(this.txtDNI);
            this.gbDatosPersonales.Location = new System.Drawing.Point(15, 60);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(500, 75);
            this.gbDatosPersonales.TabIndex = 0;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Datos Personales";
            // 
            // gbContacto
            // 
            this.gbContacto.Controls.Add(this.labEmail);
            this.gbContacto.Controls.Add(this.txtEmail);
            this.gbContacto.Controls.Add(this.labTelefono);
            this.gbContacto.Controls.Add(this.txtTelefono);
            this.gbContacto.Location = new System.Drawing.Point(15, 145);
            this.gbContacto.Name = "gbContacto";
            this.gbContacto.Size = new System.Drawing.Size(500, 75);
            this.gbContacto.TabIndex = 1;
            this.gbContacto.TabStop = false;
            this.gbContacto.Text = "Contacto";
            // 
            // gbDireccion
            // 
            this.gbDireccion.Controls.Add(this.labCalle);
            this.gbDireccion.Controls.Add(this.txtCalle);
            this.gbDireccion.Controls.Add(this.labNumero);
            this.gbDireccion.Controls.Add(this.txtNumero);
            this.gbDireccion.Controls.Add(this.labPisoDpto);
            this.gbDireccion.Controls.Add(this.txtPisoDpto);
            this.gbDireccion.Controls.Add(this.labDireccion);
            this.gbDireccion.Controls.Add(this.txtDireccion);
            this.gbDireccion.Controls.Add(this.labCiudad);
            this.gbDireccion.Controls.Add(this.txtCiudad);
            this.gbDireccion.Controls.Add(this.labCodigoPostal);
            this.gbDireccion.Controls.Add(this.txtCodigoPostal);
            this.gbDireccion.Location = new System.Drawing.Point(15, 230);
            this.gbDireccion.Name = "gbDireccion";
            this.gbDireccion.Size = new System.Drawing.Size(500, 155);
            this.gbDireccion.TabIndex = 2;
            this.gbDireccion.TabStop = false;
            this.gbDireccion.Text = "Dirección";
            // 
            // gbEstado
            // 
            this.gbEstado.Controls.Add(this.labActivo);
            this.gbEstado.Controls.Add(this.rbActivoSi);
            this.gbEstado.Controls.Add(this.rbActivoNo);
            this.gbEstado.Location = new System.Drawing.Point(15, 395);
            this.gbEstado.Name = "gbEstado";
            this.gbEstado.Size = new System.Drawing.Size(500, 65);
            this.gbEstado.TabIndex = 3;
            this.gbEstado.TabStop = false;
            this.gbEstado.Text = "Estado";
            // 
            // FormModificarCliente
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(534, 531);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbEstado);
            this.Controls.Add(this.gbDireccion);
            this.Controls.Add(this.gbContacto);
            this.Controls.Add(this.gbDatosPersonales);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModificarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HardAdmin - Modificar Cliente";
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.gbContacto.ResumeLayout(false);
            this.gbContacto.PerformLayout();
            this.gbDireccion.ResumeLayout(false);
            this.gbDireccion.PerformLayout();
            this.gbEstado.ResumeLayout(false);
            this.gbEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.Label labApellido;
        private System.Windows.Forms.Label labDatos;
        private System.Windows.Forms.Label labEmail;
        private System.Windows.Forms.Label labTelefono;
        private System.Windows.Forms.Label labDNI;
        private System.Windows.Forms.Label labCalle;
        private System.Windows.Forms.Label labDireccion;
        private System.Windows.Forms.Label labPisoDpto;
        private System.Windows.Forms.Label labNumero;
        private System.Windows.Forms.TextBox txtPisoDpto;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label labActivo;
        private System.Windows.Forms.Label labCodigoPostal;
        private System.Windows.Forms.Label labCiudad;
        private System.Windows.Forms.RadioButton rbActivoSi;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.RadioButton rbActivoNo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        
        // Contenedores nuevos
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private System.Windows.Forms.GroupBox gbContacto;
        private System.Windows.Forms.GroupBox gbDireccion;
        private System.Windows.Forms.GroupBox gbEstado;
    }
}