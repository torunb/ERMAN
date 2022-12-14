using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class PlacementStudentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlacementStudentId",
                table: "UniversityTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlacementStudentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    StudentId = table.Column<string>(type: "text", nullable: true),
                    Faculty = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Degree = table.Column<string>(type: "text", nullable: true),
                    TotalPoints = table.Column<string>(type: "text", nullable: true),
                    DurationPreferred = table.Column<string>(type: "text", nullable: true),
                    Ranking = table.Column<int>(type: "integer", nullable: true),
                    UniversityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementStudentTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacementStudentTable_UniversityTable_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "UniversityTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTable_PlacementStudentId",
                table: "UniversityTable",
                column: "PlacementStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementStudentTable_UniversityId",
                table: "PlacementStudentTable",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityTable_PlacementStudentTable_PlacementStudentId",
                table: "UniversityTable",
                column: "PlacementStudentId",
                principalTable: "PlacementStudentTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniversityTable_PlacementStudentTable_PlacementStudentId",
                table: "UniversityTable");

            migrationBuilder.DropTable(
                name: "PlacementStudentTable");

            migrationBuilder.DropIndex(
                name: "IX_UniversityTable_PlacementStudentId",
                table: "UniversityTable");

            migrationBuilder.DropColumn(
                name: "PlacementStudentId",
                table: "UniversityTable");
        }
    }
}
