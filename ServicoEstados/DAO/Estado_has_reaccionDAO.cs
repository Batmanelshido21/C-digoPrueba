using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoEstados.DAO
{
    class Estado_has_reaccionDAO
    {
        MySqlConnection conexion = null;

        public Estado_has_reaccionDAO()
        {

        }

        public void RegistrarReaccion(int idEstado, int idReaccion, string nombreUsuario)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO estado_has_reaccion (Estado_idEstado, Reaccion_idReaccion, nombreUsuario) VALUES (?idEstado, ?idReaccion, ?nombreUsuario)";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idEstado", idEstado);
            comando.Parameters.AddWithValue("?idReaccion", idReaccion);
            comando.Parameters.AddWithValue("?nombreUsuario", nombreUsuario);
            comando.ExecuteNonQuery();
            ConexionDAO.CerrarConexion();
        }

        public List<string> ObtenerUsuariosQueDieronMeGusta(int idEstado)
        {
            List<string> nombresDeUsuarios = new List<string>();

            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT nombreUsuario FROM estado_has_reaccion WHERE Estado_idEstado = ?idEstado and Reaccion_idReaccion = 1";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idEstado", idEstado);
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                nombresDeUsuarios.Add(reader.GetString(0));
            }

            return nombresDeUsuarios;
        }

        public List<string> ObtenerUsuariosQueDieronNoMeGusta(int idEstado)
        {
            List<string> nombresDeUsuarios = new List<string>();

            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT nombreUsuario FROM estado_has_reaccion WHERE Estado_idEstado = ?idEstado and Reaccion_idReaccion = 2";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idEstado", idEstado);
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                nombresDeUsuarios.Add(reader.GetString(0));
            }

            return nombresDeUsuarios;
        }
    }
}
