using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Chat{
    public class Reaccion_has_Mensaje{
        [Key]
        public int Reaccion_idReaccion {get; set;}
        
        public int Mensaje_idMensaje {get; set;}
    }
}