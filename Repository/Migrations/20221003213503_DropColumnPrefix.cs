using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class DropColumnPrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Attributes");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Attributes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Attributes");

            migrationBuilder.AddColumn<int>(
                name: "Prefix",
                table: "Attributes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
