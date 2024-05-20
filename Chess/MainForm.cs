using Microsoft.VisualBasic.Devices;

namespace Chess
{
    public partial class MainForm : Form
    {
        private readonly Graphics graphics;
        private readonly Brush saddleBrownBrush;
        private readonly Brush sandyBrownBrush;
        private readonly Point boardTopLeft;
        private readonly int boardLenghtInPixels;
        private readonly float boardSquareLenght;

        public MainForm()
        {
            InitializeComponent();

            graphics = CreateGraphics();
            graphics.TranslateTransform(0, menuStrip.Height);
            saddleBrownBrush = new SolidBrush(Color.SaddleBrown);
            sandyBrownBrush = new SolidBrush(Color.SandyBrown);

            boardTopLeft.Y = 0;
            boardTopLeft.X = (ClientRectangle.Width - ClientRectangle.Height) / 2;

            float rectHeight = (float)(ClientRectangle.Height - menuStrip.Height) / 8.0f;
            float rectWidth = (float)ClientRectangle.Width / 8.0f;
            boardSquareLenght = Math.Min(rectWidth, rectHeight);

            boardLenghtInPixels = ClientRectangle.Width - ((ClientRectangle.Height + menuStrip.Height) / 2);
        }

        private void DrawBoard()
        {
            graphics.Clear(Color.DarkSlateGray);

            for (int i = 0; i < Game.BoardLenght; i++)
            {
                for (int j = 0; j < Game.BoardLenght; j++)
                {
                    float x = j * boardSquareLenght + boardTopLeft.X;
                    float y = i * boardSquareLenght + boardTopLeft.Y;

                    if ((Game.View == View.BlackPOV && (i + j) % 2 == 0) || (Game.View == View.WhitePOV && (i + j) % 2 != 0))
                        graphics.FillRectangle(sandyBrownBrush, x, y, boardSquareLenght, boardSquareLenght);
                    else
                        graphics.FillRectangle(saddleBrownBrush, x, y, boardSquareLenght, boardSquareLenght);

                    if (Game.SelectedIndexAdjustedWithPOV().Row == i && Game.SelectedIndexAdjustedWithPOV().Col == j)
                    {
                        Color color = Color.FromArgb(Color.Red.R, Color.Red.G, Color.Red.B, 100);
                        Brush selectedBrush = new SolidBrush(color);
                        graphics.FillRectangle(selectedBrush, x, y, boardSquareLenght, boardSquareLenght);
                    }

                    Piece currentPiece = Game.PieceAtBoardPos(i, j);

                    if (currentPiece == Piece.None)
                        continue;

                    graphics.DrawImage(
                        Image.FromFile(Game.PieceImagesPaths[(int)currentPiece]),
                        (int)x, (int)y,
                        (int)boardSquareLenght, (int)boardSquareLenght
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

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Game.UnselectPiece())
                    Invalidate();

                return;
            }

            Point clientRelativePos = PointToClient(Cursor.Position);
            clientRelativePos.Y -= menuStrip.Height;
            clientRelativePos.X -= boardTopLeft.X;

            if (clientRelativePos.X < 0 || clientRelativePos.Y < 0 || clientRelativePos.X >= boardLenghtInPixels || clientRelativePos.Y >= boardLenghtInPixels)
                return;

            int row = clientRelativePos.Y / (int)boardSquareLenght;
            int col = clientRelativePos.X / (int)boardSquareLenght;

            if (Game.SelectPiece(row, col))
                Invalidate();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
