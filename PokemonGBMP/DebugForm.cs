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
            mainPosText.Text = "Position: " + main.mainXPos + ";" + main.mainYPos;

            mainSpriteIndexText.Text = "Sprite index: " + main.mainSpriteImageIndex;

            if(main.mainIsOnGrass == 0)
                mainOnGrassText.Text = "Is on grass: False";
            else
                mainOnGrassText.Text = "Is on grass: True";

            mainMapIdText.Text = "Current MapID: " + main.mainMapID;

            if (main.mainIsOnCombat == 0)
                mainOnCombatText.Text = "Is on combat: False";
            else
                mainOnCombatText.Text = "Is on combat: True";

            mainBadges.Text = "Badges: " + main.mainBadgets;

            //Secondary Player
            secondaryMapIdText.Text = "Current MapID: " + main.secondaryMapId;

            secondaryPosText.Text = "Position: " + main.secondaryRelXPos + ";" + main.secondaryRelYPos;

            secondarySpriteIndex.Text = "Sprite index: " + main.secondarySpriteImageIndex;

            if (main.secondaryIsOnGrass == 0)
                secOnGrassText.Text = "Is on grass: False";
            else
                secOnGrassText.Text = "Is on grass: True";

            if (main.secondaryIsOnCombat == 0)
                secOnCombatText.Text = "Is on combat: False";
            else
                secOnCombatText.Text = "Is on combat: True";


            secBadges.Text = "Badges: " + main.secondaryBadgets;
        }
    }
}
