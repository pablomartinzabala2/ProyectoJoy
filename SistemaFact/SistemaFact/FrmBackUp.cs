using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemaFact.Clases;
namespace SistemaFact
{
    public partial class FrmBackUp : FormBase 
    {
        public FrmBackUp()
        {
            InitializeComponent();
        }

        private void FrmBackUp_Load(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string cad = cConexion.GetConexion();
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
