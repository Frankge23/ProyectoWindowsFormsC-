using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaAccesoDatos
{
    public class BDConexion 
    {
        // private MySqlConnection connection;
        private string connectionString;


        public BDConexion()
        {
           /* string*/ connectionString = "Server=localhost;Database=GestionInventario;Uid=root;Pwd=admin;";
           // connection = new MySqlConnection(connectionString);
        }
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        /* public MySqlConnection GetConnection()
         {
             return connection;
         }*/
    }
}
