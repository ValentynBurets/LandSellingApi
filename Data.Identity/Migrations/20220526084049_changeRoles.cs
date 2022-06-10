using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Identity.Migrations
{
    public partial class changeRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f09e47ac-df6d-4194-9f2b-1f0ada3817bb", "c43162c5-f743-4b7b-88dd-28071a44e256", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "663753d7-4cef-41af-b5ee-e6a2b27032e7", "22121a15-d877-489f-8ffc-1debf029c3a8", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
