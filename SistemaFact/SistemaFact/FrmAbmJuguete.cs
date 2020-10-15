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
    public partial class FrmAbmJuguete : FormBase
    {
        public FrmAbmJuguete()
        {
            InitializeComponent();
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
                case 4:
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }


        }

        private void FrmAbmJuguete_Load(object sender, EventArgs e)
        {
            Botonera(1);
            Grupo.Enabled = false;
            cFunciones fun = new cFunciones();
            cMarca marca = new Clases.cMarca();
            DataTable trdo = marca.GetAll();
            fun.LlenarComboDatatable(cmb_CodMarca, trdo, "Nombre", "CodMarca");
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow r in trdo.Rows)
            {
                coleccion.Add(r["Nombre"].ToString());
            }
            cmb_CodMarca.AutoCompleteCustomSource = coleccion;
            cmb_CodMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_CodMarca.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_CodMarca.SelectedIndex = -1;
        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LimpiarGenerico(this);
            txtPorEfectivo.Text = "70";
            txtPorTarjeta.Text = "100";
            txt_Nombre.Focus();
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

            if (txt_Nombre.Text == "")
            {
                Mensaje("Debe ingresar una descripción para continuar");
                return;
            }
            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "Juguete");
            else
            {
                // if (txt_Ruta.Text != "")
                //   txt_Ruta.Text = txt_Ruta.Text.Replace("\\", "\\\\");
                fun.ModificarGenerico(this, "Juguete", "CodArticulo", txtCodigo.Text);

            }

            Mensaje("Datos grabados correctamente");
            txtPorEfectivo.Text = "";
            txtPorTarjeta.Text = "";
            Botonera(1);
            fun.LimpiarGenerico(this);

            txtCodigo.Text = "";
            Grupo.Enabled = false;
        }

        public void Mensaje(string msj)
        {
            MessageBox.Show(msj, "Sistema");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Codigo;Nombre;CodigoBarra";
            Principal.TablaPrincipal = "Juguete";
            Principal.OpcionesColumnasGrilla = "CodArticulo;Nombre;Costo";
            Principal.ColumnasVisibles = "0;1;1";
            Principal.ColumnasAncho = "0;390;190";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CampoIdSecundarioGenerado != "")
            {
                
                switch (Principal.NombreTablaSecundario)
                { 
                    case "Marca":
                        cFunciones fun = new Clases.cFunciones();
                        fun.LlenarCombo(cmb_CodMarca , "Marca", "Nombre", "CodMarca");
                        cmb_CodMarca.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                }
            }

            if (Principal.CodigoPrincipalAbm != null)
            {
                Botonera(3);
                txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();
                cFunciones fun = new Clases.cFunciones();
                fun.CargarControles(this, "Juguete", "CodArticulo", txtCodigo.Text);
                if (txt_PrecioEfectivo.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txt_PrecioEfectivo.Text.Replace(".", ","));
                    txt_PrecioEfectivo.Text = Math.Round(Efectivo, 0).ToString();
                }

                if (txt_Costo.Text  != "")
                {
                    Double Costo = Convert.ToDouble(txt_Costo.Text.Replace(".", ","));
                    txt_Costo.Text = Math.Round(Costo, 0).ToString();
                }

                if (txt_PrecioTarjeta.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txt_PrecioTarjeta.Text.Replace(".", ","));
                    txt_PrecioTarjeta.Text = Math.Round(Efectivo, 0).ToString();
                }

            }

        }

        private void btnAplicarEfectivo_Click(object sender, EventArgs e)
        {
            CalcularEfectivo();
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

        private void btnAplicarTarjeta_Click(object sender, EventArgs e)
        {
            calculartarjeta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
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

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodMarca";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Marca";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void txt_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txt_Stock.Focus();
            }
        }

        private void txt_Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                txt_Codigo.Focus();
        }

        private void txt_CodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                txt_Costo.Focus();
        }

        private void txt_Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                txt_CodigoBarra.Focus();
        }

        private void txt_Costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                txt_PrecioEfectivo.Focus();
        }

        private void txt_PrecioEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                txt_PrecioTarjeta.Focus();
        }

        private void txt_PrecioTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                cmb_CodMarca.Focus();
        }

        private void txt_CodigoBarra_TextChanged(object sender, EventArgs e)
        {
            if (txt_CodigoBarra.Text.Length > 5)
            {
                string CodigoBarra = txt_CodigoBarra.Text;
                cJuguete art = new Clases.cJuguete();
                DataTable trdo = art.GetArticulo("", CodigoBarra, "");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string msj = "Confirma eliminar la marca ";
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
                fun.EliminarGenerico("Juguete", "CodArticulo", txtCodigo.Text);
                fun.LimpiarGenerico(this);
                Botonera(1);
                MessageBox.Show("Datos borrados correctamente");
            }
            catch (Exception )
            {
                MessageBox.Show("No se puede eliminar el producto, debe tener asociado ventas");
                return;
            }
        }
    }
}
