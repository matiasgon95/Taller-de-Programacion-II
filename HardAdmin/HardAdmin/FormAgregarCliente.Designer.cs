namespace HardAdmin
{
    partial class FormAgregarCliente
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
            this.labTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.labDatos = new System.Windows.Forms.Label();
            this.labCodigoPostal = new System.Windows.Forms.Label();
            this.labCiudad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labNumeroCalle = new System.Windows.Forms.Label();
            this.labCalle = new System.Windows.Forms.Label();
            this.labEmail = new System.Windows.Forms.Label();
            this.labTelefono = new System.Windows.Forms.Label();
            this.labDNI = new System.Windows.Forms.Label();
            this.labNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.gbContacto = new System.Windows.Forms.GroupBox();
            this.gbDireccion = new System.Windows.Forms.GroupBox();
            this.pnlTitulo.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            this.gbContacto.SuspendLayout();
            this.gbDireccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTitulo
            // 
            this.labTitulo.AutoSize = true;
            this.labTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitulo.Location = new System.Drawing.Point(175, 9);
            this.labTitulo.Name = "labTitulo";
            this.labTitulo.Size = new System.Drawing.Size(158, 30);
            this.labTitulo.TabIndex = 0;
            this.labTitulo.Text = "Nuevo Cliente";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 99;
            this.panel1.Visible = false;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(320, 110);
            this.txtCodigoPostal.MaxLength = 5;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(70, 23);
            this.txtCodigoPostal.TabIndex = 9;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(70, 110);
            this.txtCiudad.MaxLength = 50;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(200, 23);
            this.txtCiudad.TabIndex = 8;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(80, 70);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(405, 23);
            this.txtDireccion.TabIndex = 8;
            this.txtDireccion.TabStop = false;
            // 
            // txtPisoDpto
            // 
            this.txtPisoDpto.Location = new System.Drawing.Point(415, 30);
            this.txtPisoDpto.MaxLength = 5;
            this.txtPisoDpto.Name = "txtPisoDpto";
            this.txtPisoDpto.Size = new System.Drawing.Size(70, 23);
            this.txtPisoDpto.TabIndex = 7;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(280, 30);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(50, 23);
            this.txtNumero.TabIndex = 6;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(55, 30);
            this.txtCalle.MaxLength = 10;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(150, 23);
            this.txtCalle.TabIndex = 5;
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
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(395, 30);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(90, 23);
            this.txtDNI.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(75, 30);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 23);
            this.txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(245, 30);
            this.txtApellido.MaxLength = 30;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 23);
            this.txtApellido.TabIndex = 1;
            // 
            // labDatos
            // 
            this.labDatos.Location = new System.Drawing.Point(0, 0);
            this.labDatos.Name = "labDatos";
            this.labDatos.Size = new System.Drawing.Size(0, 0);
            this.labDatos.TabIndex = 98;
            this.labDatos.Visible = false;
            // 
            // labCodigoPostal
            // 
            this.labCodigoPostal.AutoSize = true;
            this.labCodigoPostal.Location = new System.Drawing.Point(290, 113);
            this.labCodigoPostal.Name = "labCodigoPostal";
            this.labCodigoPostal.Size = new System.Drawing.Size(25, 15);
            this.labCodigoPostal.TabIndex = 10;
            this.labCodigoPostal.Text = "CP:";
            // 
            // labCiudad
            // 
            this.labCiudad.AutoSize = true;
            this.labCiudad.Location = new System.Drawing.Point(15, 113);
            this.labCiudad.Name = "labCiudad";
            this.labCiudad.Size = new System.Drawing.Size(48, 15);
            this.labCiudad.TabIndex = 9;
            this.labCiudad.Text = "Ciudad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dirección:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Piso/Dpto:";
            // 
            // labNumeroCalle
            // 
            this.labNumeroCalle.AutoSize = true;
            this.labNumeroCalle.Location = new System.Drawing.Point(220, 33);
            this.labNumeroCalle.Name = "labNumeroCalle";
            this.labNumeroCalle.Size = new System.Drawing.Size(54, 15);
            this.labNumeroCalle.TabIndex = 6;
            this.labNumeroCalle.Text = "Número:";
            // 
            // labCalle
            // 
            this.labCalle.AutoSize = true;
            this.labCalle.Location = new System.Drawing.Point(15, 33);
            this.labCalle.Name = "labCalle";
            this.labCalle.Size = new System.Drawing.Size(36, 15);
            this.labCalle.TabIndex = 5;
            this.labCalle.Text = "Calle:";
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.Location = new System.Drawing.Point(15, 33);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(39, 15);
            this.labEmail.TabIndex = 4;
            this.labEmail.Text = "Email:";
            // 
            // labTelefono
            // 
            this.labTelefono.AutoSize = true;
            this.labTelefono.Location = new System.Drawing.Point(280, 33);
            this.labTelefono.Name = "labTelefono";
            this.labTelefono.Size = new System.Drawing.Size(47, 15);
            this.labTelefono.TabIndex = 3;
            this.labTelefono.Text = "Tel/Cel:";
            // 
            // labDNI
            // 
            this.labDNI.AutoSize = true;
            this.labDNI.Location = new System.Drawing.Point(360, 33);
            this.labDNI.Name = "labDNI";
            this.labDNI.Size = new System.Drawing.Size(30, 15);
            this.labDNI.TabIndex = 2;
            this.labDNI.Text = "DNI:";
            // 
            // labNombre
            // 
            this.labNombre.AutoSize = true;
            this.labNombre.Location = new System.Drawing.Point(15, 33);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(54, 15);
            this.labNombre.TabIndex = 1;
            this.labNombre.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellido:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(310, 410);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 35);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(410, 410);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 35);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.labTitulo);
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
            this.gbDatosPersonales.Controls.Add(this.label1);
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
            this.gbDireccion.Controls.Add(this.labNumeroCalle);
            this.gbDireccion.Controls.Add(this.txtNumero);
            this.gbDireccion.Controls.Add(this.label2);
            this.gbDireccion.Controls.Add(this.txtPisoDpto);
            this.gbDireccion.Controls.Add(this.label3);
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
            // FormAgregarCliente
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(534, 465);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
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
            this.Name = "FormAgregarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HardAdmin - Agregar Cliente";
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.gbContacto.ResumeLayout(false);
            this.gbContacto.PerformLayout();
            this.gbDireccion.ResumeLayout(false);
            this.gbDireccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labTelefono;
        private System.Windows.Forms.Label labDNI;
        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labCodigoPostal;
        private System.Windows.Forms.Label labCiudad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labNumeroCalle;
        private System.Windows.Forms.Label labCalle;
        private System.Windows.Forms.Label labEmail;
        private System.Windows.Forms.Label labDatos;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtPisoDpto;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        // Contenedores estéticos 
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private System.Windows.Forms.GroupBox gbContacto;
        private System.Windows.Forms.GroupBox gbDireccion;
    }
}