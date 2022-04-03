using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Infrastructure.Migrations
{
    public partial class CreatedTableProductTypeAndBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutBrandId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutTypeId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdutBrandId",
                table: "Products",
                column: "ProdutBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdutTypeId",
                table: "Products",
                column: "ProdutTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrand_ProdutBrandId",
                table: "Products",
                column: "ProdutBrandId",
                principalTable: "ProductBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_ProdutTypeId",
                table: "Products",
                column: "ProdutTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrand_ProdutBrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_ProdutTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProdutBrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProdutTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProdutBrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProdutTypeId",
                table: "Products");
        }
    }
}
