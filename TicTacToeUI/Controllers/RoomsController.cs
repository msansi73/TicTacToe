using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeDataAccessLibrary.DataAccess;
using TicTacToeDataAccessLibrary.Models;
using TicTacToeUI.Hubs;
using TicTacToeUI.Models;

namespace TicTacToeUI.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHubContext<RoomHub> roomHub;

        public RoomsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHubContext<RoomHub> roomHub)
        {
            this.context = context;
            this.userManager = userManager;
            this.roomHub = roomHub;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await context.Rooms.Where(r => r.PlayerA == null || r.PlayerB == null).ToModel().ToListAsync();
            return View(rooms);
        }

        public async Task<IActionResult> Create()
        {
            Room room = new();
            Match match = new();
            room.Match = match;
            await context.Rooms.AddAsync(room);
            await context.Matches.AddAsync(match);
            await context.SaveChangesAsync();
            return RedirectToAction("Room", new { id = room.Id });
        }

        public async Task<IActionResult> Leaderboard()
        {
            var user = await context.ApplicationUsers.ToModel().OrderByDescending(u => u.WonMatches).ToListAsync();

            return View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) return NotFound();

            var room = await context.Rooms.FirstAsync(r => r.Id == id);

            context.Rooms.Remove(room);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Room(int? id)
        {
            if (!id.HasValue) return NotFound();

            var room = await context.Rooms.ToModel().FirstAsync(r => r.Id == id);
            ApplicationUser user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                if (room.PlayerA == null)
                {
                    room.PlayerA = user.UserName;
                    (await context.Rooms.FirstAsync(r => r.Id == id)).PlayerA = user;
                    await context.SaveChangesAsync();
                    await roomHub.Clients.All.SendAsync("JoinMessage", user.UserName, 1, id);
                    Console.Write("Inviato messaggio 1...");
                }
                else if (room.PlayerB == null && room.PlayerA != user.UserName)
                {
                    room.PlayerB = user.UserName;
                    (await context.Rooms.FirstAsync(r => r.Id == id)).PlayerB = user;
                    await context.SaveChangesAsync();
                    await roomHub.Clients.All.SendAsync("JoinMessage", user.UserName, 2, id);
                    Console.Write("Inviato messaggio 2...");
                }
            }

            return View(room);
        }
    }
}