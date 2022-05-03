using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMyNotion.Migrations
{
    public partial class fix_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Interests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Interests");
        }
    }
}
