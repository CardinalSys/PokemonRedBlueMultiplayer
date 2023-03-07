using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGBMP
{
    public partial class Box : Form
    {
        MainForm main;
        public int slctPkmNum;

        private List<string> pokemonList = new List<string>();
        public Box(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            StreamReader reader = new StreamReader("Pokemon.txt");
            pokemonList = reader.ReadToEnd().Split(',').ToList();

        }


        private void PkmBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            slctPkmText.Text = btn.Text;
            Match match = Regex.Match(btn.Name, @"\d+");
            if (match.Success)
            {
                slctPkmNum = int.Parse(match.Value) - 1;
            }
        }


        private void ScanBox_Tick(object sender, EventArgs e)
        {

            main.ScanMainBox();

            for (int i = 0; i < 20; i++)
            {
                Control[] pkmControls = this.Controls.Find("PkmBtn" + (i + 1).ToString(), true);
                if (pkmControls.Length > 0)
                {
                    pkmControls[0].Text = pokemonList[main.mPkmBox[i]].ToString();
                }
            }


            if (readyCheckBox.Checked && secReadCheckBox.Checked)
                btnTrade.Enabled = true;
            else
                btnTrade.Enabled = false;
        }

        private void readyCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void StartTrade()
        {
            if(!main.onTrade)
            {
                main.onTrade = true;
                byte[] pkmToChange = main.mem.ReadBytes("visualboyadvance-m.exe+039602E8," + (0xA96 + (33 * slctPkmNum)).ToString("X"), 33);
                byte[] nickNamePkmToChange = main.mem.ReadBytes("visualboyadvance-m.exe+039602E8," + (0xE06 + (11 * slctPkmNum)).ToString("X"), 11);
                main.SendSocket("T" + BitConverter.ToString(pkmToChange) + ";" + BitConverter.ToString(nickNamePkmToChange));
                MessageBox.Show("Trade complete");
                Close();
            }

        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            StartTrade();
        }

        private void Box_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.onTrade = false;
        }
    }
}
