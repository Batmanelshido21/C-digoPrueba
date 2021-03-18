using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.CuentaUsuario{
    public class Contrasena{
        [Key]
        public int idContrasena{get; set;}
        public string contrasena {get; set;}
    }
}