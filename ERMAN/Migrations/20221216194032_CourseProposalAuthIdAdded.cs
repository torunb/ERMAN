using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class CourseProposalAuthIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthId",
                table: "ProposalCourseTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "ProposalCourseTable");
        }
    }
}
