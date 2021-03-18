using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.CuentaUsuario{
    public class Correo{
        [Key]
        public int idCorreo {get; set;}
        public string correo {get; set;}
        public int Cuenta_idCuenta {get; set;}
    }
}