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
    public partial class FrmListadoArticulo : FormBase
    {
        public FrmListadoArticulo()
        {
            InitializeComponent();
        }

        private void FrmListadoArticulo_Load(object sender, EventArgs e)
        {
            CargarGrilla("" , "");
        }

      

        private void CargarGrilla(string Nombre,string Codigo)
        {
            cFunciones fun = new cFunciones();
            cJoya joya = new cJoya();
            DataTable trdo = joya.GetJoyas();
           
           // trdo = fun.TablaaMiles(trdo, "PrecioEfectivo");
           
            Grilla.DataSource = trdo;
            //Grilla.Columns[0].Visible = false;
            fun.AnchoColumnas(Grilla, "0;10;35;35;10;10");
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(Grilla.Font, FontStyle.Bold);
        //    Grilla.Columns[8].DefaultCellStyle = style;
            //Grilla.Rows[8].DefaultCellStyle = style;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            
            string nombre = txtDescripcion.Text;
            CargarGrilla(nombre, "");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grupo_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtDescripcion.Text, txtCodigo.Text);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla("" , txtCodigo.Text);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tecla = e.KeyChar.ToString();
        }

        private void FrmListadoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmListadoArticulo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
           // string xx = e.KeyData.ToString();
            if (e.KeyData== Keys.Delete)
            {
               
            }
        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                txtCodigo.Text = "";
                txtDescripcion.Text = "";
               
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                txtCodigo.Text = "";
           
               
            }
        }
    }
}
