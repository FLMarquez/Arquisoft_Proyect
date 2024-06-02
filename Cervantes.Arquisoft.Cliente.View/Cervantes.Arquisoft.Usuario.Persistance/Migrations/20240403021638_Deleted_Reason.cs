using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cervantes.Arquisoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class Deleted_Reason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectState_ProjectStateId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectStateId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payments",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProjectState",
                keyColumn: "ProjectStateId",
                keyValue: 3,
                column: "Description",
                value: "Iniciado");

            migrationBuilder.UpdateData(
                table: "ProjectState",
                keyColumn: "ProjectStateId",
                keyValue: 4,
                column: "Description",
                value: "Completo");

            migrationBuilder.UpdateData(
                table: "ProjectState",
                keyColumn: "ProjectStateId",
                keyValue: 5,
                column: "Description",
                value: "En Espera");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectState_ProjectStateId",
                table: "Projects",
                column: "ProjectStateId",
                principalTable: "ProjectState",
                principalColumn: "ProjectStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectState_ProjectStateId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectStateId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProjectState",
                keyColumn: "ProjectStateId",
                keyValue: 3,
                column: "Description",
                value: "En progreso");

            migrationBuilder.UpdateData(
                table: "ProjectState",
                keyColumn: "ProjectStateId",
                keyValue: 4,
                column: "Description",
                value: "Completado");

            migrationBuilder.UpdateData(
                table: "ProjectState",
                keyColumn: "ProjectStateId",
                keyValue: 5,
                column: "Description",
                value: "Pendiente");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectState_ProjectStateId",
                table: "Projects",
                column: "ProjectStateId",
                principalTable: "ProjectState",
                principalColumn: "ProjectStateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
