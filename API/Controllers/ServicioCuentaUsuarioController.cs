using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_equipo_b.Entidad.Login;
using ServicioCuentaUsuario;

namespace proyecto_equipo_b.Controllers
{
    [ApiController]
    [Route("cuenta/")]

    [CallbackBehavior(UseSynchronizationContext = false)]
    public class ServicioCuentaUsuarioController : Controller{

        [HttpPost("login")]
        public CuentaCompleta obtenerNombreUSuario(string correo, string contrasena){
            InstanceContext instanceContext = new InstanceContext(this);
                ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
                CuentaCompleta cuenta = new CuentaCompleta();
                Console.WriteLine("===============================");
                cuenta = client.IniciarSesion(correo,contrasena);
                Console.WriteLine(correo +" " + contrasena);
                Console.WriteLine("Aquí entró");
            return cuenta;
        }


      [HttpPost("registrarUsuario")]
       public int PostLigarLiastaConCancion(string nombreUsuario, string correo, string contrasena, string telefono, int idFotoCuentaUsuario, int Genero_idGenero)
        {
           int respuesta;
            ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
            respuesta = client.RegistrarUsuario(nombreUsuario, correo, contrasena, telefono, idFotoCuentaUsuario,Genero_idGenero);
            Console.WriteLine("===============================");
            Console.WriteLine("Aquí entró");
        return respuesta;
        }

      [HttpPut("modificarUsuario")]
      public int PutModificarUsuario(int idCuenta, string nombreUsuario, string correo, string contrasena, string telefono, int idFotoCuentaUsuario, int Genero_idGenero){
          int respuesta;
            ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
            respuesta = client.ModificarUsuario(idCuenta, nombreUsuario, correo, contrasena, telefono, idFotoCuentaUsuario,Genero_idGenero);
            Console.WriteLine("===============================");
            Console.WriteLine("Aquí entró");
        return respuesta;
      }  

      [HttpPost("validarExistencia")]
      public int validarUsuario(string nombreUsuario){
        int respuesta;
        ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
        respuesta = client.validarExistencia(nombreUsuario);
        return respuesta;
      }

      [HttpGet("hola")]
      public string hola(){
        return "hola";
      }

    }

}