using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioChat
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioChat
    {
        [OperationContract]
        int registrarChat(string nombreChat, string tipoChat);
        [OperationContract]
        int eliminarChat(string nombreChat);
        [OperationContract]
        int agregarUsuarioChat(string nombreChat, string nombreUsuario);
        [OperationContract]
        int enviarMensaje(string fecha, int favorito, string mensaje, string tipoMensaje, int idMensajeImagen,int mensajeAudio,string UsuarioChat_nombreUsuario, string Chat_nombreChat);
        [OperationContract]
        int editarMensaje(int idMensaje,int favorito, string mensaje);
        [OperationContract]
        int eliminarMensaje(int idMensaje);
        [OperationContract]
        int modificarChat(string nombreChat, string tipoChat);
        [OperationContract]
        int salirDeChatGrupal(string nombreUsuario, string Chat_nombreChat);
        [OperationContract]
        List<Mensaje> obtenerContenidoChat(string Chat_nombreChat);
        [OperationContract]
        int reaccionaMensaje(String UsuarioChat_nombreUsuario, int Mensaje_idMensaje, int Reaccion_idReaccion);
        [OperationContract]
        List<Reacion_has_Mensaje> obtenerReaccionesMensaje(int Mensaje_idMensaje);
        [OperationContract]
        int agregarAmigo(string nombreUsuario, string amigoNombreUsuario);
        [OperationContract]
        List<Amigo> obtenerAmigos(string nombreUsuario);
        [OperationContract]
        List<Chat_has_UsuarioChat> obtenerChatsDeUsuario(string nombreUsuario);
        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "ServicioChat.ContractType".
    [DataContract]
    public class Mensaje
    {
        [DataMember]
        int idMensaje;
        [DataMember]
        string date;
        [DataMember]
        int favorito;
        [DataMember]
        string mensaje;
        [DataMember]
        string tipoMensaje;
        [DataMember]
        int idMensajeImagen;
        [DataMember]
        int idMensajeAudio;
        [DataMember]
        string UsuarioChat_nombreUsuario;
        [DataMember]
        string Chat_nombreChat;

        public Mensaje(int idMensaje, string date, int favorito, string mensaje, string tipoMensaje, int idMensajeImagen, int idMensajeAudio, string usuarioChat_nombreUsuario, string chat_nombreChat)
        {
            this.idMensaje = idMensaje;
            this.date = date;
            this.favorito = favorito;
            this.mensaje = mensaje;
            this.tipoMensaje = tipoMensaje;
            this.idMensajeImagen = idMensajeImagen;
            this.idMensajeAudio = idMensajeAudio;
            UsuarioChat_nombreUsuario = usuarioChat_nombreUsuario;
            Chat_nombreChat = chat_nombreChat;
        }
    }

    [DataContract]
    public class Amigo
    {
        [DataMember]
        int idAmigo;
        [DataMember]
        string nombreUsuario;
        [DataMember]
        string amigoNombreUsuario;

        public Amigo(int idAmigo, string nombreUsuario, string amigoNombreUsuario)
        {
            this.idAmigo = idAmigo;
            this.nombreUsuario = nombreUsuario;
            this.amigoNombreUsuario = amigoNombreUsuario;
        }
    }
    [DataContract]
    public class Reacion_has_Mensaje
    {
        [DataMember]
        int Reaccion_idReaccion;
        [DataMember]
        int Mensaje_idMensaje;
        [DataMember]
        string UsuarioChat_nombreUsuario;

        public Reacion_has_Mensaje(int reaccion_idReaccion, int mensaje_idMensaje, string usuarioChat_nombreUsuario)
        {
            Reaccion_idReaccion = reaccion_idReaccion;
            Mensaje_idMensaje = mensaje_idMensaje;
            UsuarioChat_nombreUsuario = usuarioChat_nombreUsuario;
        }
    }

    [DataContract]
    public class Chat_has_UsuarioChat
    {
        [DataMember]
        string nombreUsuario;
        [DataMember]
        string Chat_nombreChat;

        public Chat_has_UsuarioChat(string nombreUsuario, string chat_nombreChat)
        {
            this.nombreUsuario = nombreUsuario;
            Chat_nombreChat = chat_nombreChat;
        }
    }
}
