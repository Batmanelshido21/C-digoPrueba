using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicioChat;

namespace proyecto_equipo_b.Controllers
{
    [ApiController]
    [Route("chat/")]

    public class ServicioChatController : Controller{
    
    [HttpGet("obtenerMensajesChat")]
    public Task<Mensaje[]> obtenerString(string Chat_nombreChat){
        Console.WriteLine("Entró");
        ServicioChatClient cliente = new ServicioChatClient();
            ServicioChatClient client = new ServicioChatClient();
        Task<Mensaje[]> mensajes;
           mensajes = client.obtenerContenidoChatAsync(Chat_nombreChat);
       return mensajes;
    }

    [HttpPost("registrarChat")]
    public Task<int> obtenerHola(string nombreChat, string tipoChat){
       Task<int> resultado;
       ServicioChatClient client = new ServicioChatClient();
       resultado = client.registrarChatAsync(nombreChat, tipoChat);
        return resultado;
    }

    [HttpPost("agregarUsuario")]
    public Task<int> agregarUsuario(string nombreChat, string nombreUsuario){
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.agregarUsuarioChatAsync(nombreChat, nombreUsuario);
        return resultado;
    }

    [HttpPost("enviarMensaje")]
    public Task<int> enviarMensaje(string fecha, int favorito,string mensaje,string tipoMensaje,int idMensajeImagen,int mensajeAudio,string UsuarioChat_nombreUsuario,string Chat_nombreChat){
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.enviarMensajeAsync(fecha,favorito,mensaje,tipoMensaje,idMensajeImagen,mensajeAudio,UsuarioChat_nombreUsuario,Chat_nombreChat);
        return resultado;
    }

    [HttpPost("abandonarGrupo")]
    public Task<int> salirDeChatGrupal(string nombreUsuario, string Chat_nombreChat){
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.salirDeChatGrupalAsync(nombreUsuario,Chat_nombreChat);
        return resultado;
    }

    [HttpPost("reaccionarMensaje")]
    public Task<int> reaccionarAMensaje(string UsuarioChat_nombreUsuario, int Mensaje_idMensaje, int Reaccion_idReaccion){
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.reaccionaMensajeAsync(UsuarioChat_nombreUsuario, Mensaje_idMensaje, Reaccion_idReaccion);
        return resultado;
    }

    [HttpPost("obtenerReaccionMensaje")]
    public Task<Reacion_has_Mensaje[]> obtenerReaccionMensaje(int Mensaje_idMensaje){
        Task<Reacion_has_Mensaje[]> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.obtenerReaccionesMensajeAsync(Mensaje_idMensaje);
        return resultado;
    }

    [HttpPost("editarMensaje")]
    public Task<int> editarMensaje(int idMensaje, int favorito, string mensaje){
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.editarMensajeAsync(idMensaje,favorito,mensaje);
        return resultado;
    }

    [HttpPost("eliminarMensaje")]
    public Task<int> eliminarMensaje(int idMensaje){
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.eliminarMensajeAsync(idMensaje);
        return resultado;
    }

    [HttpPost("modificarChat")]
    public Task<int> modificarChat(string nombreChat, string tipoChat){
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.modificarChatAsync(nombreChat, tipoChat);
        return resultado;
    }

    [HttpPost("eliminarChat")]
    public Task<int> eliminarChat(string nombreChat){
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
        resultado = client.eliminarChatAsync(nombreChat);
        return resultado;
    }

    [HttpPost("agregarAmigo")]
    public Task<int> agregarAmigo(string nombreUsuario, string amigoNombreUsuario)
    {
        Task<int> resultado;
        ServicioChatClient client = new ServicioChatClient();
            resultado = client.agregarAmigoAsync(nombreUsuario, amigoNombreUsuario);
        return resultado;
    }

    [HttpGet("obtenerAmigos")]
    public Task<Amigo[]> obtenerAmigos(string nombreUsuario)
    {
        ServicioChatClient client = new ServicioChatClient();
        Task<Amigo[]> amigos;
        amigos = client.obtenerAmigosAsync(nombreUsuario);
        return amigos;
    }

    [HttpPost("obtenerChatsDeUsuario")]
    public Task<Chat_has_UsuarioChat[]> obtenerChatsDeUsuario(string nombreUsuario){
        ServicioChatClient client = new ServicioChatClient();
        Task<Chat_has_UsuarioChat[]> chats;
            chats = client.obtenerChatsDeUsuarioAsync(nombreUsuario);
        return chats;
    }

    }
}