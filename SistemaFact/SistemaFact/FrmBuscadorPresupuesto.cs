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
    public partial class FrmBuscadorPresupuesto : FormBase 
    {
        cFunciones fun;
        public FrmBuscadorPresupuesto()
        {
            InitializeComponent();
        }

        private void FrmBuscadorPresupuesto_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
        }

        private void Cargar(DateTime FechaDesde,DateTime FechaHasta,string Apellido)
        {
            cPresupuesto prep = new Clases.cPresupuesto();
            DataTable trdo = prep.GetPresupuestoxFecha(FechaDesde, FechaHasta,Apellido);
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            string Col = "0;15;35;35;15";
            fun.AnchoColumnas(Grilla, Col);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            string Apellido = txtApellido.Text;
            Cargar(FechaDesde, FechaHasta, Apellido);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            Principal.CodigoPrincipalAbm = Grilla.CurrentRow.Cells[0].Value.ToString();
            this.Close(); 
            if (Principal.CodigoSenia=="1")
            {
                FrmPresupuesto frm = new SistemaFact.FrmPresupuesto();
                frm.Show();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            Principal.CodigoPrincipalAbm = Grilla.CurrentRow.Cells[0].Value.ToString();
            FrmVerReportePresupuesto frm = new FrmVerReportePresupuesto();
            frm.Show();
        }
    }
}
