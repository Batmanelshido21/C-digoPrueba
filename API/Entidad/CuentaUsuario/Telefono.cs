using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_equipo_b.Entidad.CuentaUsuario{
    public class Telefono{
        [Key]
        public int idCuenta {get; set;}
        public string telefono {get;set;}
        public int Cuenta_idCuenta {get; set;}
    }
}