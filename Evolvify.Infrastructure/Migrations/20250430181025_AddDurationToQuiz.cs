using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolvify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationToQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Quizs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Quizs");
        }
    }
}
