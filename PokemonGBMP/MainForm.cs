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

        public bool isHost = false;
        public bool onTrade = false;

        Box box;

        public Mem mem = new Mem();

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

            //Flags
            public int mainMewtwo, mainArticuno, mainMoltres, mainZapdos;

        //Player two (Client)
            public int secondaryAbsXPos, secondaryAbsYPos;
            public int secondaryRelXPos, secondaryRelYPos;
            public int secondaryMapId;

            public int secondaryBadgets;
            public int secondarySpriteImageIndex;
            public int secondaryIsOnCombat;
            public int secondaryIsOnGrass;

            //Flags
            public int secondaryMewtwo, secondaryArticuno, secondaryMoltres, secondaryZapdos;

        public bool isConnected;
        public bool procHooked;

        public MainForm()
        {
            InitializeComponent();

        }




        private void connectBtm_Click(object sender, EventArgs e)
        {
            if (procHooked)
            {
                startPannel.Hide();
                mainPanel.Show();
                BackgroundImage = Properties.Resources.secondIMG;
                Client();
            }
            else
                MessageBox.Show("Open the game before start");
        }


        private void hostBtm_Click(object sender, EventArgs e)
        {
            if(procHooked)
            {
                startPannel.Hide();
                isHost = true;
                mainPanel.Show();
                BackgroundImage = Properties.Resources.secondIMG;
                Host();
            }
            else
                MessageBox.Show("Open the game before start");

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
            //Movement
            mainYPos = mem.ReadByte("visualboyadvance-m.exe+039602E8,361");
            mainXPos = mem.ReadByte("visualboyadvance-m.exe+039602E8,362");
            mainSpriteImageIndex = mem.ReadByte("visualboyadvance-m.exe+039602E0,102");
            mainIsOnGrass = mem.ReadByte("visualboyadvance-m.exe+039602E0,207");
            mainMapID = mem.ReadByte("visualboyadvance-m.exe+039602E8,35E");

            //Misc
            mainIsOnCombat = mem.ReadByte("visualboyadvance-m.exe+039602E8,57");

            //flags
            mainBadgets = mem.ReadByte("visualboyadvance-m.exe+039602E8,356");
            mainMewtwo = mem.ReadByte("visualboyadvance-m.exe+039602E8,5C0");
            mainArticuno = mem.ReadByte("visualboyadvance-m.exe+039602E8,782");
            mainMoltres = mem.ReadByte("visualboyadvance-m.exe+039602E8,7EE");
            mainZapdos = mem.ReadByte("visualboyadvance-m.exe+039602E8,7D4");
        }

        private void WriteSecondaryValues()
        {

            if(mainMapID == secondaryMapId && mainIsOnCombat == 0)
            {
                //Spawn second player
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "1");

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

            //WriteFlags
            if(mainMewtwo == 1)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,5C0" , "byte", "1");
            if (mainArticuno == 1)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,782", "byte", "1");
            if (mainMoltres == 1)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,7EE", "byte", "1");
            if (mainZapdos == 1)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,7D4", "byte", "1");

        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if(mem.OpenProcess("visualboyadvance-m.exe"))
            {
                procHooked = true;
                ScanMainValues();
                WriteSecondaryValues();
            }
            else
                procHooked = false;
        }

        private void combatBtm_Click(object sender, EventArgs e)
        {
            if (mainMapID == secondaryMapId)
            {
                Combat combat = new Combat(this);
                combat.Show();
            }
            else
                MessageBox.Show("Your are not near to the other player");
        }



        private void TradeBtm_Click(object sender, EventArgs e)
        {
            if (mainMapID == secondaryMapId)
            {
                box = new Box(this);
                box.Show();
            }
            else
                MessageBox.Show("Your are not near to the other player");
        }



        private void debugBtm_Click(object sender, EventArgs e)
            {
                DebugForm debug = new DebugForm(this);
                debug.Show();
            }
        }
}
