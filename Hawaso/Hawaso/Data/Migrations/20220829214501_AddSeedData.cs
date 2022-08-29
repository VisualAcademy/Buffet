using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hawaso.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Broths",
                columns: new[] { "Id", "IsVegan", "Name" },
                values: new object[,]
                {
                    { 1, true, "콩국물" },
                    { 2, false, "멸치국물" }
                });

            migrationBuilder.InsertData(
                table: "Noodles",
                columns: new[] { "Id", "BrothId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "콩국수" },
                    { 2, 2, "잔치국수" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Noodles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Noodles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Broths",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Broths",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
