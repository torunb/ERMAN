using ERMAN.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERMAN.Migrations
{
    /// <inheritdoc />
    public partial class faq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FAQTable",
                columns: table => new
                {
                    FAQItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FAQQuestion = table.Column<string>(type: "text", nullable: false),
                    FAQAnswer = table.Column<int>(type: "integer", nullable: false),
                    IsChecked = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQTable", x => x.FAQItemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<< HEAD:ERMAN/Migrations/20221120110725_faq.cs
                name: "FAQTable");
=======
                name: "StudentTable");
            migrationBuilder.DropTable(
                name: "StudentUserTable");
>>>>>>> yarkin:ERMAN/Migrations/20221119142321_InitialDatabase.cs
        }
    }
}
