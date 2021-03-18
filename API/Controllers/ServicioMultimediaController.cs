using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_equipo_b.Entidad.Multimedia;
using ServicioMultimedia;

namespace proyecto_equipo_b.Controllers
{
    [ApiController]
    [Route("multimedia/")]

    public class ServicioMultimediaController : Controller{

        FotoCuentaUsuarioClient servicioCuentaUsuario;
        MensajeImagenClient servicioMensaje;
        AudioDeMensajeClient servicioAudio;
        FotoEstadoClient servicioEstado;


        [HttpPost("registrarFotoCuentaUsuario")]
        public Task<int> RegistrarFotoCuentaUsuario([FromBody] Archivo archivo)
        {
            servicioCuentaUsuario = new FotoCuentaUsuarioClient();
            return servicioCuentaUsuario.RegistrarFotoCuentaUsuarioAsync(archivo.stringBase64);
        }

        [HttpGet("obtenerFotoDeCuenta")]
        public Task<string> ObtenerFotoCuentaUsuario(int idFotoCuentaUsuario)
        {
            servicioCuentaUsuario = new FotoCuentaUsuarioClient();
            return servicioCuentaUsuario.ObtenerFotoCuentaUsuarioAsync(idFotoCuentaUsuario);
        }


        [HttpPost("registrarFotoMensaje")]
        public Task<int> RegistrarFotoMensaje([FromBody] Archivo archivo)
        {
            servicioMensaje = new MensajeImagenClient();
            return servicioMensaje.RegistrarFotoDeMensajeAsync(archivo.stringBase64);
        }

        [HttpGet("obtenerFotoDeMensaje")]
        public Task<string> ObtenerFotoDeMensaje(int idMensajeImagen)
        {
            servicioMensaje = new MensajeImagenClient();
            return servicioMensaje.ObtenerFotoDeMensajeAsync(idMensajeImagen);
        }

        [HttpPost("registrarAudioMensaje")]
        public Task<int> RegistrarAudioMensaje([FromBody] Archivo archivo)
        {
            servicioAudio = new AudioDeMensajeClient();
            return servicioAudio.RegistrarAudioDeMensajeAsync(archivo.stringBase64);
        }

        [HttpGet("obtenerAudioDeMensaje")]
        public Task<string> ObtenerAudioDeMensaje(int idMensajeAudio)
        {
            servicioAudio = new AudioDeMensajeClient();
            return servicioAudio.ObtenerAudioDeMensajeAsync(idMensajeAudio);
        }

        [HttpPost("registrarFotoEstado")]
        public Task<int> RegistrarFotoEstado([FromBody] Archivo archivo)
        {
            servicioEstado = new FotoEstadoClient();
            return servicioEstado.RegistrarFotoDeEsatadoAsync(archivo.stringBase64);
        }

        [HttpGet("obtenerFotoEstado")]
        public Task<string> ObtenerFotoEstado(int imagenEstado)
        {
            servicioEstado = new FotoEstadoClient();
            return servicioEstado.ObtenerFotoDeEstadoAsync(imagenEstado); ;
        }

    }

}