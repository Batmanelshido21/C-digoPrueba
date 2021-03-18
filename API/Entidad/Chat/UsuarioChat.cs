using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Chat{
    public class UsuarioChat{
        [Key]
        public int idUsuarioChat {get; set;}
        public int idUsuario {get; set;}
        public int Chat_idChat {get; set;}
    }
}