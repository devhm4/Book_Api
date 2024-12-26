using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryModelId",
                table: "Books",
                type: "uuid",
                nullable: true);

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
    }
}
