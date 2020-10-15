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
    public partial class FrmReporte : FormBase 
    {
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
            int Codigo = Convert.ToInt32(Principal.CodigoSenia);
            this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1, Codigo);

            this.reportViewer1.RefreshReport();
        }
    }
}
