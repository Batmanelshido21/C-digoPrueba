using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMultimedia.DAO
{
    class DireccionDAO
    {
        MySqlConnection conexion = null;

        public DireccionDAO()
        {

        }

        public int RegistrarDireccion(string ruta)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO direccion (direccion) VALUES (?direccionDAO); SELECT LAST_INSERT_ID()";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?direccionDAO", ruta);
            int idDireccion = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idDireccion;
        }

        public string ObtenerDireccionDeArchivo(int idDireccion)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT direccion FROM direccion WHERE idDireccion = ?idDireccion";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idDireccion", idDireccion);
            string direccion = "";
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                direccion = reader.GetString(0);
            }

            ConexionDAO.CerrarConexion();

            return direccion;
        }
    }
}
