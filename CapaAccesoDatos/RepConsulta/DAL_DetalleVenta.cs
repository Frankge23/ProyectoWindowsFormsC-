using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.RepConsulta
{
    public class DAL_DetalleVenta
    {
        private BDConexion bdConexion = new BDConexion();

        public DataTable DetalleVenta(String fechaInicial, String fechaFinal)
        {
            MySqlConnection connection = bdConexion.GetConnection();
            DataTable dataTable = new DataTable();

            try
            {
                string query = "SELECT a.Nombre, dt.Cantidad, SUM(dt.Cantidad * dt.PrecioVenta) as subtotal, " +
                               "v.FechaVenta, v.TipoComprobante, CONCAT(c.Nombres, ' ', c.Apellidos) as cliente " +
                               "FROM detalleventa dt " +
                               "JOIN venta v ON dt.IdVenta = v.IdVenta " +
                               "JOIN detalleingreso di ON dt.IdDetalleIngreso = di.IdDetalleIngreso " +
                               "JOIN articulo a ON di.IdArticulo = a.IdArticulo " +
                               "JOIN cliente c ON v.IdCliente = c.IdCliente " +
                               "WHERE v.FechaVenta BETWEEN '" + fechaInicial + "' AND '" + fechaFinal + "' " +
                               "GROUP BY a.Nombre, dt.Cantidad, v.FechaVenta, v.TipoComprobante, c.Nombres, c.Apellidos; ";


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
