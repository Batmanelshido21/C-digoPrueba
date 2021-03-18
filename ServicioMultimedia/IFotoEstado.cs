using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioMultimedia
{
    [ServiceContract]
    public interface IFotoEstado
    {
        [OperationContract]
        int RegistrarFotoDeEsatado(string imagenCuentaUsuario);

        [OperationContract]
        string ObtenerFotoDeEstado(int idFotoCuentaUsuario);
    }
}
