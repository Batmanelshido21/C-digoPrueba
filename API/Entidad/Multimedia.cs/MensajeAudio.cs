using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Multimedia{
    public class MensajeAudio{
        public int idMensajeAudio {get; set;}
        public int Direccion_idDireccion {get; set;}
    }
}