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
    public partial class FrmConsultaVentaJoyas : FormBase 
    {
        cFunciones fun;
        public FrmConsultaVentaJoyas()
        {
            InitializeComponent();
        }

        private void FrmConsultaVentaJoyas_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
            cTipo tipo = new Clases.cTipo();
            DataTable trdo = tipo.GetTipos();
            fun.LlenarComboDatatable(cmbTipo, trdo, "Nombre", "CodTipo");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Int32? CodTipo = null;
            if (cmbTipo.SelectedIndex > 0)
                CodTipo = Convert.ToInt32(cmbTipo.SelectedValue);
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            Buscar(FechaDesde, FechaHasta, CodTipo);
        }

        private void Buscar(DateTime FechaDesde,DateTime FechaHasta,Int32? CodTipo)
        {
            cVentaJoya venta = new Clases.cVentaJoya();
            DataTable trdo = venta.GetResumenVentasxFecha(FechaDesde, FechaHasta, CodTipo);
            trdo = fun.TablaaMiles(trdo, "Total");
            Double Total = fun.TotalizarColumna(trdo, "Total");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "60;20;20");
            txtTotal.Text = Total.ToString();
            if (txtTotal.Text !="")
            {
                txtTotal.Text = fun.SepararDecimales(txtTotal.Text);
                txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
            }
        }
    }
}
