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

        Box box;

        Mem mem = new Mem();

        //Player one (main)
            public int mainXPos, mainYPos;

        //Animation stuff
            public int mainSpriteImageIndex;

            public int mainIsOnGrass; //128 if is true, else 0
            public int mainMapID;
            public int mainBadgets;
            public int mainIsOnCombat;
            //Box
            public int[] mainPkmBox = new int[20];

        //Player two (Client)
            public int secondaryAbsXPos, secondaryAbsYPos;
            public int secondaryRelXPos, secondaryRelYPos;
            public int secondaryMapId;

            public int secondarySpriteImageIndex;


        public bool isConnected;

        public MainForm()
        {
            InitializeComponent();
            mem.OpenProcess("visualboyadvance-m.exe");
        }




        private void connectBtm_Click(object sender, EventArgs e)
        {
            startPannel.Hide();
            mainPanel.Show();
            userStateTxt.Text = "Client";
            Client();
        }


        private void hostBtm_Click(object sender, EventArgs e)
        {
            startPannel.Hide();
            isHost = true;
            mainPanel.Show();
            userStateTxt.Text = "Host";
            Host();
        }

        public void CalculateRelativePosition()
        {
            secondaryRelXPos = 0x40 + ((secondaryAbsXPos - mainXPos) * 0xF);
            secondaryRelYPos = 0x3C + ((secondaryAbsYPos - mainYPos) * 0xF);
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
            mainYPos = mem.ReadByte("visualboyadvance-m.exe+039602E8,361");
            mainXPos = mem.ReadByte("visualboyadvance-m.exe+039602E8,362");

            mainSpriteImageIndex = mem.ReadByte("visualboyadvance-m.exe+039602E0,102");

            mainIsOnGrass = mem.ReadByte("visualboyadvance-m.exe+039602E0,207");


            mainMapID = mem.ReadByte("visualboyadvance-m.exe+039602E8,35E");

            mainBadgets = mem.ReadByte("visualboyadvance-m.exe+039602E8,356");

            mainIsOnCombat = mem.ReadByte("visualboyadvance-m.exe+039602E8,57");
        }

        private void WriteSecondaryValues()
        {

            if(mainMapID == secondaryMapId)
            {
                //Spawn second player
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "1");
                //mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F2", "byte", "00");

                //if the second player is inside the main player camera, update his position, else hide it
                if(secondaryRelXPos >= 0 && secondaryRelXPos <= 140)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F6", "byte", secondaryRelXPos.ToString("X"));
                else
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");
                if (secondaryRelYPos >= 0 && secondaryRelYPos <= 120)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F4", "byte", secondaryRelYPos.ToString("X"));
                else
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");

                //Animation          
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F2", "byte", secondarySpriteImageIndex.ToString("X"));

            }
            else
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");

        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            ScanMainValues();
            WriteSecondaryValues();

        }

        private void combatBtm_Click(object sender, EventArgs e)
        {
 
        }



        private void TradeBtm_Click(object sender, EventArgs e)
        {
            box = new Box(this);
            box.Show();
        }



        private void debugBtm_Click(object sender, EventArgs e)
            {
                DebugForm debug = new DebugForm(this);
                debug.Show();
            }
        }
}
