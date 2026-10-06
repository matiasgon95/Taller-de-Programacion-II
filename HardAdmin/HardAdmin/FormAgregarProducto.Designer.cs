namespace HardAdmin
{
    partial class FormAgregarProducto
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
            this.nupStockActual = new System.Windows.Forms.NumericUpDown();
            this.nupStockMinimo = new System.Windows.Forms.NumericUpDown();
            this.nupPrecio = new System.Windows.Forms.NumericUpDown();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbImagen = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_Categoria = new System.Windows.Forms.Label();
            this.LB_ = new System.Windows.Forms.Label();
            this.LB_Codigo = new System.Windows.Forms.Label();
            this.LB_Nombre = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.gb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Producto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(176, 216);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(84, 26);
            this.btnSubir.TabIndex = 15;
            this.btnSubir.Text = "Subir Imagen..";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // nupStockActual
            // 
            this.nupStockActual.Location = new System.Drawing.Point(128, 88);
            this.nupStockActual.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nupStockActual.Name = "nupStockActual";
            this.nupStockActual.Size = new System.Drawing.Size(195, 20);
            this.nupStockActual.TabIndex = 14;
            this.nupStockActual.ValueChanged += new System.EventHandler(this.nupStockActual_ValueChanged);
            // 
            // nupStockMinimo
            // 
            this.nupStockMinimo.Location = new System.Drawing.Point(128, 57);
            this.nupStockMinimo.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nupStockMinimo.Name = "nupStockMinimo";
            this.nupStockMinimo.Size = new System.Drawing.Size(195, 20);
            this.nupStockMinimo.TabIndex = 13;
            this.nupStockMinimo.ValueChanged += new System.EventHandler(this.nupStockMinimo_ValueChanged);
            // 
            // nupPrecio
            // 
            this.nupPrecio.DecimalPlaces = 2;
            this.nupPrecio.Location = new System.Drawing.Point(128, 25);
            this.nupPrecio.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nupPrecio.Name = "nupPrecio";
            this.nupPrecio.Size = new System.Drawing.Size(195, 20);
            this.nupPrecio.TabIndex = 12;
            this.nupPrecio.ValueChanged += new System.EventHandler(this.nupPrecio_ValueChanged);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Tarjeta Grafica",
            "Pantalla",
            "Raton",
            "RAM"});
            this.cmbCategoria.Location = new System.Drawing.Point(128, 174);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(195, 21);
            this.cmbCategoria.TabIndex = 11;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(128, 92);
            this.txtDescripcion.MaxLength = 300;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(195, 60);
            this.txtDescripcion.TabIndex = 10;
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(128, 57);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(195, 20);
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(128, 23);
            this.txtNombre.MaxLength = 80;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 20);
            this.txtNombre.TabIndex = 8;
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // lbImagen
            // 
            this.lbImagen.AutoSize = true;
            this.lbImagen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImagen.Location = new System.Drawing.Point(6, 221);
            this.lbImagen.Name = "lbImagen";
            this.lbImagen.Size = new System.Drawing.Size(55, 16);
            this.lbImagen.TabIndex = 7;
            this.lbImagen.Text = "Imagen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stock Actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stock Minimo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Precio de venta:";
            // 
            // LB_Categoria
            // 
            this.LB_Categoria.AutoSize = true;
            this.LB_Categoria.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LB_Categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Categoria.Location = new System.Drawing.Point(6, 175);
            this.LB_Categoria.Name = "LB_Categoria";
            this.LB_Categoria.Size = new System.Drawing.Size(69, 16);
            this.LB_Categoria.TabIndex = 3;
            this.LB_Categoria.Text = "Categoria:";
            // 
            // LB_
            // 
            this.LB_.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LB_.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_.Location = new System.Drawing.Point(6, 92);
            this.LB_.Name = "LB_";
            this.LB_.Size = new System.Drawing.Size(113, 34);
            this.LB_.TabIndex = 2;
            this.LB_.Text = "Descripcion (max 300 caracteres):";
            // 
            // LB_Codigo
            // 
            this.LB_Codigo.AutoSize = true;
            this.LB_Codigo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LB_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Codigo.Location = new System.Drawing.Point(6, 57);
            this.LB_Codigo.Name = "LB_Codigo";
            this.LB_Codigo.Size = new System.Drawing.Size(54, 16);
            this.LB_Codigo.TabIndex = 1;
            this.LB_Codigo.Text = "Codigo:";
            // 
            // LB_Nombre
            // 
            this.LB_Nombre.AutoSize = true;
            this.LB_Nombre.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LB_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Nombre.Location = new System.Drawing.Point(6, 24);
            this.LB_Nombre.Name = "LB_Nombre";
            this.LB_Nombre.Size = new System.Drawing.Size(59, 16);
            this.LB_Nombre.TabIndex = 0;
            this.LB_Nombre.Text = "Nombre:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(428, 408);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 36);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(518, 408);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.Location = new System.Drawing.Point(428, 56);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(175, 243);
            this.pbImagen.TabIndex = 5;
            this.pbImagen.TabStop = false;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.LB_Nombre);
            this.gb1.Controls.Add(this.txtNombre);
            this.gb1.Controls.Add(this.btnSubir);
            this.gb1.Controls.Add(this.LB_Codigo);
            this.gb1.Controls.Add(this.txtCodigo);
            this.gb1.Controls.Add(this.LB_);
            this.gb1.Controls.Add(this.txtDescripcion);
            this.gb1.Controls.Add(this.LB_Categoria);
            this.gb1.Controls.Add(this.cmbCategoria);
            this.gb1.Controls.Add(this.lbImagen);
            this.gb1.Location = new System.Drawing.Point(39, 56);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(366, 260);
            this.gb1.TabIndex = 16;
            this.gb1.TabStop = false;
            this.gb1.Text = "Datos del Producto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nupPrecio);
            this.groupBox1.Controls.Add(this.nupStockActual);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nupStockMinimo);
            this.groupBox1.Location = new System.Drawing.Point(40, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 122);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Precio y Stock";
            // 
            // FormAgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 469);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Name = "FormAgregarProducto";
            this.Text = "HardAdmin - Agregar Producto";
            this.Load += new System.EventHandler(this.FormAgregarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupStockActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_;
        private System.Windows.Forms.Label LB_Codigo;
        private System.Windows.Forms.Label LB_Nombre;
        private System.Windows.Forms.Label lbImagen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LB_Categoria;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.NumericUpDown nupStockActual;
        private System.Windows.Forms.NumericUpDown nupStockMinimo;
        private System.Windows.Forms.NumericUpDown nupPrecio;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}