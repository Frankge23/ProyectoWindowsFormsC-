using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;

namespace CapaAccesoDatos
{
    public class DAL_Ventas
    {
        private BDConexion bdConexion = new BDConexion();

        public List<Venta> ObtenerVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT FechaVenta, TipoComprobante, Serie, Correlativo, PrecioTotal FROM Venta", connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venta venta = new Venta
                            {
                                FechaVenta = Convert.ToDateTime(reader["FechaVenta"]),
                                TipoComprobante = Convert.ToString(reader["TipoComprobante"]),
                                Serie = Convert.ToString(reader["Serie"]),
                                Correlativo = Convert.ToString(reader["Correlativo"]),
                                PrecioTotal = Convert.ToDecimal(reader["PrecioTotal"])
                            };
                            ventas.Add(venta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener ventas: " + ex.Message);
                }
            }
            return ventas;
        }
        public Venta ObtenerVenta(int idVenta)
        {
            Venta venta = null;
            using (MySqlConnection connection = bdConexion.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM Venta WHERE IdVenta = @IdVenta", connection);
                command.Parameters.AddWithValue("@IdVenta", idVenta);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        venta = new Venta
                        {
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            FechaVenta = Convert.ToDateTime(reader["FechaVenta"]),
                            TipoComprobante = Convert.ToString(reader["TipoComprobante"]),
                            Serie = Convert.ToString(reader["Serie"]),
                            Correlativo = Convert.ToString(reader["Correlativo"]),
                            PrecioTotal = Convert.ToDecimal(reader["PrecioTotal"])
                        };
                    }
                }
            }
            return venta;
        }

        public bool InsertarVenta(Venta venta)
        {
            try
            {
                using (MySqlConnection connection = bdConexion.GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO Venta (FechaVenta, TipoComprobante, Serie, Correlativo, PrecioTotal) VALUES (@FechaVenta, @TipoComprobante, @Serie, @Correlativo, @PrecioTotal)", connection);

                    command.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    command.Parameters.AddWithValue("@TipoComprobante", venta.TipoComprobante);
                    command.Parameters.AddWithValue("@Serie", venta.Serie);
                    command.Parameters.AddWithValue("@Correlativo", venta.Correlativo);
                    command.Parameters.AddWithValue("@PrecioTotal", venta.PrecioTotal);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar venta: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarVenta(Venta venta)
        {
            try
            {
                using (MySqlConnection connection = bdConexion.GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("UPDATE Venta SET FechaVenta = @FechaVenta, TipoComprobante = @TipoComprobante, Serie = @Serie, Correlativo = @Correlativo, PrecioTotal = @PrecioTotal WHERE IdVenta = @IdVenta", connection);

                    command.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    command.Parameters.AddWithValue("@TipoComprobante", venta.TipoComprobante);
                    command.Parameters.AddWithValue("@Serie", venta.Serie);
                    command.Parameters.AddWithValue("@Correlativo", venta.Correlativo);
                    command.Parameters.AddWithValue("@PrecioTotal", venta.PrecioTotal);
                    command.Parameters.AddWithValue("@IdVenta", venta.IdVenta);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar venta: " + ex.Message);
                return false;
            }
        }

        public bool EliminarVenta(int idVenta)
        {
            try
            {
                using (MySqlConnection connection = bdConexion.GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM Venta WHERE IdVenta = @IdVenta", connection);
                    command.Parameters.AddWithValue("@IdVenta", idVenta);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar venta: " + ex.Message);
                return false;
            }
        }
    }
}
