using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMyNotion.Migrations
{
    public partial class changeNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Notes_NoteId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_NoteId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteId",
                table: "Notes",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Notes_NoteId",
                table: "Notes",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id");
        }
    }
}
