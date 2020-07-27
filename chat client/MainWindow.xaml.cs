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
using System.Net;
using System.Net.WebSockets;
using System.Net.Sockets;

namespace chat_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ServerIp = "localhost";
        int port = 8080;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_send_Click(object sender, RoutedEventArgs e)
        {
            TcpClient client = new TcpClient(ServerIp, port);

            int byteCount = Encoding.UTF8.GetByteCount(message.Text+1);
            byte[] sendData = new byte[byteCount];
            sendData = Encoding.UTF8.GetBytes(message.Text +';') ;

            NetworkStream stream = client.GetStream();
            stream.Write(sendData);
            stream.Close(0);
            client.Close();
        }
    }
}
