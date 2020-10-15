using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFact.Clases;
namespace SistemaFact
{
    public partial class FrmConfigurarImpresora : FormBase
    {
        public FrmConfigurarImpresora()
        {
            InitializeComponent();
        }

        private void Grupo_Enter(object sender, EventArgs e)
        {

        }

        private void FrmConfigurarImpresora_Load(object sender, EventArgs e)
        {
            GetImpresora();
        }

        private void Grabar()
        {
            if (txtFila.Text =="")
            {
                Mensaje("Debe ingresar una fila");
                return;
            }

            if (txtColumna.Text  == "")
            {
                Mensaje("Debe ingresar una columna");
                return;
            }

            int Fila = Convert.ToInt32(txtFila.Text);
            int Columna = Convert.ToInt32(txtColumna.Text);
            if (Fila >11)
            {
                Mensaje("La fila no puede superar 11");
                return;
            }

            if (Fila < 1)
            {
                Mensaje("La fila no puede ser inferior a 1");
                return;
            }

            if (Columna >6)
            {
                Mensaje("La Columna no puede superar a 6");
                return;
            }

            if (Columna < 1)
            {
                Mensaje("La Columna no puede ser inferior a 1");
                return;
            }

            cImpresora imp = new cImpresora();
            imp.Insertar(Fila, Columna);
            Mensaje("Datos grabados correctamente");
        }

        private void GetImpresora()
        {
            cImpresora imp = new cImpresora();
            DataTable trdo = imp.GetCordenadas();
            if (trdo.Rows.Count >0)
            {
                txtFila.Text = trdo.Rows[0]["Fila"].ToString();
                txtColumna.Text  = trdo.Rows[0]["Columna"].ToString();
            }
        }

        private void txtColumna_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }
    }
}
