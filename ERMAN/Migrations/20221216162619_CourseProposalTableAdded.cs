using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class CourseProposalTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProposalCourseTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Intensions = table.Column<string>(type: "text", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true),
                    StudentId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalCourseTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposalCourseTable_CourseMappedTable_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseMappedTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProposalCourseTable_CourseId",
                table: "ProposalCourseTable",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProposalCourseTable");
        }
    }
}
