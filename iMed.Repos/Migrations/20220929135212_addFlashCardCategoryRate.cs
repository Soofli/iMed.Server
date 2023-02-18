using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iMed.Repos.Migrations
{
    public partial class addFlashCardCategoryRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlashCardCategoryId",
                table: "Rates",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_FlashCardCategoryId",
                table: "Rates",
                column: "FlashCardCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_FlashCardCategories_FlashCardCategoryId",
                table: "Rates",
                column: "FlashCardCategoryId",
                principalTable: "FlashCardCategories",
                principalColumn: "FlashCardCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_FlashCardCategories_FlashCardCategoryId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_FlashCardCategoryId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "FlashCardCategoryId",
                table: "Rates");
        }
    }
}
