using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KylerAndBrandonCMS2.Migrations
{
    public partial class GallaryItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GallaryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    time = table.Column<DateTime>(nullable: false),
                    PageId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GallaryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GallaryItems_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GallaryImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GallaryItemID = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GallaryImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GallaryImages_GallaryItems_GallaryItemID",
                        column: x => x.GallaryItemID,
                        principalTable: "GallaryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GallaryImages_GallaryItemID",
                table: "GallaryImages",
                column: "GallaryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_GallaryItems_PageId",
                table: "GallaryItems",
                column: "PageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GallaryImages");

            migrationBuilder.DropTable(
                name: "GallaryItems");
        }
    }
}
