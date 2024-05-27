using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;

namespace CapaAccesoDatos
{
    public class DAL_DetalleVentas
    {
        private BDConexion bdConexion = new BDConexion();

        public List<DetalleVenta> ObtenerDetallesVentas()
        {
            List<DetalleVenta> detallesVentas = new List<DetalleVenta>();
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM DetalleVenta", connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DetalleVenta detalleVenta = new DetalleVenta
                        {
                            IdDetalleVenta = Convert.ToInt32(reader["IdDetalleVenta"]),
                            IdVenta = reader.IsDBNull(reader.GetOrdinal("IdVenta")) ? 0 : Convert.ToInt32(reader["IdVenta"]),
                            IdDetalleIngreso = reader.IsDBNull(reader.GetOrdinal("IdDetalleIngreso")) ? 0 : Convert.ToInt32(reader["IdDetalleIngreso"]),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                            Descuento = reader.IsDBNull(reader.GetOrdinal("Descuento")) ? 0m : Convert.ToDecimal(reader["Descuento"])
                        };
                        detallesVentas.Add(detalleVenta);
                    }
                }
            }
            return detallesVentas;
        }

        public DetalleVenta LeerDetalleVenta(int idDetalleVenta)
        {
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM DetalleVenta WHERE IdDetalleVenta = @IdDetalleVenta", connection);
                command.Parameters.AddWithValue("@IdDetalleVenta", idDetalleVenta);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DetalleVenta
                        {
                            IdDetalleVenta = Convert.ToInt32(reader["IdDetalleVenta"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            IdDetalleIngreso = Convert.ToInt32(reader["IdDetalleIngreso"]),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                            Descuento = reader["Descuento"] != DBNull.Value ? Convert.ToDecimal(reader["Descuento"]) : 0m
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public bool ActualizarDetalleVenta(DetalleVenta detalleVenta)
        {
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("UPDATE DetalleVenta SET Cantidad = @Cantidad, PrecioVenta = @PrecioVenta, Descuento = @Descuento WHERE IdDetalleVenta = @IdDetalleVenta", connection);
                command.Parameters.AddWithValue("@IdDetalleVenta", detalleVenta.IdDetalleVenta);

                // Los campos no nulos
                command.Parameters.AddWithValue("@Cantidad", detalleVenta.Cantidad);
                command.Parameters.AddWithValue("@PrecioVenta", detalleVenta.PrecioVenta);

                // El campo que puede ser nulo
                if (detalleVenta.Descuento != 0m)
                {
                    command.Parameters.AddWithValue("@Descuento", detalleVenta.Descuento);
                }
                else
                {
                    command.Parameters.AddWithValue("@Descuento", DBNull.Value);
                }

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertarDetalleVenta(DetalleVenta detalleVenta)
        {
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO DetalleVenta (Cantidad, PrecioVenta, Descuento) VALUES (@Cantidad, @PrecioVenta, @Descuento)", connection);

                command.Parameters.AddWithValue("@Cantidad", detalleVenta.Cantidad);
                command.Parameters.AddWithValue("@PrecioVenta", detalleVenta.PrecioVenta);

                if (detalleVenta.Descuento != 0m)
                {
                    command.Parameters.AddWithValue("@Descuento", detalleVenta.Descuento);
                }
                else
                {
                    command.Parameters.AddWithValue("@Descuento", DBNull.Value);
                }

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarDetalleVenta(int idDetalleVenta)
        {
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM DetalleVenta WHERE IdDetalleVenta = @IdDetalleVenta", connection);
                command.Parameters.AddWithValue("@IdDetalleVenta", idDetalleVenta);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
