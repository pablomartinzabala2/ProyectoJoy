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
    public partial class FrmListadoCompra : FormBase
    {
        cFunciones fun;
        public FrmListadoCompra()
        {
            InitializeComponent();
        }

        private void FrmListadoCompra_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime Fechahasta = Convert.ToDateTime(txtFechaHasta.Text);
            Buscar(FechaDesde, Fechahasta);
        }

        private void Buscar(DateTime FechaDesde,DateTime FechaHasta)
        {
            cCompra compra = new Clases.cCompra();
            DataTable trdo = compra.GetComprasxFecha(FechaDesde, FechaHasta);
            Grilla.DataSource = trdo;
        }
    }
}
