using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class _202109133 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Goods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoodsCategoryCategoryId",
                table: "Goods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GoodsCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GoodsCategoryCategoryId",
                table: "Goods",
                column: "GoodsCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_GoodsCategory_GoodsCategoryCategoryId",
                table: "Goods",
                column: "GoodsCategoryCategoryId",
                principalTable: "GoodsCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_GoodsCategory_GoodsCategoryCategoryId",
                table: "Goods");

            migrationBuilder.DropTable(
                name: "GoodsCategory");

            migrationBuilder.DropIndex(
                name: "IX_Goods_GoodsCategoryCategoryId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "GoodsCategoryCategoryId",
                table: "Goods");
        }
    }
}
