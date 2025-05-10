namespace Chess
{
    partial class OpeningForm
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
            buttonStart = new Button();
            buttonStartOnline = new Button();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            labelPassword = new Label();
            buttonLogIn = new Button();
            linkLabelNoAccount = new LinkLabel();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            startLocallyToolStripMenuItem = new ToolStripMenuItem();
            findOnlineGamesToolStripMenuItem = new ToolStripMenuItem();
            logInToolStripMenuItem = new ToolStripMenuItem();
            logOffToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Font = new Font("Segoe UI", 9F);
            buttonStart.Location = new Point(11, 48);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(497, 69);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start 1v1 locally";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += ButtonStart_Click;
            // 
            // buttonStartOnline
            // 
            buttonStartOnline.Font = new Font("Segoe UI", 9F);
            buttonStartOnline.Location = new Point(11, 123);
            buttonStartOnline.Name = "buttonStartOnline";
            buttonStartOnline.Size = new Size(497, 69);
            buttonStartOnline.TabIndex = 0;
            buttonStartOnline.Text = "Find an online game";
            buttonStartOnline.UseVisualStyleBackColor = true;
            buttonStartOnline.Click += ButtonStartOnline_Click;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 9F);
            labelUsername.Location = new Point(11, 236);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(149, 20);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Insert your username:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Segoe UI", 9F);
            textBoxUsername.Location = new Point(11, 273);
            textBoxUsername.MaxLength = 20;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(237, 27);
            textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 9F);
            textBoxPassword.Location = new Point(272, 273);
            textBoxPassword.MaxLength = 20;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(237, 27);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9F);
            labelPassword.Location = new Point(272, 236);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(148, 20);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Insert your password:";
            // 
            // buttonLogIn
            // 
            buttonLogIn.Font = new Font("Segoe UI", 9F);
            buttonLogIn.Location = new Point(199, 335);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(127, 37);
            buttonLogIn.TabIndex = 5;
            buttonLogIn.Text = "Log in";
            buttonLogIn.UseVisualStyleBackColor = true;
            buttonLogIn.Click += ButtonLogIn_Click;
            // 
            // linkLabelNoAccount
            // 
            linkLabelNoAccount.AutoSize = true;
            linkLabelNoAccount.Location = new Point(11, 397);
            linkLabelNoAccount.Name = "linkLabelNoAccount";
            linkLabelNoAccount.Size = new Size(350, 20);
            linkLabelNoAccount.TabIndex = 6;
            linkLabelNoAccount.TabStop = true;
            linkLabelNoAccount.Text = "Don't have an account? Create one by clicking here!";
            linkLabelNoAccount.LinkClicked += LinkLabelNoAccount_LinkClicked;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(6, 3, 0, 3);
            menuStrip.Size = new Size(521, 30);
            menuStrip.TabIndex = 7;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { startLocallyToolStripMenuItem, findOnlineGamesToolStripMenuItem, logInToolStripMenuItem, logOffToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // startLocallyToolStripMenuItem
            // 
            startLocallyToolStripMenuItem.Name = "startLocallyToolStripMenuItem";
            startLocallyToolStripMenuItem.Size = new Size(213, 26);
            startLocallyToolStripMenuItem.Text = "Start locally";
            startLocallyToolStripMenuItem.Click += StartLocallyToolStripMenuItem_Click;
            // 
            // findOnlineGamesToolStripMenuItem
            // 
            findOnlineGamesToolStripMenuItem.Name = "findOnlineGamesToolStripMenuItem";
            findOnlineGamesToolStripMenuItem.Size = new Size(213, 26);
            findOnlineGamesToolStripMenuItem.Text = "Find online games";
            findOnlineGamesToolStripMenuItem.Click += FindOnlineGamesToolStripMenuItem_Click;
            // 
            // logInToolStripMenuItem
            // 
            logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            logInToolStripMenuItem.Size = new Size(213, 26);
            logInToolStripMenuItem.Text = "Log in";
            logInToolStripMenuItem.Click += LogInToolStripMenuItem_Click;
            // 
            // logOffToolStripMenuItem
            // 
            logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            logOffToolStripMenuItem.Size = new Size(213, 26);
            logOffToolStripMenuItem.Text = "Log off";
            logOffToolStripMenuItem.Click += LogOffToolStripMenuItem_Click;
            // 
            // OpeningForm
            // 
            AcceptButton = buttonLogIn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 431);
            Controls.Add(linkLabelNoAccount);
            Controls.Add(buttonLogIn);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(labelUsername);
            Controls.Add(buttonStartOnline);
            Controls.Add(buttonStart);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "OpeningForm";
            Text = "Chess";
            Activated += OpeningForm_Activated;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private Button buttonStartOnline;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label labelPassword;
        private Button buttonLogIn;
        private LinkLabel linkLabelNoAccount;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem logOffToolStripMenuItem;
        private ToolStripMenuItem startLocallyToolStripMenuItem;
        private ToolStripMenuItem findOnlineGamesToolStripMenuItem;
        private ToolStripMenuItem logInToolStripMenuItem;
    }
}