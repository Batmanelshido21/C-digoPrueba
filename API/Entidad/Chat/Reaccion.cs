using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Chat{
    public class Mensaje{
        [Key]
        public int idReaccion{get; set;}
        public string nombre {get; set;}
        public int UsuarioChat_idUsuarioChat {get; set;}
    }
}