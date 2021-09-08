using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class InitialCreate04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenu_SysMenu_SysMenuID",
                table: "RoleMenu");

            migrationBuilder.DropIndex(
                name: "IX_RoleMenu_SysMenuID",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "SysMenuID",
                table: "RoleMenu");

            migrationBuilder.RenameColumn(
                name: "SysMenuID",
                table: "SysMenu",
                newName: "MenuID");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "RoleMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_MenuId",
                table: "RoleMenu",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenu_SysMenu_MenuId",
                table: "RoleMenu",
                column: "MenuId",
                principalTable: "SysMenu",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenu_SysMenu_MenuId",
                table: "RoleMenu");

            migrationBuilder.DropIndex(
                name: "IX_RoleMenu_MenuId",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "RoleMenu");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "SysMenu",
                newName: "SysMenuID");

            migrationBuilder.AddColumn<int>(
                name: "SysMenuID",
                table: "RoleMenu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_SysMenuID",
                table: "RoleMenu",
                column: "SysMenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenu_SysMenu_SysMenuID",
                table: "RoleMenu",
                column: "SysMenuID",
                principalTable: "SysMenu",
                principalColumn: "SysMenuID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
