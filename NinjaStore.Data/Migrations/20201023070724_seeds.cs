using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Data.Migrations
{
    public partial class seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "EquipmentId", "Agility", "Category", "Intelligence", "Name", "Strength", "Value" },
                values: new object[,]
                {
                    { 1, 40, 0, 40, "Petje", 30, 100 },
                    { 2, 86, 3, 34, "Broek", 32, 150 },
                    { 3, 18, 0, 40, "Hoed", 16, 200 },
                    { 4, 10, 5, 10, "Kettingkje", 60, 50 },
                    { 5, 49, 3, 309, "Crocs", 98, 100 },
                    { 6, 56, 4, 86, "Vuurring", 453, 200 },
                    { 7, 76, 2, 122, "Schoenhand", 80, 300 },
                    { 8, 469, 1, 67, "Shirt", 76, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 8);
        }
    }
}
