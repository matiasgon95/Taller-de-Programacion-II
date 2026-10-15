namespace HardAdmin
{
    partial class FormGestionBackups
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
            this.gbCopiaSeguridad = new System.Windows.Forms.GroupBox();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.lblCopiaSeguridad = new System.Windows.Forms.Label();
            this.gbRestauracion = new System.Windows.Forms.GroupBox();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.lblDescRestauracion = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbCopiaSeguridad.SuspendLayout();
            this.gbRestauracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCopiaSeguridad
            // 
            this.gbCopiaSeguridad.Controls.Add(this.btnBackUp);
            this.gbCopiaSeguridad.Controls.Add(this.lblCopiaSeguridad);
            this.gbCopiaSeguridad.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbCopiaSeguridad.Location = new System.Drawing.Point(37, 41);
            this.gbCopiaSeguridad.Name = "gbCopiaSeguridad";
            this.gbCopiaSeguridad.Size = new System.Drawing.Size(463, 104);
            this.gbCopiaSeguridad.TabIndex = 1;
            this.gbCopiaSeguridad.TabStop = false;
            this.gbCopiaSeguridad.Text = "Copia de Seguridad";
            // 
            // btnBackUp
            // 
            this.btnBackUp.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnBackUp.Location = new System.Drawing.Point(325, 34);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(118, 41);
            this.btnBackUp.TabIndex = 3;
            this.btnBackUp.Text = "Crear backup";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // lblCopiaSeguridad
            // 
            this.lblCopiaSeguridad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopiaSeguridad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopiaSeguridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCopiaSeguridad.Location = new System.Drawing.Point(20, 34);
            this.lblCopiaSeguridad.Name = "lblCopiaSeguridad";
            this.lblCopiaSeguridad.Size = new System.Drawing.Size(287, 45);
            this.lblCopiaSeguridad.TabIndex = 2;
            this.lblCopiaSeguridad.Text = "Realiza una copia se seguridad de la base de datos actual.";
            // 
            // gbRestauracion
            // 
            this.gbRestauracion.Controls.Add(this.btnRestaurar);
            this.gbRestauracion.Controls.Add(this.lblDescRestauracion);
            this.gbRestauracion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbRestauracion.Location = new System.Drawing.Point(37, 178);
            this.gbRestauracion.Name = "gbRestauracion";
            this.gbRestauracion.Size = new System.Drawing.Size(463, 115);
            this.gbRestauracion.TabIndex = 2;
            this.gbRestauracion.TabStop = false;
            this.gbRestauracion.Text = "Restauracion";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnRestaurar.Location = new System.Drawing.Point(325, 47);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(118, 41);
            this.btnRestaurar.TabIndex = 4;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // lblDescRestauracion
            // 
            this.lblDescRestauracion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescRestauracion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescRestauracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescRestauracion.Location = new System.Drawing.Point(23, 43);
            this.lblDescRestauracion.Name = "lblDescRestauracion";
            this.lblDescRestauracion.Size = new System.Drawing.Size(284, 45);
            this.lblDescRestauracion.TabIndex = 2;
            this.lblDescRestauracion.Text = "Eliga un archivo .bak para realizar una restauracion de la base de datos.";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCerrar.Location = new System.Drawing.Point(425, 312);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 30);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormGestionBackups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 354);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gbRestauracion);
            this.Controls.Add(this.gbCopiaSeguridad);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGestionBackups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HardAdmin - Gestion de Backups";
            this.gbCopiaSeguridad.ResumeLayout(false);
            this.gbRestauracion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbCopiaSeguridad;
        private System.Windows.Forms.GroupBox gbRestauracion;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Label lblCopiaSeguridad;
        private System.Windows.Forms.Label lblDescRestauracion;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnCerrar;
    }
}