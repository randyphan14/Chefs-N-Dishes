using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "ChefId",
                table: "Dishes",
                newName: "CreatorChefId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                newName: "IX_Dishes_CreatorChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_CreatorChefId",
                table: "Dishes",
                column: "CreatorChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_CreatorChefId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "CreatorChefId",
                table: "Dishes",
                newName: "ChefId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_CreatorChefId",
                table: "Dishes",
                newName: "IX_Dishes_ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
