using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    enum Piece
    {
        WhitePawn,
        BlackPawn,
        WhiteBishop,
        BlackBishop,
        WhiteKnight,
        BlackKnight,
        WhiteRook,
        BlackRook,
        WhiteKing,
        BlackKing,
        WhiteQueen,
        BlackQueen,
        None
    }

    enum View
    {
        WhitePOV,
        BlackPOV
    }

    public struct BoardIndex
    {
        public BoardIndex()
        {
            Unselect();
        }

        public BoardIndex(int row, int col)
        {
            Select(row, col);
        }

        private bool selected;

        private int row;
        public readonly int Row { get { return row; } }

        private int col;
        public readonly int Col { get { return col; } }

        public void Unselect()
        {
            selected = false;
            row = -1;
            col = -1;
        }

        public void Select(int row, int col)
        {
            selected = true;

            if (row < 0 || row >= Game.BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (col < 0 || col >= Game.BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(col));

            this.row = row;
            this.col = col;
        }

        public readonly bool IsSelected()
        {
            return selected;
        }
    }

    internal static class Game
    {
        public const int BoardLenght = 8;

        public static readonly string[] PieceImagesPaths =
        [
            "assets/pieces/wp.png",
            "assets/pieces/bp.png",
            "assets/pieces/wb.png",
            "assets/pieces/bb.png",
            "assets/pieces/wn.png",
            "assets/pieces/bn.png",
            "assets/pieces/wr.png",
            "assets/pieces/br.png",
            "assets/pieces/wk.png",
            "assets/pieces/bk.png",
            "assets/pieces/wq.png",
            "assets/pieces/bq.png"
        ];

        private static Piece[,] board = new Piece[BoardLenght, BoardLenght]
        {
            { Piece.WhiteRook, Piece.WhiteKnight, Piece.WhiteBishop, Piece.WhiteQueen,
              Piece.WhiteKing, Piece.WhiteBishop, Piece.WhiteKnight, Piece.WhiteRook },

            { Piece.WhitePawn, Piece.WhitePawn, Piece.WhitePawn, Piece.WhitePawn,
              Piece.WhitePawn, Piece.WhitePawn, Piece.WhitePawn, Piece.WhitePawn },

            { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
            { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
            { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
            { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },

            { Piece.BlackPawn, Piece.BlackPawn, Piece.BlackPawn, Piece.BlackPawn,
              Piece.BlackPawn, Piece.BlackPawn, Piece.BlackPawn, Piece.BlackPawn },

            { Piece.BlackRook, Piece.BlackKnight, Piece.BlackBishop, Piece.BlackQueen,
              Piece.BlackKing, Piece.BlackBishop, Piece.BlackKnight, Piece.BlackRook }
        };

        public static Piece[,] Board { get { return board; } }


        private static View view = View.WhitePOV;
        public static View View { get { return view; } set { view = value; } }

        private static BoardIndex selectedPiece = new();
        public static BoardIndex SelectedPiece { get { return selectedPiece; } }

        public static BoardIndex SelectedIndexAdjustedWithPOV()
        {
            if (!selectedPiece.IsSelected() || view == View.BlackPOV)
                return selectedPiece;

            return new(BoardLenght - 1 - selectedPiece.Row, BoardLenght - 1 - selectedPiece.Col);
        }

        public static Piece PieceAtBoardPos(int row, int col)
        {
            if (row < 0 || row >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (col < 0 || col >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(col));

            if (View == View.BlackPOV)
                return board[row, col];

            return board[BoardLenght - 1 - row, BoardLenght - 1 - col];
        }

        public static bool SelectPiece(int row, int col)
        {
            if (row < 0 || row >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (col < 0 || col >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(col));

            if (View == View.WhitePOV)
            {
                row = BoardLenght - 1 - row;
                col = BoardLenght - 1 - col;
            }

            if (!selectedPiece.IsSelected())
            {
                if (board[row, col] == Piece.None)
                    return false;

                selectedPiece.Select(row, col);
                return true;
            }

            return false;
        }

        public static bool UnselectPiece()
        {
            if (!selectedPiece.IsSelected())
                return false;

            selectedPiece.Unselect();
            return true;
        }
    }
}
