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
    public partial class FrmActualizarPrecioJuguete : FormBase 
    {
        public FrmActualizarPrecioJuguete()
        {
            InitializeComponent();
        }

        private void FrmActualizarPrecioJuguete_Load(object sender, EventArgs e)
        {   
            cMarca marca = new Clases.cMarca();
            DataTable tb = marca.GetAll();
            this.Lista.DataSource = tb;
            this.Lista.DisplayMember = "Nombre";
            this.Lista.ValueMember = "CodMarca";

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            for (int i=0;i< Lista.Items.Count;i++)
            {
                Lista.SetItemChecked(i,true);
            }
        }

        private void btnNinguno_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lista.Items.Count; i++)
            {
                Lista.SetItemChecked(i, false);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lista.Items.Count; i++)
            {
                Boolean op = Lista.GetSelected(i);
                if (op == true)
                {
                    string msj = Lista.Items[i].ToString(); 
                    
                }
            }
        }
    }
}
