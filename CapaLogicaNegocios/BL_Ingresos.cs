using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;

namespace CapaLogicaNegocios
{
    public class BL_Ingresos
    {
        private DAL_Ingresos ingresosDAL;

        public BL_Ingresos()
        {
            ingresosDAL = new DAL_Ingresos();
        }
        public bool InsertarIngreso(Ingreso ingreso)
        {
            return ingresosDAL.InsertarIngreso(ingreso);
        }

        public DataTable ObtenerIngresos()
        {
            return ingresosDAL.ObtenerIngresos();
        }

        public bool ActualizarIngreso(Ingreso ingreso)
        {
            return ingresosDAL.ActualizarIngreso(ingreso);
        }

        public bool EliminarIngreso(int idIngreso)
        {
            return ingresosDAL.EliminarIngreso(idIngreso);
        }
    }
}
