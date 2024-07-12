using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerhanApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ApplicationUserRole",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRolePermissionMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserRoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRolePermissionMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRolePermissionMapping_ApplicationUserRole_ApplicationUserRoleId",
                        column: x => x.ApplicationUserRoleId,
                        principalTable: "ApplicationUserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRolePermissionMapping_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRolePermissionMapping_ApplicationUserRoleId",
                table: "ApplicationUserRolePermissionMapping",
                column: "ApplicationUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRolePermissionMapping_PermissionId",
                table: "ApplicationUserRolePermissionMapping",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRolePermissionMapping");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "ApplicationUserRole",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
