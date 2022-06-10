using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addmanyAgreements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agreements_LotId",
                table: "Agreements");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_LotId",
                table: "Agreements",
                column: "LotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agreements_LotId",
                table: "Agreements");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_LotId",
                table: "Agreements",
                column: "LotId",
                unique: true);
        }
    }
}
