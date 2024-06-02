using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cervantes.Arquisoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedInProjectType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "ProjectTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "ProjectTypeId",
                keyValue: 1,
                column: "IsDeleted",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "ProjectTypeId",
                keyValue: 2,
                column: "IsDeleted",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectTypes");
        }
    }
}
