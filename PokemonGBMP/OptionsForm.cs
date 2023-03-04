﻿using System;
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
    public partial class OptionsForm : Form
    {
        MainForm main;
        public OptionsForm(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DebugForm debug = new DebugForm(main);
            debug.Show();
        }

        private void gameModeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(gameModeSelector.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("This cannot be change, are you sure you want to change the game mode?", "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    if (gameModeSelector.SelectedIndex == 0)
                        main.friendlyMode = true;
                    else
                        main.friendlyMode = false;

                    gameModeSelector.Enabled = false;
                }
                else
                {
                    gameModeSelector.SelectedItem = null;
                }
            }

        }
    }
}
