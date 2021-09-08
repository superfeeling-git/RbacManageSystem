using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class InitialCreate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SysMenu_Role_RoleID",
                table: "SysMenu");

            migrationBuilder.DropIndex(
                name: "IX_SysMenu_RoleID",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "SysMenu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "SysMenu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysMenu_RoleID",
                table: "SysMenu",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_SysMenu_Role_RoleID",
                table: "SysMenu",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
