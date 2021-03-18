using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioMultimedia
{
    [ServiceContract]
    public interface IAudioDeMensaje
    {
        [OperationContract]
        int RegistrarAudioDeMensaje(string audio);

        [OperationContract]
        string ObtenerAudioDeMensaje(int idMensajeAudio);
    }
}
