using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class haidt4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryModelId",
                table: "Books",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "categoryId",
                table: "Books",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryModelId",
                table: "Books",
                column: "CategoryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_categories_CategoryModelId",
                table: "Books",
                column: "CategoryModelId",
                principalTable: "categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_categories_CategoryModelId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryModelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoryModelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Books");

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
