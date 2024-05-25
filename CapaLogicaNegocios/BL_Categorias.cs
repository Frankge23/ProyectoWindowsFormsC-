using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;


namespace CapaLogicaNegocios
{
    public class BL_Categorias
    {
        private DAL_Categorias dal_Categorias = new DAL_Categorias();

        public List<Categoria> ObtenerCategorias()
        {
            return dal_Categorias.ObtenerCategorias();
        }

        public Categoria ObtenerCategoria(int idCategoria)
        {
            return dal_Categorias.ObtenerCategoria(idCategoria);
        }

        public bool InsertarCategoria(Categoria nuevaCategoria)
        {
            return dal_Categorias.InsertarCategoria(nuevaCategoria);
        }

        public bool ActualizarCategoria(Categoria categoriaActualizada)
        {
            return dal_Categorias.ActualizarCategoria(categoriaActualizada);
        }

        public bool EliminarCategoria(int idCategoria)
        {
            return dal_Categorias.EliminarCategoria(idCategoria);
        }
    }
}
