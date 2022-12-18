using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class UnnecessaryTablesDropped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseMappedTable_CourseMappedId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_InstructorTable_InstructorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_StudentTable_StudentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMappedTable_Course_BilkentCourseId",
                table: "CourseMappedTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Todo",
                newName: "TodoTable");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "CourseTable");

            migrationBuilder.RenameIndex(
                name: "IX_Course_StudentId",
                table: "CourseTable",
                newName: "IX_CourseTable_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_InstructorId",
                table: "CourseTable",
                newName: "IX_CourseTable_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_CourseMappedId",
                table: "CourseTable",
                newName: "IX_CourseTable_CourseMappedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTable",
                table: "TodoTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTable",
                table: "CourseTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMappedTable_CourseTable_BilkentCourseId",
                table: "CourseMappedTable",
                column: "BilkentCourseId",
                principalTable: "CourseTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTable_CourseMappedTable_CourseMappedId",
                table: "CourseTable",
                column: "CourseMappedId",
                principalTable: "CourseMappedTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTable_InstructorTable_InstructorId",
                table: "CourseTable",
                column: "InstructorId",
                principalTable: "InstructorTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTable_StudentTable_StudentId",
                table: "CourseTable",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMappedTable_CourseTable_BilkentCourseId",
                table: "CourseMappedTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTable_CourseMappedTable_CourseMappedId",
                table: "CourseTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTable_InstructorTable_InstructorId",
                table: "CourseTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTable_StudentTable_StudentId",
                table: "CourseTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTable",
                table: "TodoTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTable",
                table: "CourseTable");

            migrationBuilder.RenameTable(
                name: "TodoTable",
                newName: "Todo");

            migrationBuilder.RenameTable(
                name: "CourseTable",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTable_StudentId",
                table: "Course",
                newName: "IX_Course_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTable_InstructorId",
                table: "Course",
                newName: "IX_Course_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTable_CourseMappedId",
                table: "Course",
                newName: "IX_Course_CourseMappedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseMappedTable_CourseMappedId",
                table: "Course",
                column: "CourseMappedId",
                principalTable: "CourseMappedTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_InstructorTable_InstructorId",
                table: "Course",
                column: "InstructorId",
                principalTable: "InstructorTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_StudentTable_StudentId",
                table: "Course",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMappedTable_Course_BilkentCourseId",
                table: "CourseMappedTable",
                column: "BilkentCourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
