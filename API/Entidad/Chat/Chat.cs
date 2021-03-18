using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Chat{
    public class chat{
        [Key]
        public int idChat {get; set;}
        public string nombreChat {get; set;}
        public string tipoChat {get; set;}
    }
}