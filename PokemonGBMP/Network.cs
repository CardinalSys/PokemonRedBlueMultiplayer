using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
            client.ConnectAsync(ipInputBox.Text, 12345);
            Properties.Settings.Default.Ip = ipInputBox.Text;
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
                secondaryIsOnCombat = int.Parse(mov[4]);
                secondaryIsOnGrass = int.Parse(mov[5]);
                secondaryBadgets = int.Parse(mov[6]);
                secondaryMewtwo = int.Parse(mov[7]);
                secondaryArticuno = int.Parse(mov[8]);
                secondaryMoltres = int.Parse(mov[9]);
                secondaryZapdos = int.Parse(mov[10]);
                sFoughtGiovanni = int.Parse(mov[11]);
                sFoughtBrock = int.Parse(mov[12]);
                sFoughtMisty = int.Parse(mov[13]);
                sFoughtSurge = int.Parse(mov[14]);
                sFoughtErika = int.Parse(mov[15]);
                sFoughtKoga = int.Parse(mov[16]);
                sFoughtBlaine = int.Parse(mov[17]);
                sFoughtSabrina = int.Parse(mov[18]);
                sFoughtFSnorlax = int.Parse(mov[19]);
                sFoughtSSnorlax = int.Parse(mov[20]);
                 
                for(int i = 0; i < sPkdex.Length; i++)
                {
                    sPkdex[i] = byte.Parse(mov[21].Split('-')[i], NumberStyles.HexNumber);
                }
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
                box.StartTrade();
                string[] recPkm = socket.Replace("T", "").Split(';')[0].Split('-');
                string[] nickName = socket.Replace("T", "").Split(';')[1].Split('-');
                byte[] bytes = new byte[recPkm.Length];
                for(int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = byte.Parse(recPkm[i], NumberStyles.HexNumber);
                }
                byte[] nnBytes = new byte[nickName.Length];
                for (int i = 0; i < nnBytes.Length; i++)
                {
                    nnBytes[i] = byte.Parse(nickName[i], NumberStyles.HexNumber);
                }
                //Change stats
                mem.WriteBytes("visualboyadvance-m.exe+039602E8," + (0xA96 + (33 * box.slctPkmNum)).ToString("X"), bytes);
                //Change ID
                mem.WriteMemory("visualboyadvance-m.exe+039602E8," + (0xA81 + box.slctPkmNum).ToString("X"), "byte", bytes[0].ToString("X"));
                //Change NickName
                mem.WriteBytes("visualboyadvance-m.exe+039602E8," + (0xE06 + (11 * box.slctPkmNum)).ToString("X"), nnBytes);

                

            }
        }


        private async void Listen()
        {
            try
            {
                stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                string msg = Encoding.ASCII.GetString(buffer, 0, bytes);
                ReadSocket(msg);
            }
            catch (Exception e)
            {
                SocketTimer.Enabled = false;
                MessageBox.Show("Connection Lost: ");
                this.Close();
            }
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
                string slctPkm = "null";
                bool isReady = false;

                if (box != null)
                {
                    slctPkm = box.slctPkmText.Text;
                    isReady = box.readyCheckBox.Checked;
                }

                SendSocket("X" + mainXPos + ";" + mainYPos + ";" + mainMapID + ";" + mainSpriteImageIndex + ";" + mainIsOnCombat + ";" + mainIsOnGrass + ";" + mainBadgets +
                    ";" + mainMewtwo + ";" + mainArticuno + ";" + mainMoltres + ";" + mainZapdos + ";" + mFoughtGiovanni + ";" + mFoughtBrock + ";" + mFoughtMisty + ";" +
                    mFoughtSurge + ";" + mFoughtErika + ";" + mFoughtKoga + ";" + mFoughtBlaine + ";" + mFoughtSabrina + ";" + mFoughtFSnorlax + ";" + mFoughtSSnorlax + ";" + BitConverter.ToString(mPkdex) + "Y" + slctPkm + ";" + isReady);
            }



        }
    }
}
