using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoEstados.DAO
{
    class EstadoDAO
    {
        MySqlConnection conexion = null;

        public EstadoDAO()
        {

        }

        public void RegistrarEstado(int idUsuarioEstado, int idEstadoImagen)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO estado (fecha, UsuarioEstado_idUsuarioEstado, idEstadoImagen) VALUES (?fecha, ?idUsuarioEstado, ?idEstadoImagen); SELECT LAST_INSERT_ID()";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?fecha", DateTime.Now);
            comando.Parameters.AddWithValue("?idUsuarioEstado", idUsuarioEstado);
            comando.Parameters.AddWithValue("?idEstadoImagen", idEstadoImagen);
            comando.ExecuteNonQuery();
           
            ConexionDAO.CerrarConexion();
        }

        public Estado ObtenerEstadoDeUsuario(int idUsuarioEstado)
        {
            Estado estado = new Estado();

            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT * FROM estado WHERE UsuarioEstado_idUsuarioEstado = ?idUsuarioEstado";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idUsuarioEstado", idUsuarioEstado);
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                estado.idEstado = Convert.ToInt32(reader.GetString(0));
                estado.fecha = reader.GetString(1);
                estado.idEstadoImagen = Convert.ToInt32(reader.GetString(3));
            }

            ConexionDAO.CerrarConexion();

            return estado;
        }
    }
}
