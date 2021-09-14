using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.Entity.Migrations
{
    public partial class _09143 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "SysMenu",
                newName: "CreateById");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "RoleMenu",
                newName: "CreateById");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "Role",
                newName: "CreateById");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "Goods",
                newName: "CreateById");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "Department",
                newName: "CreateById");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "Customer",
                newName: "CreateById");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "Contract",
                newName: "CreateById");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "AdminRole",
                newName: "CreateById");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "Admin",
                newName: "CreateById");

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "SysMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "RoleMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "AdminRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateByUser",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "RoleMenu");

            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "AdminRole");

            migrationBuilder.DropColumn(
                name: "CreateByUser",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "SysMenu",
                newName: "CreateId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "RoleMenu",
                newName: "CreateId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Role",
                newName: "CreateId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Goods",
                newName: "CreateId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Department",
                newName: "CreateId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Customer",
                newName: "CreateId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Contract",
                newName: "CreateId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "AdminRole",
                newName: "CreateId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Admin",
                newName: "CreateId");
        }
    }
}
