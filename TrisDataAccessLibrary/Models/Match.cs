using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace TicTacToeDataAccessLibrary.Models
{
    public class Match
    {
        public enum Piece { None, X, O }

        [Required]
        public int Id { get; set; }

        [NotMapped]
        public Piece[,] Board { get; private set; } = new Piece[3, 3];

        [Required]
        public Piece TurnPiece { get; private set; } = Piece.X;

        [Required]
        public Piece Winner { get; private set; } = Piece.None;

        [Required]
        [StringLength(9)]
        public string BoardString { get; set; } = new(' ', 9);

        public bool IsADraw => !BoardString.Contains(' ');

        public Match() { }

        /// <summary>
        /// If empty, place the turnPiece on the board at the selected coords.
        /// </summary>
        public bool Move(Point coords)
        {
            Board = StringToBoard(BoardString);
            if (IsOnBoard(coords) && BoardString[3 * coords.Y + coords.X] == ' ')
            {
                Board[coords.X, coords.Y] = TurnPiece;
                BoardString = GetUpdatedBoardString(coords);
                Winner = WinnerPiece();
                TurnPiece = GetNextTurnPiece();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if someone have won the mech. Otherways it returns Piece.None
        /// </summary>
        public Piece WinnerPiece()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, i] != Piece.None &&
                   ((Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2]) ||
                   (Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i])))
                    return Board[i, i];
            }

            if (Board[1, 1] != Piece.None && (
                (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2]) ||
                (Board[2, 0] == Board[1, 1] && Board[1, 1] == Board[0, 2])))
                return Board[1, 1];

            return Piece.None;
        }

        public override string ToString()
        {
            string s = "";
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                    s += Board[x, y] == Piece.X ? "X" : Board[x, y] == Piece.O ? "O" : " ";
            return s;
        }

        private string GetUpdatedBoardString(Point lastMoveCoord)
        {
            StringBuilder updatedString = new(BoardString);
            int stringIndex = lastMoveCoord.Y * 3 + lastMoveCoord.X;
            char charPiece = TurnPiece switch
            {
                Piece.X => 'X',
                Piece.O => 'O',
                _ => ' '
            };
            updatedString[stringIndex] = charPiece;
            return updatedString.ToString();
        }

        public static Piece[,] StringToBoard(string s)
        {
            Piece[,] board = new Piece[3, 3];
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                {
                    char c = s[3 * y + x];
                    board[x, y] = c == 'X' ? Piece.X : c == 'O' ? Piece.O : Piece.None;
                }
            return board;
        }

        /// <summary>
        /// Checks if a piece is on the board.
        /// </summary>
        private static bool IsOnBoard(Point coords)
            => coords.X < 3 || coords.Y < 3 || coords.X >= 0 || coords.Y >= 0;

        /// <summary>
        /// Returns the next turn's piece.
        /// </summary>
        /// <returns></returns>
        private Piece GetNextTurnPiece()
            => TurnPiece == Piece.X ? Piece.O : Piece.X;
    }
}