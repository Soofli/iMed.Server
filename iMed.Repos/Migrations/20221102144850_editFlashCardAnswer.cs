using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iMed.Repos.Migrations
{
    public partial class editFlashCardAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "FlashCardSubmittedAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "FlashCardAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Row",
                table: "FlashCardSubmittedAnswers");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "FlashCardAnswers");
        }
    }
}
