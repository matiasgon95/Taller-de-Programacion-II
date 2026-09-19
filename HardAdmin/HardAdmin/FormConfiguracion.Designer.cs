namespace HardAdmin
{
    partial class FormConfiguracion
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbCategorias = new System.Windows.Forms.GroupBox();
            this.lblDescCategorias = new System.Windows.Forms.Label();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.gbMetodosPago = new System.Windows.Forms.GroupBox();
            this.lblDescMetodos = new System.Windows.Forms.Label();
            this.btnMetodosPago = new System.Windows.Forms.Button();
            this.gbCategorias.SuspendLayout();
            this.gbMetodosPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(300, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(198, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configuración";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbCategorias
            // 
            this.gbCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCategorias.Controls.Add(this.lblDescCategorias);
            this.gbCategorias.Controls.Add(this.btnCategorias);
            this.gbCategorias.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCategorias.Location = new System.Drawing.Point(100, 100);
            this.gbCategorias.Name = "gbCategorias";
            this.gbCategorias.Size = new System.Drawing.Size(600, 110);
            this.gbCategorias.TabIndex = 1;
            this.gbCategorias.TabStop = false;
            this.gbCategorias.Text = "Categorías de Productos";
            // 
            // lblDescCategorias
            // 
            this.lblDescCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescCategorias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescCategorias.Location = new System.Drawing.Point(25, 40);
            this.lblDescCategorias.Name = "lblDescCategorias";
            this.lblDescCategorias.Size = new System.Drawing.Size(400, 45);
            this.lblDescCategorias.TabIndex = 1;
            this.lblDescCategorias.Text = "Administrá las distintas categorías para clasificar y organizar el inventario de " +
    "productos de forma eficiente.";
            // 
            // btnCategorias
            // 
            this.btnCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategorias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.Location = new System.Drawing.Point(440, 40);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(140, 40);
            this.btnCategorias.TabIndex = 0;
            this.btnCategorias.Text = "Gestionar Categorías";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // gbMetodosPago
            // 
            this.gbMetodosPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMetodosPago.Controls.Add(this.lblDescMetodos);
            this.gbMetodosPago.Controls.Add(this.btnMetodosPago);
            this.gbMetodosPago.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMetodosPago.Location = new System.Drawing.Point(100, 240);
            this.gbMetodosPago.Name = "gbMetodosPago";
            this.gbMetodosPago.Size = new System.Drawing.Size(600, 110);
            this.gbMetodosPago.TabIndex = 2;
            this.gbMetodosPago.TabStop = false;
            this.gbMetodosPago.Text = "Métodos de Pago";
            // 
            // lblDescMetodos
            // 
            this.lblDescMetodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescMetodos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescMetodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescMetodos.Location = new System.Drawing.Point(25, 40);
            this.lblDescMetodos.Name = "lblDescMetodos";
            this.lblDescMetodos.Size = new System.Drawing.Size(400, 45);
            this.lblDescMetodos.TabIndex = 1;
            this.lblDescMetodos.Text = "Configurá los medios de pago disponibles en el sistema (Efectivo, Tarjeta, Transf" +
    "erencia, etc) para el registro de ventas.";
            // 
            // btnMetodosPago
            // 
            this.btnMetodosPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMetodosPago.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMetodosPago.Location = new System.Drawing.Point(440, 40);
            this.btnMetodosPago.Name = "btnMetodosPago";
            this.btnMetodosPago.Size = new System.Drawing.Size(140, 40);
            this.btnMetodosPago.TabIndex = 0;
            this.btnMetodosPago.Text = "Gestionar Pagos";
            this.btnMetodosPago.UseVisualStyleBackColor = true;
            this.btnMetodosPago.Click += new System.EventHandler(this.btnMetodosPago_Click);
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.gbMetodosPago);
            this.Controls.Add(this.gbCategorias);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfiguracion";
            this.Text = "HardAdmin - Configuración";
            this.gbCategorias.ResumeLayout(false);
            this.gbMetodosPago.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbCategorias;
        private System.Windows.Forms.Label lblDescCategorias;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.GroupBox gbMetodosPago;
        private System.Windows.Forms.Label lblDescMetodos;
        private System.Windows.Forms.Button btnMetodosPago;
    }
}