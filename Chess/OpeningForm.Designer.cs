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
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonStart.Location = new Point(12, 15);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(497, 69);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start 1v1 locally";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += ButtonStart_Click;
            // 
            // buttonStartOnline
            // 
            buttonStartOnline.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonStartOnline.Location = new Point(12, 90);
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
            labelUsername.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.Location = new Point(12, 293);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(459, 20);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Insert your username (mandatory for online games):";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxUsername.Location = new Point(12, 330);
            textBoxUsername.MaxLength = 20;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(306, 25);
            textBoxUsername.TabIndex = 2;
            // 
            // OpeningForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 390);
            Controls.Add(textBoxUsername);
            Controls.Add(labelUsername);
            Controls.Add(buttonStartOnline);
            Controls.Add(buttonStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "OpeningForm";
            Text = "Chess";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private Button buttonStartOnline;
        private Label labelUsername;
        private TextBox textBoxUsername;
    }
}