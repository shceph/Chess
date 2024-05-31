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
            listViewGames = new ListView();
            timerUpdateGamesTable = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // listViewGames
            // 
            listViewGames.Location = new Point(12, 12);
            listViewGames.Name = "listViewGames";
            listViewGames.Size = new Size(521, 466);
            listViewGames.TabIndex = 0;
            listViewGames.UseCompatibleStateImageBehavior = false;
            // 
            // timerUpdateGamesTable
            // 
            timerUpdateGamesTable.Enabled = true;
            timerUpdateGamesTable.Interval = 5000;
            timerUpdateGamesTable.Tick += TimerUpdateGamesTable_Tick;
            // 
            // OnlineGamesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 490);
            Controls.Add(listViewGames);
            Name = "OnlineGamesForm";
            Text = "OnlineGamesForm";
            Load += OnlineGamesForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewGames;
        private System.Windows.Forms.Timer timerUpdateGamesTable;
    }
}