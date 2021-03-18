using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMultimedia
{
    [ServiceContract]
    interface IMensajeImagen
    {
        [OperationContract]
        int RegistrarFotoDeMensaje(string imagenMensaje);

        [OperationContract]
        string ObtenerFotoDeMensaje(int idMensajeImagen);
    }
}
