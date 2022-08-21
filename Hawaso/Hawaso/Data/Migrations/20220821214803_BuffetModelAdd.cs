using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hawaso.Data.Migrations
{
    /// <inheritdoc />
    public partial class BuffetModelAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Broths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsVegan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noodles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BrothId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noodles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noodles_Broths_BrothId",
                        column: x => x.BrothId,
                        principalTable: "Broths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garnishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NoodleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garnishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garnishes_Noodles_NoodleId",
                        column: x => x.NoodleId,
                        principalTable: "Noodles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garnishes_NoodleId",
                table: "Garnishes",
                column: "NoodleId");

            migrationBuilder.CreateIndex(
                name: "IX_Noodles_BrothId",
                table: "Noodles",
                column: "BrothId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garnishes");

            migrationBuilder.DropTable(
                name: "Noodles");

            migrationBuilder.DropTable(
                name: "Broths");
        }
    }
}
