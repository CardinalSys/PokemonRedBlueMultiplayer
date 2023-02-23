
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serverIpLabel = new System.Windows.Forms.Label();
            this.startPannel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.debugBtm = new System.Windows.Forms.Button();
            this.mapBtm = new System.Windows.Forms.Button();
            this.TradeBtm = new System.Windows.Forms.Button();
            this.combatBtm = new System.Windows.Forms.Button();
            this.userStateTxt = new System.Windows.Forms.Label();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.SocketTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.startPannel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectBtm
            // 
            this.connectBtm.Location = new System.Drawing.Point(61, 240);
            this.connectBtm.Name = "connectBtm";
            this.connectBtm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.connectBtm.Size = new System.Drawing.Size(108, 46);
            this.connectBtm.TabIndex = 0;
            this.connectBtm.Text = "Connect";
            this.connectBtm.UseVisualStyleBackColor = true;
            this.connectBtm.Click += new System.EventHandler(this.connectBtm_Click);
            // 
            // hostBtm
            // 
            this.hostBtm.Location = new System.Drawing.Point(61, 23);
            this.hostBtm.Name = "hostBtm";
            this.hostBtm.Size = new System.Drawing.Size(108, 43);
            this.hostBtm.TabIndex = 1;
            this.hostBtm.Text = "Host";
            this.hostBtm.UseVisualStyleBackColor = true;
            this.hostBtm.Click += new System.EventHandler(this.hostBtm_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(61, 197);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverIpLabel
            // 
            this.serverIpLabel.AutoSize = true;
            this.serverIpLabel.Location = new System.Drawing.Point(91, 181);
            this.serverIpLabel.Name = "serverIpLabel";
            this.serverIpLabel.Size = new System.Drawing.Size(54, 13);
            this.serverIpLabel.TabIndex = 4;
            this.serverIpLabel.Text = "Server IP:";
            // 
            // startPannel
            // 
            this.startPannel.Controls.Add(this.hostBtm);
            this.startPannel.Controls.Add(this.textBox1);
            this.startPannel.Controls.Add(this.serverIpLabel);
            this.startPannel.Controls.Add(this.connectBtm);
            this.startPannel.Location = new System.Drawing.Point(89, 56);
            this.startPannel.Name = "startPannel";
            this.startPannel.Size = new System.Drawing.Size(248, 299);
            this.startPannel.TabIndex = 5;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.debugBtm);
            this.mainPanel.Controls.Add(this.mapBtm);
            this.mainPanel.Controls.Add(this.TradeBtm);
            this.mainPanel.Controls.Add(this.combatBtm);
            this.mainPanel.Controls.Add(this.userStateTxt);
            this.mainPanel.Location = new System.Drawing.Point(60, 43);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(294, 299);
            this.mainPanel.TabIndex = 6;
            this.mainPanel.Visible = false;
            // 
            // debugBtm
            // 
            this.debugBtm.Location = new System.Drawing.Point(252, 266);
            this.debugBtm.Name = "debugBtm";
            this.debugBtm.Size = new System.Drawing.Size(25, 23);
            this.debugBtm.TabIndex = 10;
            this.debugBtm.Text = "+";
            this.debugBtm.UseVisualStyleBackColor = true;
            this.debugBtm.Click += new System.EventHandler(this.debugBtm_Click);
            // 
            // mapBtm
            // 
            this.mapBtm.Location = new System.Drawing.Point(96, 258);
            this.mapBtm.Name = "mapBtm";
            this.mapBtm.Size = new System.Drawing.Size(108, 38);
            this.mapBtm.TabIndex = 9;
            this.mapBtm.Text = "Map";
            this.mapBtm.UseVisualStyleBackColor = true;
            // 
            // TradeBtm
            // 
            this.TradeBtm.Location = new System.Drawing.Point(96, 185);
            this.TradeBtm.Name = "TradeBtm";
            this.TradeBtm.Size = new System.Drawing.Size(108, 42);
            this.TradeBtm.TabIndex = 8;
            this.TradeBtm.Text = "Trade";
            this.TradeBtm.UseVisualStyleBackColor = true;
            this.TradeBtm.Click += new System.EventHandler(this.TradeBtm_Click);
            // 
            // combatBtm
            // 
            this.combatBtm.Location = new System.Drawing.Point(96, 103);
            this.combatBtm.Name = "combatBtm";
            this.combatBtm.Size = new System.Drawing.Size(108, 42);
            this.combatBtm.TabIndex = 7;
            this.combatBtm.Text = "Combat";
            this.combatBtm.UseVisualStyleBackColor = true;
            this.combatBtm.Click += new System.EventHandler(this.combatBtm_Click);
            // 
            // userStateTxt
            // 
            this.userStateTxt.AutoSize = true;
            this.userStateTxt.Location = new System.Drawing.Point(127, 23);
            this.userStateTxt.Name = "userStateTxt";
            this.userStateTxt.Size = new System.Drawing.Size(35, 13);
            this.userStateTxt.TabIndex = 7;
            this.userStateTxt.Text = "label2";
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // SocketTimer
            // 
            this.SocketTimer.Tick += new System.EventHandler(this.SocketTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 378);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.startPannel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.startPannel.ResumeLayout(false);
            this.startPannel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectBtm;
        private System.Windows.Forms.Button hostBtm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label serverIpLabel;
        private System.Windows.Forms.Panel startPannel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label userStateTxt;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button mapBtm;
        private System.Windows.Forms.Button TradeBtm;
        private System.Windows.Forms.Button combatBtm;
        private System.Windows.Forms.Button debugBtm;
        private System.Windows.Forms.Timer SocketTimer;
        private System.Windows.Forms.Label label1;
    }
}

