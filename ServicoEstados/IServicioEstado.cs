using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

namespace ServicoEstados
{
   
    [ServiceContract]
    public interface IServicioEstado
    {
        [OperationContract]
        bool RegistrarEstado(int idUsuario, int idEstadoImagen);

        [OperationContract]
        bool ReaccionarAEstado(int idEstado, int idReaccion, string nombreUsuario);

        [OperationContract]
        List<Estado> ObtenerEstados(int idUsuario);

        [OperationContract]
        List<string> ObtenerUsuariosQueDieronMeGusta(int idEstado);

        [OperationContract]
        List<string> ObtenerUsuariosQueDieronNoMeGusta(int idEstado);
    }

    [DataContract]
    public class Estado
    {
        [DataMember]
        public int idUsuario { get; set; }

        [DataMember]
        public int idEstado { get; set; }

        [DataMember]
        public int idEstadoImagen { get; set; }

        [DataMember]
        public string fecha { get; set; }
    }
}

