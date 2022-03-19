using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Identity.Migrations
{
    public partial class IdentityUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "a8e9f3d4-89e5-46fb-b239-a7239ffab06c", "41a6e97b-1fe5-4fbd-b207-854ee2201951", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "928162a0-b868-4155-afd9-06a478ffcd6d", "8ba5bf8d-e866-4468-857c-f1cbbc02867e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1031149f-9b7c-43fe-a26c-e1f27f89f915", "c0e7e87f-cb23-4bce-9669-0bb8d33274be", "Manager", "MANA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1031149f-9b7c-43fe-a26c-e1f27f89f915");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "928162a0-b868-4155-afd9-06a478ffcd6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8e9f3d4-89e5-46fb-b239-a7239ffab06c");

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
    }
}
