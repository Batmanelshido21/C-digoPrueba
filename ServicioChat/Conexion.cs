using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioChat
{
    class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {

            MySqlConnection conectar = new MySqlConnection("server=localhost; database=ServicioChat; Uid=root; pwd=Jogabonito20");

            conectar.Open();

            return conectar;
        }
    }
}
