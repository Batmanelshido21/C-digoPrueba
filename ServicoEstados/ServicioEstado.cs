using ServicoEstados.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicoEstados
{
    public class ServicioEstado : IServicioEstado
    {
        UsuarioEstadoDAO usuarioEstadoDAO;
        EstadoDAO estadoDAO;
        Estado_has_reaccionDAO estado_Has_ReaccionDAO;

        public bool RegistrarEstado(int idUsuario, int idEstadoImagen)
        {
            usuarioEstadoDAO = new UsuarioEstadoDAO();
            estadoDAO = new EstadoDAO();

            try
            {
                int usuarioEstado = usuarioEstadoDAO.RegistrarUsuarioEstado(idUsuario);

                estadoDAO.RegistrarEstado(usuarioEstado, idEstadoImagen);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public bool ReaccionarAEstado(int idEstado, int idReaccion, string nombreUsuario)
        {
            estado_Has_ReaccionDAO = new Estado_has_reaccionDAO();

            try
            {
                estado_Has_ReaccionDAO.RegistrarReaccion(idEstado, idReaccion, nombreUsuario);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }

        }

        public List<Estado> ObtenerEstados(int idUsuario)
        {
            List<Estado> estadosDeUsuario = new List<Estado>();
            List<int> idsUsuarioEstado = new List<int>();
            usuarioEstadoDAO = new UsuarioEstadoDAO();
            estadoDAO = new EstadoDAO();

            try
            {
                idsUsuarioEstado = usuarioEstadoDAO.RecuperarIdsUsuarioEstado(idUsuario);

                foreach(int id in idsUsuarioEstado)
                {
                    estadosDeUsuario.Add(estadoDAO.ObtenerEstadoDeUsuario(id));
                }

                return estadosDeUsuario;
            }
            catch (Exception)
            {
                return estadosDeUsuario;
            }
        }

        public List<string> ObtenerUsuariosQueDieronMeGusta(int idEstado)
        {
            estado_Has_ReaccionDAO = new Estado_has_reaccionDAO();

            try
            {
                return estado_Has_ReaccionDAO.ObtenerUsuariosQueDieronMeGusta(idEstado);
            }
            catch (Exception)
            {
                List<string> usuarios = new List<string>();

                return usuarios;
            }
        }

        public List<string> ObtenerUsuariosQueDieronNoMeGusta(int idEstado)
        {
            estado_Has_ReaccionDAO = new Estado_has_reaccionDAO();

            try
            {
                return estado_Has_ReaccionDAO.ObtenerUsuariosQueDieronNoMeGusta(idEstado);
            }
            catch (Exception)
            {
                List<string> usuarios = new List<string>();

                return usuarios;
            }
        }
    }
}
