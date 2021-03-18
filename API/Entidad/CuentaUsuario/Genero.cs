using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.CuentaUsuario{
    public class Genero{
        [Key]
        public int idGenero {get; set;}
        public string genero{get; set;}
    }
}