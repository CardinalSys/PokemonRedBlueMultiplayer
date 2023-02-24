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
        private string mainDir;
        public DebugForm(MainForm main)
        {
            InitializeComponent();
            this.main = main; 
        }

        private void updateInfoTimer_Tick(object sender, EventArgs e)
        {
            mainPosText.Text = "Position: " + main.mainXPos + ";" + main.mainYPos;

            mainAnimationText.Text = "Animation index: " + main.mainSpriteImageIndex;

            if(main.mainIsOnGrass == 0)
                mainOnGrassText.Text = "Is on grass: False";
            else
                mainOnGrassText.Text = "Is on grass: True";

            mainMapIdText.Text = "Current MapID: " + main.mainMapID;


            if (main.mainIsOnCombat == 0)
                mainOnCombatText.Text = "Is on combat: False";
            else
                mainOnCombatText.Text = "Is on combat: True";

            secondaryPosText.Text = "Position: " + main.secondaryRelXPos + ";" + main.secondaryRelYPos;
        }
    }
}
