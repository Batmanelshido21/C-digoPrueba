using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClienteProyectoDeMensajeria
{
    /// <summary>
    /// Lógica de interacción para VerImagenesDelChat.xaml
    /// </summary>
    public partial class VerImagenesDelChat : UserControl
    {
        public EventHandler eventoCerrarImagenesDelChat;
        public VerImagenesDelChat()
        {
            InitializeComponent();
        }

        private void buttonCerrar_Click(object sender, RoutedEventArgs e)
        {
            eventoCerrarImagenesDelChat?.Invoke(this, e);
        }
    }
}
