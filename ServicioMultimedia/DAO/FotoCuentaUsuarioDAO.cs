using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMultimedia.DAO
{
    class FotoCuentaUsuarioDAO
    {

        public FotoCuentaUsuarioDAO()
        {

        }

        MySqlConnection conexion = null;

        public int RegistrarFotoDeCuentaUsuario(int idDireccion)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO fotocuentausuario (Direccion_idDireccion) VALUES (?idDireccion); SELECT LAST_INSERT_ID()";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idDireccion", idDireccion);
            int idFotoCuentaUsuario = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idFotoCuentaUsuario;
        }

        public int ObtenerIdDireccionDeFoto(int idFotoCuentaUsuario)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT Direccion_idDireccion FROM fotocuentausuario WHERE idFotoCuentaUsuario = ?idFotoCuentaUsuario";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idFotoCuentaUsuario", idFotoCuentaUsuario);
            int idFoto = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idFoto;
        }
    }
}
