using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolvify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditModuleAndContentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentModule");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ModuleId",
                table: "Contents",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Modules_ModuleId",
                table: "Contents",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Modules_ModuleId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_ModuleId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Contents");

            migrationBuilder.CreateTable(
                name: "ContentModule",
                columns: table => new
                {
                    ContentsId = table.Column<int>(type: "int", nullable: false),
                    ModulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentModule", x => new { x.ContentsId, x.ModulesId });
                    table.ForeignKey(
                        name: "FK_ContentModule_Contents_ContentsId",
                        column: x => x.ContentsId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentModule_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentModule_ModulesId",
                table: "ContentModule",
                column: "ModulesId");
        }
    }
}
