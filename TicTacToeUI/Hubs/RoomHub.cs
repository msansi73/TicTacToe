using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeDataAccessLibrary.DataAccess;
using TicTacToeDataAccessLibrary.Models;

namespace TicTacToeUI.Hubs
{
    public class RoomHub : Hub
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public RoomHub(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task JoinMessage(string username, int playerNumber, int roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            await Clients.Group(roomId.ToString()).SendAsync("JoinMessage", username, playerNumber);
        }

        public async Task Move(int roomId, int piece, int x, int y)
        {
            ApplicationUser user = await userManager.GetUserAsync(Context.User);
            var room = context.Rooms
                .Include(r => r.Match)
                .Where(r => r.PlayerA == user || r.PlayerB == user)
                .First(r => r.Id == roomId);

            if (room != null && ((room.PlayerA == user && (Match.Piece)piece == Match.Piece.X) || (room.PlayerB == user && (Match.Piece)piece == Match.Piece.O)) && room.Match.TurnPiece == (Match.Piece)piece && room.Match.Move(new(x, y)))
            {
                
                await Clients.Group(roomId.ToString()).SendAsync("Move", roomId, piece, x, y);

                if (room.Match.IsADraw)
                    await Clients.Group(roomId.ToString()).SendAsync("Draw");
                else if (room.Match.Winner != Match.Piece.None)
                {
                    await Clients.Group(roomId.ToString()).SendAsync("Win", (int)room.Match.Winner);
                    (room.Match.Winner == Match.Piece.X ? room.PlayerA : room.PlayerB).WonMatches++;
                }
                await context.SaveChangesAsync();
            }
        }
    }
}