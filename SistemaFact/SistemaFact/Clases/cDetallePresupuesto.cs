using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFact.Clases;
using System.Data;
namespace SistemaFact.Clases
{
    public  class cDetallePresupuesto
    {
        public DataTable getJoyasxPresupuesto(Int32 CodPresupuesto)
        {
            string sql = " select d.CodRegistro,j.CodJoya,j.Codigo,j.Nombre";
            sql = sql + ",d.Cantidad,d.Precio,d.SubTotal";
            sql = sql + ",(select tip.Nombre from tipo tip where tip.CodTipo=j.CodTipo) as Tipo ";
            sql = sql + " from detallepresupuesto d, Joya j";
            sql = sql + " where d.CodJoya=j.CodJoya";
            sql = sql + " and d.CodPresupuesto =" + CodPresupuesto.ToString();
            return cDb.GetDatatable(sql);
        }

        public DataTable getJoyasxPresupuestoxVenta(Int32 CodPresupuesto)
        {
            string sql = " select d.CodRegistro,j.CodJoya,j.Codigo,j.Nombre";
            sql = sql + ",d.Cantidad,d.Precio";
            sql = sql + " from detallepresupuesto d, Joya j";
            sql = sql + " where d.CodJoya=j.CodJoya";
            sql = sql + " and d.CodPresupuesto =" + CodPresupuesto.ToString();
            return cDb.GetDatatable(sql);
        }
    }
}
