using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roulette.Migrations
{
    public partial class AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PaidOut",
                table: "Spins",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Match",
                table: "Bets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Payout",
                table: "Bets",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidOut",
                table: "Spins");

            migrationBuilder.DropColumn(
                name: "Match",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Payout",
                table: "Bets");
        }
    }
}
