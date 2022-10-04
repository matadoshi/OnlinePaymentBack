using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Com2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Attributes_AttributesId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_AttributesId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AttributesId",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_AttributeId",
                table: "Invoice",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Attributes_AttributeId",
                table: "Invoice",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Attributes_AttributeId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_AttributeId",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "AttributesId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_AttributesId",
                table: "Invoice",
                column: "AttributesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Attributes_AttributesId",
                table: "Invoice",
                column: "AttributesId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
