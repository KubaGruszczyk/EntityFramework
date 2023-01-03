using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodie.Persistance.EntityFramework.Migrations
{
    public partial class AddMetaTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetaTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipieMetaTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipieId = table.Column<int>(type: "int", nullable: false),
                    MetaTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipieMetaTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipieMetaTag_MetaTag_MetaTagId",
                        column: x => x.MetaTagId,
                        principalTable: "MetaTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipieMetaTag_Recipies_RecipieId",
                        column: x => x.RecipieId,
                        principalTable: "Recipies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipieMetaTag_MetaTagId",
                table: "RecipieMetaTag",
                column: "MetaTagId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipieMetaTag_RecipieId",
                table: "RecipieMetaTag",
                column: "RecipieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipieMetaTag");

            migrationBuilder.DropTable(
                name: "MetaTag");
        }
    }
}
