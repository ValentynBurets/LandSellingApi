using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addIsSelectedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "PriceCoefs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "PriceCoefs");
        }
    }
}
