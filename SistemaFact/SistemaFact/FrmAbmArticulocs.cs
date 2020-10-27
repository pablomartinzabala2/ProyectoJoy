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
using BarcodeLib;
namespace SistemaFact
{
    public partial class FrmAbmArticulocs : FormBase
    {
        public FrmAbmArticulocs()
        {
            InitializeComponent();
            
        }

        private void FrmAbmArticulocs_Load(object sender, EventArgs e)
        {
            Botonera(1);
            Grupo.Enabled = false;
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(cmb_CodTipo, "Tipo", "Nombre", "CodTipo");
            //txtM_Fecha.Text = DateTime.Now.ToShortDateString();
        }

        private void Botonera(int Jugada)
        {
            switch (Jugada)
            {
                //estado inicial
                case 1:
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
                case 2:
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                case 3:
                    //viene del buscador
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LimpiarGenerico(this);
          
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string msj = "Confirma eliminar el artículo ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                cFunciones fun = new cFunciones();
                fun.EliminarGenerico("Articulo", "CodArticulo", txtCodigo.Text);
                fun.LimpiarGenerico(this);
                Botonera(1);
                MessageBox.Show("Datos borrados correctamente");
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede eliminar el producto, debe tener asociado ventas");
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
          
            if (txt_Nombre.Text =="")
            {
                Mensaje("Debe ingresar una descripción para continuar");
                return;
            }

            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "Joya");
            else
            {
                fun.ModificarGenerico(this, "Joya", "CodJoya", txtCodigo.Text);
            }
                
            Mensaje("Datos grabados correctamente");
            Botonera(1);
            fun.LimpiarGenerico(this);
            
            txtCodigo.Text = "";
            Grupo.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            txtCodigo.Text = "";
            txt_Nombre.Text = "";
            Botonera(1);
            Grupo.Enabled = false;
            fun.LimpiarGenerico(this);
           
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Codigo;Nombre";
            Principal.TablaPrincipal = "Joya";
            Principal.OpcionesColumnasGrilla = "CodJoya;Nombre;Codigo;Stock";
            Principal.ColumnasVisibles = "0;1;1;1";
            Principal.ColumnasAncho = "0;380;100;100";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaTipoPrenda_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodTipoPrenda";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "TipoPrenda";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CampoIdSecundarioGenerado != "")
            {  
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {
                    case "Tipo":  
                        fun.LlenarCombo(cmb_CodTipo, "Tipo", "Nombre", "CodTipo");
                        cmb_CodTipo.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                }
            }
            if (Principal.CodigoPrincipalAbm !=null)
            {
                Botonera(3);
                txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();
                cFunciones fun = new Clases.cFunciones();
                fun.CargarControles(this, "Joya","CodJoya", txtCodigo.Text);
                if (txt_PrecioVenta.Text !="")
                {
                    Double PrecioVenta = Convert.ToDouble(txt_PrecioVenta.Text.Replace(".", ","));
                    txt_PrecioVenta.Text  = Math.Round(PrecioVenta, 0).ToString();
                }

            }

        }

        private void btnAgregarOrigen_Click(object sender, EventArgs e)
        {    
            Principal.CampoIdSecundario = "CodOrigen";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Origen";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnGenerarCodigoBarra_Click(object sender, EventArgs e)
        {
            int c = 0;
            Random r = new Random();
            int nro = 0;
            string codigo = "";
            while (c < 10)
            {
                nro = r.Next(0, 10);
                if (c == 0)
                    codigo = nro.ToString();
                else
                    codigo = codigo + nro.ToString();
                c++;
            }
        
            BarcodeLib.Barcode CodBar = new BarcodeLib.Barcode();
            //panel1.BackgroundImage = codigo.Encode(BarcodeLib.TYPE.CODE128, "12345678988877744521", Color.Black, Color.White, 300, 300);
            //ImagenCodigo.Image = CodBar.Encode(BarcodeLib.TYPE.CODE128, codigo, Color.Black, Color.White, 300, 300);
        }

        private void btnAbrirImagen_Click(object sender, EventArgs e)
        {
           
        }

        private void btnIGregarColor_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarColor_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodColor";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Color";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void BarraBotones_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

     

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_Stock_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAplicarEfectivo_Click(object sender, EventArgs e)
        {
            //CalcularEfectivo();
           // txt_PrecioEfectivo.Text = (Math.Round(Efectivo, 0)).ToString();
        }

     
        private void btnAplicarTarjeta_Click(object sender, EventArgs e)
        {
            

        }

    

        private void txtPorEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
               
            }
        }

        private void txtPorTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodTipo";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Tipo";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }
    }
}
