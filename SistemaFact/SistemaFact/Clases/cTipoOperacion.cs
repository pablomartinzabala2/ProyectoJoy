using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public  class cTipoOperacion
    {
        public DataTable GetTipos()
        {
            string sql = "select * from TipoOperacion ";
            sql = sql + " order by Codigo ";
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }
    }
}
