using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    enum Piece
    {
        None,
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
        BlackQueen
    }

    internal static class Game
    {
        public static Piece[,] Board { get { return board; } }

        private static Piece[,] board = new Piece[,]
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
    }
}
