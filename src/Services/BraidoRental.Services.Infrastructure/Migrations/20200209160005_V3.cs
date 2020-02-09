using Microsoft.EntityFrameworkCore.Migrations;

namespace BraidoRental.Services.Infrastructure.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_CarroLocacao_CarroLocacaoId",
                table: "Agendamento");

            migrationBuilder.AlterColumn<int>(
                name: "CarroLocacaoId",
                table: "Agendamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_CarroLocacao_CarroLocacaoId",
                table: "Agendamento",
                column: "CarroLocacaoId",
                principalTable: "CarroLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_CarroLocacao_CarroLocacaoId",
                table: "Agendamento");

            migrationBuilder.AlterColumn<int>(
                name: "CarroLocacaoId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_CarroLocacao_CarroLocacaoId",
                table: "Agendamento",
                column: "CarroLocacaoId",
                principalTable: "CarroLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
