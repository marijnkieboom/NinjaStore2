using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Data.Migrations
{
	public partial class enumtest : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "Category",
				table: "Equipment",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Category",
				table: "Equipment",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(int));
		}
	}
}
