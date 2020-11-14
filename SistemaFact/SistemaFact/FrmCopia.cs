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
using System.Data.SqlClient;
namespace SistemaFact
{
    public partial class FrmCopia : FormBase
    {
        public FrmCopia()
        {
            InitializeComponent();
        }

        private void FrmCopia_Load(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            fun.EstiloBotones(btnCopia);
        }

        private void btnCopia_Click(object sender, EventArgs e)
        {
            string cad = Clases.cConexion.GetConexion();
            try
            {
                string ConnectionString = cad;
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("backupdb", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("El backup fue realizado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
