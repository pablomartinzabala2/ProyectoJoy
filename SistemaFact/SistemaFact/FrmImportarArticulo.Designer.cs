namespace SistemaFact
{
    partial class FrmImportarArticulo
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtProceso = new System.Windows.Forms.TextBox();
            this.btnAbrirImagen = new System.Windows.Forms.Button();
            this.txt_Ruta = new System.Windows.Forms.TextBox();
            this.RadioJoyas = new System.Windows.Forms.RadioButton();
            this.radioVendedoras = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Procesar ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtProceso
            // 
            this.txtProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProceso.Location = new System.Drawing.Point(157, 91);
            this.txtProceso.Name = "txtProceso";
            this.txtProceso.Size = new System.Drawing.Size(100, 26);
            this.txtProceso.TabIndex = 1;
            this.txtProceso.TextChanged += new System.EventHandler(this.txtProceso_TextChanged);
            // 
            // btnAbrirImagen
            // 
            this.btnAbrirImagen.Location = new System.Drawing.Point(27, 155);
            this.btnAbrirImagen.Name = "btnAbrirImagen";
            this.btnAbrirImagen.Size = new System.Drawing.Size(102, 34);
            this.btnAbrirImagen.TabIndex = 15;
            this.btnAbrirImagen.Text = "Seleccionar";
            this.btnAbrirImagen.UseVisualStyleBackColor = true;
            // 
            // txt_Ruta
            // 
            this.txt_Ruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ruta.Location = new System.Drawing.Point(27, 123);
            this.txt_Ruta.Name = "txt_Ruta";
            this.txt_Ruta.Size = new System.Drawing.Size(230, 26);
            this.txt_Ruta.TabIndex = 16;
            this.txt_Ruta.TextChanged += new System.EventHandler(this.txt_Ruta_TextChanged);
            // 
            // RadioJoyas
            // 
            this.RadioJoyas.AutoSize = true;
            this.RadioJoyas.Checked = true;
            this.RadioJoyas.Location = new System.Drawing.Point(27, 50);
            this.RadioJoyas.Name = "RadioJoyas";
            this.RadioJoyas.Size = new System.Drawing.Size(52, 17);
            this.RadioJoyas.TabIndex = 17;
            this.RadioJoyas.TabStop = true;
            this.RadioJoyas.Text = "Joyas";
            this.RadioJoyas.UseVisualStyleBackColor = true;
            // 
            // radioVendedoras
            // 
            this.radioVendedoras.AutoSize = true;
            this.radioVendedoras.Location = new System.Drawing.Point(106, 50);
            this.radioVendedoras.Name = "radioVendedoras";
            this.radioVendedoras.Size = new System.Drawing.Size(82, 17);
            this.radioVendedoras.TabIndex = 18;
            this.radioVendedoras.Text = "Vendedoras";
            this.radioVendedoras.UseVisualStyleBackColor = true;
            // 
            // FrmImportarArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 335);
            this.Controls.Add(this.radioVendedoras);
            this.Controls.Add(this.RadioJoyas);
            this.Controls.Add(this.txt_Ruta);
            this.Controls.Add(this.btnAbrirImagen);
            this.Controls.Add(this.txtProceso);
            this.Controls.Add(this.button1);
            this.Name = "FrmImportarArticulo";
            this.Text = "Importador de Artículos";
            this.Load += new System.EventHandler(this.FrmImportarArticulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtProceso;
        private System.Windows.Forms.Button btnAbrirImagen;
        private System.Windows.Forms.TextBox txt_Ruta;
        private System.Windows.Forms.RadioButton RadioJoyas;
        private System.Windows.Forms.RadioButton radioVendedoras;
    }
}