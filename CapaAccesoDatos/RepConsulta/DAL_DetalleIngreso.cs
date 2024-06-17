using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.RepConsulta
{
    public class DAL_DetalleIngreso
    {
        private BDConexion bdConexion = new BDConexion();

        public DataTable DetalleIngreso(String fechaInicial, String fechaFinal)
        {
            MySqlConnection connection = bdConexion.GetConnection();
            DataTable dataTable = new DataTable();

            try
            {
                string query = "SELECT a.Nombre, a.Precio, c.Nombre AS categoria, i.FechaIngreso, p.NombreProveedor, t.Nombres AS trabajador " +
                               "FROM detalleingreso dt, ingreso i, articulo a, categoria c, proveedor p, trabajador t " +
                               "WHERE dt.IdIngreso = i.IdIngreso AND dt.IdArticulo = a.IdArticulo AND a.IdCategoria = c.IdCategoria AND " +
                               "i.IdProveedor = p.IdProveedor AND i.IdTrabajador = t.IdTrabajador " +
                               " AND i.FechaIngreso BETWEEN '" + fechaInicial + "' AND'" + fechaFinal + "'; ";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                dataTable.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
    }
}
