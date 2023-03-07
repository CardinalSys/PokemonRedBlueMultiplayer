using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGBMP
{
    public partial class DebugForm : Form
    {
        MainForm main;
        public DebugForm(MainForm main)
        {
            InitializeComponent();
            this.main = main; 
        }

        private void updateInfoTimer_Tick(object sender, EventArgs e)
        {

            //Main Player
            mainPosText.Text = "Position: " + main.mXPos + ";" + main.mYPos;

            mainSpriteIndexText.Text = "Sprite index: " + main.mSpriteImageIndex;

            if(main.mIsOnGrass == 0)
                mainOnGrassText.Text = "Is on grass: False";
            else
                mainOnGrassText.Text = "Is on grass: True";

            mMapIDText.Text = "Current MapID: " + main.mMapID;

            if (main.mIsOnCombat == 0)
                mainOnCombatText.Text = "Is on combat: False";
            else
                mainOnCombatText.Text = "Is on combat: True";

            mainBadges.Text = "Badges: " + main.mBadgets;

            //Secondary Player
            sMapIdText.Text = "Current MapID: " + main.sMapId;

            sPosText.Text = "Position: " + main.sRelXPos + ";" + main.sRelYPos;

            sSpriteIndex.Text = "Sprite index: " + main.sSpriteImageIndex;

            if (main.sIsOnGrass == 0)
                secOnGrassText.Text = "Is on grass: False";
            else
                secOnGrassText.Text = "Is on grass: True";

            if (main.sIsOnCombat == 0)
                secOnCombatText.Text = "Is on combat: False";
            else
                secOnCombatText.Text = "Is on combat: True";


            secBadges.Text = "Badges: " + main.sBadgets;

            richTextBox1.Text = BitConverter.ToString(main.mPkdex);
            richTextBox2.Text = BitConverter.ToString(main.sPkdex);
        }
    }
}
