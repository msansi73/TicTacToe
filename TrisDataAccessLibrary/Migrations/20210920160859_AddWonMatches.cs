using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacToeDataAccessLibrary.Migrations
{
    public partial class AddWonMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WonMatches",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WonMatches",
                table: "AspNetUsers");
        }
    }
}
