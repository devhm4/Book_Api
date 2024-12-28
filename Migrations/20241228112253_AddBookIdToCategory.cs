using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class AddBookIdToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Bookid",
                table: "categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_categories_Bookid",
                table: "categories",
                column: "Bookid");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_Books_Bookid",
                table: "categories",
                column: "Bookid",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_Books_Bookid",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_Bookid",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "Bookid",
                table: "categories");
        }
    }
}
