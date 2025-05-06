using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolvify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionNumbertoQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "Questions");
        }
    }
}
