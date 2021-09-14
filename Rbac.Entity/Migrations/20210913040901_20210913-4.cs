using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class _202109134 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_GoodsCategory_GoodsCategoryCategoryId",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_GoodsCategoryCategoryId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "GoodsCategoryCategoryId",
                table: "Goods");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_CategoryId",
                table: "Goods",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_GoodsCategory_CategoryId",
                table: "Goods",
                column: "CategoryId",
                principalTable: "GoodsCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_GoodsCategory_CategoryId",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_CategoryId",
                table: "Goods");

            migrationBuilder.AddColumn<int>(
                name: "GoodsCategoryCategoryId",
                table: "Goods",
                type: "int",
                nullable: true);

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
    }
}
