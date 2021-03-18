using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMultimedia.DAO
{
    class MensajeImagenDAO
    {
        public MensajeImagenDAO()
        {

        }

        MySqlConnection conexion = null;

        public int RegistrarImagenMensaje(int idDireccion)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO mensajeimagen (Direccion_idDireccion) VALUES (?idDireccion); SELECT LAST_INSERT_ID()";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idDireccion", idDireccion);
            int idEstadoImagen = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idEstadoImagen;
        }

        public int ObtenerIdImagenMensaje(int idMensajeImagen)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT Direccion_idDireccion FROM mensajeimagen WHERE idMensajeImagen = ?idMensajeImagen";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idMensajeImagen", idMensajeImagen);
            int idDireccion = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idDireccion;
        }
    }
}
