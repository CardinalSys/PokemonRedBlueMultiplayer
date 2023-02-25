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


        private void PkmBtm_Click(object sender, EventArgs e)
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

            PkmBtm1.Text = pokemonList[main.mainPkmBox[0]].ToString();
            PkmBtm2.Text = pokemonList[main.mainPkmBox[1]].ToString();
            PkmBtm3.Text = pokemonList[main.mainPkmBox[2]].ToString();
            PkmBtm4.Text = pokemonList[main.mainPkmBox[3]].ToString();
            PkmBtm5.Text = pokemonList[main.mainPkmBox[4]].ToString();
            PkmBtm6.Text = pokemonList[main.mainPkmBox[5]].ToString();
            PkmBtm7.Text = pokemonList[main.mainPkmBox[6]].ToString();
            PkmBtm8.Text = pokemonList[main.mainPkmBox[7]].ToString();
            PkmBtm9.Text = pokemonList[main.mainPkmBox[8]].ToString();
            PkmBtm10.Text = pokemonList[main.mainPkmBox[9]].ToString();
            PkmBtm11.Text = pokemonList[main.mainPkmBox[10]].ToString();
            PkmBtm12.Text = pokemonList[main.mainPkmBox[11]].ToString();
            PkmBtm13.Text = pokemonList[main.mainPkmBox[12]].ToString();
            PkmBtm14.Text = pokemonList[main.mainPkmBox[13]].ToString();
            PkmBtm15.Text = pokemonList[main.mainPkmBox[14]].ToString();
            PkmBtm16.Text = pokemonList[main.mainPkmBox[15]].ToString();
            PkmBtm17.Text = pokemonList[main.mainPkmBox[16]].ToString();
            PkmBtm18.Text = pokemonList[main.mainPkmBox[17]].ToString();
            PkmBtm19.Text = pokemonList[main.mainPkmBox[18]].ToString();
            PkmBtm20.Text = pokemonList[main.mainPkmBox[19]].ToString();


            if(readyCheckBox.Checked && secReadCheckBox.Checked)
            {
                btnTrade.Enabled = true;
            }
            else
                btnTrade.Enabled = false;
        }

        private void readyCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            main.onTrade = true;
            byte[] pkmToChange = main.mem.ReadBytes("visualboyadvance-m.exe+039602E8," + (0xA96 + (33 * slctPkmNum)).ToString("X"), 33);
            main.SendSocket("T" + Convert.ToBase64String(pkmToChange));
            MessageBox.Show("Waiting for the other player");
        }

        private void Box_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.onTrade = false;
        }
    }
}
