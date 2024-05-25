using Microsoft.VisualBasic.Devices;

namespace Chess
{
    public partial class MainForm : Form
    {
        public static bool IsCheckmate { get; set; }
        public static bool IsStalemate { get; set; }
        public static PieceColor WhoWon { get; set; }

        private readonly Graphics graphics;
        private readonly Brush saddleBrownBrush;
        private readonly Brush sandyBrownBrush;
        private readonly Brush selectedBrush;
        private readonly Color selectedColor;
        private readonly Point boardTopLeft;
        //private readonly int boardLenghtInPixels;
        private readonly float boardSquareLenghtInPixels;
        private readonly Image[] pieceImages;
        public MainForm()
        {
            InitializeComponent();

            IsCheckmate = false;
            IsStalemate = false;
            WhoWon = PieceColor.White;

            graphics = CreateGraphics();
            graphics.TranslateTransform(0, menuStrip.Height);
            saddleBrownBrush = new SolidBrush(Color.SaddleBrown);
            sandyBrownBrush = new SolidBrush(Color.SandyBrown);
            selectedColor = Color.FromArgb(122, Color.Bisque.R, Color.Bisque.G, Color.Bisque.B);
            selectedBrush = new SolidBrush(selectedColor);

            boardTopLeft.Y = 0;
            boardTopLeft.X = (ClientRectangle.Width - (ClientRectangle.Height - menuStrip.Height)) / 2;

            float rectHeight = (float)(ClientRectangle.Height - menuStrip.Height) / 8.0f;
            float rectWidth = (float)ClientRectangle.Width / 8.0f;
            boardSquareLenghtInPixels = Math.Min(rectWidth, rectHeight);

            //boardLenghtInPixels = ClientRectangle.Width - ((ClientRectangle.Height + menuStrip.Height) / 2);

            pieceImages = new Image[Game.PieceImagesPaths.Length];

            for (int i = 0; i < pieceImages.Length; i++)
            {
                if (File.Exists(Game.PieceImagesPaths[i]))
                    pieceImages[i] = Image.FromFile(Game.PieceImagesPaths[i]);
                else
                    throw new FileNotFoundException($"Image file not found: {Game.PieceImagesPaths[i]}");
            }
        }

        private void DrawBoard()
        {
            graphics.Clear(Color.DarkSlateGray);

            List<BoardIndex> squaresToHighlight = [];

            if (Game.SelectedPiece.IsSelected())
            {
                squaresToHighlight = Game.GetAvailableMoves(Game.SelectedPiece, Game.Board);
                squaresToHighlight.Add(Game.SelectedPiece);

                if (Game.View == View.WhitePOV)
                {
                    for (int i = 0; i < squaresToHighlight.Count; i++)
                    {
                        BoardIndex temp = squaresToHighlight[i];
                        temp.SwapForPOV();
                        squaresToHighlight[i] = temp;
                    }
                }
            }

            BoardIndex bi = new(0, 0);
            bi.SwapForPOV();

            for (int i = 0; i < Game.BoardLenght; i++)
            {
                for (int j = 0; j < Game.BoardLenght; j++)
                {
                    float x = j * boardSquareLenghtInPixels + boardTopLeft.X;
                    float y = i * boardSquareLenghtInPixels + boardTopLeft.Y;

                    if ((i + j) % 2 != 0)
                        graphics.FillRectangle(sandyBrownBrush, x, y, boardSquareLenghtInPixels, boardSquareLenghtInPixels);
                    else
                        graphics.FillRectangle(saddleBrownBrush, x, y, boardSquareLenghtInPixels, boardSquareLenghtInPixels);

                    if (squaresToHighlight.Contains(new(i, j)))
                        graphics.FillRectangle(selectedBrush, x, y, boardSquareLenghtInPixels, boardSquareLenghtInPixels);

                    Piece currentPiece = Game.GetPieceAtBoardPosPOVAdjusted(i, j);

                    if (currentPiece == Piece.None)
                        continue;

                    graphics.DrawImage(
                        pieceImages[(int)currentPiece],
                        (int)x, (int)y,
                        (int)boardSquareLenghtInPixels, (int)boardSquareLenghtInPixels
                    );
                }
            }
        }

        private void HandleCheckmate()
        {
            MessageBox.Show($"{(WhoWon == PieceColor.White ? "White" : "Black")} won!\nClick OK to reset the game", "Congratulations!");
            ResetGame();
        }

        private void HandleRemi()
        {
            MessageBox.Show("It's remi!\nClick OK to reset the game", "Remi");
            ResetGame();
        }

        private void ResetGame()
        {
            Game.Reset();
            IsCheckmate = false;
            IsStalemate = false;
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard();

            if (IsCheckmate)
                HandleCheckmate();
            else if (IsStalemate)
                HandleRemi();
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

            int row = clientRelativePos.Y / (int)boardSquareLenghtInPixels;
            int col = clientRelativePos.X / (int)boardSquareLenghtInPixels;

            if (row < 0 || col < 0 || row >= Game.BoardLenght || col >= Game.BoardLenght)
                return;

            if (Game.SelectPieceOrMoveSelected(row, col))
                Invalidate();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetTheBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
