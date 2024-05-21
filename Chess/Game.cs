using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    enum PieceColor
    {
        White,
        Black
    }

    enum Piece
    {
        WhitePawn,
        BlackPawn,
        WhiteKnight,
        BlackKnight,
        WhiteBishop,
        BlackBishop,
        WhiteRook,
        BlackRook,
        WhiteQueen,
        BlackQueen,
        WhiteKing,
        BlackKing,
        None
    }

    static class PieceExtensions
    {
        public static bool IsWhite(this Piece piece)
        {
            switch (piece)
            {
                case Piece.WhitePawn:
                case Piece.WhiteBishop:
                case Piece.WhiteKnight:
                case Piece.WhiteRook:
                case Piece.WhiteKing:
                case Piece.WhiteQueen:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsBlack(this Piece piece)
        {
            switch (piece)
            {
                case Piece.BlackPawn:
                case Piece.BlackBishop:
                case Piece.BlackKnight:
                case Piece.BlackRook:
                case Piece.BlackKing:
                case Piece.BlackQueen:
                    return true;
                default:
                    return false;
            }
        }

        public static PieceColor GetColor(this Piece piece)
        {
            if (piece.IsWhite())
                return PieceColor.White;
            else
                return PieceColor.Black;
        }
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

        public void SwapForPOV()
        {
            row = Game.BoardLenght - 1 - row;
            col = Game.BoardLenght - 1 - col;
        }
    }

    internal static class Game
    {
        public const int BoardLenght = 8;

        public static readonly string[] PieceImagesPaths =
        [
            "assets/pieces/wp.png",
            "assets/pieces/bp.png",
            "assets/pieces/wn.png",
            "assets/pieces/bn.png",
            "assets/pieces/wb.png",
            "assets/pieces/bb.png",
            "assets/pieces/wr.png",
            "assets/pieces/br.png",
            "assets/pieces/wq.png",
            "assets/pieces/bq.png",
            "assets/pieces/wk.png",
            "assets/pieces/bk.png",
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

        public static Piece GetPieceAtBoardPosPOVAdjusted(int row, int col)
        {
            if (row < 0 || row >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (col < 0 || col >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(col));

            if (View == View.BlackPOV)
                return board[row, col];

            return board[BoardLenght - 1 - row, BoardLenght - 1 - col];
        }

        /// <summary>
        /// Not adjusted to the POV
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Piece GetPieceAtBoardPos(int row, int col)
        {
            if (row < 0 || row >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (col < 0 || col >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(col));

            return board[row, col];
        }

        private static Piece GetPieceAtBoardPos(BoardIndex boardIndex)
        {
            if (!boardIndex.IsSelected())
                return Piece.None;

            if (boardIndex.Row < 0 || boardIndex.Row >= BoardLenght || boardIndex.Col < 0 || boardIndex.Col >= BoardLenght)
                throw new ArgumentOutOfRangeException(nameof(boardIndex), $"boardIndex: {{ {boardIndex.Row}, {boardIndex.Col} }}");

            return board[boardIndex.Row, boardIndex.Col];
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

            // If a piece is selected, an attemp to move that piece was made, so we're checking if that's possible
            if (selectedPiece.IsSelected())
            {
                List<BoardIndex> availableSquares = GetAvailableSquares(selectedPiece);

                if (availableSquares.Contains(new(row, col)))
                {
                    int currRow = selectedPiece.Row;
                    int currCol = selectedPiece.Col;

                    if (board[row, col] == Piece.None)
                        (board[row, col], board[currRow, currCol]) = (board[currRow, currCol], board[row, col]);
                    else
                        (board[row, col], board[currRow, currCol]) = (board[currRow, currCol], Piece.None);

                    selectedPiece.Unselect();
                    return true;
                }
                else
                {
                    if (board[row, col] == Piece.None)
                        selectedPiece.Unselect();
                    else
                        selectedPiece.Select(row, col);

                    return true;
                }
            }
            else
            {
                if (board[row, col] == Piece.None)
                    return false;

                selectedPiece.Select(row, col);
                return true;
            }
        }

        /// <returns>
        /// 'true' if the unselecting had any effect (if a piece was selected when unselecting), 'false' otherwise.
        /// This is used to check if there is a need to redraw the board when the user attempts to unselect the piece.
        /// </returns>
        public static bool UnselectPiece()
        {
            if (!selectedPiece.IsSelected())
                return false;

            selectedPiece.Unselect();
            return true;
        }

        private static int ColumnMarkToArrayIndex(char col)
        {
            if (col < 'A' || col > 'H')
                throw new ArgumentOutOfRangeException(nameof(col));

            return col - 'A';
        }

        private static int RowNumToArrayIndex(int row)
        {
            if (row < 1 || row > 8)
                throw new ArgumentOutOfRangeException(nameof(row));

            return row - 1;
        }

        public static List<BoardIndex> GetAvailableSquares(BoardIndex piece)
        {
            List<BoardIndex> availableSquares = [];

            bool checkSquare(int row, int col)
            {
                if (row < 0 || row >= BoardLenght || col < 0 || col >= BoardLenght)
                    return false;

                if (GetPieceAtBoardPos(row, col) == Piece.None)
                {
                    availableSquares.Add(new(row, col));
                    return true;
                }

                if (GetPieceAtBoardPos(selectedPiece).GetColor() == PieceColor.White ?
                    GetPieceAtBoardPos(row, col).IsBlack() : GetPieceAtBoardPos(row, col).IsWhite())
                {
                    availableSquares.Add(new(row, col));
                    return false;
                }

                return false;
            }

            switch (GetPieceAtBoardPos(piece))
            {
                case Piece.WhitePawn:
                    if (piece.Row != RowNumToArrayIndex(8) && GetPieceAtBoardPos(piece.Row + 1, piece.Col) == Piece.None)
                        availableSquares.Add(new(piece.Row + 1, piece.Col));

                    if (piece.Row == RowNumToArrayIndex(2) && GetPieceAtBoardPos(piece.Row + 2, piece.Col) == Piece.None)
                        availableSquares.Add(new(piece.Row + 2, piece.Col));

                    if (piece.Row != RowNumToArrayIndex(8) && piece.Col != ColumnMarkToArrayIndex('H') && GetPieceAtBoardPos(piece.Row + 1, piece.Col + 1).IsBlack())
                        availableSquares.Add(new(piece.Row + 1, piece.Col + 1));

                    if (piece.Row != RowNumToArrayIndex(8) && piece.Col != ColumnMarkToArrayIndex('A') && GetPieceAtBoardPos(piece.Row + 1, piece.Col - 1).IsBlack())
                        availableSquares.Add(new(piece.Row + 1, piece.Col - 1));

                    break;

                case Piece.BlackPawn:
                    if (piece.Row != RowNumToArrayIndex(1) && GetPieceAtBoardPos(piece.Row - 1, piece.Col) == Piece.None)
                        availableSquares.Add(new(piece.Row - 1, piece.Col));

                    if (piece.Row == RowNumToArrayIndex(7) && GetPieceAtBoardPos(piece.Row - 2, piece.Col) == Piece.None)
                        availableSquares.Add(new(piece.Row - 2, piece.Col));

                    if (piece.Row != RowNumToArrayIndex(1) && piece.Col != ColumnMarkToArrayIndex('H') && GetPieceAtBoardPos(piece.Row - 1, piece.Col + 1).IsWhite())
                        availableSquares.Add(new(piece.Row - 1, piece.Col + 1));

                    if (piece.Row != RowNumToArrayIndex(1) && piece.Col != ColumnMarkToArrayIndex('A') && GetPieceAtBoardPos(piece.Row - 1, piece.Col - 1).IsWhite())
                        availableSquares.Add(new(piece.Row - 1, piece.Col - 1));

                    break;

                case Piece.WhiteKnight:
                case Piece.BlackKnight:
                    checkSquare(piece.Row + 2, piece.Col + 1);
                    checkSquare(piece.Row + 2, piece.Col - 1);
                    checkSquare(piece.Row - 2, piece.Col + 1);
                    checkSquare(piece.Row - 2, piece.Col - 1);
                    checkSquare(piece.Row + 1, piece.Col + 2);
                    checkSquare(piece.Row + 1, piece.Col - 2);
                    checkSquare(piece.Row - 1, piece.Col + 2);
                    checkSquare(piece.Row - 1, piece.Col - 2);
                    break;

                case Piece.WhiteBishop:
                case Piece.BlackBishop:
                    for (int row = piece.Row + 1, col = piece.Col + 1; row < BoardLenght && col < BoardLenght; row++, col++)
                    { if (!checkSquare(row, col)) break; }
                    for (int row = piece.Row - 1, col = piece.Col - 1; row >= 0 && col >= 0; row--, col--)
                    { if (!checkSquare(row, col)) break; }
                    for (int row = piece.Row - 1, col = piece.Col + 1; row >= 0 && col < BoardLenght; row--, col++)
                    { if (!checkSquare(row, col)) break; }
                    for (int row = piece.Row + 1, col = piece.Col - 1; col >= 0 && row < BoardLenght; row++, col--)
                    { if (!checkSquare(row, col)) break; }

                    break;

                case Piece.WhiteRook:
                case Piece.BlackRook:
                    for (int row = piece.Row + 1; row < BoardLenght; row++) { if (!checkSquare(row, piece.Col)) break; }
                    for (int row = piece.Row - 1; row >= 0; row--)          { if (!checkSquare(row, piece.Col)) break; }
                    for (int col = piece.Col + 1; col < BoardLenght; col++) { if (!checkSquare(piece.Row, col)) break; }
                    for (int col = piece.Col - 1; col >= 0; col--)          { if (!checkSquare(piece.Row, col)) break; }
                    break;

                case Piece.WhiteQueen:
                case Piece.BlackQueen:
                    for (int row = piece.Row + 1, col = piece.Col + 1; row < BoardLenght && col < BoardLenght; row++, col++)
                    { if (!checkSquare(row, col)) break; }
                    for (int row = piece.Row - 1, col = piece.Col - 1; row >= 0 && col >= 0; row--, col--)
                    { if (!checkSquare(row, col)) break; }
                    for (int row = piece.Row - 1, col = piece.Col + 1; row >= 0 && col < BoardLenght; row--, col++)
                    { if (!checkSquare(row, col)) break; }
                    for (int row = piece.Row + 1, col = piece.Col - 1; col >= 0 && row < BoardLenght; row++, col--)
                    { if (!checkSquare(row, col)) break; }

                    for (int row = piece.Row + 1; row < BoardLenght; row++) { if (!checkSquare(row, piece.Col)) break; }
                    for (int row = piece.Row - 1; row >= 0; row--) { if (!checkSquare(row, piece.Col)) break; }
                    for (int col = piece.Col + 1; col < BoardLenght; col++) { if (!checkSquare(piece.Row, col)) break; }
                    for (int col = piece.Col - 1; col >= 0; col--) { if (!checkSquare(piece.Row, col)) break; }
                    break;

                case Piece.WhiteKing:
                case Piece.BlackKing:
                    checkSquare(selectedPiece.Row + 1, selectedPiece.Col + 1);
                    checkSquare(selectedPiece.Row + 1, selectedPiece.Col - 1);
                    checkSquare(selectedPiece.Row - 1, selectedPiece.Col + 1);
                    checkSquare(selectedPiece.Row - 1, selectedPiece.Col - 1);
                    checkSquare(selectedPiece.Row + 1, selectedPiece.Col);
                    checkSquare(selectedPiece.Row - 1, selectedPiece.Col);
                    checkSquare(selectedPiece.Row, selectedPiece.Col + 1);
                    checkSquare(selectedPiece.Row, selectedPiece.Col - 1);
                    break;
            }

            return availableSquares;
        }
    }
}
