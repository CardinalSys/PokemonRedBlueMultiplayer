using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PokemonGBMP
{
    public partial class Combat : Form
    {

        MainForm main;
        string[] names = new string[6];
        string[] atks = new string[6];

        private List<string> pokemonList = new List<string>();
        private List<string> atkList = new List<string>();

        private int pkmInParty;
        public Combat(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            ExportTeamToText();
            MessageBox.Show("1-Login clicking on choose name. \n2-Go to TeamBuilder, create a new team and select Gen1 Ubers on format. \n3-Go to import from text and just paste a text with ctrol+v. \n4-Go back to home and select Find a user and put your friend username. \n5-Go to the top and select Ubers Gen 1, your team and click on challenge.");
        }

        private async void Test()
        {
            string playBtn = await webView.CoreWebView2.ExecuteScriptAsync("document.getElementById('play-online').querySelector('a').click()");

            await webView.ExecuteScriptAsync(playBtn);

        }

        private void ExportTeamToText()
        {
            pkmInParty = main.mem.ReadByte("visualboyadvance-m.exe+039602E8,163");
            StreamReader reader = new StreamReader("Pokemon.txt");
            pokemonList = reader.ReadToEnd().Split(',').ToList();
            reader = new StreamReader("atks.txt");
            atkList = reader.ReadToEnd().Split(',').ToList();
            for (int i = 0; i < pkmInParty; i++)
            {
                int pkm = main.mem.ReadByte("visualboyadvance-m.exe+039602E8," + (0x16B + (44 * i)).ToString("X"));

                int atk1 = Math.Max(0, main.mem.ReadByte("visualboyadvance-m.exe+039602E8," + (0x173 + (44 * i)).ToString("X")));
                int atk2 = Math.Max(0, main.mem.ReadByte("visualboyadvance-m.exe+039602E8," + (0x174 + (44 * i)).ToString("X")));
                int atk3 = Math.Max(0, main.mem.ReadByte("visualboyadvance-m.exe+039602E8," + (0x175 + (44 * i)).ToString("X")));
                int atk4 = Math.Max(0, main.mem.ReadByte("visualboyadvance-m.exe+039602E8," + (0x176 + (44 * i)).ToString("X")));

                names[i] = pokemonList[pkm];


                atks[i] = "- " + atkList[atk1] + "- " + atkList[atk2] + "- " + atkList[atk3] + "- " + atkList[atk4];

                richTextBox1.Text += names[i];
                richTextBox1.Text += "Ability: No Ability\n";
                richTextBox1.Text += atks[i] + "\n";
            }
;
            File.WriteAllText("Team.txt", richTextBox1.Text);
            Clipboard.SetText(richTextBox1.Text);
        }

        private void webView_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            Test();
        }

        private void Combat_Resize(object sender, EventArgs e)
        {
            webView.Size = this.Size;
        }
    }
}
