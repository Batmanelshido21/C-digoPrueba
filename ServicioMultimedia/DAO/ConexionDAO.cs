using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMultimedia.DAO
{
    class ConexionDAO
    {
        static MySqlConnection conexion = new MySqlConnection("server=localhost; database=multimedia; Uid=root; pwd=Jogabonito20");

        public static MySqlConnection ObtenerConexion()
        {
            conexion.Open();

            return conexion;
        }

        public static MySqlConnection CerrarConexion()
        {
           conexion.Close();

            return conexion;
        }
    }
}
