using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public class cAccesos
    {
        public void Restar()
        {
            string sql = "update Accesos set Cantidad = Cantidad - 1";
            cDb.Grabar(sql);
        }

        public int GetCantidad()
        {
            int Cantidad = 0;
            string sql = "select Cantidad from Accesos";
            DataTable tb = cDb.GetDatatable(sql);
            if (tb.Rows.Count > 0)
                if (tb.Rows[0]["Cantidad"].ToString() != "")
                    Cantidad = Convert.ToInt32(tb.Rows[0]["Cantidad"].ToString());
            return Cantidad;
            
        }
    }
}
