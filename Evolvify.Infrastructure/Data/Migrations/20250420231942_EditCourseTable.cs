using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolvify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgress_ApplicationUser_UserId",
                table: "CourseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgress_Courses_CourseId",
                table: "CourseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleProgress_ApplicationUser_UserId",
                table: "ModuleProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleProgress_Modules_ModuleId",
                table: "ModuleProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleProgress",
                table: "ModuleProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseProgress",
                table: "CourseProgress");

            migrationBuilder.RenameTable(
                name: "ModuleProgress",
                newName: "ModuleProgresses");

            migrationBuilder.RenameTable(
                name: "CourseProgress",
                newName: "CourseProgresses");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleProgress_UserId",
                table: "ModuleProgresses",
                newName: "IX_ModuleProgresses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseProgress_UserId",
                table: "CourseProgresses",
                newName: "IX_CourseProgresses_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleProgresses",
                table: "ModuleProgresses",
                columns: new[] { "ModuleId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseProgresses",
                table: "CourseProgresses",
                columns: new[] { "CourseId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgresses_ApplicationUser_UserId",
                table: "CourseProgresses",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgresses_Courses_CourseId",
                table: "CourseProgresses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleProgresses_ApplicationUser_UserId",
                table: "ModuleProgresses",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleProgresses_Modules_ModuleId",
                table: "ModuleProgresses",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgresses_ApplicationUser_UserId",
                table: "CourseProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgresses_Courses_CourseId",
                table: "CourseProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleProgresses_ApplicationUser_UserId",
                table: "ModuleProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleProgresses_Modules_ModuleId",
                table: "ModuleProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleProgresses",
                table: "ModuleProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseProgresses",
                table: "CourseProgresses");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "ModuleProgresses",
                newName: "ModuleProgress");

            migrationBuilder.RenameTable(
                name: "CourseProgresses",
                newName: "CourseProgress");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleProgresses_UserId",
                table: "ModuleProgress",
                newName: "IX_ModuleProgress_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseProgresses_UserId",
                table: "CourseProgress",
                newName: "IX_CourseProgress_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleProgress",
                table: "ModuleProgress",
                columns: new[] { "ModuleId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseProgress",
                table: "CourseProgress",
                columns: new[] { "CourseId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgress_ApplicationUser_UserId",
                table: "CourseProgress",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgress_Courses_CourseId",
                table: "CourseProgress",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleProgress_ApplicationUser_UserId",
                table: "ModuleProgress",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleProgress_Modules_ModuleId",
                table: "ModuleProgress",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
