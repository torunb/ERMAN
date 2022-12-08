using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class checklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Starred",
                table: "Todo");

            migrationBuilder.RenameTable(
                name: "Checklists",
                newName: "ChecklistTable");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Todo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoordinatorId",
                table: "MessageTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "MessageTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "MessageTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Course",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoordinatorUniversityId",
                table: "CoordinatorTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool[]>(
                name: "Checked",
                table: "ChecklistTable",
                type: "boolean[]",
                nullable: false,
                defaultValue: new bool[0]);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ChecklistTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChecklistTable",
                table: "ChecklistTable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    BilkentId = table.Column<int>(type: "integer", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    Faculty = table.Column<string>(type: "text", nullable: false),
                    University = table.Column<string>(type: "text", nullable: false),
                    DurationPreffered = table.Column<string>(type: "text", nullable: false),
                    Program = table.Column<string>(type: "text", nullable: false),
                    InsrtDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageTable_CoordinatorId",
                table: "MessageTable",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageTable_InstructorId",
                table: "MessageTable",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageTable_StudentId",
                table: "MessageTable",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstructorId",
                table: "Course",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_StudentId",
                table: "Course",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_InstructorTable_InstructorId",
                table: "Course",
                column: "InstructorId",
                principalTable: "InstructorTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_StudentTable_StudentId",
                table: "Course",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTable_CoordinatorTable_CoordinatorId",
                table: "MessageTable",
                column: "CoordinatorId",
                principalTable: "CoordinatorTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTable_InstructorTable_InstructorId",
                table: "MessageTable",
                column: "InstructorId",
                principalTable: "InstructorTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTable_StudentTable_StudentId",
                table: "MessageTable",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_InstructorTable_InstructorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_StudentTable_StudentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTable_CoordinatorTable_CoordinatorId",
                table: "MessageTable");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTable_InstructorTable_InstructorId",
                table: "MessageTable");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTable_StudentTable_StudentId",
                table: "MessageTable");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropIndex(
                name: "IX_MessageTable_CoordinatorId",
                table: "MessageTable");

            migrationBuilder.DropIndex(
                name: "IX_MessageTable_InstructorId",
                table: "MessageTable");

            migrationBuilder.DropIndex(
                name: "IX_MessageTable_StudentId",
                table: "MessageTable");

            migrationBuilder.DropIndex(
                name: "IX_Course_InstructorId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_StudentId",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChecklistTable",
                table: "ChecklistTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "MessageTable");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "MessageTable");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "MessageTable");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CoordinatorUniversityId",
                table: "CoordinatorTable");

            migrationBuilder.DropColumn(
                name: "Checked",
                table: "ChecklistTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChecklistTable");

            migrationBuilder.RenameTable(
                name: "ChecklistTable",
                newName: "Checklists");

            migrationBuilder.AddColumn<bool>(
                name: "Starred",
                table: "Todo",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists",
                column: "Id");
        }
    }
}
