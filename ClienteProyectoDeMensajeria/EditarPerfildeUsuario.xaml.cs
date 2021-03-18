using ClienteProyectoDeMensajeria.ClasesReutilizables;
using RestSharp;
using System;
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
    /// Lógica de interacción para EditarPerfildeUsuario.xaml
    /// </summary>
    public partial class EditarPerfildeUsuario : System.Windows.Controls.UserControl
    {
        private int genero;
        public EventHandler eventoCancelarEditarPerfil;
        private int idImagenPerfil;
        private string imagenPerfil_Base64;
        public EditarPerfildeUsuario()
        {
            InitializeComponent();
            
        }

        private void buttonGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (CamposLlenosEditarPerfil())
            {
                if (Validacion.EsCorreoElectronicoValido(textBoxCorreo.Text))
                {
                    if (idImagenPerfil != MainWindow.usuarioLogeado.idFotoCuentaUsuario)
                        registrarMiImagenPerfil();

                    string nombreUsuario = textBoxUsuario.Text;
                    string correo = textBoxCorreo.Text;
                    string contrasenia = textBoxContrasena.Password;
                    string telefono = textBoxTelefono.Text;                 

                    string url = "http://25.21.180.245:8000/cuenta/modificarUsuario?idCuenta=" + MainWindow.usuarioLogeado.idCuenta + 
                        "&nombreUsuario=" + nombreUsuario + "&correo=" + correo + "&contrasena=" + contrasenia + "&telefono=" + telefono + 
                        "&idFotoCuentaUsuario=" + idImagenPerfil + "&Genero_idGenero=" + genero;

                    var client = new RestClient(url);
                    client.Timeout = -1;
                    RestRequest request = new RestRequest(Method.PUT);
                    try
                    {
                        IRestResponse response = client.Execute(request);
                        if (response.ResponseStatus != ResponseStatus.Completed)
                            MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                                "' Sucedió algo mal, intente más tarde");
                        else if (response.Content.Equals("1"))
                        {
                            MainWindow.usuarioLogeado.idFotoCuentaUsuario = idImagenPerfil;
                            MainWindow.usuarioLogeado.nombreUsuario = nombreUsuario;
                            MainWindow.usuarioLogeado.telefono = telefono;
                            MainWindow.usuarioLogeado.correo = correo;
                            MainWindow.usuarioLogeado.contrasena = contrasenia;
                            MainWindow.usuarioLogeado.Genero_idGenero = genero;
                            MessageBox.Show("Se guardaron los cambios correctamente");
                        }
                        else
                            MessageBox.Show("No se pudo guardar los cambios");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    textBoxCorreo.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
                MessageBox.Show("Hay campos vacíos");
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            textBoxContrasena.Password = "";          
            eventoCancelarEditarPerfil?.Invoke(this, e);
        }

        private void buttonCargarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog exploradorArchivos = new OpenFileDialog
            {
                Filter = "*.jpg | *.jpg",
                Title = "Imagen de perfil",
                RestoreDirectory = true
            };

            DialogResult rutaImagen = exploradorArchivos.ShowDialog();

            if (rutaImagen == System.Windows.Forms.DialogResult.OK)
            {
                string imagePath = exploradorArchivos.FileName;
                Uri FilePath = new Uri(imagePath);
                imagenPerfil.Source = new BitmapImage(FilePath);
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
                imagenPerfil_Base64 = Convert.ToBase64String(imagen);
                idImagenPerfil = 0;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.GetType() + " | | " + error.Message);
            }
        }

        private void comboBoxGenero_Loaded(object sender, RoutedEventArgs e)
        {            
            comboBoxGenero.Items.Add("Masculino");
            comboBoxGenero.Items.Add("Femenino");

            if (MainWindow.usuarioLogeado.Genero_idGenero == 1)
                comboBoxGenero.SelectedItem = "Masculino";
            else if (MainWindow.usuarioLogeado.Genero_idGenero == 2)
                comboBoxGenero.SelectedItem = "Femenino";
        }

        private void comboBoxGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxGenero.SelectedValue.ToString() == "Masculino")
                genero = 1;
            else if (comboBoxGenero.SelectedValue.ToString() == "Femenino")
                genero = 2;
        }
       

        private void textBoxUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxUsuario.Text = MainWindow.usuarioLogeado.nombreUsuario;                 
        }

        private void textBoxCorreo_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxCorreo.Text = MainWindow.usuarioLogeado.correo;
        }

        private void textBoxTelefono_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxTelefono.Text = MainWindow.usuarioLogeado.telefono;
        }

        private Boolean CamposLlenosEditarPerfil()
        {
            if (textBoxUsuario.Text.Length > 0 && textBoxCorreo.Text.Length > 0 && textBoxTelefono.Text.Length > 0
                && textBoxContrasena.Password.Length > 0 && (comboBoxGenero.SelectedIndex > -1))
                return true;
            else
                return false;
        }

        private void imagenPerfil_Loaded(object sender, RoutedEventArgs e)
        {
            idImagenPerfil = MainWindow.usuarioLogeado.idFotoCuentaUsuario;
            string url = "http://25.21.180.245:8000/multimedia/obtenerFotoDeCuenta?idFotoCuentaUsuario=" + idImagenPerfil;
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
                    var base64Formateada = response.Content.Substring(1, response.Content.Length - 2).Replace(@"\/", "/");
                    byte[] bytesDeImagen = Convert.FromBase64String(base64Formateada);
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
                imagenPerfil.Source = image;
            }
            catch (Exception)
            {
                MessageBox.Show("Por el momento no se puede mostrar la imágen");                
            }
        }

        private void registrarMiImagenPerfil()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://25.21.180.245:8000/multimedia/registrarFotoCuentaUsuario");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"stringBase64\":" + "\"" + imagenPerfil_Base64 + "\"}";
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                string result2 = result;
                idImagenPerfil = Int32.Parse(result2);
                MessageBox.Show("Estamos registrandolo...");
            }
        }
    }
}
