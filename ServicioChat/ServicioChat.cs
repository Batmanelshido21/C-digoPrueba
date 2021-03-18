using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioChat
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicioChat : IServicioChat
    {
        int salida;

        public int agregarAmigo(string nombreUsuario, string amigoNombreUsuario)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into Amigo (nombreUsuario,amigoNombreUsuario) values ('{0}','{1}')",nombreUsuario,amigoNombreUsuario), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();

                MySqlCommand comando2 = new MySqlCommand(string.Format(
                "Insert into Amigo (nombreUsuario,amigoNombreUsuario) values ('{0}','{1}')",amigoNombreUsuario, nombreUsuario), Conexion.ObtenerConexion());
                retorno = comando2.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return retorno;
            }
            return retorno;
        }

        public int agregarUsuarioChat(string nombreChat, string nombreUsuario)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into UsuarioChat (nombreUsuario) values ('{0}')", nombreUsuario), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                try
                {
                    MySqlCommand comando1 = new MySqlCommand(string.Format(
                    "Insert into Chat_has_UsuarioChat (UsuarioChat_nombreUsuario,Chat_nombreChat) values ('{0}','{1}')", nombreUsuario, nombreChat), Conexion.ObtenerConexion());
                    retorno = comando1.ExecuteNonQuery();
                    return retorno;
                }
                catch(Exception a)
                {
                    retorno = 0;
                    return retorno;
                }
            }
            try
            {
                MySqlCommand comando1 = new MySqlCommand(string.Format(
                "Insert into Chat_has_UsuarioChat (UsuarioChat_nombreUsuario,Chat_nombreChat) values ('{0}','{1}')", nombreUsuario, nombreChat), Conexion.ObtenerConexion());
                retorno = comando1.ExecuteNonQuery();
            }
            catch (Exception a)
            {
                retorno = 0;
                return retorno;
            }


            return retorno;
        }

        public int editarMensaje(int idMensaje, int favorito, string mensaje)
        {
            int retorno=0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Update Mensaje set favorito='{0}', mensaje='{1}' where idMensaje='{2}'", favorito, mensaje, idMensaje), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return retorno;
            }
            return retorno;
        }

        public int eliminarChat(string nombreChat)
        {
            int retorno=0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
              "Delete from Chat where nombreChat='{0}'", nombreChat), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }catch(Exception e)
            {
                return retorno;
            }
            return retorno;
        }

        public int eliminarMensaje(int idMensaje)
        {
            int retorno=0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
              "Delete from Mensaje where idMensaje='{0}'", idMensaje), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return retorno;
            }
            return retorno;
        }

        public int enviarMensaje(string fecha, int favorito, string mensaje, string tipoMensaje, int idMensajeImagen, int mensajeAudio, string UsuarioChat_nombreUsuario, string Chat_nombreChat)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
               "Insert into Mensaje (fecha,favorito,mensaje,tipoMensaje,idMensajeImagen,idMensajeAudio,UsuarioChat_nombreUsuario,Chat_nombreChat) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", fecha, favorito, mensaje, tipoMensaje, idMensajeImagen, mensajeAudio, UsuarioChat_nombreUsuario, Chat_nombreChat), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }catch(Exception e)
            {
                return retorno;
            }
            return retorno;
        }

        public int modificarChat(string nombreChat, string tipoChat)
        {
            int retorno;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Update Chat set tipoChat='{0}' where nombreChat='{1}'", tipoChat, nombreChat), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }catch(Exception e)
            {
                return 0;
            }
            return retorno;
        }

        public List<Amigo> obtenerAmigos(string nombreUsuario)
        {
            List<Amigo> list = new List<Amigo>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
               "Select * from Amigo where nombreUsuario='{0}'", nombreUsuario), Conexion.ObtenerConexion());
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Amigo amigo = new Amigo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    list.Add(amigo);
                }
            }
            catch(Exception e)
            {
                return list;
            }
            return list;
        }

        public List<Chat_has_UsuarioChat> obtenerChatsDeUsuario(string nombreUsuario)
        {
            List<Chat_has_UsuarioChat> list = new List<Chat_has_UsuarioChat>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
             "Select * from Chat_has_UsuarioChat where UsuarioChat_nombreUsuario='{0}'", nombreUsuario), Conexion.ObtenerConexion());
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Chat_has_UsuarioChat usuarioC = new Chat_has_UsuarioChat(reader.GetString(1), reader.GetString(0));
                    list.Add(usuarioC);
                }
            }catch(Exception e)
            {
                return list;
            }
            return list;
        }

        public List<Mensaje> obtenerContenidoChat(string Chat_nombreChat)
        {
            List<Mensaje> list = new List<Mensaje>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Select * from Mensaje where Chat_nombreChat='{0}' ORDER BY Mensaje.fecha DESC", Chat_nombreChat), Conexion.ObtenerConexion());
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Mensaje mensaje = new Mensaje(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8));
                    list.Add(mensaje);
                }
            }
            catch(Exception e)
            {
                return list;
            }
            return list;
        }

        public List<Reacion_has_Mensaje> obtenerReaccionesMensaje(int Mensaje_idMensaje)
        {
            salida = 0;
            List<Reacion_has_Mensaje> list = new List<Reacion_has_Mensaje>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
               "Select * from Reaccion_has_Mensaje where Mensaje_idMensaje='{0}'", Mensaje_idMensaje), Conexion.ObtenerConexion());
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Reacion_has_Mensaje mensaje = new Reacion_has_Mensaje(reader.GetInt32(0),reader.GetInt32(1),reader.GetString(2));
                    list.Add(mensaje);
                }
            }catch(Exception e)
            {
                return list;
            }
            
            return list;
        }

        public int reaccionaMensaje(string UsuarioChat_nombreUsuario, int Mensaje_idMensaje, int Reaccion_idReaccion)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into Reaccion_has_Mensaje (Reaccion_idReaccion,Mensaje_idMensaje,UsuarioChat_nombreUsuario) values ('{0}','{1}','{2}')", Reaccion_idReaccion, Mensaje_idMensaje, UsuarioChat_nombreUsuario), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }catch(Exception e)
            {
                return retorno;
            }
            return retorno;
        }

        public int registrarChat(string nombreChat, string tipoChat)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into Chat (nombreChat,tipoChat) values ('{0}','{1}')", nombreChat, tipoChat), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }catch(Exception e)
            {
                return retorno;
            }
            return retorno;
        }

        public int salirDeChatGrupal(string nombreUsuario, string Chat_nombreChat)
        {
            int retorno=0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(
               "Delete from Chat_has_UsuarioChat where UsuarioChat_nombreUsuario='{0}' and Chat_nombreChat ='{1}'", nombreUsuario, Chat_nombreChat), Conexion.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            } catch (Exception e)
            {
                return retorno;
            }
            return retorno;
        }
    }
}
