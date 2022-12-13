using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class AddFacultyAndDepartmentToCoordinator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoordinatorName",
                table: "CoordinatorTable",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "CoordinatorId",
                table: "CoordinatorTable",
                newName: "AuthId");

            migrationBuilder.RenameColumn(
                name: "CoordinatorEmailAddress",
                table: "CoordinatorTable",
                newName: "Faculty");

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
                name: "Department",
                table: "CoordinatorTable",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CoordinatorTable",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CoordinatorTable",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "CoordinatorTable");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CoordinatorTable");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CoordinatorTable");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "CoordinatorTable",
                newName: "CoordinatorName");

            migrationBuilder.RenameColumn(
                name: "Faculty",
                table: "CoordinatorTable",
                newName: "CoordinatorEmailAddress");

            migrationBuilder.RenameColumn(
                name: "AuthId",
                table: "CoordinatorTable",
                newName: "CoordinatorId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRejected",
                table: "StudentTable",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
