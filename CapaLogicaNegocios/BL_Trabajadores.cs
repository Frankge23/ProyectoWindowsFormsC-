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
    public class BL_Trabajadores
    {
        private DAL_Trabajadores trabajadoresDAL;

        public BL_Trabajadores()
        {
            trabajadoresDAL = new DAL_Trabajadores();
        }

        public DataTable ObtenerTrabajadores()
        {          
            return trabajadoresDAL.ObtenerTrabajadores();
        }

        public bool InsertarTrabajador(Trabajador trabajador)
        {
            return trabajadoresDAL.InsertarTrabajador(trabajador);
        }

        public bool ActualizarTrabajador(Trabajador trabajador)
        {
            return trabajadoresDAL.ActualizarTrabajador(trabajador);
        }

        public bool EliminarTrabajador(int idTrabajador)
        {
            return trabajadoresDAL.EliminarTrabajador(idTrabajador);
        }

    }
}
