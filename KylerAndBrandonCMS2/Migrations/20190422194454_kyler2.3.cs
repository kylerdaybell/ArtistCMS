using Microsoft.EntityFrameworkCore.Migrations;

namespace KylerAndBrandonCMS2.Migrations
{
    public partial class kyler23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Footer",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Pages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Footer",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "Pages");
        }
    }
}
