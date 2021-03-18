using RestSharp;
using System;
using System.Web.Helpers;
using System.Windows;
using System.Windows.Controls;


namespace ClienteProyectoDeMensajeria
{
    /// <summary>
    /// Lógica de interacción para ChatGrupal.xaml
    /// </summary>
    public partial class ChatGrupal : UserControl
    {
        public EventHandler eventoCancelarChatGrupal;
        public ChatGrupal()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            eventoCancelarChatGrupal?.Invoke(this, e);
        }

        private void listViewTodosMisAmigos_Loaded(object sender, RoutedEventArgs e)
        {
            if (listViewTodosMisAmigos.Items.Count > 0) listViewTodosMisAmigos.Items.Clear();
            string url = "http://25.21.180.245:8000/chat/obtenerAmigos?nombreUsuario=" + MainWindow.usuarioLogeado.nombreUsuario;
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus != ResponseStatus.Completed)
                    MessageBox.Show(response.ResponseStatus + " '" + response.StatusCode.ToString() +
                        "' Sucedió algo mal, intente más tarde");
                if (response.Content.Length > 0)
                {
                    var amigos = Json.Decode(response.Content);
                    foreach (var amigo in amigos)
                        listViewTodosMisAmigos.Items.Add(amigo.amigoNombreUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listViewTodosMisAmigos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listViewAmigosGrupo.Items.Add(listViewTodosMisAmigos.SelectedItem);
        }

        private void buttonGuardar_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://25.21.180.245:8000/chat/registrarChat?nombreChat=" + textBoxNombreGrupo.Text + "&tipoChat=grupal";

            RestClient client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.Content.Equals("1"))
                {
                    string url_Yo = "http://25.21.180.245:8000/chat/agregarUsuario?nombreChat=" + textBoxNombreGrupo.Text +
                       "&nombreUsuario=" + MainWindow.usuarioLogeado.nombreUsuario;

                    client = new RestClient(url_Yo);
                    client.Timeout = -1;
                    var requestAgregarUsuarioAChat = new RestRequest(Method.POST);
                    IRestResponse response2 = client.Execute(requestAgregarUsuarioAChat);
                    if (response2.Content.Equals("1"))
                    {

                        foreach (var amigo in listViewAmigosGrupo.Items)
                        {
                        MessageBox.Show(amigo.ToString());
                        string url_Amigo = "http://25.21.180.245:8000/chat/agregarUsuario?nombreChat=" + textBoxNombreGrupo.Text +
                       "&nombreUsuario=" + amigo.ToString();
                        client = new RestClient(url_Amigo);
                        client.Timeout = -1;
                        var requestAgregarAmigoAChat = new RestRequest(Method.POST);
                        IRestResponse response3 = client.Execute(requestAgregarUsuarioAChat);
                        if (response3.Content.Equals("0")) { MessageBox.Show("Se interrumpió al guardar el guardar el grupo");  break; }
                        }
                    }
                    else MessageBox.Show("No se pudo guardar");
                }
                else MessageBox.Show("No se pudo guardar");
                eventoCancelarChatGrupal?.Invoke(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
