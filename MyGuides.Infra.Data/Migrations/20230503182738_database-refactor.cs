using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGuides.Infra.Data.Migrations
{
    public partial class databaserefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievement_Difficulty_DifficultyId",
                table: "Achievement");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Achievement");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievement_Difficulty_DifficultyId",
                table: "Achievement",
                column: "DifficultyId",
                principalTable: "Difficulty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievement_Difficulty_DifficultyId",
                table: "Achievement");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Achievement",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievement_Difficulty_DifficultyId",
                table: "Achievement",
                column: "DifficultyId",
                principalTable: "Difficulty",
                principalColumn: "Id");
        }
    }
}
