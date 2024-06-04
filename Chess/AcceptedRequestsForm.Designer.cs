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
            // AcceptedRequestsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 436);
            Controls.Add(buttonEnterGame);
            Controls.Add(listBoxAcceptedRequests);
            Name = "AcceptedRequestsForm";
            Text = "AcceptedRequestsForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxAcceptedRequests;
        private Button buttonEnterGame;
    }
}