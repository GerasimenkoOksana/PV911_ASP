using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationCoreNet5.Data.Migrations
{
    public partial class ProductTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PivotProductTags",
                columns: table => new
                {
                    productsId = table.Column<int>(type: "int", nullable: false),
                    tagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PivotProductTags", x => new { x.productsId, x.tagsId });
                    table.ForeignKey(
                        name: "FK_PivotProductTags_Products_productsId",
                        column: x => x.productsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PivotProductTags_Tags_tagsId",
                        column: x => x.tagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PivotProductTags_tagsId",
                table: "PivotProductTags",
                column: "tagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PivotProductTags");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
