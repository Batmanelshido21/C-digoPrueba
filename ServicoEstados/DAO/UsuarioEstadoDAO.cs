using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoEstados.DAO
{
    class UsuarioEstadoDAO
    {
        MySqlConnection conexion = null;

        public UsuarioEstadoDAO()
        {

        }

        public int RegistrarUsuarioEstado(int idUsuario)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO usuarioestado (idUsuario) VALUES (?idUsuario); SELECT LAST_INSERT_ID()";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idUsuario", idUsuario);
            int idUsuarioEstado = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idUsuarioEstado;
        }

        public List<int> RecuperarIdsUsuarioEstado(int idUsuario)
        {
            List<int> idEstadosDeUsuario = new List<int>();

            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT idUsuarioEstado FROM usuarioestado WHERE idUsuario = ?idUsuario";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idUsuario", idUsuario);
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                idEstadosDeUsuario.Add(Convert.ToInt32(reader.GetString(0)));
            }

            ConexionDAO.CerrarConexion();

            return idEstadosDeUsuario;
        }
    }
}
