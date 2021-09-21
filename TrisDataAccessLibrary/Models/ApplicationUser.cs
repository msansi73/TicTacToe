using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicTacToeDataAccessLibrary.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DefaultValue(0)]
        public int WonMatches { get; set; }
    }
}