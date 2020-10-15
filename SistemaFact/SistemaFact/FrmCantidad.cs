using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFact
{
    public partial class FrmCantidad : Form
    {
        public FrmCantidad()
        {
            InitializeComponent();
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                Int32 Can = Convert.ToInt32(txtCantidad.Text);
                Principal.CantidadArticulo = Can;
                this.Close();
            }
        }
    }
}
