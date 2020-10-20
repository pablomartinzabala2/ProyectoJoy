using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFact
{
    public partial class FrmVerReportePresupuesto : FormBase 
    {
        public FrmVerReportePresupuesto()
        {
            InitializeComponent();
        }

        private void FrmVerReportePresupuesto_Load(object sender, EventArgs e)
        {
            
            Int32 Codigo = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            // TODO: This line of code loads data into the 'DsJoyasPresupuesto.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DsJoyasPresupuesto.DataTable1, Codigo);
            this.reportViewer1.RefreshReport();
        }
    }
}
