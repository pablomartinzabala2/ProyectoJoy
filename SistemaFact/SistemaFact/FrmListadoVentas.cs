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
    public partial class FrmListadoVentas : FormBase 
    {
        public FrmListadoVentas()
        {
            InitializeComponent();
        }

        private void FrmListadoVentas_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
            BuscarVenta(Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text));
        }

        private void BuscarVenta(DateTime FechaDesde,DateTime FechaHasta)
        {
            cFunciones fun = new cFunciones();
            Double Efectivo = 0;
            Double Tarjeta = 0;
            Double Total = 0;
            cVenta venta = new Clases.cVenta();
            DataTable trdo = venta.GetVentasxFecha(FechaDesde, FechaHasta);
            Grilla.DataSource = trdo;
            Efectivo = fun.TotalizarColumna(trdo, "ImporteEfectivo");
            Tarjeta = fun.TotalizarColumna(trdo, "ImporteTarjeta");
            Total = Efectivo + Tarjeta;
            txtTotal.Text = Total.ToString();
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[4].Width = 230;
            Grilla.Columns[2].HeaderText = "Eft/Débito";
            Grilla.Columns[3].HeaderText = "Tarjeta";
            Grilla.Columns[4].HeaderText = "Desc. Tarjeta";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarVenta(Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            Principal.CodigoPrincipalAbm = Grilla.CurrentRow.Cells[0].Value.ToString();
            FrmVenta frm = new FrmVenta();
            frm.ShowDialog();
        }
    }
}
