using ClienteProyectoDeMensajeria.ClasesReutilizables;
using RestSharp;
using System;
using System.Web.Helpers;
using System.Windows;


namespace ClienteProyectoDeMensajeria
{
    public partial class MainWindow : Window
    {
        public static dynamic usuarioLogeado;
        RegistroCuenta userControlRegistroCuenta;
        MenuPrincipalUsuario UserControlPrincipal = new MenuPrincipalUsuario();
        Estados UserControlEstados = new Estados();
        EditarPerfildeUsuario UserControlEditarPerfil = new EditarPerfildeUsuario();
        AgregarAmigo UserControlAgregarAmigo = new AgregarAmigo();
        ChatGrupal UserControlChatGrupal = new ChatGrupal();
        VerImagenesDelChat UserControlImagenesDelChat = new VerImagenesDelChat();
        public MainWindow()
        {
            InitializeComponent();
            UserControlPrincipal.eventoEstados += EventoVerEstados;
            UserControlPrincipal.eventoPerfil += EventoVerPerfil;
            UserControlPrincipal.eventoAgregarAmigo += EventoVerAgregarAmigo;
            UserControlPrincipal.eventoChatGrupal += EventoVerChatGrupal;
            UserControlPrincipal.eventCerrarSesion += EventoCerrarSesion;
            UserControlPrincipal.eventVerImagenesDelChat += EventoVerImagenesDelChat;

            UserControlEstados.eventoCerrarEstados += EventoCerrarEstados;

            UserControlEditarPerfil.eventoCancelarEditarPerfil += EventoCancelarEditarPerfil;

            UserControlAgregarAmigo.eventoCancelar += EventoCancelarAgregarAmigo;

            UserControlChatGrupal.eventoCancelarChatGrupal += EventoCancelarChatGrupal;

            UserControlImagenesDelChat.eventoCerrarImagenesDelChat += EventoCerrarImagenesDelChat;
        }

        private void iniciarSesion(object sender, RoutedEventArgs e)
        {
            if (ValidarDatosIngresados())
            {
                if (Validacion.EsCorreoElectronicoValido(textBoxCorreo.Text))
                {                    
                    string correo = textBoxCorreo.Text;
                    string contrasena = textboxContrasena.Password;
                    string url = "http://25.21.180.245:8000/cuenta/login?correo=" + correo + "&contrasena=" + contrasena;

                    RestClient client = new RestClient(url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddParameter("text/plain", "", ParameterType.RequestBody);
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                    try
                    {
                        IRestResponse response = client.Execute(request);                        
                        if (response.ResponseStatus != ResponseStatus.Completed)
                            MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                                "' Sucedió algo mal, intente más tarde");
                        else if (response.Content.Length == 0)
                        {
                            MessageBox.Show("Los datos son inválidos");
                        }
                        else
                        {
                            usuarioLogeado = Json.Decode(response.Content);
                            DesaparecerComponentes();
                            UserControlPrincipal.Visibility = Visibility.Visible;
                            gridPrincipal.Children.Add(UserControlPrincipal);
                        }
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
            {
                textBoxCorreo.BorderBrush = System.Windows.Media.Brushes.Red;
                textboxContrasena.BorderBrush = System.Windows.Media.Brushes.Red;
            }                                              
        }

        private bool ValidarDatosIngresados()
        {           
            if (textBoxCorreo.Text.Length > 0 && textboxContrasena.Password.Length > 0)
            {
                return true;
            }
            else            
                return false;           
        }

        private void registrarUsuario(object sender, RoutedEventArgs e)
        {
            userControlRegistroCuenta = new RegistroCuenta();
            userControlRegistroCuenta.eventoRegistro += EventoRegistrar;
            userControlRegistroCuenta.eventoCancelarRegistro += EventoCancelarRegistro;
            DesaparecerComponentes();
            userControlRegistroCuenta.Visibility = Visibility.Visible;
            gridPrincipal.Children.Add(userControlRegistroCuenta);
        }        

        public void EventoRegistrar(object sender, EventArgs e)
        {
            AparecerComponentes();            
            gridPrincipal.Children.Remove(userControlRegistroCuenta);
        }

        private void EventoCancelarRegistro(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(userControlRegistroCuenta);
            AparecerComponentes();
        }

        private void EventoVerEstados(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlPrincipal);
            UserControlEstados.Visibility = Visibility.Visible;
            gridPrincipal.Children.Add(UserControlEstados);
        }

        private void EventoVerPerfil(object sender, EventArgs e)
        {
            UserControlEditarPerfil.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlEditarPerfil);
        }

        private void EventoVerAgregarAmigo(object sender, EventArgs e)
        {
            UserControlAgregarAmigo.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlAgregarAmigo);
        }

        private void EventoVerChatGrupal(object sender, EventArgs e)
        {
            UserControlChatGrupal.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlChatGrupal);
        }

        private void EventoVerImagenesDelChat(object sender, EventArgs e)
        {
            UserControlImagenesDelChat.Visibility = Visibility.Visible;
            gridPrincipal.Children.Remove(UserControlPrincipal);
            gridPrincipal.Children.Add(UserControlImagenesDelChat);
        }

        private void EventoCerrarSesion(object sender, EventArgs e)
        {         
            gridPrincipal.Children.Remove(UserControlPrincipal);
            AparecerComponentes();
        }

        private void EventoCancelarChatGrupal(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlChatGrupal);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        private void EventoCancelarEditarPerfil(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlEditarPerfil);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        private void EventoCancelarAgregarAmigo(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlAgregarAmigo);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        public void EventoCerrarEstados(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlEstados);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        private void EventoCerrarImagenesDelChat(object sender, EventArgs e)
        {
            gridPrincipal.Children.Remove(UserControlImagenesDelChat);
            gridPrincipal.Children.Add(UserControlPrincipal);
            UserControlPrincipal.Visibility = Visibility.Visible;
        }

        public void AparecerComponentes()
        {
            buttonLogin.Visibility = Visibility.Visible;
            buttonRegistrar.Visibility = Visibility.Visible;
            textBoxCorreo.Visibility = Visibility.Visible;
            labelCorreo.Visibility = Visibility.Visible;
            labelContrasena.Visibility = Visibility.Visible;
            textboxContrasena.Visibility = Visibility.Visible;
            labelTitulo.Visibility = Visibility.Visible;
        }

        public void DesaparecerComponentes()
        {
            buttonLogin.Visibility = Visibility.Collapsed;
            buttonRegistrar.Visibility = Visibility.Collapsed;
            textBoxCorreo.Visibility = Visibility.Collapsed;
            labelCorreo.Visibility = Visibility.Collapsed;
            labelContrasena.Visibility = Visibility.Collapsed;
            textboxContrasena.Visibility = Visibility.Collapsed;
            labelTitulo.Visibility = Visibility.Collapsed;
        }       
    }
}
