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
            public int mXPos, mYPos;

        //Animation stuff
            public int mSpriteImageIndex;

            public int mIsOnGrass; //128 if is true, else 0
            public int mMapID;
            public int mBadgets;
            public int mIsOnCombat;
            //Box
            public int[] mPkmBox = new int[20];

            //Flags
            public int mMewtwo, mArticuno, mMoltres, mZapdos;

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
            public int sAbsXPos, sAbsYPos;
            public int sRelXPos, sRelYPos;
            public int sMapId;

            public int sBadgets;
            public int sSpriteImageIndex;
            public int sIsOnCombat;
            public int sIsOnGrass;

            //Flags
            public int sMewtwo, sArticuno, sMoltres, sZapdos;

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

        Dictionary<int, Tuple<double, double>> progressMap = new Dictionary<int, Tuple<double, double>>()
        {
            { 0, Tuple.Create(0.0, 0.0) },
            { 1, Tuple.Create(0.5, 0.0) },
            { 2, Tuple.Create(0.0, 0.0) },
            { 3, Tuple.Create(0.0, 0.0) },
            { 4, Tuple.Create(0.0, 0.0) },
            { 5, Tuple.Create(-0.5, 0.0) },
            { 6, Tuple.Create(0.0, 0.0) },
            { 7, Tuple.Create(0.0, 0.0) },
            { 8, Tuple.Create(0.0, 0.0) },
            { 9, Tuple.Create(0.0, -0.5) },
            { 10, Tuple.Create(0.0, 0.0) },
            { 11, Tuple.Create(0.0, 0.0) },
            { 12, Tuple.Create(0.0, 0.0) },
            { 13, Tuple.Create(0.0, 0.5) },
            { 14, Tuple.Create(0.0, 0.0) },
            { 15, Tuple.Create(0.0, 0.0) }
        };

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

            if (progressMap.ContainsKey(mSpriteImageIndex))
            {
                Tuple<double, double> progressTuple = progressMap[mSpriteImageIndex];
                progresoY = progressTuple.Item1;
                progresoX = progressTuple.Item2;
            }

            sRelXPos = 0x40 + (int)(((sAbsXPos - mXPos) * 0x10) - (progresoX * 0x10));
            sRelYPos = 0x3C + (int)(((sAbsYPos - mYPos) * 0x10) - (progresoY * 0x10));
        }


        public void ScanMainBox()
        {
            for(int i = 0; i < mPkmBox.Length; i++)
            {
                mPkmBox[i] = mem.ReadByte("visualboyadvance-m.exe+039602E8," + (0xA81 + i).ToString("X"));
                if (mPkmBox[i] < 0 || mPkmBox[i] >= 255)
                    mPkmBox[i] = 0;
            }
        }

        //Friendly mode: Badgets, Story Flags, MO
        private void FriendlyMode()
        {
            //Badgets
            if (mBadgets < sBadgets)
                mem.WriteMemory("visualboyadvance-m.exe+039602E8,356", "byte", sBadgets.ToString("X"));
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
                    mem.WriteMemory("visualboyadvance-m.exe+039602E8," + (0x30A + i).ToString("X"), "byte", mPkdex[i].ToString("X"));
                }
            }

        }


        private void ScanMainValues()
        {
            //Movement
            mYPos = mem.ReadByte("visualboyadvance-m.exe+039602E8,361");
            mXPos = mem.ReadByte("visualboyadvance-m.exe+039602E8,362");
            mSpriteImageIndex = mem.ReadByte("visualboyadvance-m.exe+039602E0,102");
            mIsOnGrass = mem.ReadByte("visualboyadvance-m.exe+039602E0,207");
            mMapID = mem.ReadByte("visualboyadvance-m.exe+039602E8,35E");

            //Misc
            mIsOnCombat = mem.ReadByte("visualboyadvance-m.exe+039602E8,57");
            mBadgets = mem.ReadByte("visualboyadvance-m.exe+039602E8,356");
            canChangeGameMode = mem.ReadByte("visualboyadvance-m.exe+039602E8,60D") == 0 && mBadgets == 0;

            //Legendary flags
            mMewtwo = mem.ReadByte("visualboyadvance-m.exe+039602E8,5C0");
            mArticuno = mem.ReadByte("visualboyadvance-m.exe+039602E8,782");
            mMoltres = mem.ReadByte("visualboyadvance-m.exe+039602E8,7EE");
            mZapdos = mem.ReadByte("visualboyadvance-m.exe+039602E8,7D4");

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

            if(mMapID == sMapId && mIsOnCombat == 0)
            {
                //Spawn second player
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "1");

                //if the second player is inside the main player camera, update his position, else hide it
                if(sRelXPos >= 0 && sRelXPos <= 140)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F6", "byte", sRelXPos.ToString("X"));
                else
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");
                if (sRelYPos >= 0 && sRelYPos <= 120)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F4", "byte", sRelYPos.ToString("X"));
                else
                    mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");

                //Animation          
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F2", "byte", sSpriteImageIndex.ToString("X"));
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,2F7", "byte", sIsOnGrass.ToString("X"));

            }
            else
                mem.WriteMemory("visualboyadvance-m.exe+039602E0,1F0", "byte", "0");

            //WriteFlags
            if(!friendlyMode)
            {
                if (sMewtwo == 1)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E8,5C0", "byte", "1");
                if (sArticuno == 1)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E8,782", "byte", "1");
                if (sMoltres == 1)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E8,7EE", "byte", "1");
                if (sZapdos == 1)
                    mem.WriteMemory("visualboyadvance-m.exe+039602E8,7D4", "byte", "1");
            }


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
            if (mMapID == sMapId)
            {
                Combat combat = new Combat(this);
                combat.Show();
            }
            else
                MessageBox.Show("Your are not near to the other player");
        }



        private void TradeBtm_Click(object sender, EventArgs e)
        {
            if (mMapID == sMapId)
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
