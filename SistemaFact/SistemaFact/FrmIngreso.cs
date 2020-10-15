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
    public partial class FrmIngreso : FormBase
    {
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(CmbTipoPrenda, "TipoPrenda", "Nombre", "CodTipoPrenda");
            fun.LlenarCombo(cmbColor , "Color", "Nombre", "CodColor");
            fun.LlenarCombo(cmbOrigen , "Origen", "Nombre", "CodOrigen");
        }

        private void btnAbrirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string ruta = file.FileName;
                txtRuta.Text = ruta;
                Imagen.Image = System.Drawing.Image.FromFile(ruta);
                string RUTAGRABAR = "e:\\ARCHIVO\\" + file.SafeFileName.ToString();
                Imagen.Image.Save(RUTAGRABAR);
            }
            else
            {
                txtRuta.Text = "";
            }
        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text =="")
            {
                Mensaje("Ingresar descripcion");
                return;
            }
            string Nombre = txtDescripcion.Text;
            Double? Costo = null;
            Double? Precio = null;
            int? CodColor = null;
            string Ruta = txtRuta.Text;
            int? CodTipoPrenda = null;
            string CodigoBarra = null;
            cArticulo art = new Clases.cArticulo();
            cCodigoBarra objCodBarra = new cCodigoBarra();
            if (txtPrecioVenta.Text != "")
                Precio = Convert.ToDouble(txtPrecioVenta.Text);
            if (cmbColor.SelectedIndex > 0)
                CodColor = Convert.ToInt32(cmbColor.SelectedValue);
            if (CmbTipoPrenda.SelectedIndex > 0)
                CodTipoPrenda = Convert.ToInt32(CmbTipoPrenda.SelectedValue);
           
            CodigoBarra = txtCodigoBarra.Text;
            art.Insertar(Nombre, Costo, Precio, CodColor,Ruta, CodTipoPrenda,CodigoBarra);
            if (txtCodigoBarra.Text != "")
                objCodBarra.Insertar(ImagenCodigo, 1,2 );
            Mensaje("Datos grabados correctamente");
            Limpiar();
            

        }

        private void Limpiar()
        {
            txtDescripcion.Text = "";
            txtPrecioVenta.Text = "";
            txtRuta.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                    case "TipoPrenda":  
                        fun.LlenarCombo(CmbTipoPrenda, "TipoPrenda", "Nombre", "CodTipoPrenda");
                        CmbTipoPrenda.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                    case "Origen":  
                        fun.LlenarCombo(cmbOrigen, "Origen", "Nombre", "CodOrigen");
                        cmbOrigen.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
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
            while (c<10)
            {
                nro = r.Next(0, 10);
                if (c == 0)
                    codigo = nro.ToString();
                else
                    codigo = codigo + nro.ToString();
                c++;
            }  
            txtCodigoBarra.Text = codigo;
            BarcodeLib.Barcode CodBar = new BarcodeLib.Barcode();
            //panel1.BackgroundImage = codigo.Encode(BarcodeLib.TYPE.CODE128, "12345678988877744521", Color.Black, Color.White, 300, 300);
            ImagenCodigo.Image = CodBar.Encode(BarcodeLib.TYPE.CODE128, codigo , Color.Black, Color.White, 300, 300);
        }
    }
}
