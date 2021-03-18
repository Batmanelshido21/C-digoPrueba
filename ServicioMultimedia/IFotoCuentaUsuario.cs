using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioMultimedia
{
    [ServiceContract]
    public interface IFotoCuentaUsuario
    {
        [OperationContract]
        int RegistrarFotoCuentaUsuario(string imagenCuentaUsuario);

        [OperationContract]
        string ObtenerFotoCuentaUsuario(int idFotoCuentaUsuario);
    }
}
