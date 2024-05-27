using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaAccesoDatos;
using CapaEntidades;
using static CapaEntidades.ClaseEntidades;


namespace CapaLogicaNegocios
{
    public class BL_DetalleIngresos
    {
        private DAL_DetalleIngresos dalDetalleIngresos = new DAL_DetalleIngresos();

        public bool InsertarDetalleIngreso(DetalleIngreso detalleIngreso)
        {
            return dalDetalleIngresos.InsertarDetalleIngreso(detalleIngreso);
        }

        public DetalleIngreso LeerDetalleIngreso(int idDetalleIngreso)
        {
            return dalDetalleIngresos.LeerDetalleIngreso(idDetalleIngreso);
        }

        public bool ActualizarDetalleIngreso(DetalleIngreso detalleIngreso)
        {
            // Verifica si el detalle de ingreso existe antes de intentar actualizarlo
            if (LeerDetalleIngreso(detalleIngreso.IdDetalleIngreso) != null)
            {
                return dalDetalleIngresos.ActualizarDetalleIngreso(detalleIngreso);
            }
            else
            {
                return false; // No se encontró el detalle de ingreso
            }
        }

        public bool EliminarDetalleIngreso(int idDetalleIngreso)
        {
            // Verifica si el detalle de ingreso existe antes de intentar eliminarlo
            if (LeerDetalleIngreso(idDetalleIngreso) != null)
            {
                return dalDetalleIngresos.EliminarDetalleIngreso(idDetalleIngreso);
            }
            else
            {
                return false; // No se encontró el detalle de ingreso
            }
        }

        public List<DetalleIngreso> ObtenerDetallesIngresos()
        {
            return dalDetalleIngresos.ObtenerDetallesIngresos();
        }

    }
}
