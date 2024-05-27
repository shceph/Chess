using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class PromotePawnForm : Form
    {
        private readonly PieceColor pieceColor;
        private Piece chosenPiece;
        public Piece ChosenPiece { get { return chosenPiece; } }

        public PromotePawnForm(PieceColor pieceColor)
        {
            InitializeComponent();

            string iconPath = Path.Combine(Application.StartupPath, "assets", "icon.ico");
            this.Icon = new Icon(iconPath);

            if (pieceColor == PieceColor.White)
            {
                pictureBoxQueen.ImageLocation  = Game.PieceImagesPaths[(int)Piece.WhiteQueen];
                pictureBoxRook.ImageLocation   = Game.PieceImagesPaths[(int)Piece.WhiteRook];
                pictureBoxBishop.ImageLocation = Game.PieceImagesPaths[(int)Piece.WhiteBishop];
                pictureBoxKnight.ImageLocation = Game.PieceImagesPaths[(int)Piece.WhiteKnight];
            }
            else
            {
                pictureBoxQueen.ImageLocation  = Game.PieceImagesPaths[(int)Piece.BlackQueen];
                pictureBoxRook.ImageLocation   = Game.PieceImagesPaths[(int)Piece.BlackRook];
                pictureBoxBishop.ImageLocation = Game.PieceImagesPaths[(int)Piece.BlackBishop];
                pictureBoxKnight.ImageLocation = Game.PieceImagesPaths[(int)Piece.BlackKnight];
            }

            this.pieceColor = pieceColor;
        }

        private void PictureBoxQueen_MouseClick(object sender, MouseEventArgs e)
        {
            chosenPiece = (pieceColor == PieceColor.White ? Piece.WhiteQueen : Piece.BlackQueen);

            var result = MessageBox.Show("Are you sure you want to promote to Queen?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            Close();
        }

        private void PictureBoxRook_MouseClick(object sender, MouseEventArgs e)
        {
            chosenPiece = (pieceColor == PieceColor.White ? Piece.WhiteRook : Piece.BlackRook);

            var result = MessageBox.Show("Are you sure you want to promote to Rook?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            Close();
        }

        private void PictureBoxBishop_MouseClick(object sender, MouseEventArgs e)
        {
            chosenPiece = (pieceColor == PieceColor.White ? Piece.WhiteBishop : Piece.BlackBishop);

            var result = MessageBox.Show("Are you sure you want to promote to Bishop?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            Close();
        }

        private void PictureBoxKnight_MouseClick(object sender, MouseEventArgs e)
        {
            chosenPiece = (pieceColor == PieceColor.White ? Piece.WhiteKnight : Piece.BlackKnight);

            var result = MessageBox.Show("Are you sure you want to promote to Knight?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            Close();
        }
    }
}
