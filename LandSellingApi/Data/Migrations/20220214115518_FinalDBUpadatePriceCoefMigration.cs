using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FinalDBUpadatePriceCoefMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Customers_BidderId",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Sellings_SellingId",
                table: "Bid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bid",
                table: "Bid");

            migrationBuilder.RenameTable(
                name: "Bid",
                newName: "Bids");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_SellingId",
                table: "Bids",
                newName: "IX_Bids_SellingId");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_Id",
                table: "Bids",
                newName: "IX_Bids_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_BidderId",
                table: "Bids",
                newName: "IX_Bids_BidderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bids",
                table: "Bids",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Customers_BidderId",
                table: "Bids",
                column: "BidderId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Sellings_SellingId",
                table: "Bids",
                column: "SellingId",
                principalTable: "Sellings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Customers_BidderId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Sellings_SellingId",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bids",
                table: "Bids");

            migrationBuilder.RenameTable(
                name: "Bids",
                newName: "Bid");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_SellingId",
                table: "Bid",
                newName: "IX_Bid_SellingId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_Id",
                table: "Bid",
                newName: "IX_Bid_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_BidderId",
                table: "Bid",
                newName: "IX_Bid_BidderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bid",
                table: "Bid",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Customers_BidderId",
                table: "Bid",
                column: "BidderId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Sellings_SellingId",
                table: "Bid",
                column: "SellingId",
                principalTable: "Sellings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
