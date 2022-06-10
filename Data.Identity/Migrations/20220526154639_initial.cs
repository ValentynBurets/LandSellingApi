using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Identity.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "663753d7-4cef-41af-b5ee-e6a2b27032e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09e47ac-df6d-4194-9f2b-1f0ada3817bb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6303504-9218-4a0e-9b53-cc6f940d4924", "ab66ee31-9468-4763-a28b-ed7af29c9cf7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f93fd516-a238-40c1-a2a1-ced8dba7e48b", "2d6afa0b-dc0c-4f0c-89ba-79321dc8860f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6303504-9218-4a0e-9b53-cc6f940d4924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f93fd516-a238-40c1-a2a1-ced8dba7e48b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f09e47ac-df6d-4194-9f2b-1f0ada3817bb", "c43162c5-f743-4b7b-88dd-28071a44e256", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "663753d7-4cef-41af-b5ee-e6a2b27032e7", "22121a15-d877-489f-8ffc-1debf029c3a8", "Admin", "ADMIN" });
        }
    }
}
