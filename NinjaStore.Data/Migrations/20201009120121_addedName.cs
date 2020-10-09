using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Data.Migrations
{
    public partial class addedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Equipment",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Equipment");
        }
    }
}