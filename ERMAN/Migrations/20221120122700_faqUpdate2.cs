using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class faqUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "FAQTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FAQTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "FAQTable",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FAQTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
