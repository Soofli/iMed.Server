using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iMed.Repos.Migrations
{
    public partial class editVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Videos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Row",
                table: "Videos");
        }
    }
}
