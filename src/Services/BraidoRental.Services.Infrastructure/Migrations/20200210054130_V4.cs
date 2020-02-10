using Microsoft.EntityFrameworkCore.Migrations;

namespace BraidoRental.Services.Infrastructure.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Cliente_ClienteId",
                table: "Agendamento");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Agendamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Cliente_ClienteId",
                table: "Agendamento",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Cliente_ClienteId",
                table: "Agendamento");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Cliente_ClienteId",
                table: "Agendamento",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
