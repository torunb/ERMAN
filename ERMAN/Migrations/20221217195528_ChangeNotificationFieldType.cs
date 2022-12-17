using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNotificationFieldType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "NotificationTable",
                type: "integer",
                nullable: false,
                oldClrType: null,
                oldType: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "NotificationTable",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
