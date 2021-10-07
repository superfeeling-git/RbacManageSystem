using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class _09281 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminRole_Role_RoleID",
                table: "AdminRole");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenu_Role_RoleID",
                table: "RoleMenu");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "SysMenu",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "ParnetID",
                table: "SysMenu",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "RoleMenu",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleMenu_RoleID",
                table: "RoleMenu",
                newName: "IX_RoleMenu_RoleId");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Role",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "ParnetID",
                table: "GoodsCategory",
                newName: "ParentID");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "AdminRole",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminRole_RoleID",
                table: "AdminRole",
                newName: "IX_AdminRole_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminRole_Role_RoleId",
                table: "AdminRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenu_Role_RoleId",
                table: "RoleMenu",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminRole_Role_RoleId",
                table: "AdminRole");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenu_Role_RoleId",
                table: "RoleMenu");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "SysMenu",
                newName: "MenuID");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "SysMenu",
                newName: "ParnetID");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RoleMenu",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_RoleMenu_RoleId",
                table: "RoleMenu",
                newName: "IX_RoleMenu_RoleID");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Role",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "GoodsCategory",
                newName: "ParnetID");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AdminRole",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_AdminRole_RoleId",
                table: "AdminRole",
                newName: "IX_AdminRole_RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminRole_Role_RoleID",
                table: "AdminRole",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenu_Role_RoleID",
                table: "RoleMenu",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
