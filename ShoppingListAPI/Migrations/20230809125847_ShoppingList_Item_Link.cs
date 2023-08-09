using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListAPI.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListItemLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListModelId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ShoppingListModelId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ShoppingListModelId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingListId",
                table: "Items",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListId",
                table: "Items",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ShoppingListId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListModelId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingListModelId",
                table: "Items",
                column: "ShoppingListModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListModelId",
                table: "Items",
                column: "ShoppingListModelId",
                principalTable: "ShoppingLists",
                principalColumn: "Id");
        }
    }
}
