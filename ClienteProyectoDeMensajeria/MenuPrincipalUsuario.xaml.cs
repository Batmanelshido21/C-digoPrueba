using ClienteProyectoDeMensajeria.ClasesReutilizables;
using Microsoft.Win32;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Web.Helpers;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.IO;
using MessageBox = System.Windows.MessageBox;
using System.Net;

namespace ClienteProyectoDeMensajeria
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipalUsuario.xaml
    /// </summary>
    public partial class MenuPrincipalUsuario : System.Windows.Controls.UserControl
    {
        SoundPlayer ReproductoWav;
        public EventHandler eventoEstados;
        public EventHandler eventoPerfil;
        public EventHandler eventoAgregarAmigo;
        public EventHandler eventoChatGrupal;
        public EventHandler eventCerrarSesion;
        public EventHandler eventVerImagenesDelChat;
        String url;

        //Valores para el chat
        public bool modoEdicionMensaje = false;
        public string nombreChat_Actual;
        public ObservableCollection<Mensaje> mensajes = new ObservableCollection<Mensaje>();
        public ObservableCollection<String> misChats = new ObservableCollection<String>();
        public MenuPrincipalUsuario()
        {
            InitializeComponent();
        }

        private void buttonEstados_Click(object sender, RoutedEventArgs e)
        {
            eventoEstados?.Invoke(this, e);
        }

        private void buttonPerfil_Click(object sender, RoutedEventArgs e)
        {
            eventoPerfil?.Invoke(this, e);
        }

        private void buttonAgregarAmigo_Click(object sender, RoutedEventArgs e)
        {
            eventoAgregarAmigo?.Invoke(this, e);
        }

        private void buttonChatGrupal_Click(object sender, RoutedEventArgs e)
        {
            eventoChatGrupal?.Invoke(this, e);
        }

        private void buttonCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.usuarioLogeado = null;
            LabelNombreAmigo.Content = "";
            mensajes.Clear();
            misChats.Clear();
            eventCerrarSesion?.Invoke(this, e);
        }

        private void VerImgChat_Click(object sender, RoutedEventArgs e)
        {
            eventVerImagenesDelChat?.Invoke(this, e);
        }

        private void LabelMiNombreDeUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            LabelMiNombreDeUsuario.Content = MainWindow.usuarioLogeado.nombreUsuario;
        }


        private void detenerAudio(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog CajaDeDiaologoGuardar = new Microsoft.Win32.SaveFileDialog();
            CajaDeDiaologoGuardar.AddExtension = true;
            CajaDeDiaologoGuardar.FileName = "Audio.wav";
            CajaDeDiaologoGuardar.Filter = "Sonido (*.wav)|*.wav";
            CajaDeDiaologoGuardar.ShowDialog();
            if (!string.IsNullOrEmpty(CajaDeDiaologoGuardar.FileName))
            {
                url = CajaDeDiaologoGuardar.FileName;

                Grabar("save recsound " + CajaDeDiaologoGuardar.FileName, "", 0, 0);
                Grabar("close recsound", "", 0, 0);
                MessageBox.Show("Archivo Guardado en:" + CajaDeDiaologoGuardar.FileName);

            }
        }


        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int Grabar(string Comando, string StringRetono, int Longitud, int hwndCallback);
        private void grabarAudio(object sender, RoutedEventArgs e)
        {
            Grabar("open new Type waveaudio Alias recsound", "", 0, 0);
            Grabar("record recsound", "", 0, 0);
        }

        private void reproducir(object sender, RoutedEventArgs e)
        {
            ReproductoWav.SoundLocation = url;
            ReproductoWav.Play();
        }

        private void eliminar(object sender, RoutedEventArgs e)
        {

        }

        private void listChats_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "http://25.21.180.245:8000/chat/obtenerChatsDeUsuario?nombreUsuario=" + MainWindow.usuarioLogeado.nombreUsuario;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            try {
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus != ResponseStatus.Completed)
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                        "' Sucedió algo mal, intente más tarde");
                if (response.Content.Length > 0) {
                    var chatsDeserializados = JsonConvert.DeserializeObject<List<Chat>>(response.Content);
                    if (misChats.Count > 0) misChats.Clear();
                    foreach (var chat in chatsDeserializados) {
                        misChats.Add(chat.Chat_nombreChat);
                    }
                    listChats.ItemsSource = misChats;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void listChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            if(listChats.SelectedItem != null)
            {
                LabelNombreAmigo.Content = listChats.SelectedItem;
                nombreChat_Actual = listChats.SelectedItem.ToString();
                obtenerMensajes();
            }           
            textboxMensaje.Text = "";
            
        }

        private void obtenerMensajes()
        {
            string url = "http://25.21.180.245:8000/chat/obtenerMensajesChat?Chat_nombreChat=" + listChats.SelectedItem;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus != ResponseStatus.Completed)
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                        "' Sucedió algo mal, intente más tarde");
                var mensajesDeserializados = JsonConvert.DeserializeObject<List<Mensaje>>(response.Content);
                if (mensajes.Count > 0) mensajes.Clear();
                foreach (var msj in mensajesDeserializados)
                {
                    if (msj.idMensajeImagen != 0)
                    {
                        var imagen = obtenerImagen(msj.idMensajeImagen);
                        msj.imagenChat = imagen;
                    }
                    mensajes.Add(msj);
                }
                listViewMensajes.ItemsSource = mensajes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public BitmapImage obtenerImagen(int idImagen) {
            string url = "http://25.21.180.245:8000/multimedia/obtenerFotoDeMensaje?idMensajeImagen=" + idImagen;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                BitmapImage image = null;
                if (response.ResponseStatus != ResponseStatus.Completed) {
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                               "' Sucedió algo mal, intente más tarde"); return null; }
                else if (response.Content.Length > 0)
                {
                    var cadena = response.Content.Substring(1, response.Content.Length - 2).Replace(@"\/", "/");                                       
                    byte[] bytesDeImagen = Convert.FromBase64String(cadena);
                    image = new BitmapImage();
                    using (var mem = new MemoryStream(bytesDeImagen))
                    {
                        mem.Position = 0;
                        image.BeginInit();
                        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.UriSource = null;
                        image.StreamSource = mem;
                        image.EndInit();
                    }                    
                } 
                return image;
            }
            catch (Exception)
            {
                MessageBox.Show("Por el momento no se puede mostrar la imágen");
                return null;
            }
        }
    

        private void buttonEnviarMensaje_Click(object sender, RoutedEventArgs e)
        {
            if (modoEdicionMensaje)
            {
                var mensajeSeleccionado = listViewMensajes.SelectedItem as Mensaje;
                string urlEdicion = "http://25.21.180.245:8000/chat/editarMensaje?idMensaje=" + mensajeSeleccionado.idMensaje + "&favorito=" + 0 + "&mensaje=" + textboxMensaje.Text;
                RestClient client = new RestClient(urlEdicion);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                try
                {
                    IRestResponse response = client.Execute(request);
                    if (response.ResponseStatus != ResponseStatus.Completed)
                        MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                                   "' Sucedió algo mal, intente más tarde");
                    else if (response.Content.Equals("1"))
                    {
                        obtenerMensajes();
                    }
                    else
                        MessageBox.Show("no se pudo enviar tu mensaje");
                    modoEdicionMensaje = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                var fecha = DateTime.Now.ToString("yyyy-MM-dd");
                string url = "http://25.21.180.245:8000/chat/enviarMensaje?fecha=" + fecha +
                "&favorito=" + 0 + "&mensaje=" + textboxMensaje.Text + "&tipoMensaje=" + "texto" + "&idMensajeImagen=" + 0 +
                    "&mensajeAudio=" + 0 + "&UsuarioChat_nombreUsuario=" + MainWindow.usuarioLogeado.nombreUsuario + "&Chat_nombreChat=" +
                    nombreChat_Actual;
                RestClient client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                try
                {
                    IRestResponse response = client.Execute(request);
                    if (response.ResponseStatus != ResponseStatus.Completed)
                        MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                                   "' Sucedió algo mal, intente más tarde");
                    else if (response.Content.Equals("1"))
                    {
                        obtenerMensajes();
                    }
                    else
                        MessageBox.Show("no se pudo enviar tu mensaje");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            textboxMensaje.Text = "";
        }

        private void listViewMensajes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonEditarMsj.Visibility = Visibility.Visible;
            buttonEliminarMsj.Visibility = Visibility.Visible;
        }

        private void buttonEditarMsj_Click(object sender, RoutedEventArgs e)
        {
            modoEdicionMensaje = true;
            var mensajeSeleccionado = listViewMensajes.SelectedItem as Mensaje;
            textboxMensaje.Text = mensajeSeleccionado.mensaje;
        }

        private void buttonEliminarMsj_Click(object sender, RoutedEventArgs e)
        {
            var mensajeSeleccionado = listViewMensajes.SelectedItem as Mensaje;
            string url = "http://25.21.180.245:8000/chat/eliminarMensaje?idMensaje=" + mensajeSeleccionado.idMensaje;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus != ResponseStatus.Completed)
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                               "' Sucedió algo mal, intente más tarde");
                else if (response.Content.Equals("1"))
                {
                    mensajes.Remove(mensajeSeleccionado);
                }
                else MessageBox.Show("No se puso eliminar el mensaje");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonFoto_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog exploradorArchivos = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "*.jpg | *.jpg",
                Title = "Elige una imagen",
                RestoreDirectory = true
            };
            DialogResult rutaImagen = exploradorArchivos.ShowDialog();
            if (rutaImagen == System.Windows.Forms.DialogResult.OK)
            {
                string imagePath = exploradorArchivos.FileName;
                Uri FilePath = new Uri(imagePath);
                var imagen = new BitmapImage(FilePath);                
            }
            try
            {
                byte[] imagen;
                byte[] buffer = null;
                int longitud;
                var PathfileName = string.Empty;
                using (var fs = new FileStream(exploradorArchivos.FileName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    longitud = (int)fs.Length;
                }
                imagen = buffer;
                var imagen_Base64 = Convert.ToBase64String(imagen);
                
                //mando a llamar a guardar imagen
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://25.21.180.245:8000/multimedia/registrarFotoMensaje");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"stringBase64\":" + "\"" + imagen_Base64 + "\"}";
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string result2 = result;
                    int idMsjImagen = Int32.Parse(result2);
                    MessageBox.Show("enviando...");
                    enviarMensajeImagen(idMsjImagen);
                }
                
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void enviarMensajeImagen(int idImagen)
        {
            var fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string url = "http://25.21.180.245:8000/chat/enviarMensaje?fecha=" + fecha +
            "&favorito=" + 0 + "&mensaje=" + textboxMensaje.Text + "&tipoMensaje=" + "imagen" + "&idMensajeImagen=" + idImagen +
                "&mensajeAudio=" + 0 + "&UsuarioChat_nombreUsuario=" + MainWindow.usuarioLogeado.nombreUsuario + "&Chat_nombreChat=" +
                nombreChat_Actual;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus != ResponseStatus.Completed)
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                               "' Sucedió algo mal, intente más tarde");
                else if (response.Content.Equals("1"))
                {                    
                    obtenerMensajes();
                }
                else
                    MessageBox.Show("no se pudo enviar tu mensaje");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textboxMensaje.Text = "";
        }
    }
}
