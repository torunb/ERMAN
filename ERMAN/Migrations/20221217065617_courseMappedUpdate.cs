using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class courseMappedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMappedTable_StudentTable_StudentId",
                table: "CourseMappedTable");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "CourseMappedTable",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMappedTable_StudentTable_StudentId",
                table: "CourseMappedTable",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMappedTable_StudentTable_StudentId",
                table: "CourseMappedTable");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "CourseMappedTable",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMappedTable_StudentTable_StudentId",
                table: "CourseMappedTable",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
