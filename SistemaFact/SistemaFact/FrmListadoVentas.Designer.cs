namespace SistemaFact
{
    partial class FrmListadoVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListadoVentas));
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Controls.Add(this.txtTotal);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.button1);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.lblFecha);
            this.Grupo.Controls.Add(this.txtFechaHasta);
            this.Grupo.Controls.Add(this.txtFechaDesde);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(724, 490);
            this.Grupo.TabIndex = 20;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Información de  ventas";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(16, 92);
            this.Grilla.Name = "Grilla";
            this.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(691, 356);
            this.Grilla.TabIndex = 86;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(607, 461);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 23);
            this.txtTotal.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 83;
            this.label3.Text = "Total";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(691, 25);
            this.label2.TabIndex = 81;
            this.label2.Text = "Listado de ventas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(400, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 26);
            this.button1.TabIndex = 80;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(363, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(31, 26);
            this.btnBuscar.TabIndex = 79;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "Hasta::";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(13, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(53, 17);
            this.lblFecha.TabIndex = 66;
            this.lblFecha.Text = "Desde:";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(281, 35);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(76, 23);
            this.txtFechaHasta.TabIndex = 65;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(106, 35);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(76, 23);
            this.txtFechaDesde.TabIndex = 64;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // FrmListadoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 514);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmListadoVentas";
            this.Text = "FrmListadoVentas";
            this.Load += new System.EventHandler(this.FrmListadoVentas_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.MaskedTextBox txtFechaHasta;
        private System.Windows.Forms.MaskedTextBox txtFechaDesde;
        private System.Windows.Forms.DataGridView Grilla;
    }
}