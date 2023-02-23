
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
            this.mainFaceDirText = new System.Windows.Forms.Label();
            this.mainAnimationText = new System.Windows.Forms.Label();
            this.mainOnGrassText = new System.Windows.Forms.Label();
            this.mainMapIdText = new System.Windows.Forms.Label();
            this.mainOnCombatText = new System.Windows.Forms.Label();
            this.PlayerTwoLabel = new System.Windows.Forms.Label();
            this.secondaryPosText = new System.Windows.Forms.Label();
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
            this.playerOneInfo.Location = new System.Drawing.Point(13, 79);
            this.playerOneInfo.Name = "playerOneInfo";
            this.playerOneInfo.Size = new System.Drawing.Size(113, 20);
            this.playerOneInfo.TabIndex = 1;
            this.playerOneInfo.Text = "Player 1 (main)";
            // 
            // mainPosText
            // 
            this.mainPosText.AutoSize = true;
            this.mainPosText.Location = new System.Drawing.Point(16, 119);
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
            // mainFaceDirText
            // 
            this.mainFaceDirText.AutoSize = true;
            this.mainFaceDirText.Location = new System.Drawing.Point(14, 143);
            this.mainFaceDirText.Name = "mainFaceDirText";
            this.mainFaceDirText.Size = new System.Drawing.Size(82, 13);
            this.mainFaceDirText.TabIndex = 3;
            this.mainFaceDirText.Text = "Face Direction: ";
            // 
            // mainAnimationText
            // 
            this.mainAnimationText.AutoSize = true;
            this.mainAnimationText.Location = new System.Drawing.Point(14, 166);
            this.mainAnimationText.Name = "mainAnimationText";
            this.mainAnimationText.Size = new System.Drawing.Size(112, 13);
            this.mainAnimationText.TabIndex = 4;
            this.mainAnimationText.Text = "Odd Animation Stuffs: ";
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
            this.mainMapIdText.Location = new System.Drawing.Point(14, 213);
            this.mainMapIdText.Name = "mainMapIdText";
            this.mainMapIdText.Size = new System.Drawing.Size(82, 13);
            this.mainMapIdText.TabIndex = 6;
            this.mainMapIdText.Text = "Current MapID: ";
            // 
            // mainOnCombatText
            // 
            this.mainOnCombatText.AutoSize = true;
            this.mainOnCombatText.Location = new System.Drawing.Point(14, 236);
            this.mainOnCombatText.Name = "mainOnCombatText";
            this.mainOnCombatText.Size = new System.Drawing.Size(66, 13);
            this.mainOnCombatText.TabIndex = 7;
            this.mainOnCombatText.Text = "On Combat: ";
            // 
            // PlayerTwoLabel
            // 
            this.PlayerTwoLabel.AutoSize = true;
            this.PlayerTwoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTwoLabel.Location = new System.Drawing.Point(15, 268);
            this.PlayerTwoLabel.Name = "PlayerTwoLabel";
            this.PlayerTwoLabel.Size = new System.Drawing.Size(65, 20);
            this.PlayerTwoLabel.TabIndex = 8;
            this.PlayerTwoLabel.Text = "Player 2";
            // 
            // secondaryPosText
            // 
            this.secondaryPosText.AutoSize = true;
            this.secondaryPosText.Location = new System.Drawing.Point(16, 300);
            this.secondaryPosText.Name = "secondaryPosText";
            this.secondaryPosText.Size = new System.Drawing.Size(47, 13);
            this.secondaryPosText.TabIndex = 9;
            this.secondaryPosText.Text = "Position:";
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 450);
            this.Controls.Add(this.secondaryPosText);
            this.Controls.Add(this.PlayerTwoLabel);
            this.Controls.Add(this.mainOnCombatText);
            this.Controls.Add(this.mainMapIdText);
            this.Controls.Add(this.mainOnGrassText);
            this.Controls.Add(this.mainAnimationText);
            this.Controls.Add(this.mainFaceDirText);
            this.Controls.Add(this.mainPosText);
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
        private System.Windows.Forms.Label mainFaceDirText;
        private System.Windows.Forms.Label mainAnimationText;
        private System.Windows.Forms.Label mainOnGrassText;
        private System.Windows.Forms.Label mainMapIdText;
        private System.Windows.Forms.Label mainOnCombatText;
        private System.Windows.Forms.Label PlayerTwoLabel;
        private System.Windows.Forms.Label secondaryPosText;
    }
}