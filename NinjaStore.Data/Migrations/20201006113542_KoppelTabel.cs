using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Data.Migrations
{
    public partial class KoppelTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Ninjas_NinjaName",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_NinjaName",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "NinjaName",
                table: "Equipment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NinjaName",
                table: "Equipment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_NinjaName",
                table: "Equipment",
                column: "NinjaName");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Ninjas_NinjaName",
                table: "Equipment",
                column: "NinjaName",
                principalTable: "Ninjas",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
