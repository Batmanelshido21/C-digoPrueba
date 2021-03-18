using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMultimedia.DAO
{
    class MensajeAudioDAO
    {
        public MensajeAudioDAO()
        {

        }

        MySqlConnection conexion = null;

        public int RegistrarAudioMensaje(int idDireccion)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO mensajeaudio (Direccion_idDireccion) VALUES (?idDireccion); SELECT LAST_INSERT_ID()";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idDireccion", idDireccion);
            int idEstadoImagen = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idEstadoImagen;
        }

        public int ObtenerIdAudioMensaje(int idMensajeAudio)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT Direccion_idDireccion FROM mensajeaudio WHERE idEstadoImagen = ?idMensajeAudio";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idEstadoImagen", idMensajeAudio);
            int idDireccion = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idDireccion;
        }
    }
}
