using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateAgreementTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "AgreementManagers");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Agreements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Agreements");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "AgreementManagers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
