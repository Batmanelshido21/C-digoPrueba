using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMultimedia.DAO
{
    class ArchivoDAO
    {

        public ArchivoDAO()
        {

        }

        public static bool GuardarArchivo(string ruta, string archivo)
        {
            try
            {
                byte[] bytesDeImagen = Convert.FromBase64String(archivo);
                File.WriteAllBytes(ruta, bytesDeImagen);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string ObtenerArchivo(string ruta)
        {
            string archivoBase64 = "";
             
            try
            {
                byte[] bytesArchivo;
                byte[] buffer = null;
                int longitud;
                var PathfileName = string.Empty;

                PathfileName = ruta;

                using (var fs = new FileStream(PathfileName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    longitud = (int)fs.Length;
                }

                bytesArchivo = buffer;
            
                archivoBase64 = Convert.ToBase64String(bytesArchivo);

                return archivoBase64;
            }
            catch (Exception)
            {
                return archivoBase64;
            }
        }
    }
}
