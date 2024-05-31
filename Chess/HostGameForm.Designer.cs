namespace Chess
{
    partial class HostGameForm
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
            radioButtonWhite = new RadioButton();
            labelSide = new Label();
            radioButtonBlack = new RadioButton();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            textBoxAllowedPlayer = new TextBox();
            labelAllowedPlayer = new Label();
            buttonHost = new Button();
            SuspendLayout();
            // 
            // radioButtonWhite
            // 
            radioButtonWhite.AutoSize = true;
            radioButtonWhite.Checked = true;
            radioButtonWhite.Location = new Point(12, 53);
            radioButtonWhite.Name = "radioButtonWhite";
            radioButtonWhite.Size = new Size(69, 24);
            radioButtonWhite.TabIndex = 2;
            radioButtonWhite.TabStop = true;
            radioButtonWhite.Text = "White";
            radioButtonWhite.UseVisualStyleBackColor = true;
            // 
            // labelSide
            // 
            labelSide.AutoSize = true;
            labelSide.Location = new Point(12, 19);
            labelSide.Name = "labelSide";
            labelSide.Size = new Size(125, 20);
            labelSide.TabIndex = 1;
            labelSide.Text = "Choose your side:";
            // 
            // radioButtonBlack
            // 
            radioButtonBlack.AutoSize = true;
            radioButtonBlack.Location = new Point(12, 83);
            radioButtonBlack.Name = "radioButtonBlack";
            radioButtonBlack.Size = new Size(65, 24);
            radioButtonBlack.TabIndex = 2;
            radioButtonBlack.Text = "Black";
            radioButtonBlack.UseVisualStyleBackColor = true;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(12, 141);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(196, 20);
            labelDescription.TabIndex = 4;
            labelDescription.Text = "Insert description (optional):";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(12, 174);
            textBoxDescription.MaxLength = 255;
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(403, 113);
            textBoxDescription.TabIndex = 3;
            // 
            // textBoxAllowedPlayer
            // 
            textBoxAllowedPlayer.Location = new Point(171, 52);
            textBoxAllowedPlayer.MaxLength = 20;
            textBoxAllowedPlayer.Name = "textBoxAllowedPlayer";
            textBoxAllowedPlayer.Size = new Size(244, 27);
            textBoxAllowedPlayer.TabIndex = 0;
            // 
            // labelAllowedPlayer
            // 
            labelAllowedPlayer.AutoSize = true;
            labelAllowedPlayer.Location = new Point(171, 19);
            labelAllowedPlayer.Name = "labelAllowedPlayer";
            labelAllowedPlayer.Size = new Size(240, 20);
            labelAllowedPlayer.TabIndex = 1;
            labelAllowedPlayer.Text = "The only allowed player (optional):";
            // 
            // buttonHost
            // 
            buttonHost.Location = new Point(165, 303);
            buttonHost.Name = "buttonHost";
            buttonHost.Size = new Size(94, 29);
            buttonHost.TabIndex = 5;
            buttonHost.Text = "Host";
            buttonHost.UseVisualStyleBackColor = true;
            buttonHost.Click += ButtonHost_Click;
            // 
            // HostGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 345);
            Controls.Add(buttonHost);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(radioButtonBlack);
            Controls.Add(radioButtonWhite);
            Controls.Add(labelSide);
            Controls.Add(labelAllowedPlayer);
            Controls.Add(textBoxAllowedPlayer);
            Name = "HostGameForm";
            Text = "Host your game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RadioButton radioButtonWhite;
        private Label labelSide;
        private RadioButton radioButtonBlack;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private TextBox textBoxAllowedPlayer;
        private Label labelAllowedPlayer;
        private Button buttonHost;
    }
}