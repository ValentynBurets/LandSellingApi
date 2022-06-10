using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addMonthCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DaysCount",
                table: "PriceCoefs",
                newName: "MonthCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthCount",
                table: "PriceCoefs",
                newName: "DaysCount");
        }
    }
}
