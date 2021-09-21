using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeDataAccessLibrary.Models;

namespace TicTacToeUI.Models
{
    public static class RoomExtensions
    {
        public static IQueryable<RoomModel> ToModel(this IQueryable<Room> source)
            => source.Select(room =>
                new RoomModel()
                {
                    Id = room.Id,
                    PlayerA = room.PlayerA.UserName,
                    PlayerB = room.PlayerB.UserName,
                    Board = Match.StringToBoard(room.Match.BoardString),
                    Winner = room.Match.Winner,
                    TurnPiece = room.Match.TurnPiece
                });
    }

    public class RoomModel
    {
        public int Id { get; set; }
        public int JoinedPlayers => (PlayerA != null ? 1 : 0) + (PlayerB != null ? 1 : 0);
        public string PlayerA { get; set; }
        public string PlayerB { get; set; }

        public Match.Piece[,] Board { get; set; } = new Match.Piece[3, 3];
        public Match.Piece TurnPiece { get; set; } = Match.Piece.X;
        public Match.Piece Winner { get; set; } = Match.Piece.None;
    }
}