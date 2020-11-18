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
    public partial class FrmResumenVentas : FormBase 
    {
        cFunciones fun;
        public FrmResumenVentas()
        {
            InitializeComponent();
        }

        private void FrmResumenVentas_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
        }

        public string Getmes(int Mes)
        {
            string Nombre = "";
            switch(Mes)
            {
                case 1:
                    Nombre = "Enero";
                    break;
                case 2:
                    Nombre = "Febrero";
                    break;
                case 3:
                    Nombre = "Marzo";
                    break;
                case 4:
                    Nombre = "Abril";
                    break;
                case 5:
                    Nombre = "Mayo";
                    break;
                case 6:
                    Nombre = "Junio";
                    break;
                case 7:
                    Nombre = "Julio";
                    break;
                case 8:
                    Nombre = "Agosto";
                    break;
                case 9:
                    Nombre = "Septiembre";
                    break;
                case 10:
                    Nombre = "Octubre";
                    break;
                case 11:
                    Nombre = "Novimbre";
                    break;
                case 12:
                    Nombre = "Diciembre";
                    break;
            }
            return Nombre;
        }

        public void Buscar (DateTime FechaDesde,DateTime FechaHasta)
        {
            string Mes = "";
            string Anio = "";
            int NumeroMes = 0;
            string Total = "";
            string TotalComision = "";
            string TotalRendido = "";
            string Val = "";
            string Col = "Mes;Anio;Total;TotalComision;TotalRendido";
            DataTable tbResumen = fun.CrearTabla(Col);
            cVenta venta = new Clases.cVenta();
            DataTable trdo = venta.GetResumenVentas(FechaDesde, FechaHasta);
            if (trdo.Rows.Count >0)
            {
                for (int i=0;i<trdo.Rows.Count;i++)
                {
                     Val = "";
                     NumeroMes =Convert.ToInt32(trdo.Rows[i]["Mes"].ToString());
                     Mes = Getmes(NumeroMes); 
                     Anio = trdo.Rows[i]["Anio"].ToString();
                     Total = trdo.Rows[i]["Total"].ToString();
                     TotalComision = trdo.Rows[i]["TotalComision"].ToString();
                     TotalRendido = trdo.Rows[i]["TotalRendido"].ToString();
                     Val = Mes + ";" + Anio;
                     Val = Val + ";" + Total + ";" + TotalComision + ";" + TotalRendido;
                     tbResumen = fun.AgregarFilas(tbResumen, Val);
                }
            }
            if (tbResumen.Rows.Count >0)
            {
                tbResumen = fun.TablaaMiles(tbResumen, "Total");
                tbResumen = fun.TablaaMiles(tbResumen, "TotalComision");
                tbResumen = fun.TablaaMiles(tbResumen, "TotalRendido");
            }
            Double dTotal = fun.TotalizarColumna(tbResumen, "Total");
            Double dTotalComision = fun.TotalizarColumna(tbResumen, "TotalComision");
            Double dTotalRendido = fun.TotalizarColumna(tbResumen, "TotalRendido");
            txtTotal.Text = dTotal.ToString();
            txtTotalRendido.Text = dTotalRendido.ToString();
            txtTotalComision.Text = dTotalComision.ToString();
            Grilla.DataSource = tbResumen;
            if (txtTotal.Text !="")
            {
                txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
            }
            if (txtTotalComision.Text != "")
            {
                txtTotalComision.Text = fun.FormatoEnteroMiles(txtTotalComision.Text);
            }
            if (txtTotalRendido.Text != "")
            {
                txtTotalRendido.Text = fun.FormatoEnteroMiles(txtTotalRendido.Text);
            }
            string ancho = "30;10;20;20;20";
            fun.AnchoColumnas(Grilla, ancho);
            Grilla.Columns[3].HeaderText = "Total Comisión";
            Grilla.Columns[4].HeaderText = "Total Rendido";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            Buscar(FechaDesde, FechaHasta);
        }
    }
}
