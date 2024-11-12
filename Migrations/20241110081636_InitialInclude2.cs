using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class InitialInclude2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "BookModelCategory",
                columns: table => new
                {
                    Booksid = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookModelCategory", x => new { x.Booksid, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BookModelCategory_Books_Booksid",
                        column: x => x.Booksid,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookModelCategory_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookModelCategory_CategoriesId",
                table: "BookModelCategory",
                column: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookModelCategory");

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
    }
}
