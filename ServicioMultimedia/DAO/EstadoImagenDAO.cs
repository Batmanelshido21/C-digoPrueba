using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMultimedia.DAO
{
    class EstadoImagenDAO
    {
        public EstadoImagenDAO()
        {

        }

        MySqlConnection conexion = null;

        public int RegistrarFotoDeEstado(int idDireccion)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO estadoimagen (Direccion_idDireccion) VALUES (?idDireccion); SELECT LAST_INSERT_ID()";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idDireccion", idDireccion);
            int idEstadoImagen = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idEstadoImagen;
        }

        public int ObtenerIdDireccionDeFotoEstado(int idFotoEstado)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT Direccion_idDireccion FROM estadoimagen WHERE idEstadoImagen = ?idEstadoImagen";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idEstadoImagen", idFotoEstado);
            int idDireccion = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idDireccion;
        }
    }
}
