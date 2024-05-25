using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;

namespace CapaLogicaNegocios
{
    public class BL_Proveedores
    {
        private DAL_Proveedores dalProveedores;

        public BL_Proveedores()
        {
            dalProveedores = new DAL_Proveedores();
        }

        public void CrearProveedor(string nombreProveedor, string sectorComercial, string tipoDocumento, string numeroDocumento, string direccion, string telefono)
        {
            dalProveedores.CrearProveedor(nombreProveedor, sectorComercial, tipoDocumento, numeroDocumento, direccion, telefono);
        }

        public List<Proveedor> ObtenerProveedores()
        {
            return dalProveedores.ObtenerProveedores();
        }

        public void ActualizarProveedor(int idProveedor, string nombreProveedor, string sectorComercial, string tipoDocumento, string numeroDocumento, string direccion, string telefono)
        {
            dalProveedores.ActualizarProveedor(idProveedor, nombreProveedor, sectorComercial, tipoDocumento, numeroDocumento, direccion, telefono);
        }


        public void EliminarProveedor(int idProveedor)
        {
            dalProveedores.EliminarProveedor(idProveedor);
        }

    }
}
