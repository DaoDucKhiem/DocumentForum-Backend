using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumDocument.Migrations
{
    public partial class updatedocumentfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFeature",
                table: "Document",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFeature",
                table: "Document");
        }
    }
}
