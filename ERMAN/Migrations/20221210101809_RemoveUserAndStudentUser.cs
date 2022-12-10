using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserAndStudentUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUserTable");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "StudentTable");

            migrationBuilder.RenameColumn(
                name: "StudentEmailAddress",
                table: "StudentTable",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "UniversityTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRejected",
                table: "StudentTable",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<int>(
                name: "DurationPreffered",
                table: "StudentTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StudentTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Program",
                table: "StudentTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "StudentPlacements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "StudentPlacements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "StudentPlacements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTable_StudentId",
                table: "UniversityTable",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityTable_StudentTable_StudentId",
                table: "UniversityTable",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniversityTable_StudentTable_StudentId",
                table: "UniversityTable");

            migrationBuilder.DropIndex(
                name: "IX_UniversityTable_StudentId",
                table: "UniversityTable");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "UniversityTable");

            migrationBuilder.DropColumn(
                name: "DurationPreffered",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "Program",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "StudentPlacements");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "StudentPlacements");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "StudentPlacements");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "StudentTable",
                newName: "StudentEmailAddress");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRejected",
                table: "StudentTable",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "StudentTable",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StudentUserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUserTable_StudentTable_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BilkentId = table.Column<int>(type: "integer", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    DurationPreffered = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Faculty = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    InsrtDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Program = table.Column<string>(type: "text", nullable: false),
                    University = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserTable_StudentId",
                table: "StudentUserTable",
                column: "StudentId");
        }
    }
}
