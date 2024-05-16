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
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(144, 98);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(229, 69);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start the game";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // OpeningForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 474);
            Controls.Add(buttonStart);
            Name = "OpeningForm";
            Text = "OpeningForm";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonStart;
    }
}