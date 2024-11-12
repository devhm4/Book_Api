using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class InitialInclude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
