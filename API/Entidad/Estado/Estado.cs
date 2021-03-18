using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Estado{
    public class Estado{

        public Estado()
        {

        }

        public string fecha {get; set;}
        public string imagen { get; set; }
        public string nombreUsuario { get; set; }
    }
}