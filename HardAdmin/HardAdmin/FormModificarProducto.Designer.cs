namespace HardAdmin
{
    partial class FormModificarProducto
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
            this.btnSubir = new System.Windows.Forms.Button();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbSi = new System.Windows.Forms.RadioButton();
            this.nupStockActual = new System.Windows.Forms.NumericUpDown();
            this.nupStockMinimo = new System.Windows.Forms.NumericUpDown();
            this.nupPrecio = new System.Windows.Forms.NumericUpDown();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modificar Producto";
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(222, 215);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(85, 23);
            this.btnSubir.TabIndex = 18;
            this.btnSubir.Text = "Subir Imagen..";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(112, 32);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(39, 17);
            this.rbNo.TabIndex = 17;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            this.rbNo.CheckedChanged += new System.EventHandler(this.rbNo_CheckedChanged);
            // 
            // rbSi
            // 
            this.rbSi.AutoSize = true;
            this.rbSi.Location = new System.Drawing.Point(72, 32);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(34, 17);
            this.rbSi.TabIndex = 16;
            this.rbSi.TabStop = true;
            this.rbSi.Text = "Si";
            this.rbSi.UseVisualStyleBackColor = true;
            // 
            // nupStockActual
            // 
            this.nupStockActual.Location = new System.Drawing.Point(167, 96);
            this.nupStockActual.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nupStockActual.Name = "nupStockActual";
            this.nupStockActual.Size = new System.Drawing.Size(195, 20);
            this.nupStockActual.TabIndex = 15;
            this.nupStockActual.ValueChanged += new System.EventHandler(this.nupStockActual_ValueChanged);
            // 
            // nupStockMinimo
            // 
            this.nupStockMinimo.Location = new System.Drawing.Point(167, 62);
            this.nupStockMinimo.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nupStockMinimo.Name = "nupStockMinimo";
            this.nupStockMinimo.Size = new System.Drawing.Size(195, 20);
            this.nupStockMinimo.TabIndex = 14;
            this.nupStockMinimo.ValueChanged += new System.EventHandler(this.nupStockMinimo_ValueChanged);
            // 
            // nupPrecio
            // 
            this.nupPrecio.DecimalPlaces = 2;
            this.nupPrecio.Location = new System.Drawing.Point(167, 27);
            this.nupPrecio.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nupPrecio.Name = "nupPrecio";
            this.nupPrecio.Size = new System.Drawing.Size(195, 20);
            this.nupPrecio.TabIndex = 13;
            this.nupPrecio.ValueChanged += new System.EventHandler(this.nupPrecio_ValueChanged);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(167, 174);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(195, 21);
            this.cmbCategoria.TabIndex = 12;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(167, 106);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(195, 39);
            this.txtDescripcion.TabIndex = 11;
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(167, 64);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(195, 20);
            this.txtCodigo.TabIndex = 10;
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(167, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 20);
            this.txtNombre.TabIndex = 9;
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Activo:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Imagen:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Stock Actual:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Stock Minimo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Precio de venta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Categoria:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 37);
            this.label4.TabIndex = 2;
            this.label4.Text = "Descripcion (max 300 caracteres):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // pbImagen
            // 
            this.pbImagen.Location = new System.Drawing.Point(436, 52);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(177, 250);
            this.pbImagen.TabIndex = 2;
            this.pbImagen.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(436, 417);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(533, 417);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSubir);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.cmbCategoria);
            this.groupBox1.Location = new System.Drawing.Point(17, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 253);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Producto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.nupPrecio);
            this.groupBox2.Controls.Add(this.nupStockMinimo);
            this.groupBox2.Controls.Add(this.nupStockActual);
            this.groupBox2.Location = new System.Drawing.Point(17, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 143);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Precio y Stock";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbSi);
            this.groupBox3.Controls.Add(this.rbNo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(437, 314);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 77);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado";
            // 
            // FormModificarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 469);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.label1);
            this.Name = "FormModificarProducto";
            this.Text = "HardAdmin -Modificar Producto";
            this.Load += new System.EventHandler(this.FormModificarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupStockActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.NumericUpDown nupStockActual;
        private System.Windows.Forms.NumericUpDown nupStockMinimo;
        private System.Windows.Forms.NumericUpDown nupPrecio;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbSi;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}