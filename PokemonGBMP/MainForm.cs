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

            //Friendly Mode flags (Giovanni, Brock, Misty, Lt Surge, Erika, Koga, Blaine, Sabrina, SS Anne, from D5A6 to D5C5
            public int mFoughtGiovanni;
            public int mFoughtBrock;
            public int mFoughtMisty;
            public int mFoughtSurge;
            public int mFoughtErika;
            public int mFoughtKoga;
            public int mFoughtBlaine;
            public int mFoughtSabrina;
            public int mFoughtFSnorlax;
            public int mFoughtSSnorlax;

            //pokedex
            public byte[] mPkdex = new byte[37];

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

            //Friendly Mode flags (Giovanni, Brock, Misty, Lt Surge, Erika, Koga, Blaine, Sabrina, SS Anne, from D5A6 to D5C5
            public int sFoughtGiovanni;
            public int sFoughtBrock;
            public int sFoughtMisty;
            public int sFoughtSurge;
            public int sFoughtErika;
            public int sFoughtKoga;
            public int sFoughtBlaine;
            public int sFoughtSabrina;
            public int sFoughtFSnorlax;
            public int sFoughtSSnorlax;

            //pokedex
            public byte[] sPkdex = new byte[37];

        public bool isConnected;
        public bool procHooked;
        public bool friendlyMode;
        public bool canChangeGameMode = true;
        public MainForm()
        {
            InitializeComponent();
            ipInputBox.Text = Properties.Settings.Default.Ip;
            friendlyMode = Properties.Settings.Default.friendlyMode;
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

        private void optionBtm_Click(object sender, EventArgs e)
        {
            OptionsForm options = new OptionsForm(this);
            options.Show();
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
            double progresoX = 0;
            double progresoY = 0;

            if (mainSpriteImageIndex >= 8 && mainSpriteImageIndex < 12)
            {
                if ((mainSpriteImageIndex % 2) == 0)
                    progresoX = 0;
                else
                    progresoX = -0.5f;
            }
            else if(mainSpriteImageIndex >= 12)
            {
                if ((mainSpriteImageIndex % 2) == 0)
                    progresoX = 0;
                else
                    progresoX = 0.5f;
            }
            if (mainSpriteImageIndex >= 0 && mainSpriteImageIndex < 4)
            {
                if ((mainSpriteImageIndex % 2) == 0)
                    progresoY = 0;
                else
                    progresoY = 0.5f;
            }
            else if(mainSpriteImageIndex >= 4 && mainSpriteImageIndex < 8)
            {
                if ((mainSpriteImageIndex % 2) == 0)
                    progresoY = 0;
                else
                    progresoY = -0.5f;
            }

            secondaryRelXPos = 0x40 + (int)(((secondaryAbsXPos - mainXPos) * 0x10) - (progresoX * 0x10));
            secondaryRelYPos = 0x3C + (int)(((secondaryAbsYPos - mainYPos) * 0x10) - (progresoY * 0x10));
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

        //Friendly mode: Badgets, Story Flags, MO
        private void FriendlyMode()
        {
            //Badgets
            if (mainBadgets < secondaryBadgets)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,356", "byte", secondaryBadgets.ToString("X"));
            if (mFoughtGiovanni < sFoughtGiovanni)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,751", "byte", sFoughtGiovanni.ToString("X"));
            if (mFoughtBrock < sFoughtBrock)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,755", "byte", sFoughtBrock.ToString("X"));
            if (mFoughtMisty < sFoughtMisty)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,773", "byte", sFoughtMisty.ToString("X"));
            if (mFoughtSurge < sFoughtSurge)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,77E", "byte", sFoughtSurge.ToString("X"));
            if (mFoughtErika < sFoughtErika)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,77C", "byte", sFoughtErika.ToString("X"));
            if (mFoughtKoga < sFoughtKoga)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,792", "byte", sFoughtKoga.ToString("X"));
            if (mFoughtBlaine < sFoughtBlaine)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,79A", "byte", sFoughtBlaine.ToString("X"));
            if (mFoughtSabrina < sFoughtSabrina)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,7B3", "byte", sFoughtSabrina.ToString("X"));
            if(mFoughtFSnorlax < sFoughtFSnorlax)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,7D8", "byte", sFoughtFSnorlax.ToString("X"));
            if (mFoughtSSnorlax < sFoughtSSnorlax)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,7E0", "byte", sFoughtSSnorlax.ToString("X"));

            mPkdex = mem.ReadBytes("visualboyadvance-m.exe+039602E8,30A", 37);
            //Pokedex
            for (int i = 0; i < mPkdex.Length; i++)
            {
                if(mPkdex[i] < sPkdex[i])
                {
                    mPkdex[i] = sPkdex[i];
                    mem.WriteMemory("visualboyadvance-m.exe+039602E,"+ (0x30A + i).ToString("X"), "byte", mPkdex[i].ToString("X"));
                }
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
            mainBadgets = mem.ReadByte("visualboyadvance-m.exe+039602E8,356");
            canChangeGameMode = mem.ReadByte("visualboyadvance-m.exe+039602E8,60D") == 0 && mainBadgets == 0;

            //Legendary flags
            mainMewtwo = mem.ReadByte("visualboyadvance-m.exe+039602E8,5C0");
            mainArticuno = mem.ReadByte("visualboyadvance-m.exe+039602E8,782");
            mainMoltres = mem.ReadByte("visualboyadvance-m.exe+039602E8,7EE");
            mainZapdos = mem.ReadByte("visualboyadvance-m.exe+039602E8,7D4");

            //Gym flags
            mFoughtGiovanni = mem.ReadByte("visualboyadvance-m.exe+039602E8,751");
            mFoughtBrock = mem.ReadByte("visualboyadvance-m.exe+039602E8,755");
            mFoughtMisty = mem.ReadByte("visualboyadvance-m.exe+039602E8,75E");
            mFoughtSurge = mem.ReadByte("visualboyadvance-m.exe+039602E8,773");
            mFoughtErika = mem.ReadByte("visualboyadvance-m.exe+039602E8,77C");
            mFoughtKoga = mem.ReadByte("visualboyadvance-m.exe+039602E8,792");
            mFoughtBlaine = mem.ReadByte("visualboyadvance-m.exe+039602E8,79A");
            mFoughtSabrina = mem.ReadByte("visualboyadvance-m.exe+039602E8,7B3");

            mFoughtFSnorlax = mem.ReadByte("visualboyadvance-m.exe+039602E8,7D8");
            mFoughtSSnorlax = mem.ReadByte("visualboyadvance-m.exe+039602E8,7E0");
        }   

        private void WriteValues()
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
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,2F7", "byte", secondaryIsOnGrass.ToString("X"));

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

            if (friendlyMode && !canChangeGameMode)
                FriendlyMode();

        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if(mem.OpenProcess("visualboyadvance-m.exe"))
            {
                procHooked = true;
                if(SocketTimer.Enabled)
                {
                    ScanMainValues();
                    WriteValues();
                }    
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
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.friendlyMode = friendlyMode;
            Properties.Settings.Default.Save();
        }
    }
}
