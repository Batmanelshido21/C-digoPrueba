using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_equipo_b.Entidad.Chat{
    public class Amigo{
        [Key]
        public int idAmigo {get; set;}
        public int idCuenta {get; set;}
        public int amigoId {get; set;}
    }
}