using System.ComponentModel.DataAnnotations;

namespace TicTacToeDataAccessLibrary.Models
{
    public class Room
    {
        [Required]
        public int Id { get; set; }
        public ApplicationUser PlayerA { get; set; }
        public ApplicationUser PlayerB { get; set; }
        public Match Match { get; set; }
    }
}