using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddManyToManyRelation_BetweenAgreementAndAdminTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "LotManagers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AgreementManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgreementManagers_Admins_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgreementManagers_Agreements_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Agreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgreementManagers_Id",
                table: "AgreementManagers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgreementManagers_ManagerId",
                table: "AgreementManagers",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgreementManagers");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "LotManagers");
        }
    }
}
