using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddManyToManyRelation_BetweenLotAndAdminTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Admins_ManagerId",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_ManagerId",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Lots");

            migrationBuilder.CreateTable(
                name: "LotManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotManagers_Admins_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotManagers_Lots_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LotManagers_Id",
                table: "LotManagers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LotManagers_ManagerId",
                table: "LotManagers",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LotManagers");

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Lots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Lots_ManagerId",
                table: "Lots",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Admins_ManagerId",
                table: "Lots",
                column: "ManagerId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
