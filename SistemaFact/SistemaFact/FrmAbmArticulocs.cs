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
            txtPorEfectivo.Text = "70";
            txtPorTarjeta.Text = "100";
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
            if (txt_Costo.Text != "")
                txt_Costo.Text = txt_Costo.Text.Replace(",", ".");
            
            if (txt_PrecioEfectivo.Text != "")
                txt_PrecioEfectivo.Text = txt_PrecioEfectivo.Text.Replace(",", ".");
             
            if (txt_PrecioTarjeta.Text != "")
                txt_PrecioTarjeta.Text = txt_PrecioTarjeta.Text.Replace(",", ".");

            if (txt_Nombre.Text =="")
            {
                Mensaje("Debe ingresar una descripción para continuar");
                return;
            }
            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "Articulo");
            else
            {
               // if (txt_Ruta.Text != "")
                 //   txt_Ruta.Text = txt_Ruta.Text.Replace("\\", "\\\\");
                fun.ModificarGenerico(this, "Articulo", "CodArticulo", txtCodigo.Text);
                
            }
                
            Mensaje("Datos grabados correctamente");
            txtPorEfectivo.Text = "";
            txtPorTarjeta.Text = "";
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
            Principal.OpcionesdeBusqueda = "Codigo;Nombre;CodigoBarra";
            Principal.TablaPrincipal = "Articulo";
            Principal.OpcionesColumnasGrilla = "CodArticulo;Nombre;Costo";
            Principal.ColumnasVisibles = "0;1;1";
            Principal.ColumnasAncho = "0;390;190";
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
                    
                }
            }
            if (Principal.CodigoPrincipalAbm !=null)
            {
                Botonera(3);
                txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();
                cFunciones fun = new Clases.cFunciones();
                fun.CargarControles(this, "Articulo","CodArticulo", txtCodigo.Text);
                if (txt_PrecioEfectivo.Text !="")
                {
                    Double Efectivo = Convert.ToDouble(txt_PrecioEfectivo.Text.Replace(".", ","));
                    txt_PrecioEfectivo.Text  = Math.Round(Efectivo, 0).ToString();
                }

                if (txt_Costo.Text != "")
                {
                    Double Costo = Convert.ToDouble(txt_Costo.Text.Replace(".", ","));
                    txt_Costo.Text = Math.Round(Costo, 0).ToString();
                }

                if (txt_PrecioTarjeta.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txt_PrecioTarjeta.Text.Replace(".", ","));
                    txt_PrecioTarjeta.Text  = Math.Round(Efectivo, 0).ToString();
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
            txt_CodigoBarra.Text = codigo;
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

        private void txt_CodigoBarra_TextChanged(object sender, EventArgs e)
        {
            if (txt_CodigoBarra.Text.Length  >5)
            {
                string CodigoBarra = txt_CodigoBarra.Text;
                cArticulo art = new cArticulo();
                DataTable trdo = art.GetArticulo("", CodigoBarra,"");
                if (trdo.Rows.Count >0)
                {
                    if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    {
                        txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                        txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                        txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                        txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                        txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                        txt_Costo.Text = trdo.Rows[0]["Costo"].ToString();
                        txt_PrecioEfectivo.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                        txt_PrecioTarjeta.Text = trdo.Rows[0]["PrecioTarjeta"].ToString();
                    }
                }
                else
                {/*
                    txtCodigo.Text = "";
                    txt_Nombre.Text = "";
                    txt_Stock.Text = "";
                    txt_Costo.Text = "";
                    txt_PrecioEfectivo.Text = "";
                    txt_PrecioTarjeta.Text = "";
                    txt_Codigo.Text = "";*/
                }
                    
            }
            if (txt_PrecioEfectivo.Text != "")
            {
                Double Efectivo = Convert.ToDouble(txt_PrecioEfectivo.Text.Replace(".", ","));
                txt_PrecioEfectivo.Text = Math.Round(Efectivo, 0).ToString();
            }

            if (txt_PrecioTarjeta.Text != "")
            {
                Double Efectivo = Convert.ToDouble(txt_PrecioTarjeta.Text.Replace(".", ","));
                txt_PrecioTarjeta.Text = Math.Round(Efectivo, 0).ToString();
            }
        }

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            if(txt_Codigo.Text.Length <4)
            {
                return;
            }
            string Codigo = txt_Codigo.Text;
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetArticulo("", "", Codigo);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                {
                    txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                    txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                    txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                    txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                    txt_Costo.Text = trdo.Rows[0]["Costo"].ToString();
                    txt_PrecioEfectivo.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                    txt_PrecioTarjeta.Text = trdo.Rows[0]["PrecioTarjeta"].ToString();
                }
            }
            else
            {/*
                txt_Nombre.Text = "";
                txt_CodigoBarra.Text = "";
                txt_Stock.Text = "";
                txtCodigo.Text = "";
                txt_Costo.Text = "";
                txt_PrecioEfectivo.Text = "";
                txt_PrecioTarjeta.Text = "";*/
            }
            if (txt_PrecioEfectivo.Text != "")
            {
                Double Efectivo = Convert.ToDouble(txt_PrecioEfectivo.Text.Replace(".", ","));
                txt_PrecioEfectivo.Text = Math.Round(Efectivo, 0).ToString();
            }

            if (txt_PrecioTarjeta.Text != "")
            {
                Double Efectivo = Convert.ToDouble(txt_PrecioTarjeta.Text.Replace(".", ","));
                txt_PrecioTarjeta.Text = Math.Round(Efectivo, 0).ToString();
            }

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
            CalcularEfectivo();
           // txt_PrecioEfectivo.Text = (Math.Round(Efectivo, 0)).ToString();
        }

        private void CalcularEfectivo()
        {
            if (txt_Costo.Text == "")
            {
                Mensaje("Debe ingresar un Costo");
                return;
            }
            if (txtPorEfectivo.Text == "")
            {
                Mensaje("Debe ingresar un porcentaje");
                return;
            }
            Double Costo = Convert.ToDouble(txt_Costo.Text.Replace(".", ","));
            Double Por = Convert.ToDouble(txtPorEfectivo.Text.Replace(".", ","));
            Double Efectivo = Costo + Costo * (Por / 100);
            Efectivo = Math.Round(Efectivo, 0);
            txt_PrecioEfectivo.Text = Math.Round(Efectivo, 0).ToString();
        }
        private void btnAplicarTarjeta_Click(object sender, EventArgs e)
        {
            calculartarjeta();

        }

        private void calculartarjeta()
        {
            if (txt_Costo.Text == "")
            {
                Mensaje("Debe ingresar un Costo");
                return;
            }
            if (txtPorTarjeta.Text == "")
            {
                Mensaje("Debe ingresar un porcentaje");
                return;
            }

            Double Costo = Convert.ToDouble(txt_Costo.Text.Replace(".", ","));
            Double Por = Convert.ToDouble(txtPorTarjeta.Text.Replace(".", ","));
            Double Tarjeta = Costo + Costo * (Por / 100);
            Tarjeta = Math.Round(Tarjeta, 0);
            txt_PrecioTarjeta.Text = Math.Round(Tarjeta, 0).ToString();
        }

        private void txtPorEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CalcularEfectivo();
            }
        }

        private void txtPorTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                calculartarjeta();
        }
    }
}
