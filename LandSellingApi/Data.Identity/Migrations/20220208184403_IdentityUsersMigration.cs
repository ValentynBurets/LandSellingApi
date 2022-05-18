using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Identity.Migrations
{
    public partial class IdentityUsersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1726dd7-76bf-41b2-b692-0503c4720752");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be01da68-d3d0-47e5-88ee-f6f01b9dc1da", "72df7551-726d-45f7-a418-e7db754d0b05", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6401e6d0-2b3c-4b58-ac90-03d50e223c2c", "e543ff03-f751-4ef8-9521-fdf1364d4910", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "867f4bcc-6e1a-4dd1-95da-8068931f96e7", "0b666430-85f7-449d-a618-147e3e676cd3", "Manager", "MANA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6401e6d0-2b3c-4b58-ac90-03d50e223c2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "867f4bcc-6e1a-4dd1-95da-8068931f96e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be01da68-d3d0-47e5-88ee-f6f01b9dc1da");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1726dd7-76bf-41b2-b692-0503c4720752", "43834ddd-138f-4f5a-8c4a-7711c64d3e77", "Manager", "MANAGER" });
        }
    }
}
