using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public class cImpresora
    {
        public void Insertar(int Fila,int Columna)
        {
            string sql = "delete from Impresora";
            cDb.Grabar(sql);
            sql = "insert into Impresora(Fila,Columna)";
            sql = sql + " Values(" + Fila.ToString();
            sql = sql + "," + Columna.ToString();
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetCordenadas()
        {
            string sql = "select * from Impresora";
            return cDb.GetDatatable(sql);
        }

    }
}
