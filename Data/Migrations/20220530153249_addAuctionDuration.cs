using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addAuctionDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuctionDuration",
                table: "Lots",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuctionDuration",
                table: "Lots");
        }
    }
}
