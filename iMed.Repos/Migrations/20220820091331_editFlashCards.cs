using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace iMed.Repos.Migrations
{
    public partial class editFlashCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_FlashCardCategories_FlashCardCategoryId",
                table: "FlashCards");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_FlashCardCategoryId",
                table: "FlashCards");

            migrationBuilder.RenameColumn(
                name: "FlashCardCategoryId",
                table: "FlashCards",
                newName: "FlashCardType");

            migrationBuilder.AddColumn<DateTime>(
                name: "NextReviewAt",
                table: "UserFlashCardStatuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<double>(
                name: "ElapsedTimePerSecond",
                table: "FlashCardSubmittedAnswers",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "FlashCardTagId",
                table: "FlashCards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FlashCardTags",
                columns: table => new
                {
                    FlashCardTagId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FlashCardCategoryId = table.Column<int>(type: "integer", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsRemoved = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    RemovedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardTags", x => x.FlashCardTagId);
                    table.ForeignKey(
                        name: "FK_FlashCardTags_FlashCardCategories_FlashCardCategoryId",
                        column: x => x.FlashCardCategoryId,
                        principalTable: "FlashCardCategories",
                        principalColumn: "FlashCardCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_FlashCardTagId",
                table: "FlashCards",
                column: "FlashCardTagId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardTags_FlashCardCategoryId",
                table: "FlashCardTags",
                column: "FlashCardCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_FlashCardTags_FlashCardTagId",
                table: "FlashCards",
                column: "FlashCardTagId",
                principalTable: "FlashCardTags",
                principalColumn: "FlashCardTagId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_FlashCardTags_FlashCardTagId",
                table: "FlashCards");

            migrationBuilder.DropTable(
                name: "FlashCardTags");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_FlashCardTagId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "NextReviewAt",
                table: "UserFlashCardStatuses");

            migrationBuilder.DropColumn(
                name: "FlashCardTagId",
                table: "FlashCards");

            migrationBuilder.RenameColumn(
                name: "FlashCardType",
                table: "FlashCards",
                newName: "FlashCardCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "ElapsedTimePerSecond",
                table: "FlashCardSubmittedAnswers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_FlashCardCategoryId",
                table: "FlashCards",
                column: "FlashCardCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_FlashCardCategories_FlashCardCategoryId",
                table: "FlashCards",
                column: "FlashCardCategoryId",
                principalTable: "FlashCardCategories",
                principalColumn: "FlashCardCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
