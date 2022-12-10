using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStudentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StudentTable",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "StudentTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthId",
                table: "StudentTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "StudentTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "StudentTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "StudentTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "StudentTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentTable_UniversityId",
                table: "StudentTable",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTable_UniversityTable_UniversityId",
                table: "StudentTable",
                column: "UniversityId",
                principalTable: "UniversityTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTable_UniversityTable_UniversityId",
                table: "StudentTable");

            migrationBuilder.DropIndex(
                name: "IX_StudentTable_UniversityId",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "StudentTable");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "StudentTable");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "StudentTable",
                newName: "Name");
        }
    }
}
