using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class _09144 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "SysMenu",
                newName: "CreateByName");

            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "RoleMenu",
                newName: "CreateByName");

            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "Role",
                newName: "CreateByName");

            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "Goods",
                newName: "CreateByName");

            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "Department",
                newName: "CreateByName");

            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "Customer",
                newName: "CreateByName");

            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "Contract",
                newName: "CreateByName");

            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "AdminRole",
                newName: "CreateByName");

            migrationBuilder.RenameColumn(
                name: "CreateByUser",
                table: "Admin",
                newName: "CreateByName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "SysMenu",
                newName: "CreateByUser");

            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "RoleMenu",
                newName: "CreateByUser");

            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "Role",
                newName: "CreateByUser");

            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "Goods",
                newName: "CreateByUser");

            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "Department",
                newName: "CreateByUser");

            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "Customer",
                newName: "CreateByUser");

            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "Contract",
                newName: "CreateByUser");

            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "AdminRole",
                newName: "CreateByUser");

            migrationBuilder.RenameColumn(
                name: "CreateByName",
                table: "Admin",
                newName: "CreateByUser");
        }
    }
}
