using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeDataAccessLibrary.Models;

namespace TicTacToeUI.Models
{
    public static class ApplicationUserExtensions
    {
        public static IQueryable<ApplicationUserModel> ToModel(this IQueryable<ApplicationUser> source)
            => source.Select(user =>
                new ApplicationUserModel()
                {
                    Name = user.UserName,
                    WonMatches = user.WonMatches,
                });
    }

    public class ApplicationUserModel
    {
        public string Name { get; set; }
        public int WonMatches { get; set; }
    }
}