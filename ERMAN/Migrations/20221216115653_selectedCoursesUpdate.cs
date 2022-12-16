using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class selectedCoursesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CourseMappedTable_StudentId",
                table: "CourseMappedTable",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMappedTable_StudentTable_StudentId",
                table: "CourseMappedTable",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMappedTable_StudentTable_StudentId",
                table: "CourseMappedTable");

            migrationBuilder.DropIndex(
                name: "IX_CourseMappedTable_StudentId",
                table: "CourseMappedTable");
        }
    }
}
