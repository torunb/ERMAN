using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class studentPlacements1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentPlacements",
                columns: table => new
                {
                    PlacementId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    StudentFirstName = table.Column<string>(type: "text", nullable: false),
                    StudentLastName = table.Column<string>(type: "text", nullable: false),
                    TranscriptGradeFromFour = table.Column<double>(type: "double precision", nullable: false),
                    TranscriptGradeFromHundred = table.Column<double>(type: "double precision", nullable: false),
                    TranscriptGradeContribution = table.Column<double>(type: "double precision", nullable: false),
                    ErasmusApplicationWithGradesBehindSeUe = table.Column<double>(type: "double precision", nullable: false),
                    UESECount = table.Column<int>(type: "integer", nullable: false),
                    UECGPA = table.Column<int>(type: "integer", nullable: false),
                    Eng101 = table.Column<string>(type: "text", nullable: false),
                    Eng102 = table.Column<string>(type: "text", nullable: false),
                    LanguagePoints = table.Column<double>(type: "double precision", nullable: false),
                    TranscriptPoints = table.Column<double>(type: "double precision", nullable: false),
                    TotalPoints = table.Column<double>(type: "double precision", nullable: false),
                    DurationPrefered = table.Column<string>(type: "text", nullable: false),
                    UniversityChoices = table.Column<string[]>(type: "text[]", nullable: false),
                    IsInWaitingList = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPlacements", x => x.PlacementId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentPlacements");
        }
    }
}
