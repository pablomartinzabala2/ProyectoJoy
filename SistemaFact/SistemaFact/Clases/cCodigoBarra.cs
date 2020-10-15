using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SistemaFact.Clases
{
    public class cCodigoBarra
    {
        public void Insertar(PictureBox Cuadro,int Fila,int Columna)
        {
            cDb.Grabar("delete from CodigoBarra");
            SqlConnection con = new SqlConnection(Clases.cConexion.GetConexion());
            SqlCommand cmd = new SqlCommand();
            string sql = "Insert into CodigoBarra(Foto,Foto2,Foto3,Foto4,Foto5,Foto6)";
            sql = sql + "values(@Foto,@Foto2,@Foto3,@Foto4,@Foto5,@Foto6)";
            
            con.Open();
            for (int i=1;i< Fila + 1;i++)
            {
                if (i==Fila)
                {
                    cmd.Parameters.Add("@Foto", System.Data.SqlDbType.Image);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    Cuadro.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    cmd.Parameters["@Foto"].Value = ms.GetBuffer();
                    switch (Columna)
                    {
                        case 1:
                            sql = "Insert into CodigoBarra(Foto)";
                            sql = sql + " values(@Foto)";
                            break;
                        case 2:
                            sql = "Insert into CodigoBarra(Foto2)";
                            sql = sql + " values(@Foto)";
                            break;
                        case 3:
                            sql = "Insert into CodigoBarra(Foto3)";
                            sql = sql + " values(@Foto)";
                            break;
                        case 4:
                            sql = "Insert into CodigoBarra(Foto4)";
                            sql = sql + " values(@Foto)";
                            break;
                        case 5:
                            sql = "Insert into CodigoBarra(Foto5)";
                            sql = sql + " values(@Foto)";
                            break;
                        case 6:
                            sql = "Insert into CodigoBarra(Foto6)";
                            sql = sql + " values(@Foto)";
                            break;                            
                    }
                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string sql2 = "Insert into CodigoBarra(Foto,Foto2,Foto3,Foto4,Foto5,Foto6)";
                    sql2 = sql2 + " Values(null,null,null,null,null,null)";
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = sql2;
                    cmd2.Connection = con;
                    cmd2.ExecuteNonQuery();
                }
            }
            con.Close();

        }
    }
}
