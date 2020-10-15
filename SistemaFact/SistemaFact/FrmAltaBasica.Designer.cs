namespace SistemaFact
{
    partial class FrmAltaBasica
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGrabar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtTabla = new System.Windows.Forms.TextBox();
            this.txtCampoNombre = new System.Windows.Forms.TextBox();
            this.txtCampoId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(373, 67);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 36);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre";
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrabar.Location = new System.Drawing.Point(285, 67);
            this.BtnGrabar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(80, 36);
            this.BtnGrabar.TabIndex = 16;
            this.BtnGrabar.Text = "&Grabar";
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(13, 12);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(44, 20);
            this.txtId.TabIndex = 15;
            this.txtId.Visible = false;
            // 
            // txtTabla
            // 
            this.txtTabla.Location = new System.Drawing.Point(152, 67);
            this.txtTabla.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTabla.Name = "txtTabla";
            this.txtTabla.Size = new System.Drawing.Size(48, 20);
            this.txtTabla.TabIndex = 14;
            this.txtTabla.Visible = false;
            // 
            // txtCampoNombre
            // 
            this.txtCampoNombre.Location = new System.Drawing.Point(82, 67);
            this.txtCampoNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCampoNombre.Name = "txtCampoNombre";
            this.txtCampoNombre.Size = new System.Drawing.Size(62, 20);
            this.txtCampoNombre.TabIndex = 13;
            this.txtCampoNombre.Visible = false;
            // 
            // txtCampoId
            // 
            this.txtCampoId.Location = new System.Drawing.Point(10, 67);
            this.txtCampoId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCampoId.Name = "txtCampoId";
            this.txtCampoId.Size = new System.Drawing.Size(56, 20);
            this.txtCampoId.TabIndex = 12;
            this.txtCampoId.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(105, 35);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(348, 23);
            this.txtNombre.TabIndex = 11;
            // 
            // FrmAltaBasica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 133);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtTabla);
            this.Controls.Add(this.txtCampoNombre);
            this.Controls.Add(this.txtCampoId);
            this.Controls.Add(this.txtNombre);
            this.Name = "FrmAltaBasica";
            this.Text = "Formulario de altas";
            this.Load += new System.EventHandler(this.FrmAltaBasica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGrabar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtTabla;
        private System.Windows.Forms.TextBox txtCampoNombre;
        private System.Windows.Forms.TextBox txtCampoId;
        private System.Windows.Forms.TextBox txtNombre;
    }
}