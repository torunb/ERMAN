using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class AddCoordinatorInfoToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receiverType",
                table: "MessageTable");

            migrationBuilder.DropColumn(
                name: "senderType",
                table: "MessageTable");

            migrationBuilder.AddColumn<int>(
                name: "CoordinatorId",
                table: "StudentTable",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "StudentTable");

            migrationBuilder.AddColumn<string>(
                name: "receiverType",
                table: "MessageTable",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "senderType",
                table: "MessageTable",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
