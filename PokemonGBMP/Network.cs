using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGBMP
{
    public partial class MainForm
    {
        TcpListener host;
        TcpClient client;
        NetworkStream stream;

        public void Client()
        {
            client = new TcpClient();
            client.ConnectAsync("192.168.1.106", 12345);
            isConnected = true;
            SocketTimer.Enabled = true;
        }


        public async void Host()
        {
            host = new TcpListener(IPAddress.Any, 12345);
            host.Start();

            client = await host.AcceptTcpClientAsync();
            isConnected = true;
            SocketTimer.Enabled = true;
        }

        private void ReadSocket(string socket)
        {
            if(socket.StartsWith("X"))
            {
                string[] pos;
                pos = socket.Replace("X", "").Split('Y');
                secondaryRelXPos = int.Parse(pos[0]);
                secondaryRelYPos = int.Parse(pos[1]);
            }
        }


        private async void Listen()
        {
            stream = client.GetStream();

            byte[] buffer = new byte[1024];

            int bytes = await stream.ReadAsync(buffer, 0, buffer.Length);

            string msg = Encoding.ASCII.GetString(buffer, 0, bytes);

            ReadSocket(msg);

        }

        public void SendSocket(string msg)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(msg);
            stream.Write(buffer, 0, buffer.Length);

        }

        private void SocketTimer_Tick(object sender, EventArgs e)
        {
            Listen();
            SendSocket("X" + mainXPos + "Y" + mainYPos);
        }
    }
}
