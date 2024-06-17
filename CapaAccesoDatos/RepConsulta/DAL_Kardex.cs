using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.RepConsulta
{
    public class DAL_Kardex
    {
        private BDConexion bdConexion = new BDConexion();

        public DataTable Kardex(String fechaInicial, String fechaFinal)
        {
            MySqlConnection connection = bdConexion.GetConnection();
            DataTable dataTable = new DataTable();

            try
            {
                string query = "SELECT a.Codigo, a.Nombre, k.FechaMovimiento, k.TipoMovimiento, k.Cantidad, Precio, k.StockFinal FROM kardex k," +
                    " articulo a WHERE k.IdArticulo = a.IdArticulo AND k.FechaMovimiento BETWEEN '" + fechaInicial + "' AND'" + fechaFinal + "'; "; MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                dataTable.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el kardex: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
    }
}
