using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicioDeEstado;

namespace proyecto_equipo_b.Controllers
{
    [ApiController]
    [Route("estado/")]

    public class ServicioEstadoController : Controller{

        ServicioEstadoClient servicioEstado;
    
        [HttpPost("RegistrarEstado")]
        public Task<bool> registrarEstado(int idUsuario, int idEstadoImagen)
        {
            servicioEstado = new ServicioEstadoClient();

            return servicioEstado.RegistrarEstadoAsync(idUsuario, idEstadoImagen);
        }

        [HttpPost("ReaccionarAEstado")]
        public Task<bool> reaccionarAEstado(int idEstado, int idReaccion, string nombreUsuario)
        {
            servicioEstado = new ServicioEstadoClient();

            return servicioEstado.ReaccionarAEstadoAsync(idEstado, idReaccion, nombreUsuario);
        }

        [HttpGet("ObtenerMeGusta")]
        public Task<string[]> ObtenerMeGustaDeEstado(int idEstado)
        {
            servicioEstado = new ServicioEstadoClient();

            return servicioEstado.ObtenerUsuariosQueDieronMeGustaAsync(idEstado);
        }

        [HttpGet("ObtenerNoMeGusta")]
        public Task<string[]> ObtenerNoMeGustaDeEstado(int idEstado)
        {
            servicioEstado = new ServicioEstadoClient();

            return servicioEstado.ObtenerUsuariosQueDieronNoMeGustaAsync(idEstado);
        }

        [HttpGet("ObtenerEstados")]
        public Task<Estado[]> ObtenerEstadosDeUsuario(int idUsuario)
        {
            servicioEstado = new ServicioEstadoClient();
            return servicioEstado.ObtenerEstadosAsync(idUsuario); ;
        }

    }

}