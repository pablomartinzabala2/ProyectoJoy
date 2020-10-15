using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public class cMarca
    {
        public DataTable GetAll()
        {
            string sql = "select * from Marca";
            return cDb.GetDatatable(sql);
        }
    }
}
