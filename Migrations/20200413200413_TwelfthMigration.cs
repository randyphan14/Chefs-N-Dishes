using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class TwelfthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_CreatorChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CreatorChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CreatorChefId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "Chef_ChefId",
                table: "Dishes",
                newName: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "ChefId",
                table: "Dishes",
                newName: "Chef_ChefId");

            migrationBuilder.AddColumn<int>(
                name: "CreatorChefId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CreatorChefId",
                table: "Dishes",
                column: "CreatorChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_CreatorChefId",
                table: "Dishes",
                column: "CreatorChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
