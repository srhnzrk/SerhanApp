using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerhanApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Permission");

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                table: "Permission",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemName",
                table: "Permission");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Permission",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
