using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorEmailAddress",
                table: "InstructorTable");

            migrationBuilder.RenameColumn(
                name: "InstructorName",
                table: "InstructorTable",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "AuthId",
                table: "InstructorTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "InstructorTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "InstructorTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "InstructorTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "InstructorTable",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "InstructorTable");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "InstructorTable");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "InstructorTable");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "InstructorTable");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "InstructorTable");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "InstructorTable",
                newName: "InstructorName");

            migrationBuilder.AddColumn<string>(
                name: "InstructorEmailAddress",
                table: "InstructorTable",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
