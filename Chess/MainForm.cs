namespace Chess
{
    public partial class MainForm : Form
    {
        private readonly Graphics graphics;
        private readonly Brush saddleBrownBrush;
        private readonly Brush sandyBrownBrush;
        public MainForm()
        {
            InitializeComponent();

            graphics = CreateGraphics();
            graphics.TranslateTransform(0, menuStrip.Height);
            saddleBrownBrush = new SolidBrush(Color.SaddleBrown);
            sandyBrownBrush = new SolidBrush(Color.SandyBrown);
        }

        private void DrawBoard()
        {
            graphics.Clear(Color.DarkSlateGray);

            float rectHeight = (float)(ClientRectangle.Height - menuStrip.Height) / 8.0f;
            float rectWidth = (float)ClientRectangle.Width / 8.0f;
            float squareWidth = Math.Min(rectWidth, rectHeight);

            float addToX = 0.0f, addToY = 0.0f;

            if (ClientRectangle.Width > ClientRectangle.Height)
                addToX = (ClientRectangle.Width - ClientRectangle.Height) / 2;
            else
                addToY = (ClientRectangle.Height - ClientRectangle.Width) / 2;

            for (int i = 0; i < Game.BoardLenght; i++)
            {
                for (int j = 0; j < Game.BoardLenght; j++)
                {
                    float x = j * squareWidth + addToX;
                    float y = i * squareWidth + addToY;

                    if ((Game.View == View.BlackPOV && (i + j) % 2 == 0) || (Game.View == View.WhitePOV && (i + j) % 2 != 0))
                        graphics.FillRectangle(sandyBrownBrush, x, y, squareWidth, squareWidth);
                    else
                        graphics.FillRectangle(saddleBrownBrush, x, y, squareWidth, squareWidth);

                    Piece currentPiece = Game.BoardAtIndex(i, j);

                    if (currentPiece == Piece.None)
                        continue;

                    graphics.DrawImage(
                        Image.FromFile(Game.PieceImagesPaths[(int)currentPiece]),
                        (int)x, (int)y,
                        (int)squareWidth, (int)squareWidth
                    );
                }
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard();
        }

        private void SwitchViewSideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.View = (Game.View == View.WhitePOV ? View.BlackPOV : View.WhitePOV);

            // When the form is invalidated, the 'Paint' method of the form is called
            Invalidate();
        }
    }
}
