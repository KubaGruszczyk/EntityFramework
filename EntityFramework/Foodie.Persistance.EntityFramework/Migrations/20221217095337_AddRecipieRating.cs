using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodie.Persistance.EntityFramework.Migrations
{
    public partial class AddRecipieRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipieRatingId",
                table: "Recipies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecipieRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipieRating", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipies_RecipieRatingId",
                table: "Recipies",
                column: "RecipieRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipies_RecipieRating_RecipieRatingId",
                table: "Recipies",
                column: "RecipieRatingId",
                principalTable: "RecipieRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipies_RecipieRating_RecipieRatingId",
                table: "Recipies");

            migrationBuilder.DropTable(
                name: "RecipieRating");

            migrationBuilder.DropIndex(
                name: "IX_Recipies_RecipieRatingId",
                table: "Recipies");

            migrationBuilder.DropColumn(
                name: "RecipieRatingId",
                table: "Recipies");
        }
    }
}
