using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class InitialCreate0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nvarchar(500)",
                table: "Admin",
                newName: "LastModify");

            migrationBuilder.AlterColumn<string>(
                name: "LastModify",
                table: "Admin",
                type: "nvarchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModify",
                table: "Admin",
                newName: "nvarchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "nvarchar(500)",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldNullable: true);
        }
    }
}
