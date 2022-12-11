using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class CourseMapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseDescription",
                table: "Course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CourseMappedId",
                table: "Course",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsElectiveCourse",
                table: "Course",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsForeignUniversity",
                table: "Course",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMustCourse",
                table: "Course",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CourseMappedTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApprovedStatus = table.Column<bool>(type: "boolean", nullable: false),
                    BilkentCourseId = table.Column<int>(type: "integer", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMappedTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMappedTable_Course_BilkentCourseId",
                        column: x => x.BilkentCourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseMappedId",
                table: "Course",
                column: "CourseMappedId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMappedTable_BilkentCourseId",
                table: "CourseMappedTable",
                column: "BilkentCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseMappedTable_CourseMappedId",
                table: "Course",
                column: "CourseMappedId",
                principalTable: "CourseMappedTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseMappedTable_CourseMappedId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "CourseMappedTable");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseMappedId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseDescription",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseMappedId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsElectiveCourse",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsForeignUniversity",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsMustCourse",
                table: "Course");
        }
    }
}
