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
    public class DAL_Trabajadores
    {
        private BDConexion conexion;

        public DAL_Trabajadores()
        {
            conexion = new BDConexion();
        }

        public DataTable ObtenerTrabajadores()
        {
            DataTable dtTrabajadores = new DataTable();

            using (MySqlConnection con = conexion.GetConnection())
            {
                con.Open();
                string query = "SELECT IdTrabajador, Nombres FROM Trabajador";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtTrabajadores);
            }

            return dtTrabajadores;
        }

        public bool InsertarTrabajador(Trabajador trabajador)
        {
            using (MySqlConnection con = conexion.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Trabajador (Nombres, Apellidos, Sexo, FechaNacimiento, NumeroDocumento, Direccion, Telefono) " +
                               "VALUES (@Nombres, @Apellidos, @Sexo, @FechaNacimiento, @NumeroDocumento, @Direccion, @Telefono)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombres", trabajador.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", trabajador.Apellidos);
                cmd.Parameters.AddWithValue("@Sexo", trabajador.Sexo);
                cmd.Parameters.AddWithValue("@FechaNacimiento", trabajador.FechaNacimiento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", trabajador.NumeroDocumento);
                cmd.Parameters.AddWithValue("@Direccion", trabajador.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", trabajador.Telefono);

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool ActualizarTrabajador(Trabajador trabajador)
        {
            using (MySqlConnection con = conexion.GetConnection())
            {
                con.Open();
                string query = "UPDATE Trabajador SET Nombres = @Nombres, Apellidos = @Apellidos, Sexo = @Sexo, " +
                               "FechaNacimiento = @FechaNacimiento, NumeroDocumento = @NumeroDocumento, Direccion = @Direccion, " +
                               "Telefono = @Telefono WHERE IdTrabajador = @IdTrabajador";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombres", trabajador.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", trabajador.Apellidos);
                cmd.Parameters.AddWithValue("@Sexo", trabajador.Sexo);
                cmd.Parameters.AddWithValue("@FechaNacimiento", trabajador.FechaNacimiento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", trabajador.NumeroDocumento);
                cmd.Parameters.AddWithValue("@Direccion", trabajador.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", trabajador.Telefono);
                cmd.Parameters.AddWithValue("@IdTrabajador", trabajador.IdTrabajador);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarTrabajador(int idTrabajador)
        {
            using (MySqlConnection con = conexion.GetConnection())
            {
                con.Open();
                string query = "DELETE FROM Trabajador WHERE IdTrabajador = @IdTrabajador";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdTrabajador", idTrabajador);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
