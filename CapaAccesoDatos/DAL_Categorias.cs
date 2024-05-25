using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidades.ClaseEntidades;

namespace CapaAccesoDatos
{
    public class DAL_Categorias
    {
        private BDConexion bdConexion = new BDConexion();

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            MySqlConnection connection = bdConexion.GetConnection();

            try
            {
                string query = "SELECT * FROM Categoria";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        IdCategoria = reader.GetInt32("IdCategoria"),
                        TipoCategoria = reader.GetString("TipoCategoria"),
                        Nombre = reader.GetString("Nombre"),
                        Descripcion = reader.GetString("Descripcion")
                    };

                    categorias.Add(categoria);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return categorias;
        }

        public Categoria ObtenerCategoria(int idCategoria)
        {
            Categoria categoria = null;
            MySqlConnection connection = bdConexion.GetConnection();

            try
            {
                string query = $"SELECT * FROM Categoria WHERE IdCategoria = {idCategoria}";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    categoria = new Categoria
                    {
                        IdCategoria = reader.GetInt32("IdCategoria"),
                        TipoCategoria = reader.GetString("TipoCategoria"),
                        Nombre = reader.GetString("Nombre"),
                        Descripcion = reader.GetString("Descripcion")
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la categoría: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return categoria;
        }

        public bool InsertarCategoria(Categoria nuevaCategoria)
        {
            bool isInserted = false;
            MySqlConnection connection = bdConexion.GetConnection();

            try
            {
                string query = $"INSERT INTO Categoria (TipoCategoria, Nombre, Descripcion) VALUES ('{nuevaCategoria.TipoCategoria}', '{nuevaCategoria.Nombre}', '{nuevaCategoria.Descripcion}')";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();

                if (command.ExecuteNonQuery() > 0)
                {
                    isInserted = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la categoría: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isInserted;
        }

        public bool ActualizarCategoria(Categoria categoriaActualizada)
        {
            bool isUpdated = false;
            MySqlConnection connection = bdConexion.GetConnection();

            try
            {
                string query = $"UPDATE Categoria SET TipoCategoria = '{categoriaActualizada.TipoCategoria}', Nombre = '{categoriaActualizada.Nombre}', Descripcion = '{categoriaActualizada.Descripcion}' WHERE IdCategoria = {categoriaActualizada.IdCategoria}";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();

                if (command.ExecuteNonQuery() > 0)
                {
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la categoría: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public bool EliminarCategoria(int idCategoria)
        {
            bool isDeleted = false;
            MySqlConnection connection = bdConexion.GetConnection();

            try
            {
                string query = $"DELETE FROM Categoria WHERE IdCategoria = {idCategoria}";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();

                if (command.ExecuteNonQuery() > 0)
                {
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isDeleted;
        }

    }
}
