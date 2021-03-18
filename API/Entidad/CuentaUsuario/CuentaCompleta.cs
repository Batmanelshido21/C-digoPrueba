using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.CuentaUsuario{
    public class Cuenta{
        [Key]
        public int idCuenta {get; set;}
        public string nombreUsuario {get; set;}
        public string correo {get;set;}
        public string contrasena {get; set;}
        public string telefono{get;set;}
        public int idFotoCuentaUsuario {get; set;}
        public int Genero_idGenero{get; set;}
    }
}