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
                //Movement
                string[] mov;
                mov = socket.Replace("X", "").Split('T')[0].Split(';');
                secondaryAbsXPos = int.Parse(mov[0]);
                secondaryAbsYPos = int.Parse(mov[1]);
                secondaryMapId = int.Parse(mov[2]);
                secondarySpriteImageIndex = int.Parse(mov[3]);
                CalculateRelativePosition();

                //Trade
                string[] trade;
                try
                {
                    trade = socket.Split('T')[1].Split(';');
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "/Error: " + socket.Split('T')[0]);
                }
                /*box.secSlctPkmText.Text = trade[0];
                try
                {
                    box.secReadCheckBox.Checked = bool.Parse(trade[1]);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "/Error: " + trade[1]);
                }*/
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
            if(box != null)
                SendSocket("X" + mainXPos + ";" + mainYPos + ";" + mainMapID + ";" + mainSpriteImageIndex + "T" + box.slctPkmText.Text + "; " + box.readyCheckBox.Checked);
            else
                SendSocket("X" + mainXPos + ";" + mainYPos + ";" + mainMapID + ";" + mainSpriteImageIndex + "T" + "null" + "; " + "false");


        }
    }
}
