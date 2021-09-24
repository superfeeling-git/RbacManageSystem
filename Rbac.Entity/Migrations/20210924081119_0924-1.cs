using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class _09241 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParnetID",
                table: "GoodsCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParnetID",
                table: "GoodsCategory");
        }
    }
}
