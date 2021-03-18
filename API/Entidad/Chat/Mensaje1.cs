using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_equipo_b.Entidad.Chat{
    public class Mensaje1{
        [Key]
        public int idMensaje {get; set;}
        public String fecha {get; set;}
        public Boolean favorito {get; set;}
        public string mensaje {get; set;}
        public int TipoMensaje_idTipoMensaje {get; set;}
        public int Chat_idChat {get; set;}
        public string tipoMensaje {get; set;}
        public int idMensajeImagen {get; set;}
        public int idMensajeAudio {get; set;}
    }
}