using CapaEntidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;

namespace CapaAccesoDatos
{
    public class DAL_DetalleIngresos
    {
        private BDConexion bdConexion = new BDConexion();

        public bool InsertarDetalleIngreso(ClaseEntidades.DetalleIngreso detalleIngreso)
        {
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO DetalleIngreso (PrecioCompra, StockInicial, StockActual, Descuento) VALUES (@PrecioCompra, @StockInicial, @StockActual, @Descuento)", connection);
                command.Parameters.AddWithValue("@IdIngreso", detalleIngreso.IdIngreso);
                command.Parameters.AddWithValue("@PrecioCompra", detalleIngreso.PrecioCompra);
                command.Parameters.AddWithValue("@StockInicial", detalleIngreso.StockInicial);
                command.Parameters.AddWithValue("@StockActual", detalleIngreso.StockActual);
                command.Parameters.AddWithValue("@Descuento", detalleIngreso.Descuento);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public DetalleIngreso LeerDetalleIngreso(int idDetalleIngreso)
        {
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM DetalleIngreso WHERE IdDetalleIngreso = @IdDetalleIngreso", connection);
                command.Parameters.AddWithValue("@IdDetalleIngreso", idDetalleIngreso);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DetalleIngreso detalleIngreso = new DetalleIngreso();
                        detalleIngreso.IdDetalleIngreso = Convert.ToInt32(reader["IdDetalleIngreso"]);
                        if (reader["IdIngreso"] != DBNull.Value)
                        {
                            detalleIngreso.IdIngreso = Convert.ToInt32(reader["IdIngreso"]);
                        }

                        return detalleIngreso;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public bool ActualizarDetalleIngreso(DetalleIngreso detalleIngreso)
        {
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("UPDATE DetalleIngreso SET PrecioCompra = @PrecioCompra, StockInicial = @StockInicial, StockActual = @StockActual, Descuento = @Descuento WHERE IdDetalleIngreso = @IdDetalleIngreso", connection);
                command.Parameters.AddWithValue("@IdDetalleIngreso", detalleIngreso.IdDetalleIngreso);

                if (detalleIngreso.PrecioCompra != null)
                {
                    command.Parameters.AddWithValue("@PrecioCompra", detalleIngreso.PrecioCompra);
                }
                else
                {
                    command.Parameters.AddWithValue("@PrecioCompra", DBNull.Value);
                }

                if (detalleIngreso.StockInicial != null)
                {
                    command.Parameters.AddWithValue("@StockInicial", detalleIngreso.StockInicial);
                }
                else
                {
                    command.Parameters.AddWithValue("@StockInicial", DBNull.Value);
                }

                if (detalleIngreso.StockActual != null)
                {
                    command.Parameters.AddWithValue("@StockActual", detalleIngreso.StockActual);
                }
                else
                {
                    command.Parameters.AddWithValue("@StockActual", DBNull.Value);
                }

                if (detalleIngreso.Descuento != null)
                {
                    command.Parameters.AddWithValue("@Descuento", detalleIngreso.Descuento);
                }
                else
                {
                    command.Parameters.AddWithValue("@Descuento", DBNull.Value);
                }

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarDetalleIngreso(int idDetalleIngreso)
        {
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM DetalleIngreso WHERE IdDetalleIngreso = @IdDetalleIngreso", connection);
                command.Parameters.AddWithValue("@IdDetalleIngreso", idDetalleIngreso);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<DetalleIngreso> ObtenerDetallesIngresos()
        {
            List<DetalleIngreso> detallesIngresos = new List<DetalleIngreso>();
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM DetalleIngreso", connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DetalleIngreso detalleIngreso = new DetalleIngreso();

                        detalleIngreso.IdDetalleIngreso = reader.IsDBNull(reader.GetOrdinal("IdDetalleIngreso")) ? 0 : Convert.ToInt32(reader["IdDetalleIngreso"]);
                        detalleIngreso.PrecioCompra = reader.IsDBNull(reader.GetOrdinal("PrecioCompra")) ? 0 : Convert.ToDecimal(reader["PrecioCompra"]);
                        detalleIngreso.StockInicial = reader.IsDBNull(reader.GetOrdinal("StockInicial")) ? 0 : Convert.ToInt32(reader["StockInicial"]);
                        detalleIngreso.StockActual = reader.IsDBNull(reader.GetOrdinal("StockActual")) ? 0 : Convert.ToInt32(reader["StockActual"]);
                        detalleIngreso.Descuento = reader.IsDBNull(reader.GetOrdinal("Descuento")) ? 0 : Convert.ToDecimal(reader["Descuento"]);

                        detallesIngresos.Add(detalleIngreso);
                    }
                }
            }
            return detallesIngresos;
        }
    }
}