using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticationTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Checked = table.Column<bool[]>(type: "boolean[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoordinatorTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    AuthId = table.Column<int>(type: "integer", nullable: false),
                    CoordinatorUniversityId = table.Column<int>(type: "integer", nullable: true),
                    Faculty = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinatorTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQTable",
                columns: table => new
                {
                    FAQItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FAQQuestion = table.Column<string>(type: "text", nullable: false),
                    FAQAnswer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQTable", x => x.FAQItemId);
                });

            migrationBuilder.CreateTable(
                name: "InstructorTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstructorEmailAddress = table.Column<string>(type: "text", nullable: false),
                    InstructorName = table.Column<string>(type: "text", nullable: false),
                    InstructorId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserType = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<string>(type: "text", nullable: false),
                    Done = table.Column<bool>(type: "boolean", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstructorId = table.Column<int>(type: "integer", nullable: false),
                    CourseName = table.Column<string>(type: "text", nullable: false),
                    CourseDescription = table.Column<string>(type: "text", nullable: false),
                    IsForeignUniversity = table.Column<bool>(type: "boolean", nullable: false),
                    IsElectiveCourse = table.Column<bool>(type: "boolean", nullable: false),
                    IsMustCourse = table.Column<bool>(type: "boolean", nullable: false),
                    CourseType = table.Column<string>(type: "text", nullable: false),
                    CourseCredit = table.Column<float>(type: "real", nullable: false),
                    UniversityId = table.Column<int>(type: "integer", nullable: false),
                    CourseCode = table.Column<string>(type: "text", nullable: false),
                    CourseMappedId = table.Column<int>(type: "integer", nullable: true),
                    StudentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_InstructorTable_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "InstructorTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseMappedTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApprovedStatus = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "MessageTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    messageText = table.Column<string>(type: "text", nullable: false),
                    senderType = table.Column<string>(type: "text", nullable: false),
                    senderId = table.Column<int>(type: "integer", nullable: false),
                    receiverType = table.Column<string>(type: "text", nullable: false),
                    receiverId = table.Column<int>(type: "integer", nullable: false),
                    CoordinatorId = table.Column<int>(type: "integer", nullable: true),
                    InstructorId = table.Column<int>(type: "integer", nullable: true),
                    StudentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageTable_CoordinatorTable_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "CoordinatorTable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageTable_InstructorTable_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "InstructorTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: true),
                    AuthId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Faculty = table.Column<string>(type: "text", nullable: true),
                    Ranking = table.Column<int>(type: "integer", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "text", nullable: true),
                    UniversityId = table.Column<int>(type: "integer", nullable: true),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    IsRejected = table.Column<bool>(type: "boolean", nullable: false),
                    DurationPreffered = table.Column<string>(type: "text", nullable: true),
                    Program = table.Column<int>(type: "integer", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalPoints = table.Column<double>(type: "double precision", nullable: false),
                    Degree = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversityName = table.Column<string>(type: "text", nullable: false),
                    UniversityCapacity = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityTable_StudentTable_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseMappedId",
                table: "Course",
                column: "CourseMappedId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstructorId",
                table: "Course",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_StudentId",
                table: "Course",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMappedTable_BilkentCourseId",
                table: "CourseMappedTable",
                column: "BilkentCourseId");

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
                name: "IX_StudentTable_UniversityId",
                table: "StudentTable",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTable_StudentId",
                table: "UniversityTable",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseMappedTable_CourseMappedId",
                table: "Course",
                column: "CourseMappedId",
                principalTable: "CourseMappedTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_StudentTable_StudentId",
                table: "Course",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTable_StudentTable_StudentId",
                table: "MessageTable",
                column: "StudentId",
                principalTable: "StudentTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTable_UniversityTable_UniversityId",
                table: "StudentTable",
                column: "UniversityId",
                principalTable: "UniversityTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseMappedTable_CourseMappedId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityTable_StudentTable_StudentId",
                table: "UniversityTable");

            migrationBuilder.DropTable(
                name: "AuthenticationTable");

            migrationBuilder.DropTable(
                name: "ChecklistTable");

            migrationBuilder.DropTable(
                name: "FAQTable");

            migrationBuilder.DropTable(
                name: "MessageTable");

            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "CoordinatorTable");

            migrationBuilder.DropTable(
                name: "CourseMappedTable");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "InstructorTable");

            migrationBuilder.DropTable(
                name: "StudentTable");

            migrationBuilder.DropTable(
                name: "UniversityTable");
        }
    }
}
