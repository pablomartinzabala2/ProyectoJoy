namespace SistemaFact
{
    partial class FrmActualizarPrecioJuguete
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
            this.Lista = new System.Windows.Forms.CheckedListBox();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnNinguno = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lista
            // 
            this.Lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lista.FormattingEnabled = true;
            this.Lista.Location = new System.Drawing.Point(12, 41);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(253, 238);
            this.Lista.TabIndex = 0;
            // 
            // btnTodos
            // 
            this.btnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodos.Location = new System.Drawing.Point(12, 12);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(95, 23);
            this.btnTodos.TabIndex = 1;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnNinguno
            // 
            this.btnNinguno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNinguno.Location = new System.Drawing.Point(113, 12);
            this.btnNinguno.Name = "btnNinguno";
            this.btnNinguno.Size = new System.Drawing.Size(95, 23);
            this.btnNinguno.TabIndex = 2;
            this.btnNinguno.Text = "Ninguno";
            this.btnNinguno.UseVisualStyleBackColor = true;
            this.btnNinguno.Click += new System.EventHandler(this.btnNinguno_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(271, 41);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(95, 23);
            this.btnAplicar.TabIndex = 3;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // FrmActualizarPrecioJuguete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 328);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnNinguno);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.Lista);
            this.Name = "FrmActualizarPrecioJuguete";
            this.Text = "FrmActualizarPrecioJuguete";
            this.Load += new System.EventHandler(this.FrmActualizarPrecioJuguete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox Lista;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnNinguno;
        private System.Windows.Forms.Button btnAplicar;
    }
}