using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using CapaEntidades;
using static CapaEntidades.ClaseEntidades;



namespace CapaAccesoDatos
{
    public class DAL_Articulos
    {
       private BDConexion bdConexion = new BDConexion();

        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();
            MySqlConnection connection = bdConexion.GetConnection();
            
            try
            {
                string query = "SELECT a.IdArticulo, a.Codigo, a.Nombre, a.Descripcion, a.Precio, c.TipoCategoria " +
                       "FROM Articulo a " +
                       "INNER JOIN Categoria c ON a.IdCategoria = c.IdCategoria";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Articulo articulo = new Articulo
                    {
                        IdArticulo = reader.GetInt32("IdArticulo"),
                        Codigo = reader.GetString("Codigo"),
                        Nombre = reader.GetString("Nombre"),
                        Descripcion = reader.GetString("Descripcion"),
                        Precio = reader.GetDecimal("Precio"),
                        TipoCategoria = reader.GetString("TipoCategoria")
                    };

                    articulos.Add(articulo);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los artículos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return articulos;
        }

        public bool InsertarArticulo(Articulo nuevoArticulo)
        {
            MySqlConnection connection = bdConexion.GetConnection();

            try
            {
                string query = "INSERT INTO Articulo (Codigo, Nombre, Descripcion, Precio, IdCategoria) VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdCategoria)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codigo", nuevoArticulo.Codigo);
                command.Parameters.AddWithValue("@Nombre", nuevoArticulo.Nombre);
                command.Parameters.AddWithValue("@Descripcion", nuevoArticulo.Descripcion);
                command.Parameters.AddWithValue("@Precio", nuevoArticulo.Precio);
                command.Parameters.AddWithValue("@IdCategoria", nuevoArticulo.IdCategoria);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el artículo: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool ActualizarArticulo(Articulo articuloActualizado)
        {
            MySqlConnection connection = bdConexion.GetConnection();

            try
            {
                string query = "UPDATE Articulo SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, IdCategoria = @IdCategoria WHERE IdArticulo = @IdArticulo";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codigo", articuloActualizado.Codigo);
                command.Parameters.AddWithValue("@Nombre", articuloActualizado.Nombre);
                command.Parameters.AddWithValue("@Descripcion", articuloActualizado.Descripcion);
                command.Parameters.AddWithValue("@Precio", articuloActualizado.Precio);
                command.Parameters.AddWithValue("@IdCategoria", articuloActualizado.IdCategoria);
                command.Parameters.AddWithValue("@IdArticulo", articuloActualizado.IdArticulo);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el artículo: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool EliminarArticulo(int idArticulo)
        {
            MySqlConnection connection = bdConexion.GetConnection();

            try
            {
                string query = "DELETE FROM Articulo WHERE IdArticulo = @IdArticulo";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdArticulo", idArticulo);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el artículo: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }          
        }

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
                        TipoCategoria = reader.GetString("TipoCategoria")
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
    }
}
