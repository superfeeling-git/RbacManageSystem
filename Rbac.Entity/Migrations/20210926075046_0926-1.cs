using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class _09261 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentPath",
                table: "GoodsCategory",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentPath",
                table: "GoodsCategory");
        }
    }
}
