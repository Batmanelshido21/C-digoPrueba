using ClienteProyectoDeMensajeria.ClasesReutilizables;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.MessageBox;

namespace ClienteProyectoDeMensajeria
{
    /// <summary>
    /// Lógica de interacción para Estados.xaml
    /// </summary>
    public partial class Estados : System.Windows.Controls.UserControl
    {
        public EventHandler eventoCerrarEstados;
        private string imagenEstado_Base64;
        private int idMiFotoEstado;
        BitmapImage bitmapEstado;

        public ObservableCollection<Estado> estados = new ObservableCollection<Estado>();

        public Estados()
        {
            InitializeComponent();
        }

        private void buttonCerrar_Click(object sender, RoutedEventArgs e)
        {
            eventoCerrarEstados?.Invoke(this, e);
        }

        private void buttonCargarEstado_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog exploradorArchivos = new OpenFileDialog
            {
                Filter = "*.jpg | *.jpg",
                Title = "Imagen de estado",
                RestoreDirectory = true
            };

            DialogResult rutaImagen = exploradorArchivos.ShowDialog();

            if (rutaImagen == System.Windows.Forms.DialogResult.OK)
            {
                string imagePath = exploradorArchivos.FileName;
                Uri FilePath = new Uri(imagePath);
                bitmapEstado = new BitmapImage(FilePath);
                imagenNuevoEstado.Source = bitmapEstado;
                buttonAgregarEstado.Visibility = Visibility.Visible;
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
                imagenEstado_Base64 = Convert.ToBase64String(imagen);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.GetType() + " | | " + error.Message);
            }
        }

        private void buttonAgregarEstado_Click(object sender, RoutedEventArgs e)
        {
            if(imagenEstado_Base64.Length> 0)
            {
                guardarMiImagenEstado();
                string url = "http://25.21.180.245:8000/estado/RegistrarEstado?idUsuario=" + MainWindow.usuarioLogeado.idCuenta + 
                    "&idEstadoImagen=" + idMiFotoEstado;
                MessageBox.Show(url);
                var client = new RestClient(url);
                client.Timeout = -1;
                RestRequest request = new RestRequest(Method.POST);

                try
                {
                    IRestResponse response = client.Execute(request);
                    if (response.ResponseStatus != ResponseStatus.Completed)
                        MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                            "' Sucedió algo mal, intente más tarde");
                    else
                    {
                        MessageBox.Show(response.Content);
                        imagenEstado.Source = bitmapEstado;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("sucedió algo mal al subir tu estado, intenta mas tarde");
                }
            }
            buttonAgregarEstado.Visibility = Visibility.Hidden;
        }

        private void guardarMiImagenEstado()
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://25.21.180.245:8000/multimedia/registrarFotoEstado");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"stringBase64\":" + "\"" + imagenEstado_Base64 + "\"}";
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string result2 = result;
                    idMiFotoEstado = Int32.Parse(result2);
                    MessageBox.Show("Estamos registrando su estado...");
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        private void ListViewEstados_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "http://25.21.180.245:8000/estado/ObtenerEstados?idUsuario=" + MainWindow.usuarioLogeado.idCuenta;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus != ResponseStatus.Completed)
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                        "' Sucedió algo mal, intente más tarde");
                else if (response.Content.Length > 0)
                {
                    MessageBox.Show(response.Content);
                    var mensajesDeserializados = JsonConvert.DeserializeObject<List<Estado>>(response.Content);
                    if (estados.Count > 0) estados.Clear();
                    foreach (var msj in mensajesDeserializados)
                    {
                        estados.Add(msj);
                    }
                    ListViewEstados.ItemsSource = estados;
                }
                else MessageBox.Show("No se han podido recuperar los estados, intente mas tarde");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al recueprar estados");
            }
        }

        private void ListViewEstados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var estadoseleccionado = ListViewEstados.SelectedItem as Estado;
            string url = "http://25.21.180.245:8000/multimedia/obtenerFotoEstado?imagenEstado=" + estadoseleccionado.idEstadoImagen;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                BitmapImage image = null;
                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                               "' Sucedió algo mal, intente más tarde"); 
                }
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
                imagenEstado.Source = image;
            }
            catch (Exception)
            {
                MessageBox.Show("Por el momento no se puede mostrar la imágen");
               
            }
        }
    }
}
