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
    public class DAL_Proveedores
    {
        private BDConexion conexion;

        public DAL_Proveedores()
        {
            conexion = new BDConexion();
        }

        public void CrearProveedor(string nombreProveedor, string sectorComercial, string tipoDocumento, string numeroDocumento, string direccion, string telefono)
        {
            using (MySqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Proveedor (NombreProveedor, SectorComercial, TipoDocumento, NumeroDocumento, Direccion, Telefono) VALUES (@NombreProveedor, @SectorComercial, @TipoDocumento, @NumeroDocumento, @Direccion, @Telefono)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreProveedor", nombreProveedor);
                    cmd.Parameters.AddWithValue("@SectorComercial", sectorComercial);
                    cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.ExecuteNonQuery();
                }
            }
        }

         public List<Proveedor> ObtenerProveedores()
         {
             List<Proveedor> proveedores = new List<Proveedor>();
             using (MySqlConnection conn = conexion.GetConnection())
             {
                 conn.Open();
                 string query = "SELECT * FROM Proveedor";
                 using (MySqlCommand cmd = new MySqlCommand(query, conn))
                 {
                     using (MySqlDataReader reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             Proveedor proveedor = new Proveedor
                             {
                                 IdProveedor = reader.GetInt32("IdProveedor"),
                                 NombreProveedor = reader.GetString("NombreProveedor"),
                                 SectorComercial = reader.GetString("SectorComercial"),
                                 TipoDocumento = reader.GetString("TipoDocumento"),
                                 NumeroDocumento = reader.GetString("NumeroDocumento"),
                                 Direccion = reader.GetString("Direccion"),
                                 Telefono = reader.GetString("Telefono")
                             };
                             proveedores.Add(proveedor);
                         }
                     }
                 }
             }
             return proveedores;
         }

        public void ActualizarProveedor(int idProveedor, string nombreProveedor, string sectorComercial, string tipoDocumento, string numeroDocumento, string direccion, string telefono)
        {
            using (MySqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Proveedor SET NombreProveedor = @NombreProveedor, SectorComercial = @SectorComercial, TipoDocumento = @TipoDocumento, NumeroDocumento = @NumeroDocumento, Direccion = @Direccion, Telefono = @Telefono WHERE IdProveedor = @IdProveedor";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@NombreProveedor", nombreProveedor);
                    cmd.Parameters.AddWithValue("@SectorComercial", sectorComercial);
                    cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProveedor(int idProveedor)
        {
            using (MySqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Proveedor WHERE IdProveedor = @IdProveedor";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
