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
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal.CodigoPrincipalAbm = "31";
            FrmVerReportePresupuesto frm = new FrmVerReportePresupuesto();
            frm.Show();
        }

        private void Prueba_Load(object sender, EventArgs e)
        {
            string xxx = SistemaFact.Properties.Settings.Default.JOYConnectionString1;
            string yyyy = SistemaFact.Properties.Settings.Default.JOYConnectionString;
            string zzz = SistemaFact.Properties.Settings.Default.ISAUIConnectionString;
        }
    }
}
