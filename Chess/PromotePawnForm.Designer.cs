namespace Chess
{
    partial class PromotePawnForm
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
            label1 = new Label();
            pictureBoxQueen = new PictureBox();
            pictureBoxRook = new PictureBox();
            pictureBoxBishop = new PictureBox();
            pictureBoxKnight = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQueen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBishop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxKnight).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 22);
            label1.Name = "label1";
            label1.Size = new Size(403, 30);
            label1.TabIndex = 0;
            label1.Text = "Choose the piece to promote to";
            // 
            // pictureBoxQueen
            // 
            pictureBoxQueen.Location = new Point(12, 91);
            pictureBoxQueen.Name = "pictureBoxQueen";
            pictureBoxQueen.Size = new Size(108, 108);
            pictureBoxQueen.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxQueen.TabIndex = 1;
            pictureBoxQueen.TabStop = false;
            pictureBoxQueen.MouseClick += PictureBoxQueen_MouseClick;
            // 
            // pictureBoxRook
            // 
            pictureBoxRook.Location = new Point(126, 91);
            pictureBoxRook.Name = "pictureBoxRook";
            pictureBoxRook.Size = new Size(108, 108);
            pictureBoxRook.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRook.TabIndex = 1;
            pictureBoxRook.TabStop = false;
            pictureBoxRook.MouseClick += PictureBoxRook_MouseClick;
            // 
            // pictureBoxBishop
            // 
            pictureBoxBishop.Location = new Point(240, 91);
            pictureBoxBishop.Name = "pictureBoxBishop";
            pictureBoxBishop.Size = new Size(108, 108);
            pictureBoxBishop.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBishop.TabIndex = 1;
            pictureBoxBishop.TabStop = false;
            pictureBoxBishop.MouseClick += PictureBoxBishop_MouseClick;
            // 
            // pictureBoxKnight
            // 
            pictureBoxKnight.Location = new Point(354, 91);
            pictureBoxKnight.Name = "pictureBoxKnight";
            pictureBoxKnight.Size = new Size(108, 108);
            pictureBoxKnight.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxKnight.TabIndex = 1;
            pictureBoxKnight.TabStop = false;
            pictureBoxKnight.MouseClick += PictureBoxKnight_MouseClick;
            // 
            // PromotePawnForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 206);
            Controls.Add(pictureBoxKnight);
            Controls.Add(pictureBoxBishop);
            Controls.Add(pictureBoxRook);
            Controls.Add(pictureBoxQueen);
            Controls.Add(label1);
            Name = "PromotePawnForm";
            Text = "Promote pawn";
            ((System.ComponentModel.ISupportInitialize)pictureBoxQueen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRook).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBishop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxKnight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBoxQueen;
        private PictureBox pictureBoxRook;
        private PictureBox pictureBoxBishop;
        private PictureBox pictureBoxKnight;
    }
}