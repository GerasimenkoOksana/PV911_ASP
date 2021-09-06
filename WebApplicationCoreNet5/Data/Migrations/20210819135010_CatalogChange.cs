using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationCoreNet5.Data.Migrations
{
    public partial class CatalogChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Catalog_ParentId",
                table: "Catalog");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Catalog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Catalog_ParentId",
                table: "Catalog",
                column: "ParentId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Catalog_ParentId",
                table: "Catalog");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Catalog",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Catalog_ParentId",
                table: "Catalog",
                column: "ParentId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
