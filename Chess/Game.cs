using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum PieceColor
    {
        White,
        Black
    }

    public enum Piece
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
            return piece switch
            {
                Piece.WhitePawn or Piece.WhiteBishop or Piece.WhiteKnight or
                Piece.WhiteRook or Piece.WhiteKing or Piece.WhiteQueen => true,
                _ => false,
            };
        }

        public static bool IsBlack(this Piece piece)
        {
            return piece switch
            {
                Piece.BlackPawn or Piece.BlackBishop or Piece.BlackKnight or
                Piece.BlackRook or Piece.BlackKing or Piece.BlackQueen => true,
                _ => false,
            };
        }

        public static PieceColor GetColor(this Piece piece)
        {
            if (piece.IsWhite())
            {
                return PieceColor.White;
            }
            else
            {
                return PieceColor.Black;
            }
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
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }

            if (col < 0 || col >= Game.BoardLenght)
            {
                throw new ArgumentOutOfRangeException(nameof(col));
            }

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

        public readonly Piece GetPiece()
        {
            if (!selected)
            {
                return Piece.None;
            }

            return Game.Board[row, col];
        }
    }

    internal static class Game
    {
        public const int BoardLenght = 8;
        public const bool RespectMoveRights = true;

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

        private static readonly Piece[,] initialBoard = new Piece[BoardLenght, BoardLenght]
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

        public static readonly string InitialBoardString = GetBoardString(initialBoard);

        private static readonly Piece[,] board;
        public static Piece[,] Board { get { return board; } }

        private static View view = View.WhitePOV;
        public static View View { get { return view; } set { view = value; } }

        private static BoardIndex selectedPiece = new();
        public static BoardIndex SelectedPiece { get { return selectedPiece; } }
        public static bool BoardChanged { get; set; } = false;

        //private static PieceColor whoseTurn = PieceColor.White;
        public static PieceColor WhoseTurn { get; set; } = PieceColor.White;
        public static Guid? OnlineGameID { get; set; } = null;

        static Game()
        {
            board = new Piece[BoardLenght, BoardLenght];
            Reset();
        }

        public static void UpdateDataToDatabase()
        {
            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                if (Globals.Account == null)
                {
                    throw new Exception("You aren't logged in");
                }

                connection.Open();

                string query = @"
                    UPDATE Games
                    SET is_whites_turn = @is_whites_turn, board = @board_string
                    WHERE id = @id";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@is_whites_turn", WhoseTurn == PieceColor.White);
                command.Parameters.AddWithValue("@board_string", GetBoardString(board));
                command.Parameters.AddWithValue("@id", OnlineGameID);
                command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public static void SwapTurn()
        {
            if (WhoseTurn == PieceColor.White)
            {
                WhoseTurn = PieceColor.Black;
            }
            else
            {
                WhoseTurn = PieceColor.White;
            }
        }

        public static void Reset()
        {
            for (int i = 0; i < BoardLenght; i++)
            {
                for (int j = 0; j < BoardLenght; j++)
                {
                    board[i, j] = initialBoard[i, j];
                }
            }

            selectedPiece.Unselect();
            WhoseTurn = PieceColor.White;
        }

        public static void SetByBoardString(string boardString)
        {
            for (int i = 0; i < boardString.Length; i++)
            {
                board[i / 8, i % 8] = boardString[i] switch
                {
                    'P' => Piece.WhitePawn,
                    'p' => Piece.BlackPawn,
                    'N' => Piece.WhiteKnight,
                    'n' => Piece.BlackKnight,
                    'B' => Piece.WhiteBishop,
                    'b' => Piece.BlackBishop,
                    'R' => Piece.WhiteRook,
                    'r' => Piece.BlackRook,
                    'Q' => Piece.WhiteQueen,
                    'q' => Piece.BlackQueen,
                    'K' => Piece.WhiteKing,
                    'k' => Piece.BlackKing,
                    '-' => Piece.None,
                    _ => throw new Exception("boadrdString in incorrect format")
                };
            }
        }

        public static string GetBoardString(Piece[,] boardToUse)
        {
            string ret = "";

            foreach (var piece in boardToUse)
            {
                switch (piece)
                {
                    case Piece.WhitePawn:
                        ret += 'P'; break;
                    case Piece.BlackPawn:
                        ret += 'p'; break;
                    case Piece.WhiteKnight:
                        ret += 'N'; break;
                    case Piece.BlackKnight:
                        ret += 'n'; break;
                    case Piece.WhiteBishop:
                        ret += 'B'; break;
                    case Piece.BlackBishop:
                        ret += 'b'; break;
                    case Piece.WhiteRook:
                        ret += 'R'; break;
                    case Piece.BlackRook:
                        ret += 'r'; break;
                    case Piece.WhiteQueen:
                        ret += 'Q'; break;
                    case Piece.BlackQueen:
                        ret += 'q'; break;
                    case Piece.WhiteKing:
                        ret += 'K'; break;
                    case Piece.BlackKing:
                        ret += 'k'; break;
                    case Piece.None:
                        ret += '-'; break;
                }
            }

            return ret;
        }

        public static Piece GetPieceAtBoardPosPOVAdjusted(int row, int col)
        {
            if (row < 0 || row >= BoardLenght)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }

            if (col < 0 || col >= BoardLenght)
            {
                throw new ArgumentOutOfRangeException(nameof(col));
            }

            if (View == View.BlackPOV)
            {
                return board[row, col];
            }

            return board[BoardLenght - 1 - row, BoardLenght - 1 - col];
        }

        /// <summary>
        /// This function is run when the player clicks a square with the left button
        /// </summary>
        /// <param name="row">The row of the clicked square</param>
        /// <param name="col">The column of the clicked square</param>
        /// <returns>
        /// True if something happend with the board, false otherwise.
        /// This value is used to check if the board needs redrawing.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool SelectPieceOrMoveSelected(int row, int col)
        {
            if (row < 0 || row >= BoardLenght)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }

            if (col < 0 || col >= BoardLenght)
            {
                throw new ArgumentOutOfRangeException(nameof(col));
            }

            // If the view is from white player's perspective, the indices of pieces are inverted, so we're returning them to normal
            if (View == View.WhitePOV)
            {
                row = BoardLenght - 1 - row;
                col = BoardLenght - 1 - col;
            }

            // If a piece is selected, an attemp to move that piece was made, so we're checking if that's possible
            if (selectedPiece.IsSelected())
            {
                BoardIndex squareToMoveTo = new(row, col);
                List<BoardIndex> availableMoves = GetAvailableMoves(selectedPiece, board);

                if (availableMoves.Contains(squareToMoveTo))
                {
                    int selectedRow = selectedPiece.Row;
                    int selectedCol = selectedPiece.Col;

                    Piece chosenSquareOldVal = board[row, col];
                    Piece selectedPieceSquareOldVal = board[selectedRow, selectedCol];

                    if (board[row, col] == Piece.None)
                    {
                        (board[row, col], board[selectedRow, selectedCol]) = (board[selectedRow, selectedCol], board[row, col]);
                    }
                    else
                    {
                        (board[row, col], board[selectedRow, selectedCol]) = (board[selectedRow, selectedCol], Piece.None);
                    }

                    if (IsInCheck(board[row, col].GetColor(), board))
                    {
                        MessageBox.Show("If you move there, your king will be in check", "Can't go there");
                        board[row, col] = chosenSquareOldVal;
                        board[selectedRow, selectedCol] = selectedPieceSquareOldVal;
                        selectedPiece.Unselect();
                        return true;
                    }

                    if ((board[row, col] == Piece.WhitePawn && row == RowNumToArrayIndex(8)) ||
                        (board[row, col] == Piece.BlackPawn && row == RowNumToArrayIndex(1)))
                    {
                        using PromotePawnForm ppf = new(board[row, col].GetColor());
                        ppf.ShowDialog();
                        board[row, col] = ppf.ChosenPiece;
                    }

                    PieceColor oppositeColor = (board[row, col].IsWhite() ? PieceColor.Black : PieceColor.White);

                    if (CheckIfThereAreNoAvailableMoves(oppositeColor))
                    {
                        if (IsInCheck(oppositeColor, board))
                        {
                            MainForm.IsCheckmate = true;
                            MainForm.WhoWon = board[row, col].GetColor();
                        }
                        else
                        {
                            MainForm.IsStalemate = true;
                        }
                    }

                    BoardChanged = true;
                    SwapTurn();
                    selectedPiece.Unselect();
                    return true;
                }
                else  // if (availableMoves.Contains(squareToMoveTo))
                {
                    if (board[row, col] == Piece.None || (RespectMoveRights && board[row, col].GetColor() != WhoseTurn))
                    {
                        selectedPiece.Unselect();
                    }
                    else
                    {
                        selectedPiece.Select(row, col);
                    }

                    return true;
                }
            }
            else  // if (selectedPiece.IsSelected())
            {
                if (board[row, col] == Piece.None || (RespectMoveRights && board[row, col].GetColor() != WhoseTurn))
                {
                    return false;
                }

                selectedPiece.Select(row, col);
                return true;
            }
        }

        /// <returns>
        /// 'true' if the unselecting had any effect (if a piece was selected when unselecting), 'false' otherwise.
        /// This value is used to check if there is a need to redraw the board when the user attempts to unselect the piece.
        /// </returns>
        public static bool UnselectPiece()
        {
            if (!selectedPiece.IsSelected())
            {
                return false;
            }

            selectedPiece.Unselect();
            return true;
        }

        private static int ColumnMarkToArrayIndex(char col)
        {
            if (col < 'A' || col > 'H')
            {
                throw new ArgumentOutOfRangeException(nameof(col));
            }

            return col - 'A';
        }

        private static int RowNumToArrayIndex(int row)
        {
            if (row < 1 || row > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }

            return row - 1;
        }

        public static bool IsInCheck(PieceColor kingsColor, Piece[,] boardToUse)
        {
            Piece kingToSearchFor = (kingsColor == PieceColor.White ? Piece.WhiteKing : Piece.BlackKing);
            PieceColor oppositeColor = (kingsColor == PieceColor.White ? PieceColor.Black : PieceColor.White);
            BoardIndex kingIndex = new();

            bool goOn = true;
            for (int i = 0; i < BoardLenght && goOn; i++)
            {
                for (int j = 0; j < BoardLenght; j++)
                {
                    if (boardToUse[i, j] == kingToSearchFor)
                    {
                        kingIndex.Select(i, j);
                        goOn = false;
                        break;
                    }
                }
            }

            if (!kingIndex.IsSelected())
            {
                throw new Exception($"{(kingToSearchFor == Piece.WhiteKing ? "White" : "Black")} king not found");
            }

            for (int i = 0; i < BoardLenght; i++)
            {
                for (int j = 0; j < BoardLenght; j++)
                {
                    // Checks if the pieces of the opposite color can attack the king
                    if (boardToUse[i, j].GetColor() == oppositeColor)
                    {
                        List<BoardIndex> pieceAvailableSquares = GetAvailableMoves(new(i, j), boardToUse);

                        if (pieceAvailableSquares.Contains(kingIndex))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check if you can move without leaving your king in check.
        /// In other words, check if it's remi or checkmate
        /// </summary>
        /// <param name="side">Tells for which side to do the checking</param>
        /// <returns></returns>
        private static bool CheckIfThereAreNoAvailableMoves(PieceColor side)
        {
            Piece[,] tempBoard = new Piece[BoardLenght, BoardLenght];

            for (int i = 0; i < BoardLenght; i++)
            {
                for (int j = 0; j < BoardLenght; j++)
                {
                    tempBoard[i, j] = board[i, j];
                }
            }

            // This loop below checks for every possible move of every piece of the checked side, and if all those moves
            // result in check, it means there are no possible and true is returned. If a possible move is found, false is returned in foreach
            for (int i = 0; i < BoardLenght; i++)
            {
                for (int j = 0; j < BoardLenght; j++)
                {
                    if (board[i, j].GetColor() == side)
                    {
                        List<BoardIndex> availableMoves = GetAvailableMoves(new(i, j), board);

                        foreach (var move in availableMoves)
                        {
                            Piece ijOldVal = tempBoard[i, j];
                            Piece moveRowMoveColOldVal = tempBoard[move.Row, move.Col];

                            if (moveRowMoveColOldVal == Piece.None)
                            {
                                (tempBoard[i, j], tempBoard[move.Row, move.Col]) = (tempBoard[move.Row, move.Col], tempBoard[i, j]);
                            }
                            else
                            {
                                (tempBoard[i, j], tempBoard[move.Row, move.Col]) = (Piece.None, tempBoard[i, j]);
                            }

                            if (!IsInCheck(side, tempBoard))
                            {
                                return false;
                            }

                            tempBoard[i, j] = ijOldVal;
                            tempBoard[move.Row, move.Col] = moveRowMoveColOldVal;
                        }
                    }
                }
            }

            return true;
        }

        public static List<BoardIndex> GetAvailableMoves(BoardIndex piece, Piece[,] boardToUse)
        {
            List<BoardIndex> availableMoves = [];

            // The return value is used in loops for pieces that can move further than one square. If the return value is false,
            // it means the piece can't go further in the direction you are checking and the loop breaks (see below)
            bool checkSquare(int row, int col)
            {
                if (row < 0 || row >= BoardLenght || col < 0 || col >= BoardLenght)
                {
                    return false;
                }

                if (boardToUse[row, col] == Piece.None)
                {
                    availableMoves.Add(new(row, col));
                    return true;
                }

                // If you get to the opponent piece, you can take it but can't go any further, so false is returned to indicate that
                if (boardToUse[piece.Row, piece.Col].GetColor() == PieceColor.White ?
                    boardToUse[row, col].IsBlack() : boardToUse[row, col].IsWhite())
                {
                    availableMoves.Add(new(row, col));
                    return false;
                }

                return false;
            }

            switch (boardToUse[piece.Row, piece.Col])
            {
                case Piece.WhitePawn:
                    if (piece.Row != RowNumToArrayIndex(8) && boardToUse[piece.Row + 1, piece.Col] == Piece.None)
                    {
                        availableMoves.Add(new(piece.Row + 1, piece.Col));
                    }

                    if (piece.Row == RowNumToArrayIndex(2) && boardToUse[piece.Row + 2, piece.Col] == Piece.None)
                    {
                        availableMoves.Add(new(piece.Row + 2, piece.Col));
                    }

                    if (piece.Row != RowNumToArrayIndex(8) && piece.Col != ColumnMarkToArrayIndex('H') &&
                        boardToUse[piece.Row + 1, piece.Col + 1].IsBlack())
                    {
                        availableMoves.Add(new(piece.Row + 1, piece.Col + 1));
                    }

                    if (piece.Row != RowNumToArrayIndex(8) && piece.Col != ColumnMarkToArrayIndex('A') &&
                        boardToUse[piece.Row + 1, piece.Col - 1].IsBlack())
                    {
                        availableMoves.Add(new(piece.Row + 1, piece.Col - 1));
                    }

                    break;

                case Piece.BlackPawn:
                    if (piece.Row != RowNumToArrayIndex(1) && boardToUse[piece.Row - 1, piece.Col] == Piece.None)
                    {
                        availableMoves.Add(new(piece.Row - 1, piece.Col));
                    }

                    if (piece.Row == RowNumToArrayIndex(7) && boardToUse[piece.Row - 2, piece.Col] == Piece.None)
                    {
                        availableMoves.Add(new(piece.Row - 2, piece.Col));
                    }

                    if (piece.Row != RowNumToArrayIndex(1) && piece.Col != ColumnMarkToArrayIndex('H') &&
                        boardToUse[piece.Row - 1, piece.Col + 1].IsWhite())
                    {
                        availableMoves.Add(new(piece.Row - 1, piece.Col + 1));
                    }

                    if (piece.Row != RowNumToArrayIndex(1) && piece.Col != ColumnMarkToArrayIndex('A') &&
                        boardToUse[piece.Row - 1, piece.Col - 1].IsWhite())
                    {
                        availableMoves.Add(new(piece.Row - 1, piece.Col - 1));
                    }

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
                    for (int row = piece.Row - 1; row >= 0; row--)          { if (!checkSquare(row, piece.Col)) break; }
                    for (int col = piece.Col + 1; col < BoardLenght; col++) { if (!checkSquare(piece.Row, col)) break; }
                    for (int col = piece.Col - 1; col >= 0; col--)          { if (!checkSquare(piece.Row, col)) break; }
                    break;

                case Piece.WhiteKing:
                case Piece.BlackKing:
                    checkSquare(piece.Row + 1, piece.Col + 1);
                    checkSquare(piece.Row + 1, piece.Col - 1);
                    checkSquare(piece.Row - 1, piece.Col + 1);
                    checkSquare(piece.Row - 1, piece.Col - 1);
                    checkSquare(piece.Row + 1, piece.Col);
                    checkSquare(piece.Row - 1, piece.Col);
                    checkSquare(piece.Row, piece.Col + 1);
                    checkSquare(piece.Row, piece.Col - 1);
                    break;
            }

            return availableMoves;
        }
    }
}
