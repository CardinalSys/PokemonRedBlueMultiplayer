
namespace PokemonGBMP
{
    partial class DebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.debugInfoLabel = new System.Windows.Forms.Label();
            this.playerOneInfo = new System.Windows.Forms.Label();
            this.mainPosText = new System.Windows.Forms.Label();
            this.updateInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.mainSpriteIndexText = new System.Windows.Forms.Label();
            this.mainOnGrassText = new System.Windows.Forms.Label();
            this.mMapIDText = new System.Windows.Forms.Label();
            this.mainOnCombatText = new System.Windows.Forms.Label();
            this.PlayerTwoLabel = new System.Windows.Forms.Label();
            this.sPosText = new System.Windows.Forms.Label();
            this.sMapIdText = new System.Windows.Forms.Label();
            this.sSpriteIndex = new System.Windows.Forms.Label();
            this.secOnGrassText = new System.Windows.Forms.Label();
            this.secOnCombatText = new System.Windows.Forms.Label();
            this.mainBadges = new System.Windows.Forms.Label();
            this.secBadges = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // debugInfoLabel
            // 
            this.debugInfoLabel.AutoSize = true;
            this.debugInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugInfoLabel.Location = new System.Drawing.Point(105, 26);
            this.debugInfoLabel.Name = "debugInfoLabel";
            this.debugInfoLabel.Size = new System.Drawing.Size(107, 25);
            this.debugInfoLabel.TabIndex = 0;
            this.debugInfoLabel.Text = "Debug Info";
            // 
            // playerOneInfo
            // 
            this.playerOneInfo.AutoSize = true;
            this.playerOneInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerOneInfo.Location = new System.Drawing.Point(13, 80);
            this.playerOneInfo.Name = "playerOneInfo";
            this.playerOneInfo.Size = new System.Drawing.Size(113, 20);
            this.playerOneInfo.TabIndex = 1;
            this.playerOneInfo.Text = "Player 1 (main)";
            // 
            // mainPosText
            // 
            this.mainPosText.AutoSize = true;
            this.mainPosText.Location = new System.Drawing.Point(14, 140);
            this.mainPosText.Name = "mainPosText";
            this.mainPosText.Size = new System.Drawing.Size(47, 13);
            this.mainPosText.TabIndex = 2;
            this.mainPosText.Text = "Position:";
            // 
            // updateInfoTimer
            // 
            this.updateInfoTimer.Enabled = true;
            this.updateInfoTimer.Tick += new System.EventHandler(this.updateInfoTimer_Tick);
            // 
            // mainSpriteIndexText
            // 
            this.mainSpriteIndexText.AutoSize = true;
            this.mainSpriteIndexText.Location = new System.Drawing.Point(14, 165);
            this.mainSpriteIndexText.Name = "mainSpriteIndexText";
            this.mainSpriteIndexText.Size = new System.Drawing.Size(69, 13);
            this.mainSpriteIndexText.TabIndex = 4;
            this.mainSpriteIndexText.Text = "Sprite Index: ";
            // 
            // mainOnGrassText
            // 
            this.mainOnGrassText.AutoSize = true;
            this.mainOnGrassText.Location = new System.Drawing.Point(14, 190);
            this.mainOnGrassText.Name = "mainOnGrassText";
            this.mainOnGrassText.Size = new System.Drawing.Size(57, 13);
            this.mainOnGrassText.TabIndex = 5;
            this.mainOnGrassText.Text = "On Grass: ";
            // 
            // mMapIDText
            // 
            this.mMapIDText.AutoSize = true;
            this.mMapIDText.Location = new System.Drawing.Point(14, 115);
            this.mMapIDText.Name = "mMapIDText";
            this.mMapIDText.Size = new System.Drawing.Size(82, 13);
            this.mMapIDText.TabIndex = 6;
            this.mMapIDText.Text = "Current MapID: ";
            // 
            // mainOnCombatText
            // 
            this.mainOnCombatText.AutoSize = true;
            this.mainOnCombatText.Location = new System.Drawing.Point(14, 215);
            this.mainOnCombatText.Name = "mainOnCombatText";
            this.mainOnCombatText.Size = new System.Drawing.Size(66, 13);
            this.mainOnCombatText.TabIndex = 7;
            this.mainOnCombatText.Text = "On Combat: ";
            // 
            // PlayerTwoLabel
            // 
            this.PlayerTwoLabel.AutoSize = true;
            this.PlayerTwoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTwoLabel.Location = new System.Drawing.Point(14, 265);
            this.PlayerTwoLabel.Name = "PlayerTwoLabel";
            this.PlayerTwoLabel.Size = new System.Drawing.Size(65, 20);
            this.PlayerTwoLabel.TabIndex = 8;
            this.PlayerTwoLabel.Text = "Player 2";
            // 
            // secondaryPosText
            // 
            this.sPosText.AutoSize = true;
            this.sPosText.Location = new System.Drawing.Point(14, 315);
            this.sPosText.Name = "sPosText";
            this.sPosText.Size = new System.Drawing.Size(47, 13);
            this.sPosText.TabIndex = 9;
            this.sPosText.Text = "Position:";
            // 
            // secondaryMapIdText
            // 
            this.sMapIdText.AutoSize = true;
            this.sMapIdText.Location = new System.Drawing.Point(14, 290);
            this.sMapIdText.Name = "sMapIdText";
            this.sMapIdText.Size = new System.Drawing.Size(82, 13);
            this.sMapIdText.TabIndex = 10;
            this.sMapIdText.Text = "Current MapID: ";
            // 
            // secondarySpriteIndex
            // 
            this.sSpriteIndex.AutoSize = true;
            this.sSpriteIndex.Location = new System.Drawing.Point(14, 340);
            this.sSpriteIndex.Name = "sSpriteIndex";
            this.sSpriteIndex.Size = new System.Drawing.Size(69, 13);
            this.sSpriteIndex.TabIndex = 11;
            this.sSpriteIndex.Text = "Sprite Index: ";
            // 
            // secOnGrassText
            // 
            this.secOnGrassText.AutoSize = true;
            this.secOnGrassText.Location = new System.Drawing.Point(15, 364);
            this.secOnGrassText.Name = "secOnGrassText";
            this.secOnGrassText.Size = new System.Drawing.Size(57, 13);
            this.secOnGrassText.TabIndex = 12;
            this.secOnGrassText.Text = "On Grass: ";
            // 
            // secOnCombatText
            // 
            this.secOnCombatText.AutoSize = true;
            this.secOnCombatText.Location = new System.Drawing.Point(14, 386);
            this.secOnCombatText.Name = "secOnCombatText";
            this.secOnCombatText.Size = new System.Drawing.Size(66, 13);
            this.secOnCombatText.TabIndex = 13;
            this.secOnCombatText.Text = "On Combat: ";
            // 
            // mainBadges
            // 
            this.mainBadges.AutoSize = true;
            this.mainBadges.Location = new System.Drawing.Point(14, 237);
            this.mainBadges.Name = "mainBadges";
            this.mainBadges.Size = new System.Drawing.Size(66, 13);
            this.mainBadges.TabIndex = 14;
            this.mainBadges.Text = "On Combat: ";
            // 
            // secBadges
            // 
            this.secBadges.AutoSize = true;
            this.secBadges.Location = new System.Drawing.Point(13, 408);
            this.secBadges.Name = "secBadges";
            this.secBadges.Size = new System.Drawing.Size(66, 13);
            this.secBadges.TabIndex = 15;
            this.secBadges.Text = "On Combat: ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(181, 112);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(181, 315);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(100, 96);
            this.richTextBox2.TabIndex = 17;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Pokedex";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Pokedex";
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.secBadges);
            this.Controls.Add(this.mainBadges);
            this.Controls.Add(this.secOnCombatText);
            this.Controls.Add(this.secOnGrassText);
            this.Controls.Add(this.sSpriteIndex);
            this.Controls.Add(this.sMapIdText);
            this.Controls.Add(this.mainPosText);
            this.Controls.Add(this.mainSpriteIndexText);
            this.Controls.Add(this.sPosText);
            this.Controls.Add(this.PlayerTwoLabel);
            this.Controls.Add(this.mainOnCombatText);
            this.Controls.Add(this.mMapIDText);
            this.Controls.Add(this.mainOnGrassText);
            this.Controls.Add(this.playerOneInfo);
            this.Controls.Add(this.debugInfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DebugForm";
            this.Text = "Debug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label debugInfoLabel;
        private System.Windows.Forms.Label playerOneInfo;
        private System.Windows.Forms.Label mainPosText;
        private System.Windows.Forms.Timer updateInfoTimer;
        private System.Windows.Forms.Label mainSpriteIndexText;
        private System.Windows.Forms.Label mainOnGrassText;
        private System.Windows.Forms.Label mMapIDText;
        private System.Windows.Forms.Label mainOnCombatText;
        private System.Windows.Forms.Label PlayerTwoLabel;
        private System.Windows.Forms.Label sPosText;
        private System.Windows.Forms.Label sMapIdText;
        private System.Windows.Forms.Label sSpriteIndex;
        private System.Windows.Forms.Label secOnGrassText;
        private System.Windows.Forms.Label secOnCombatText;
        private System.Windows.Forms.Label mainBadges;
        private System.Windows.Forms.Label secBadges;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}