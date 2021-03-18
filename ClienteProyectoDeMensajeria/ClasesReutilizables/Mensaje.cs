using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ClienteProyectoDeMensajeria.ClasesReutilizables
{
    public class Mensaje
    {
        public int idMensaje { get; set; }
        public string date { get; set; }
        public int favorito { get; set; }
        public string mensaje { get; set; }
        public string tipoMensaje { get; set; }
        public int idMensajeImagen { get; set; }
        public int mensajeAudio { get; set; }
        public string UsuarioChat_nombreUsuario { get; set; }
        public string Chat_nombreChat { get; set; }
        public BitmapImage imagenChat { get; set; }
        
        public Mensaje()
        {

        }
    }
}
