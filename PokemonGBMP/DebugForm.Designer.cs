
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
            this.mainMapIdText = new System.Windows.Forms.Label();
            this.mainOnCombatText = new System.Windows.Forms.Label();
            this.PlayerTwoLabel = new System.Windows.Forms.Label();
            this.secondaryPosText = new System.Windows.Forms.Label();
            this.secondaryMapIdText = new System.Windows.Forms.Label();
            this.secondarySpriteIndex = new System.Windows.Forms.Label();
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
            // mainMapIdText
            // 
            this.mainMapIdText.AutoSize = true;
            this.mainMapIdText.Location = new System.Drawing.Point(14, 115);
            this.mainMapIdText.Name = "mainMapIdText";
            this.mainMapIdText.Size = new System.Drawing.Size(82, 13);
            this.mainMapIdText.TabIndex = 6;
            this.mainMapIdText.Text = "Current MapID: ";
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
            this.secondaryPosText.AutoSize = true;
            this.secondaryPosText.Location = new System.Drawing.Point(14, 315);
            this.secondaryPosText.Name = "secondaryPosText";
            this.secondaryPosText.Size = new System.Drawing.Size(47, 13);
            this.secondaryPosText.TabIndex = 9;
            this.secondaryPosText.Text = "Position:";
            // 
            // secondaryMapIdText
            // 
            this.secondaryMapIdText.AutoSize = true;
            this.secondaryMapIdText.Location = new System.Drawing.Point(14, 290);
            this.secondaryMapIdText.Name = "secondaryMapIdText";
            this.secondaryMapIdText.Size = new System.Drawing.Size(82, 13);
            this.secondaryMapIdText.TabIndex = 10;
            this.secondaryMapIdText.Text = "Current MapID: ";
            // 
            // secondarySpriteIndex
            // 
            this.secondarySpriteIndex.AutoSize = true;
            this.secondarySpriteIndex.Location = new System.Drawing.Point(14, 340);
            this.secondarySpriteIndex.Name = "secondarySpriteIndex";
            this.secondarySpriteIndex.Size = new System.Drawing.Size(69, 13);
            this.secondarySpriteIndex.TabIndex = 11;
            this.secondarySpriteIndex.Text = "Sprite Index: ";
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 450);
            this.Controls.Add(this.secondarySpriteIndex);
            this.Controls.Add(this.secondaryMapIdText);
            this.Controls.Add(this.mainPosText);
            this.Controls.Add(this.mainSpriteIndexText);
            this.Controls.Add(this.secondaryPosText);
            this.Controls.Add(this.PlayerTwoLabel);
            this.Controls.Add(this.mainOnCombatText);
            this.Controls.Add(this.mainMapIdText);
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
        private System.Windows.Forms.Label mainMapIdText;
        private System.Windows.Forms.Label mainOnCombatText;
        private System.Windows.Forms.Label PlayerTwoLabel;
        private System.Windows.Forms.Label secondaryPosText;
        private System.Windows.Forms.Label secondaryMapIdText;
        private System.Windows.Forms.Label secondarySpriteIndex;
    }
}