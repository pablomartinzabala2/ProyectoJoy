namespace SistemaFact
{
    partial class FrmConfigurarImpresora
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
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtColumna = new System.Windows.Forms.TextBox();
            this.txtFila = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.btnGrabar);
            this.Grupo.Controls.Add(this.txtColumna);
            this.Grupo.Controls.Add(this.txtFila);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(225, 131);
            this.Grupo.TabIndex = 21;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Configurar Impresión";
            this.Grupo.Enter += new System.EventHandler(this.Grupo_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Columna";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(102, 90);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtColumna
            // 
            this.txtColumna.Location = new System.Drawing.Point(63, 64);
            this.txtColumna.Multiline = true;
            this.txtColumna.Name = "txtColumna";
            this.txtColumna.Size = new System.Drawing.Size(114, 20);
            this.txtColumna.TabIndex = 3;
            this.txtColumna.TextChanged += new System.EventHandler(this.txtColumna_TextChanged);
            // 
            // txtFila
            // 
            this.txtFila.Location = new System.Drawing.Point(63, 35);
            this.txtFila.Multiline = true;
            this.txtFila.Name = "txtFila";
            this.txtFila.Size = new System.Drawing.Size(114, 20);
            this.txtFila.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fila";
            // 
            // FrmConfigurarImpresora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 153);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmConfigurarImpresora";
            this.Text = "Impresión";
            this.Load += new System.EventHandler(this.FrmConfigurarImpresora_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txtFila;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColumna;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label label2;
    }
}