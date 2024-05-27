using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;

namespace CapaLogicaNegocios
{
    public class BL_DetalleVentas
    {
        private DAL_DetalleVentas dalDetalleVentas = new DAL_DetalleVentas();


        public List<DetalleVenta> ObtenerDetallesVentas()
        {
            return dalDetalleVentas.ObtenerDetallesVentas();
        }


        public DetalleVenta LeerDetalleVenta(int idDetalleVenta)
        {
            return dalDetalleVentas.LeerDetalleVenta(idDetalleVenta);
        }


        public bool ActualizarDetalleVenta(DetalleVenta detalleVenta)
        {
            return dalDetalleVentas.ActualizarDetalleVenta(detalleVenta);
        }

        public bool InsertarDetalleVenta(DetalleVenta detalleVenta)
        {
            return dalDetalleVentas.InsertarDetalleVenta(detalleVenta);
        }

        public bool EliminarDetalleVenta(int idDetalleVenta)
        {
            return dalDetalleVentas.EliminarDetalleVenta(idDetalleVenta);
        }
    }
}
