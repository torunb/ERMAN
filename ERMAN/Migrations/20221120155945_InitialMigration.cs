using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoordinatorTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CoordinatorEmailAddress = table.Column<string>(type: "text", nullable: false),
                    CoordinatorName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CoordinatorId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinatorTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaqTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstructorTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstructorEmailAddress = table.Column<string>(type: "text", nullable: false),
                    InstructorName = table.Column<string>(type: "text", nullable: false),
                    InstructorId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentEmailAddress = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    StudentName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    IsRejected = table.Column<bool>(type: "boolean", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Starred = table.Column<bool>(type: "boolean", nullable: false),
                    DueDate = table.Column<string>(type: "text", nullable: false),
                    Done = table.Column<bool>(type: "boolean", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversityName = table.Column<string>(type: "text", nullable: false),
                    UniversityCapacity = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoordinatorTable");

            migrationBuilder.DropTable(
                name: "FaqTable");

            migrationBuilder.DropTable(
                name: "InstructorTable");

            migrationBuilder.DropTable(
                name: "StudentTable");

            migrationBuilder.DropTable(
                name: "TodoTable");

            migrationBuilder.DropTable(
                name: "UniversityTable");
        }
    }
}
