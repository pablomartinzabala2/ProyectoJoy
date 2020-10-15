using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using System.Data.SqlClient;
namespace SistemaFact
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BarcodeLib.Barcode codigo = new BarcodeLib.Barcode();
            panel1.BackgroundImage = codigo.Encode(BarcodeLib.TYPE.CODE128, "12345678988877744521", Color.Black, Color.White, 300, 300);
            pictureBox1.Image = codigo.Encode(BarcodeLib.TYPE.CODE128, "12345678988877744521", Color.Black, Color.White, 300, 300);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Clases.cConexion.GetConexion());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into CodigoBarra(Foto) values(@foto)";
            cmd.Parameters.Add("@Foto", System.Data.SqlDbType.Image);
            // Stream usado como buffer
             System.IO.MemoryStream ms = new System.IO.MemoryStream();
            // Se guarda la imagen en el buffer
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            // Se extraen los bytes del buffer para asignarlos como valor para el 
            // parámetro.
            cmd.Parameters["@Foto"].Value = ms.GetBuffer();
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /*
         * alter table articulo add  Fecha date
         * create table Impresora
( 
   Fila int,
   Columna int
   )
    

         * 
         */
    }
}
