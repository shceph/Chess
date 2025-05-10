namespace Chess
{
    partial class AcceptedRequestsForm
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
            listBoxAcceptedRequests = new ListBox();
            buttonEnterGame = new Button();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            enterTheGameToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxAcceptedRequests
            // 
            listBoxAcceptedRequests.FormattingEnabled = true;
            listBoxAcceptedRequests.Location = new Point(11, 80);
            listBoxAcceptedRequests.Name = "listBoxAcceptedRequests";
            listBoxAcceptedRequests.Size = new Size(414, 344);
            listBoxAcceptedRequests.TabIndex = 1;
            // 
            // buttonEnterGame
            // 
            buttonEnterGame.Location = new Point(268, 45);
            buttonEnterGame.Name = "buttonEnterGame";
            buttonEnterGame.Size = new Size(157, 29);
            buttonEnterGame.TabIndex = 2;
            buttonEnterGame.Text = "Enter the game";
            buttonEnterGame.UseVisualStyleBackColor = true;
            buttonEnterGame.Click += ButtonEnterGame_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, refreshToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(437, 28);
            menuStrip.TabIndex = 3;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enterTheGameToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // enterTheGameToolStripMenuItem
            // 
            enterTheGameToolStripMenuItem.Name = "enterTheGameToolStripMenuItem";
            enterTheGameToolStripMenuItem.Size = new Size(224, 26);
            enterTheGameToolStripMenuItem.Text = "Enter the game";
            enterTheGameToolStripMenuItem.Click += EnterTheGameToolStripMenuItem_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(72, 24);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += RefreshToolStripMenuItem_Click;
            // 
            // AcceptedRequestsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 436);
            Controls.Add(buttonEnterGame);
            Controls.Add(listBoxAcceptedRequests);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "AcceptedRequestsForm";
            Text = "Accepted requests";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxAcceptedRequests;
        private Button buttonEnterGame;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem enterTheGameToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
    }
}