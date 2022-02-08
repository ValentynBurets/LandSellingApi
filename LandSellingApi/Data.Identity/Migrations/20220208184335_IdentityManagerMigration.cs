using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Identity.Migrations
{
    public partial class IdentityManagerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02169966-0ae9-4802-a0f0-99b799ae16e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3590b45-2fb7-4b77-8631-df7c25b4b4b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1726dd7-76bf-41b2-b692-0503c4720752", "43834ddd-138f-4f5a-8c4a-7711c64d3e77", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1726dd7-76bf-41b2-b692-0503c4720752");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02169966-0ae9-4802-a0f0-99b799ae16e4", "d51d0d43-5021-4457-b52c-96d1775df08e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3590b45-2fb7-4b77-8631-df7c25b4b4b7", "d380bac0-b659-40e4-ada3-5fc2c566faab", "Admin", "ADMIN" });
        }
    }
}
