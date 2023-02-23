using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace PokemonGBMP
{
    public partial class MainForm : Form
    {

        bool isHost = false;

        Mem mem = new Mem();

        //Player one (main)
            public int mainXPos, mainYPos;
            public int mainFaceDir;
            //Animation stuff
            public int mainSpriteImageIndex;
            public int mainIntraAnimationFrameCounter;
            public int mainAnimationFrameCounter;
            public int mainIsOnGrass; //128 if is true, else 0
            public int mainMapID;
            public int mainBadgets;
            public int mainIsOnCombat;
            //Box
            public int[] mainPkmBox = new int[20];

        //Player two (Client)
            public int secondaryRelXPos, secondaryRelYPos;


        TcpListener host;
        TcpClient client;
        NetworkStream stream;
        private BackgroundWorker backgroundWorker;

        public bool isConnected;

        public MainForm()
        {
            InitializeComponent();
            mem.OpenProcess(27752); //27752 14328
        }

        public void BackGroundWorker()
        {
            // Inicializar el objeto BackgroundWorker
            backgroundWorker = new BackgroundWorker();
            if(isHost)
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
            while(stream == null)
                stream = client.GetStream();
            isConnected = true;
            Listen();
        }


        private void Listen()
        {
            while(true)
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


        private void connectBtm_Click(object sender, EventArgs e)
        {
            startPannel.Hide();
            mainPanel.Show();
            userStateTxt.Text = "Client";
            BackGroundWorker();
        }


        private void hostBtm_Click(object sender, EventArgs e)
        {
            startPannel.Hide();
            isHost = true;
            mainPanel.Show();
            userStateTxt.Text = "Host";
            BackGroundWorker();
        }


        public void ScanMainBox()
        {
            for(int i = 0; i < mainPkmBox.Length; i++)
            {
                mainPkmBox[i] = mem.ReadByte("visualboyadvance-m.exe+039602E8," + (0xA81 + i).ToString("X"));
                if (mainPkmBox[i] < 0 || mainPkmBox[i] >= 255)
                    mainPkmBox[i] = 0;
            }

        }


        private void ScanMainValues()
        {

            mainXPos = mem.ReadByte("visualboyadvance-m.exe+039602E8,362");
            mainYPos = mem.ReadByte("visualboyadvance-m.exe+039602E8,361");



            mainFaceDir = mem.ReadByte("visualboyadvance-m.exe+039602E0,109");

            mainSpriteImageIndex = mem.ReadByte("visualboyadvance-m.exe+039602E0,102");
            mainIntraAnimationFrameCounter = mem.ReadByte("visualboyadvance-m.exe+039602E0,108");
            mainAnimationFrameCounter = mem.ReadByte("visualboyadvance-m.exe+039602E0,107");

            mainIsOnGrass = mem.ReadByte("visualboyadvance-m.exe+039602E0,207");

            mainMapID = mem.ReadByte("visualboyadvance-m.exe+039602E8,35E");

            mainBadgets = mem.ReadByte("visualboyadvance-m.exe+039602E8,356");

            mainIsOnCombat = mem.ReadByte("visualboyadvance-m.exe+039602E8,57");
        }

        private void WriteSecondaryValues()
        {
            //mem.ReadByte("visualboyadvance-m.exe+039602E0,1F6");
            mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F6", "byte", secondaryRelXPos.ToString());
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            ScanMainValues();
            WriteSecondaryValues();

            if (isConnected)
            {
                SendSocket(mainXPos.ToString());
            }

        }

        private void combatBtm_Click(object sender, EventArgs e)
        {
 
        }

        private void TradeBtm_Click(object sender, EventArgs e)
        {
            Box box = new Box();
            box.Show();
        }

        private void SocketTimer_Tick(object sender, EventArgs e)
        {
            //if(!startPannel.Visible)
                //Listen();
        }

        private void debugBtm_Click(object sender, EventArgs e)
            {
                DebugForm debug = new DebugForm();
                debug.Show();
            }
        }
}
