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

        public void Client()
        {
            client = new TcpClient();
            client.Connect("127.0.0.1", 12345);
            isConnected = true;
            SocketTimer.Enabled = true;
        }


        public void Host()
        {
            host = new TcpListener(IPAddress.Any, 12345);
            host.Start();

            client = host.AcceptTcpClient();
            isConnected = true;
            SocketTimer.Enabled = true;
        }

        private void ReadSocket(string socket)
        {
            secondaryRelXPos = int.Parse(socket);
        }


        private void Listen()
        {
            stream = client.GetStream();

            byte[] buffer = new byte[1024];

            int bytes = stream.Read(buffer, 0, buffer.Length);

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
            SendSocket(mainXPos.ToString());
        }
    }
}
