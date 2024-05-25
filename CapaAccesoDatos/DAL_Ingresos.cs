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
    public class DAL_Ingresos
    {
        private BDConexion conexion;

        public DAL_Ingresos()
        {
            conexion = new BDConexion();
        }
        public bool InsertarIngreso(Ingreso ingreso)
        {
            using (MySqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Ingreso (IdTrabajador, IdProveedor, FechaIngreso, TipoComprobante, Serie, Correlativo, Estado) VALUES (@IdTrabajador, @IdProveedor, @FechaIngreso, @TipoComprobante, @Serie, @Correlativo, @Estado)", conn);
                cmd.Parameters.AddWithValue("@IdTrabajador", ingreso.IdTrabajador);
                cmd.Parameters.AddWithValue("@IdProveedor", ingreso.IdProveedor);
                cmd.Parameters.AddWithValue("@FechaIngreso", ingreso.FechaIngreso);
                cmd.Parameters.AddWithValue("@TipoComprobante", ingreso.TipoComprobante);
                cmd.Parameters.AddWithValue("@Serie", ingreso.Serie);
                cmd.Parameters.AddWithValue("@Correlativo", ingreso.Correlativo);
                cmd.Parameters.AddWithValue("@Estado", ingreso.Estado);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
        public DataTable ObtenerIngresos()
        {
            DataTable dtIngresos = new DataTable();

            using (MySqlConnection con = conexion.GetConnection())
            {
                con.Open();
                string query = @"
                    SELECT 
                        i.IdIngreso,
                        p.NombreProveedor,
                        t.Nombres AS NombreTrabajador,
                        i.FechaIngreso,
                        i.TipoComprobante,
                        i.Serie,
                        i.Correlativo,
                        i.Estado
                    FROM Ingreso i
                    JOIN Proveedor p ON i.IdProveedor = p.IdProveedor
                    JOIN Trabajador t ON i.IdTrabajador = t.IdTrabajador";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtIngresos);
            }

            return dtIngresos;
        }

        public bool ActualizarIngreso(Ingreso ingreso)
        {
            using (MySqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Ingreso SET IdTrabajador = @IdTrabajador, IdProveedor = @IdProveedor, FechaIngreso = @FechaIngreso, TipoComprobante = @TipoComprobante, Serie = @Serie, Correlativo = @Correlativo, Estado = @Estado WHERE IdIngreso = @IdIngreso", conn);
                cmd.Parameters.AddWithValue("@IdTrabajador", ingreso.IdTrabajador);
                cmd.Parameters.AddWithValue("@IdProveedor", ingreso.IdProveedor);
                cmd.Parameters.AddWithValue("@FechaIngreso", ingreso.FechaIngreso);
                cmd.Parameters.AddWithValue("@TipoComprobante", ingreso.TipoComprobante);
                cmd.Parameters.AddWithValue("@Serie", ingreso.Serie);
                cmd.Parameters.AddWithValue("@Correlativo", ingreso.Correlativo);
                cmd.Parameters.AddWithValue("@Estado", ingreso.Estado);
                cmd.Parameters.AddWithValue("@IdIngreso", ingreso.IdIngreso);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
        public bool EliminarIngreso(int idIngreso)
        {
            using (MySqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Ingreso WHERE IdIngreso = @IdIngreso", conn);
                cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
        
    }
}
