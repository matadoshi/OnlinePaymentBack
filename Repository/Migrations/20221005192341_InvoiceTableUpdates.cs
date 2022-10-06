using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InvoiceTableUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CardId",
                table: "Invoices",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Cards_CardId",
                table: "Invoices",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Cards_CardId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CardId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Invoices");
        }
    }
}
