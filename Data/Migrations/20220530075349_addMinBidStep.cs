using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addMinBidStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MinBidStep",
                table: "Lots",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinBidStep",
                table: "Lots");
        }
    }
}
