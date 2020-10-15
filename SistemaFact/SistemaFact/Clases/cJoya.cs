using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public  class cJoya
    {
        public void Insertar (string Nombre,Int32?CodTipo)
        {
            string sql = "insert into Joya(Nombre,CodTipo)";
            sql = sql + " values(" + "'" + Nombre +"'";
            if (CodTipo !=null)
            {
                sql = sql + "," + CodTipo.ToString();
            }
            else
            {
                sql = sql + ",null";
            }
            sql = sql + ")";
            cDb.Grabar(sql);
        }
    }
}
