namespace HardAdmin
{
    partial class FormAgregarCliente
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTitulo
            // 
            this.labTitulo.AutoSize = true;
            this.labTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitulo.Location = new System.Drawing.Point(165, 9);
            this.labTitulo.Name = "labTitulo";
            this.labTitulo.Size = new System.Drawing.Size(198, 31);
            this.labTitulo.TabIndex = 0;
            this.labTitulo.Text = "Nuevo Cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCodigoPostal);
            this.panel1.Controls.Add(this.txtCiudad);
            this.panel1.Controls.Add(this.txtDireccion);
            this.panel1.Controls.Add(this.txtPisoDpto);
            this.panel1.Controls.Add(this.txtNumero);
            this.panel1.Controls.Add(this.txtCalle);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.txtDNI);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.txtApellido);
            this.panel1.Controls.Add(this.labDatos);
            this.panel1.Controls.Add(this.labCodigoPostal);
            this.panel1.Controls.Add(this.labCiudad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labNumeroCalle);
            this.panel1.Controls.Add(this.labCalle);
            this.panel1.Controls.Add(this.labEmail);
            this.panel1.Controls.Add(this.labTelefono);
            this.panel1.Controls.Add(this.labDNI);
            this.panel1.Controls.Add(this.labNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(87, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 344);
            this.panel1.TabIndex = 1;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(192, 295);
            this.txtCodigoPostal.MaxLength = 5;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(129, 20);
            this.txtCodigoPostal.TabIndex = 22;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(192, 266);
            this.txtCiudad.MaxLength = 30;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(129, 20);
            this.txtCiudad.TabIndex = 21;
            this.txtCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCiudad_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(192, 239);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(129, 20);
            this.txtDireccion.TabIndex = 20;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // txtPisoDpto
            // 
            this.txtPisoDpto.Location = new System.Drawing.Point(192, 213);
            this.txtPisoDpto.MaxLength = 2;
            this.txtPisoDpto.Name = "txtPisoDpto";
            this.txtPisoDpto.Size = new System.Drawing.Size(129, 20);
            this.txtPisoDpto.TabIndex = 19;
            this.txtPisoDpto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPisoDpto_KeyPress);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(192, 188);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(129, 20);
            this.txtNumero.TabIndex = 18;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(192, 160);
            this.txtCalle.MaxLength = 10;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(129, 20);
            this.txtCalle.TabIndex = 17;
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalle_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(192, 136);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(129, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(192, 110);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(129, 20);
            this.txtTelefono.TabIndex = 15;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(192, 85);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(129, 20);
            this.txtDNI.TabIndex = 14;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(192, 59);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(129, 20);
            this.txtNombre.TabIndex = 13;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(192, 32);
            this.txtApellido.MaxLength = 30;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(129, 20);
            this.txtApellido.TabIndex = 12;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // labDatos
            // 
            this.labDatos.AutoSize = true;
            this.labDatos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labDatos.Location = new System.Drawing.Point(48, -1);
            this.labDatos.Name = "labDatos";
            this.labDatos.Size = new System.Drawing.Size(89, 15);
            this.labDatos.TabIndex = 11;
            this.labDatos.Text = "Datos del Cliente";
            // 
            // labCodigoPostal
            // 
            this.labCodigoPostal.AutoSize = true;
            this.labCodigoPostal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labCodigoPostal.Location = new System.Drawing.Point(48, 298);
            this.labCodigoPostal.Name = "labCodigoPostal";
            this.labCodigoPostal.Size = new System.Drawing.Size(77, 15);
            this.labCodigoPostal.TabIndex = 10;
            this.labCodigoPostal.Text = "Codigo Postal:";
            // 
            // labCiudad
            // 
            this.labCiudad.AutoSize = true;
            this.labCiudad.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labCiudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labCiudad.Location = new System.Drawing.Point(48, 269);
            this.labCiudad.Name = "labCiudad";
            this.labCiudad.Size = new System.Drawing.Size(45, 15);
            this.labCiudad.TabIndex = 9;
            this.labCiudad.Text = "Ciudad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(48, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Direccion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(48, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Piso/Dpto:";
            // 
            // labNumeroCalle
            // 
            this.labNumeroCalle.AutoSize = true;
            this.labNumeroCalle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labNumeroCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labNumeroCalle.Location = new System.Drawing.Point(48, 191);
            this.labNumeroCalle.Name = "labNumeroCalle";
            this.labNumeroCalle.Size = new System.Drawing.Size(49, 15);
            this.labNumeroCalle.TabIndex = 6;
            this.labNumeroCalle.Text = "Numero:";
            // 
            // labCalle
            // 
            this.labCalle.AutoSize = true;
            this.labCalle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labCalle.Location = new System.Drawing.Point(48, 163);
            this.labCalle.Name = "labCalle";
            this.labCalle.Size = new System.Drawing.Size(35, 15);
            this.labCalle.TabIndex = 5;
            this.labCalle.Text = "Calle:";
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labEmail.Location = new System.Drawing.Point(48, 139);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(37, 15);
            this.labEmail.TabIndex = 4;
            this.labEmail.Text = "Email:";
            // 
            // labTelefono
            // 
            this.labTelefono.AutoSize = true;
            this.labTelefono.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labTelefono.Location = new System.Drawing.Point(48, 113);
            this.labTelefono.Name = "labTelefono";
            this.labTelefono.Size = new System.Drawing.Size(47, 15);
            this.labTelefono.TabIndex = 3;
            this.labTelefono.Text = "Tel/Cel:";
            // 
            // labDNI
            // 
            this.labDNI.AutoSize = true;
            this.labDNI.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labDNI.Location = new System.Drawing.Point(48, 88);
            this.labDNI.Name = "labDNI";
            this.labDNI.Size = new System.Drawing.Size(61, 15);
            this.labDNI.TabIndex = 2;
            this.labDNI.Text = "DNI/CUIT:";
            // 
            // labNombre
            // 
            this.labNombre.AutoSize = true;
            this.labNombre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labNombre.Location = new System.Drawing.Point(48, 62);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(49, 15);
            this.labNombre.TabIndex = 1;
            this.labNombre.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(48, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellido:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(288, 399);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 39);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(373, 399);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormAgregarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labTitulo);
            this.Name = "FormAgregarCliente";
            this.Text = "HardAdmin - Agregar Cliente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}