
namespace PokemonGBMP
{
    partial class MainForm
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
            this.connectBtm = new System.Windows.Forms.Button();
            this.hostBtm = new System.Windows.Forms.Button();
            this.startPannel = new System.Windows.Forms.Panel();
            this.ipInputBox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.optionBtm = new System.Windows.Forms.Button();
            this.mapBtm = new System.Windows.Forms.Button();
            this.TradeBtm = new System.Windows.Forms.Button();
            this.combatBtm = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.SocketTimer = new System.Windows.Forms.Timer(this.components);
            this.startPannel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectBtm
            // 
            this.connectBtm.FlatAppearance.BorderSize = 0;
            this.connectBtm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.connectBtm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.connectBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectBtm.Location = new System.Drawing.Point(198, 15);
            this.connectBtm.Name = "connectBtm";
            this.connectBtm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.connectBtm.Size = new System.Drawing.Size(140, 80);
            this.connectBtm.TabIndex = 0;
            this.connectBtm.UseVisualStyleBackColor = true;
            this.connectBtm.Click += new System.EventHandler(this.connectBtm_Click);
            // 
            // hostBtm
            // 
            this.hostBtm.FlatAppearance.BorderSize = 0;
            this.hostBtm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.hostBtm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.hostBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hostBtm.ForeColor = System.Drawing.Color.Transparent;
            this.hostBtm.Location = new System.Drawing.Point(25, 15);
            this.hostBtm.Name = "hostBtm";
            this.hostBtm.Size = new System.Drawing.Size(158, 80);
            this.hostBtm.TabIndex = 1;
            this.hostBtm.UseVisualStyleBackColor = true;
            this.hostBtm.Click += new System.EventHandler(this.hostBtm_Click);
            // 
            // startPannel
            // 
            this.startPannel.BackColor = System.Drawing.Color.Transparent;
            this.startPannel.Controls.Add(this.ipInputBox);
            this.startPannel.Controls.Add(this.hostBtm);
            this.startPannel.Controls.Add(this.connectBtm);
            this.startPannel.Location = new System.Drawing.Point(32, 56);
            this.startPannel.Name = "startPannel";
            this.startPannel.Size = new System.Drawing.Size(381, 299);
            this.startPannel.TabIndex = 5;
            // 
            // ipInputBox
            // 
            this.ipInputBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.ipInputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipInputBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ipInputBox.Location = new System.Drawing.Point(143, 177);
            this.ipInputBox.Name = "ipInputBox";
            this.ipInputBox.Size = new System.Drawing.Size(100, 20);
            this.ipInputBox.TabIndex = 11;
            this.ipInputBox.Text = "127.0.0.1";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.optionBtm);
            this.mainPanel.Controls.Add(this.mapBtm);
            this.mainPanel.Controls.Add(this.TradeBtm);
            this.mainPanel.Controls.Add(this.combatBtm);
            this.mainPanel.Location = new System.Drawing.Point(32, 21);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(387, 345);
            this.mainPanel.TabIndex = 6;
            this.mainPanel.Visible = false;
            // 
            // optionBtm
            // 
            this.optionBtm.FlatAppearance.BorderSize = 0;
            this.optionBtm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.optionBtm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.optionBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionBtm.ForeColor = System.Drawing.Color.Transparent;
            this.optionBtm.Location = new System.Drawing.Point(316, 308);
            this.optionBtm.Name = "optionBtm";
            this.optionBtm.Size = new System.Drawing.Size(71, 37);
            this.optionBtm.TabIndex = 10;
            this.optionBtm.Text = "+";
            this.optionBtm.UseVisualStyleBackColor = true;
            this.optionBtm.Click += new System.EventHandler(this.optionBtm_Click);
            // 
            // mapBtm
            // 
            this.mapBtm.FlatAppearance.BorderSize = 0;
            this.mapBtm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mapBtm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mapBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mapBtm.ForeColor = System.Drawing.Color.Transparent;
            this.mapBtm.Location = new System.Drawing.Point(102, 155);
            this.mapBtm.Name = "mapBtm";
            this.mapBtm.Size = new System.Drawing.Size(171, 59);
            this.mapBtm.TabIndex = 9;
            this.mapBtm.UseVisualStyleBackColor = true;
            // 
            // TradeBtm
            // 
            this.TradeBtm.FlatAppearance.BorderSize = 0;
            this.TradeBtm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TradeBtm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TradeBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TradeBtm.ForeColor = System.Drawing.Color.Transparent;
            this.TradeBtm.Location = new System.Drawing.Point(198, 49);
            this.TradeBtm.Name = "TradeBtm";
            this.TradeBtm.Size = new System.Drawing.Size(142, 77);
            this.TradeBtm.TabIndex = 8;
            this.TradeBtm.UseVisualStyleBackColor = true;
            this.TradeBtm.Click += new System.EventHandler(this.TradeBtm_Click);
            // 
            // combatBtm
            // 
            this.combatBtm.FlatAppearance.BorderSize = 0;
            this.combatBtm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.combatBtm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.combatBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combatBtm.ForeColor = System.Drawing.Color.Transparent;
            this.combatBtm.Location = new System.Drawing.Point(44, 49);
            this.combatBtm.Name = "combatBtm";
            this.combatBtm.Size = new System.Drawing.Size(130, 77);
            this.combatBtm.TabIndex = 7;
            this.combatBtm.UseVisualStyleBackColor = true;
            this.combatBtm.Click += new System.EventHandler(this.combatBtm_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 1;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // SocketTimer
            // 
            this.SocketTimer.Tick += new System.EventHandler(this.SocketTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PokemonGBMP.Properties.Resources.firstIMG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(438, 378);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.startPannel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.startPannel.ResumeLayout(false);
            this.startPannel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connectBtm;
        private System.Windows.Forms.Button hostBtm;
        private System.Windows.Forms.Panel startPannel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button mapBtm;
        private System.Windows.Forms.Button TradeBtm;
        private System.Windows.Forms.Button combatBtm;
        private System.Windows.Forms.Button optionBtm;
        private System.Windows.Forms.Timer SocketTimer;
        private System.Windows.Forms.TextBox ipInputBox;
    }
}

