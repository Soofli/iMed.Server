using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iMed.Repos.Migrations
{
    public partial class editCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RateAvg",
                table: "Courses",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateAvg",
                table: "Courses");
        }
    }
}
