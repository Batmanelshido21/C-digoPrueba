using ServicioMultimedia.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioMultimedia
{
    public partial class Servicios : IFotoCuentaUsuario
    {
        DireccionDAO direccionDAO;
        FotoCuentaUsuarioDAO fotoDAO;

        public int RegistrarFotoCuentaUsuario(string imagenCuentaUsuario)
        {
            try
            {
                direccionDAO = new DireccionDAO();
                fotoDAO = new FotoCuentaUsuarioDAO();

                string nombreDeImagen = Path.GetRandomFileName();
                string ruta = "C:/Users/javie/Documents/Sistemas en red/MultimediaDeServicio/ImagenesCuentaUsuario/" + nombreDeImagen + ".jpg";

                if (ArchivoDAO.GuardarArchivo(ruta, imagenCuentaUsuario))
                {
                    int idDireccion = direccionDAO.RegistrarDireccion(ruta);

                    int idFotoCuentaUsuario = fotoDAO.RegistrarFotoDeCuentaUsuario(idDireccion);

                    return idFotoCuentaUsuario;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string ObtenerFotoCuentaUsuario(int idFotoCuentaUsuario)
        {
            try
            {
                fotoDAO = new FotoCuentaUsuarioDAO();
                direccionDAO = new DireccionDAO();

                int idDireccion = fotoDAO.ObtenerIdDireccionDeFoto(idFotoCuentaUsuario);
                string direccion = direccionDAO.ObtenerDireccionDeArchivo(idDireccion);

                return ArchivoDAO.ObtenerArchivo(direccion);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }

    public partial class Servicios : IFotoEstado
    {
        EstadoImagenDAO estadoImagenDAO;
       
        public int RegistrarFotoDeEsatado(string imagenEstado)
        {
            try
            {
                direccionDAO = new DireccionDAO();
                estadoImagenDAO = new EstadoImagenDAO();

                string nombreDeImagen = Path.GetRandomFileName();
                string ruta = "C:/Users/javie/Documents/Sistemas en red/MultimediaDeServicio/ImagenesEstado/" + nombreDeImagen + ".jpg";

                if (ArchivoDAO.GuardarArchivo(ruta, imagenEstado))
                {
                    int idDireccion = direccionDAO.RegistrarDireccion(ruta);

                    int idEstadoImagen = estadoImagenDAO.RegistrarFotoDeEstado(idDireccion);

                    return idEstadoImagen;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string ObtenerFotoDeEstado(int idFotoEstado)
        {
            try
            {
                direccionDAO = new DireccionDAO();
                estadoImagenDAO = new EstadoImagenDAO();

                int idDireccion = estadoImagenDAO.ObtenerIdDireccionDeFotoEstado(idFotoEstado);
                string direccion = direccionDAO.ObtenerDireccionDeArchivo(idDireccion);

                return ArchivoDAO.ObtenerArchivo(direccion);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }

    public partial class Servicios : IAudioDeMensaje
    {
        MensajeAudioDAO mensajeAudioDAO;

        public int RegistrarAudioDeMensaje(string audio)
        {
            try
            {
                direccionDAO = new DireccionDAO();
                mensajeAudioDAO = new MensajeAudioDAO();

                string nombreDelAudio = Path.GetRandomFileName();
                string ruta = "C:/Users/javie/Documents/Sistemas en red/MultimediaDeServicio/AudioMensaje/" + nombreDelAudio + ".jpg";

                if (ArchivoDAO.GuardarArchivo(ruta, audio))
                {
                    int idDireccion = direccionDAO.RegistrarDireccion(ruta);

                    int idMensajeAudio = mensajeAudioDAO.RegistrarAudioMensaje(idDireccion);

                    return idMensajeAudio;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string ObtenerAudioDeMensaje(int idMensajeAudio)
        {
            try
            {
                direccionDAO = new DireccionDAO();
                mensajeAudioDAO = new MensajeAudioDAO();

                int idDireccion = estadoImagenDAO.ObtenerIdDireccionDeFotoEstado(idMensajeAudio);
                string direccion = direccionDAO.ObtenerDireccionDeArchivo(idDireccion);

                return ArchivoDAO.ObtenerArchivo(direccion);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }

    public partial class Servicios : IMensajeImagen
    {
        MensajeImagenDAO mensajeImagenDAO;

        public int RegistrarFotoDeMensaje(string imagenMensaje)
        {
            try
            {
                direccionDAO = new DireccionDAO();
                mensajeImagenDAO = new MensajeImagenDAO();

                string nombreImagen = Path.GetRandomFileName();
                string ruta = "C:/Users/javie/Documents/Sistemas en red/MultimediaDeServicio/FotoMensaje/" + nombreImagen + ".jpg";

                if (ArchivoDAO.GuardarArchivo(ruta, imagenMensaje))
                {
                    int idDireccion = direccionDAO.RegistrarDireccion(ruta);

                    int idMensajeImagen = mensajeImagenDAO.RegistrarImagenMensaje(idDireccion);

                    return idMensajeImagen;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string ObtenerFotoDeMensaje(int idMensajeImagen)
        {
            try
            {
                direccionDAO = new DireccionDAO();
                mensajeImagenDAO = new MensajeImagenDAO();

                int idDireccion = mensajeImagenDAO.ObtenerIdImagenMensaje(idMensajeImagen);
                string direccion = direccionDAO.ObtenerDireccionDeArchivo(idDireccion);

                return ArchivoDAO.ObtenerArchivo(direccion);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
