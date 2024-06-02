using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cervantes.Arquisoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeletedReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Hub",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Hub");
        }
    }
}
