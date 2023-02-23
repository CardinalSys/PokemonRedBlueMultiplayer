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
        public void BackGroundWorker()
        {
            // Inicializar el objeto BackgroundWorker
            backgroundWorker = new BackgroundWorker();
            if (isHost)
                backgroundWorker.DoWork += new DoWorkEventHandler(Host);
            else
                backgroundWorker.DoWork += new DoWorkEventHandler(Client);

            // Iniciar el BackgroundWorker
            backgroundWorker.RunWorkerAsync();
        }


        public void Client(object sender, DoWorkEventArgs e)
        {
            client = new TcpClient();
            client.Connect("127.0.0.1", 12345);
            stream = client.GetStream();
            isConnected = true;
            Listen();
        }


        public void Host(object sender, DoWorkEventArgs e)
        {
            host = new TcpListener(IPAddress.Any, 12345);
            host.Start();

            client = host.AcceptTcpClient();
            while (stream == null)
                stream = client.GetStream();
            isConnected = true;
            Listen();
        }


        private void Listen()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];

                int bytes = stream.Read(buffer, 0, buffer.Length);

                string msg = Encoding.ASCII.GetString(buffer, 0, bytes);

                secondaryRelXPos = Int32.Parse(msg);

                if (label1.InvokeRequired)
                {
                    label1.Invoke((MethodInvoker)delegate
                    {
                        label1.Text = msg;
                    });
                }
                else
                {
                    label1.Text = msg;
                }
            }

        }

        public void SendSocket(string msg)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(msg);
            stream.Write(buffer, 0, buffer.Length);

        }
    }
}
