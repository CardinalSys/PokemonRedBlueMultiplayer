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
            public int mainMovementStatus;
            public int mainSpriteImageIndex;
            public int mainIntraAnimationFrameCounter;
            public int mainAnimationFrameCounter;
            public int mainWalkAnimationCounter;

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

            public int secondaryMovementStatus;
            public int secondarySpriteImageIndex;
            public int secondaryIntraAnimationFrameCounter;
            public int secondaryAnimationFrameCounter;


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
            secondaryRelXPos = 40 + ((secondaryAbsXPos - mainXPos) * 10);
            secondaryRelYPos = 40 + ((secondaryAbsYPos - mainYPos) * 10);
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

            mainMovementStatus = mem.ReadByte("visualboyadvance-m.exe+039602E0,101");
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

            if(mainMapID == secondaryMapId)
            {
                //Spawn second player
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "1");
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F2", "byte", "00");

                //if the second player is inside the main player camera, update his position, else hide it
                if(secondaryRelXPos >= 0 && secondaryRelXPos <= 0x60)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F6", "byte", secondaryRelXPos.ToString());
                else
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");
                if (secondaryRelYPos >= 0 && secondaryRelYPos <= 0x60)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F4", "byte", secondaryRelYPos.ToString());
                else
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");

                //Animation stuffs
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,101", "byte", mainMovementStatus.ToString());
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F7", "byte", secondaryIntraAnimationFrameCounter.ToString());
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F8", "byte", secondaryAnimationFrameCounter.ToString());
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F2", "byte", secondarySpriteImageIndex.ToString());

            }
            else
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");

        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            ScanMainValues();
            WriteSecondaryValues();

            label1.Text = secondaryRelXPos.ToString();
        }

        private void combatBtm_Click(object sender, EventArgs e)
        {
 
        }



        private void TradeBtm_Click(object sender, EventArgs e)
        {
            Box box = new Box();
            box.Show();
        }



        private void debugBtm_Click(object sender, EventArgs e)
            {
                DebugForm debug = new DebugForm(this);
                debug.Show();
            }
        }
}
