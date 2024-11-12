using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class Initiatestb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.AddColumn<Guid>(
                name: "BookModelid",
                table: "categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_BookModelid",
                table: "categories",
                column: "BookModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_Books_BookModelid",
                table: "categories",
                column: "BookModelid",
                principalTable: "Books",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_Books_BookModelid",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_BookModelid",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "BookModelid",
                table: "categories");

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookModelId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BookModelId",
                        column: x => x.BookModelId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");
        }
    }
}
