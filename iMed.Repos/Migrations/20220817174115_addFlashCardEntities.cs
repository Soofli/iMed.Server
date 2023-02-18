using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace iMed.Repos.Migrations
{
    public partial class addFlashCardEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlashCardCategoryId",
                table: "Purchases",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlashCardCategoryId",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlashCardCategories",
                columns: table => new
                {
                    FlashCardCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Detail = table.Column<string>(type: "text", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    IsFree = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_FlashCardCategories", x => x.FlashCardCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    FlashCardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_FlashCards", x => x.FlashCardId);
                    table.ForeignKey(
                        name: "FK_FlashCards_FlashCardCategories_FlashCardCategoryId",
                        column: x => x.FlashCardCategoryId,
                        principalTable: "FlashCardCategories",
                        principalColumn: "FlashCardCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardAnswers",
                columns: table => new
                {
                    FlashCardAnswerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    IsTrue = table.Column<bool>(type: "boolean", nullable: false),
                    FlashCardId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_FlashCardAnswers", x => x.FlashCardAnswerId);
                    table.ForeignKey(
                        name: "FK_FlashCardAnswers_FlashCards_FlashCardId",
                        column: x => x.FlashCardId,
                        principalTable: "FlashCards",
                        principalColumn: "FlashCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFlashCardStatuses",
                columns: table => new
                {
                    UserFlashCardStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlashCardStatus = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FlashCardId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_UserFlashCardStatuses", x => x.UserFlashCardStatusId);
                    table.ForeignKey(
                        name: "FK_UserFlashCardStatuses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFlashCardStatuses_FlashCards_FlashCardId",
                        column: x => x.FlashCardId,
                        principalTable: "FlashCards",
                        principalColumn: "FlashCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardSubmittedAnswers",
                columns: table => new
                {
                    FlashCardSubmittedAnswerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsTrue = table.Column<bool>(type: "boolean", nullable: false),
                    ElapsedTimePerSecond = table.Column<int>(type: "integer", nullable: false),
                    FlashCardId = table.Column<int>(type: "integer", nullable: false),
                    FlashCardAnswerId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_FlashCardSubmittedAnswers", x => x.FlashCardSubmittedAnswerId);
                    table.ForeignKey(
                        name: "FK_FlashCardSubmittedAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlashCardSubmittedAnswers_FlashCardAnswers_FlashCardAnswerId",
                        column: x => x.FlashCardAnswerId,
                        principalTable: "FlashCardAnswers",
                        principalColumn: "FlashCardAnswerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlashCardSubmittedAnswers_FlashCards_FlashCardId",
                        column: x => x.FlashCardId,
                        principalTable: "FlashCards",
                        principalColumn: "FlashCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_FlashCardCategoryId",
                table: "Purchases",
                column: "FlashCardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_FlashCardCategoryId",
                table: "Images",
                column: "FlashCardCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardAnswers_FlashCardId",
                table: "FlashCardAnswers",
                column: "FlashCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_FlashCardCategoryId",
                table: "FlashCards",
                column: "FlashCardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardSubmittedAnswers_FlashCardAnswerId",
                table: "FlashCardSubmittedAnswers",
                column: "FlashCardAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardSubmittedAnswers_FlashCardId",
                table: "FlashCardSubmittedAnswers",
                column: "FlashCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardSubmittedAnswers_UserId",
                table: "FlashCardSubmittedAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFlashCardStatuses_FlashCardId",
                table: "UserFlashCardStatuses",
                column: "FlashCardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFlashCardStatuses_UserId",
                table: "UserFlashCardStatuses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_FlashCardCategories_FlashCardCategoryId",
                table: "Images",
                column: "FlashCardCategoryId",
                principalTable: "FlashCardCategories",
                principalColumn: "FlashCardCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_FlashCardCategories_FlashCardCategoryId",
                table: "Purchases",
                column: "FlashCardCategoryId",
                principalTable: "FlashCardCategories",
                principalColumn: "FlashCardCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_FlashCardCategories_FlashCardCategoryId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_FlashCardCategories_FlashCardCategoryId",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "FlashCardSubmittedAnswers");

            migrationBuilder.DropTable(
                name: "UserFlashCardStatuses");

            migrationBuilder.DropTable(
                name: "FlashCardAnswers");

            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "FlashCardCategories");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_FlashCardCategoryId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Images_FlashCardCategoryId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FlashCardCategoryId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "FlashCardCategoryId",
                table: "Images");
        }
    }
}
