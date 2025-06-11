using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolvify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "QuizAttemptId",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Quizs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "QuizResults",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "QuizResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuizAttemptId",
                table: "UserAnswers",
                column: "QuizAttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_QuizResults_QuizAttemptId",
                table: "UserAnswers",
                column: "QuizAttemptId",
                principalTable: "QuizResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_QuizResults_QuizAttemptId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_QuizAttemptId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "QuizAttemptId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Quizs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "QuizResults");

            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "QuizResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
