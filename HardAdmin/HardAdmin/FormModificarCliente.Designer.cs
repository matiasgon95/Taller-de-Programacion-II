namespace HardAdmin
{
    partial class FormModificarCliente
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modificar Cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbActivoNo);
            this.panel1.Controls.Add(this.rbActivoSi);
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
            this.panel1.Controls.Add(this.labActivo);
            this.panel1.Controls.Add(this.labCodigoPostal);
            this.panel1.Controls.Add(this.labCiudad);
            this.panel1.Controls.Add(this.labDireccion);
            this.panel1.Controls.Add(this.labPisoDpto);
            this.panel1.Controls.Add(this.labNumero);
            this.panel1.Controls.Add(this.labCalle);
            this.panel1.Controls.Add(this.labEmail);
            this.panel1.Controls.Add(this.labTelefono);
            this.panel1.Controls.Add(this.labDNI);
            this.panel1.Controls.Add(this.labNombre);
            this.panel1.Controls.Add(this.labApellido);
            this.panel1.Controls.Add(this.labDatos);
            this.panel1.Location = new System.Drawing.Point(78, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 341);
            this.panel1.TabIndex = 1;
            // 
            // rbActivoNo
            // 
            this.rbActivoNo.AutoSize = true;
            this.rbActivoNo.Location = new System.Drawing.Point(288, 312);
            this.rbActivoNo.Name = "rbActivoNo";
            this.rbActivoNo.Size = new System.Drawing.Size(39, 17);
            this.rbActivoNo.TabIndex = 25;
            this.rbActivoNo.TabStop = true;
            this.rbActivoNo.Text = "No";
            this.rbActivoNo.UseVisualStyleBackColor = true;
            // 
            // rbActivoSi
            // 
            this.rbActivoSi.AutoSize = true;
            this.rbActivoSi.Location = new System.Drawing.Point(248, 312);
            this.rbActivoSi.Name = "rbActivoSi";
            this.rbActivoSi.Size = new System.Drawing.Size(34, 17);
            this.rbActivoSi.TabIndex = 24;
            this.rbActivoSi.TabStop = true;
            this.rbActivoSi.Text = "Si";
            this.rbActivoSi.UseVisualStyleBackColor = true;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(221, 284);
            this.txtCodigoPostal.MaxLength = 5;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(143, 20);
            this.txtCodigoPostal.TabIndex = 23;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(221, 260);
            this.txtCiudad.MaxLength = 50;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(143, 20);
            this.txtCiudad.TabIndex = 22;
            this.txtCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCiudad_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(221, 235);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(143, 20);
            this.txtDireccion.TabIndex = 21;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // txtPisoDpto
            // 
            this.txtPisoDpto.Location = new System.Drawing.Point(221, 210);
            this.txtPisoDpto.MaxLength = 5;
            this.txtPisoDpto.Name = "txtPisoDpto";
            this.txtPisoDpto.Size = new System.Drawing.Size(143, 20);
            this.txtPisoDpto.TabIndex = 20;
            this.txtPisoDpto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPisoDpto_KeyPress);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(221, 186);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(143, 20);
            this.txtNumero.TabIndex = 19;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(221, 161);
            this.txtCalle.MaxLength = 10;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(143, 20);
            this.txtCalle.TabIndex = 18;
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalle_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(221, 137);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(143, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(221, 113);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(143, 20);
            this.txtTelefono.TabIndex = 16;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(221, 89);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(143, 20);
            this.txtDNI.TabIndex = 15;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(221, 64);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(143, 20);
            this.txtNombre.TabIndex = 14;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(221, 40);
            this.txtApellido.MaxLength = 30;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(143, 20);
            this.txtApellido.TabIndex = 13;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // labActivo
            // 
            this.labActivo.AutoSize = true;
            this.labActivo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labActivo.Location = new System.Drawing.Point(47, 312);
            this.labActivo.Name = "labActivo";
            this.labActivo.Size = new System.Drawing.Size(42, 15);
            this.labActivo.TabIndex = 12;
            this.labActivo.Text = "Activo:";
            // 
            // labCodigoPostal
            // 
            this.labCodigoPostal.AutoSize = true;
            this.labCodigoPostal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labCodigoPostal.Location = new System.Drawing.Point(47, 287);
            this.labCodigoPostal.Name = "labCodigoPostal";
            this.labCodigoPostal.Size = new System.Drawing.Size(77, 15);
            this.labCodigoPostal.TabIndex = 11;
            this.labCodigoPostal.Text = "Codigo Postal:";
            // 
            // labCiudad
            // 
            this.labCiudad.AutoSize = true;
            this.labCiudad.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labCiudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labCiudad.Location = new System.Drawing.Point(47, 263);
            this.labCiudad.Name = "labCiudad";
            this.labCiudad.Size = new System.Drawing.Size(45, 15);
            this.labCiudad.TabIndex = 10;
            this.labCiudad.Text = "Ciudad:";
            // 
            // labDireccion
            // 
            this.labDireccion.AutoSize = true;
            this.labDireccion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labDireccion.Location = new System.Drawing.Point(47, 238);
            this.labDireccion.Name = "labDireccion";
            this.labDireccion.Size = new System.Drawing.Size(57, 15);
            this.labDireccion.TabIndex = 9;
            this.labDireccion.Text = "Direccion:";
            // 
            // labPisoDpto
            // 
            this.labPisoDpto.AutoSize = true;
            this.labPisoDpto.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labPisoDpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labPisoDpto.Location = new System.Drawing.Point(47, 213);
            this.labPisoDpto.Name = "labPisoDpto";
            this.labPisoDpto.Size = new System.Drawing.Size(60, 15);
            this.labPisoDpto.TabIndex = 8;
            this.labPisoDpto.Text = "Piso/Dpto:";
            // 
            // labNumero
            // 
            this.labNumero.AutoSize = true;
            this.labNumero.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labNumero.Location = new System.Drawing.Point(47, 189);
            this.labNumero.Name = "labNumero";
            this.labNumero.Size = new System.Drawing.Size(49, 15);
            this.labNumero.TabIndex = 7;
            this.labNumero.Text = "Numero:";
            // 
            // labCalle
            // 
            this.labCalle.AutoSize = true;
            this.labCalle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labCalle.Location = new System.Drawing.Point(47, 164);
            this.labCalle.Name = "labCalle";
            this.labCalle.Size = new System.Drawing.Size(35, 15);
            this.labCalle.TabIndex = 6;
            this.labCalle.Text = "Calle:";
            this.labCalle.Click += new System.EventHandler(this.labCalle_Click);
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labEmail.Location = new System.Drawing.Point(47, 140);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(37, 15);
            this.labEmail.TabIndex = 5;
            this.labEmail.Text = "Email:";
            this.labEmail.Click += new System.EventHandler(this.labEmail_Click);
            // 
            // labTelefono
            // 
            this.labTelefono.AutoSize = true;
            this.labTelefono.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labTelefono.Location = new System.Drawing.Point(47, 116);
            this.labTelefono.Name = "labTelefono";
            this.labTelefono.Size = new System.Drawing.Size(47, 15);
            this.labTelefono.TabIndex = 4;
            this.labTelefono.Text = "Tel/Cel:";
            // 
            // labDNI
            // 
            this.labDNI.AutoSize = true;
            this.labDNI.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labDNI.Location = new System.Drawing.Point(47, 92);
            this.labDNI.Name = "labDNI";
            this.labDNI.Size = new System.Drawing.Size(61, 15);
            this.labDNI.TabIndex = 3;
            this.labDNI.Text = "DNI/CUIT:";
            // 
            // labNombre
            // 
            this.labNombre.AutoSize = true;
            this.labNombre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labNombre.Location = new System.Drawing.Point(47, 67);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(49, 15);
            this.labNombre.TabIndex = 2;
            this.labNombre.Text = "Nombre:";
            // 
            // labApellido
            // 
            this.labApellido.AutoSize = true;
            this.labApellido.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labApellido.Location = new System.Drawing.Point(47, 43);
            this.labApellido.Name = "labApellido";
            this.labApellido.Size = new System.Drawing.Size(49, 15);
            this.labApellido.TabIndex = 1;
            this.labApellido.Text = "Apellido:";
            // 
            // labDatos
            // 
            this.labDatos.AutoSize = true;
            this.labDatos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labDatos.Location = new System.Drawing.Point(47, 0);
            this.labDatos.Name = "labDatos";
            this.labDatos.Size = new System.Drawing.Size(89, 15);
            this.labDatos.TabIndex = 0;
            this.labDatos.Text = "Datos del Cliente";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(310, 403);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 38);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(398, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 38);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormModificarCliente";
            this.Text = "HardAdmin - Modificar Cliente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}