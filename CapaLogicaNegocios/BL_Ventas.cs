using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;

namespace CapaLogicaNegocios
{
    public class BL_Ventas
    {
        private DAL_Ventas dalVentas = new DAL_Ventas();

        public List<Venta> ObtenerVentas()
        {
            return dalVentas.ObtenerVentas();
        }

        public Venta ObtenerVenta(int idVenta)
        {
            return dalVentas.ObtenerVenta(idVenta);
        }

        public bool InsertarVenta(Venta venta)
        {

            return dalVentas.InsertarVenta(venta);
        }

        public bool ActualizarVenta(Venta venta)
        {

            return dalVentas.ActualizarVenta(venta);
        }

        public bool EliminarVenta(int idVenta)
        {

            return dalVentas.EliminarVenta(idVenta);
        }
    }
}
