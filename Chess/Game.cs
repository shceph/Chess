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

        public static Piece BoardAtIndex(int i, int j)
        {
            if (i < 0 || j < 0 || i >= BoardLenght || j > BoardLenght)
            {
                MessageBox.Show("i or j out of range [0, BoardLenght)\ni: " + i + "\nj: " + j, "Error");
                throw new ArgumentOutOfRangeException();
            }

            if (View == View.BlackPOV)
                return board[i, j];

            return board[BoardLenght - 1 - i, BoardLenght - 1 - j];
        }
    }
}
