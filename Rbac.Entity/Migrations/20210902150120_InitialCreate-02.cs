using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class InitialCreate02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenu_SysMenu_SysMenuMenuID",
                table: "RoleMenu");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "SysMenu",
                newName: "SysMenuID");

            migrationBuilder.RenameColumn(
                name: "SysMenuMenuID",
                table: "RoleMenu",
                newName: "SysMenuID");

            migrationBuilder.RenameIndex(
                name: "IX_RoleMenu_SysMenuMenuID",
                table: "RoleMenu",
                newName: "IX_RoleMenu_SysMenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenu_SysMenu_SysMenuID",
                table: "RoleMenu",
                column: "SysMenuID",
                principalTable: "SysMenu",
                principalColumn: "SysMenuID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenu_SysMenu_SysMenuID",
                table: "RoleMenu");

            migrationBuilder.RenameColumn(
                name: "SysMenuID",
                table: "SysMenu",
                newName: "MenuID");

            migrationBuilder.RenameColumn(
                name: "SysMenuID",
                table: "RoleMenu",
                newName: "SysMenuMenuID");

            migrationBuilder.RenameIndex(
                name: "IX_RoleMenu_SysMenuID",
                table: "RoleMenu",
                newName: "IX_RoleMenu_SysMenuMenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenu_SysMenu_SysMenuMenuID",
                table: "RoleMenu",
                column: "SysMenuMenuID",
                principalTable: "SysMenu",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
