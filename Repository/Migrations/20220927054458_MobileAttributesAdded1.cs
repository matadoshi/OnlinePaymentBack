using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class MobileAttributesAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Mobiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Mobiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
