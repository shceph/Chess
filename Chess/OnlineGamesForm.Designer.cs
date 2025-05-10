namespace Chess
{
    partial class OnlineGamesForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            timerUpdateGamesTable = new System.Windows.Forms.Timer(components);
            dataGridViewGames = new DataGridView();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            hostAGameToolStripMenuItem = new ToolStripMenuItem();
            joinToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            buttonHost = new Button();
            buttonJoin = new Button();
            labelGameCount = new Label();
            buttonCheckRequests = new Button();
            buttonAcceptedRequests = new Button();
            checkReToolStripMenuItem = new ToolStripMenuItem();
            checkAcceptedRequestsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGames).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // timerUpdateGamesTable
            // 
            timerUpdateGamesTable.Enabled = true;
            timerUpdateGamesTable.Interval = 5000;
            // 
            // dataGridViewGames
            // 
            dataGridViewGames.AllowUserToAddRows = false;
            dataGridViewGames.AllowUserToDeleteRows = false;
            dataGridViewGames.AllowUserToResizeColumns = false;
            dataGridViewGames.AllowUserToResizeRows = false;
            dataGridViewGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 8.4F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewGames.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewGames.Location = new Point(12, 76);
            dataGridViewGames.MultiSelect = false;
            dataGridViewGames.Name = "dataGridViewGames";
            dataGridViewGames.ReadOnly = true;
            dataGridViewGames.RowHeadersVisible = false;
            dataGridViewGames.RowHeadersWidth = 51;
            dataGridViewGames.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewGames.RowTemplate.Height = 23;
            dataGridViewGames.RowTemplate.ReadOnly = true;
            dataGridViewGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGames.Size = new Size(914, 415);
            dataGridViewGames.TabIndex = 1;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, refreshToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(6, 3, 0, 3);
            menuStrip.Size = new Size(938, 30);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hostAGameToolStripMenuItem, joinToolStripMenuItem, checkReToolStripMenuItem, checkAcceptedRequestsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // hostAGameToolStripMenuItem
            // 
            hostAGameToolStripMenuItem.Name = "hostAGameToolStripMenuItem";
            hostAGameToolStripMenuItem.Size = new Size(224, 26);
            hostAGameToolStripMenuItem.Text = "Host";
            hostAGameToolStripMenuItem.Click += HostToolStripMenuItem_Click;
            // 
            // joinToolStripMenuItem
            // 
            joinToolStripMenuItem.Name = "joinToolStripMenuItem";
            joinToolStripMenuItem.Size = new Size(224, 26);
            joinToolStripMenuItem.Text = "Join";
            joinToolStripMenuItem.Click += JoinToolStripMenuItem_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(72, 24);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += RefreshToolStripMenuItem_Click;
            // 
            // buttonHost
            // 
            buttonHost.Location = new Point(457, 41);
            buttonHost.Name = "buttonHost";
            buttonHost.Size = new Size(94, 29);
            buttonHost.TabIndex = 3;
            buttonHost.Text = "Host";
            buttonHost.UseVisualStyleBackColor = true;
            buttonHost.Click += ButtonHost_Click;
            // 
            // buttonJoin
            // 
            buttonJoin.Location = new Point(357, 41);
            buttonJoin.Name = "buttonJoin";
            buttonJoin.Size = new Size(94, 29);
            buttonJoin.TabIndex = 3;
            buttonJoin.Text = "Join";
            buttonJoin.UseVisualStyleBackColor = true;
            buttonJoin.Click += ButtonJoin_Click;
            // 
            // labelGameCount
            // 
            labelGameCount.AutoSize = true;
            labelGameCount.Location = new Point(12, 44);
            labelGameCount.Name = "labelGameCount";
            labelGameCount.Size = new Size(104, 20);
            labelGameCount.TabIndex = 4;
            labelGameCount.Text = "Game count: 0";
            // 
            // buttonCheckRequests
            // 
            buttonCheckRequests.Location = new Point(557, 41);
            buttonCheckRequests.Name = "buttonCheckRequests";
            buttonCheckRequests.Size = new Size(165, 29);
            buttonCheckRequests.TabIndex = 3;
            buttonCheckRequests.Text = "Check requests";
            buttonCheckRequests.UseVisualStyleBackColor = true;
            buttonCheckRequests.Click += ButtonCheckRequests_Click;
            // 
            // buttonAcceptedRequests
            // 
            buttonAcceptedRequests.Location = new Point(728, 41);
            buttonAcceptedRequests.Name = "buttonAcceptedRequests";
            buttonAcceptedRequests.Size = new Size(198, 29);
            buttonAcceptedRequests.TabIndex = 5;
            buttonAcceptedRequests.Text = "Check accepted requests";
            buttonAcceptedRequests.UseVisualStyleBackColor = true;
            buttonAcceptedRequests.Click += ButtonAcceptedRequests_Click;
            // 
            // checkReToolStripMenuItem
            // 
            checkReToolStripMenuItem.Name = "checkReToolStripMenuItem";
            checkReToolStripMenuItem.Size = new Size(255, 26);
            checkReToolStripMenuItem.Text = "Check requests";
            checkReToolStripMenuItem.Click += CheckRequestsToolStripMenuItem_Click;
            // 
            // checkAcceptedRequestsToolStripMenuItem
            // 
            checkAcceptedRequestsToolStripMenuItem.Name = "checkAcceptedRequestsToolStripMenuItem";
            checkAcceptedRequestsToolStripMenuItem.Size = new Size(255, 26);
            checkAcceptedRequestsToolStripMenuItem.Text = "Check accepted requests";
            checkAcceptedRequestsToolStripMenuItem.Click += CheckAcceptedRequestsToolStripMenuItem_Click;
            // 
            // OnlineGamesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 503);
            Controls.Add(buttonAcceptedRequests);
            Controls.Add(labelGameCount);
            Controls.Add(buttonJoin);
            Controls.Add(buttonCheckRequests);
            Controls.Add(buttonHost);
            Controls.Add(dataGridViewGames);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "OnlineGamesForm";
            Text = "Available games";
            ((System.ComponentModel.ISupportInitialize)dataGridViewGames).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timerUpdateGamesTable;
        private DataGridView dataGridViewGames;
        private MenuStrip menuStrip;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem hostAGameToolStripMenuItem;
        private ToolStripMenuItem joinToolStripMenuItem;
        private Button buttonHost;
        private Button buttonJoin;
        private Label labelGameCount;
        private Button buttonCheckRequests;
        private Button buttonAcceptedRequests;
        private ToolStripMenuItem checkReToolStripMenuItem;
        private ToolStripMenuItem checkAcceptedRequestsToolStripMenuItem;
    }
}