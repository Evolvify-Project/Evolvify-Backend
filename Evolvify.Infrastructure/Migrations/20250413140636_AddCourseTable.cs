using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolvify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Skills_SkillId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Modules",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_SkillId",
                table: "Modules",
                newName: "IX_Modules_CourseId");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_SkillId",
                table: "Course",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Course_CourseId",
                table: "Modules",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Course_CourseId",
                table: "Modules");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Modules",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_CourseId",
                table: "Modules",
                newName: "IX_Modules_SkillId");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Skills_SkillId",
                table: "Modules",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
