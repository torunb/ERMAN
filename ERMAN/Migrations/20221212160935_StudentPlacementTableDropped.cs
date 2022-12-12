using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class StudentPlacementTableDropped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentPlacements");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "StudentTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ranking",
                table: "StudentTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPoints",
                table: "StudentTable",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "StudentTable");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Course",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "StudentPlacements",
                columns: table => new
                {
                    PlacementId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Degree = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    DurationPrefered = table.Column<string>(type: "text", nullable: false),
                    Eng101 = table.Column<string>(type: "text", nullable: false),
                    Eng102 = table.Column<string>(type: "text", nullable: false),
                    ErasmusApplicationWithGradesBehindSeUe = table.Column<double>(type: "double precision", nullable: false),
                    Faculty = table.Column<string>(type: "text", nullable: false),
                    IsInWaitingList = table.Column<bool>(type: "boolean", nullable: false),
                    LanguagePoints = table.Column<double>(type: "double precision", nullable: false),
                    StudentFirstName = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    StudentLastName = table.Column<string>(type: "text", nullable: false),
                    TotalPoints = table.Column<double>(type: "double precision", nullable: false),
                    TranscriptGradeContribution = table.Column<double>(type: "double precision", nullable: false),
                    TranscriptGradeFromFour = table.Column<double>(type: "double precision", nullable: false),
                    TranscriptGradeFromHundred = table.Column<double>(type: "double precision", nullable: false),
                    TranscriptPoints = table.Column<double>(type: "double precision", nullable: false),
                    UECGPA = table.Column<double>(type: "double precision", nullable: false),
                    UESECount = table.Column<int>(type: "integer", nullable: false),
                    UniversityChoices = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPlacements", x => x.PlacementId);
                });
        }
    }
}
