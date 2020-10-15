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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            // color de fondo 192; 255; 192
            // fondo narajna PeachPuff
        }

        public void Mensaje(string msj)
        {
            MessageBox.Show(msj, "Sistema");
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void btnAbrirImagen_Click(object sender, EventArgs e)
        {
            
        }
    }
}
