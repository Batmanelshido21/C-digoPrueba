using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Multimedia{
    public class Direccion{
        [Key]
        public int idDireccion {get; set;}
        public string direccion {get; set;}
    }
}