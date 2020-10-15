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
            CargarMarcas();
            CargarGrilla("", "", "");
        }

        private void CargarMarcas()
        {
            cMarca marca = new cMarca();
            DataTable trdo = marca.GetAll();
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarComboDatatable(cmbMarca, trdo, "Nombre", "CodMarca");
        }

        private void CargarGrilla(string Nombre,string CodigoBarra,string Codigo)
        {
            string Tabla = "";
            if (chkLibreria.Checked == true)
                Tabla = "Articulo";
            else
                Tabla = "Juguete";
            Int32? CodMarca = null;
            if (cmbMarca.SelectedIndex > 0)
                CodMarca = Convert.ToInt32(cmbMarca.SelectedValue);

            cFunciones fun = new cFunciones();
            cArticulo art = new Clases.cArticulo();
            cJuguete jug = new cJuguete();
            DataTable trdo = new DataTable();
            if (Tabla =="Articulo")
                 trdo = art.GetDetalleArticulo(Nombre,CodigoBarra,Codigo,Tabla);
            if (Tabla == "Juguete")
                trdo = jug.GetDetalleArticulo(Nombre, CodigoBarra, Codigo, CodMarca);

            trdo = fun.TablaaMiles(trdo, "PrecioEfectivo");
            trdo = fun.TablaaMiles(trdo, "PrecioTarjeta");
            trdo = fun.TablaaMiles(trdo, "Descuento");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[5].Visible = false;
            Grilla.Columns[3].Width = 410;
            Grilla.Columns[6].HeaderText = "Tarjeta";
            Grilla.Columns[8].HeaderText = "Efectivo/Deb";

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(Grilla.Font, FontStyle.Bold);
            Grilla.Columns[8].DefaultCellStyle = style;
            //Grilla.Rows[8].DefaultCellStyle = style;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            
            string nombre = txtDescripcion.Text;
            CargarGrilla(nombre, "", "");
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
            string Codigo = txtCodigoBarra.Text;
            if (Codigo.Length >4)
            {
                CargarGrilla("", Codigo, "");
            } 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtDescripcion.Text, txtCodigoBarra.Text, txtCodigo.Text);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla("", "", txtCodigo.Text);
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
                txtCodigo.Text = "";
                txtDescripcion.Text = "";
                txtCodigoBarra.Text = "";
            }
        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                txtCodigo.Text = "";
                txtDescripcion.Text = "";
                txtCodigoBarra.Text = "";
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                txtCodigo.Text = "";
                txtDescripcion.Text = "";
                txtCodigoBarra.Text = "";
            }
        }
    }
}
