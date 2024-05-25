using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using static CapaEntidades.ClaseEntidades;

namespace CapaLogicaNegocios
{
    public class BL_Articulos
    {
        private DAL_Articulos dal_Articulos = new DAL_Articulos();

        public List<Articulo> ObtenerArticulos()
        {
            return dal_Articulos.ObtenerArticulos();
        }       
        public bool InsertarArticulo(Articulo nuevoArticulo)
        {
            return dal_Articulos.InsertarArticulo(nuevoArticulo);
        }

        public bool ActualizarArticulo(Articulo articuloActualizado)
        {
            return dal_Articulos.ActualizarArticulo(articuloActualizado);
        }

        public bool EliminarArticulo(int idArticulo)
        {
            return dal_Articulos.EliminarArticulo(idArticulo);
        }
        public List<Categoria> ObtenerCategorias()
        {
            try
            {
                //Metodo Implementado en DAL_Articulos
                return dal_Articulos.ObtenerCategorias();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }
        }

    }
}
