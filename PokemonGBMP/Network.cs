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
                mov = socket.Replace("X", "").Split('Y')[0].Split(';');
                secondaryAbsXPos = int.Parse(mov[0]);
                secondaryAbsYPos = int.Parse(mov[1]);
                secondaryMapId = int.Parse(mov[2]);
                secondarySpriteImageIndex = int.Parse(mov[3]);
                CalculateRelativePosition();

                //Trade
                if(box != null)
                {
                    string[] trade;

                    trade = socket.Split('Y')[1].Split(';');

                    box.secSlctPkmText.Text = trade[0];

                    box.secReadCheckBox.Checked = trade[1] == "True";

                }
            }
            else if(socket.StartsWith("T"))
            {
                string recPkm = socket.Replace("T", "");
                mem.WriteBytes("visualboyadvance-m.exe+039602E8," + (0xA96 + (33 * box.slctPkmNum)).ToString("X"), Encoding.ASCII.GetBytes(recPkm));
                mem.WriteBytes("visualboyadvance-m.exe+039602E8," + (0xA81 + box.slctPkmNum).ToString("X"), Encoding.ASCII.GetBytes(recPkm.Remove(2, recPkm.Length)));

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
            if (!onTrade)
            {
                if (box != null)
                    SendSocket("X" + mainXPos + ";" + mainYPos + ";" + mainMapID + ";" + mainSpriteImageIndex + "Y" + box.slctPkmText.Text + ";" + box.readyCheckBox.Checked);
                else
                    SendSocket("X" + mainXPos + ";" + mainYPos + ";" + mainMapID + ";" + mainSpriteImageIndex + "Y" + "null" + ";" + "false");
            }



        }
    }
}
