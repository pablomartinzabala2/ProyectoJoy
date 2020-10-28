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
    public partial class FrmListadoVentaJoya : FormBase 
    {
        public FrmListadoVentaJoya()
        {
            InitializeComponent();
        }

        private void FrmListadoVentaJoya_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
            BuscarVenta(Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
            BuscarVenta(Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text));
        }

        private void BuscarVenta(DateTime FechaDesde, DateTime FechaHasta)
        {
            cFunciones fun = new cFunciones();
           
            cVentaJoya  venta = new Clases.cVentaJoya();
            DataTable trdo = venta.GetVentasxFecha(FechaDesde, FechaHasta);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;10;45;45");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro para continuar");
                return;
            }
            Principal.CodVenta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            FrmVentaJoya frm = new FrmVentaJoya();
            frm.Show();
        }
    }
}
