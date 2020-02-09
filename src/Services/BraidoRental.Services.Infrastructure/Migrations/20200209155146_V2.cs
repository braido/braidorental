using Microsoft.EntityFrameworkCore.Migrations;

namespace BraidoRental.Services.Infrastructure.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_CarroLocacao_CarroLocacaoId1",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_CarroLocacaoId1",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "CarroLocacaoId1",
                table: "Agendamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarroLocacaoId1",
                table: "Agendamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_CarroLocacaoId1",
                table: "Agendamento",
                column: "CarroLocacaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_CarroLocacao_CarroLocacaoId1",
                table: "Agendamento",
                column: "CarroLocacaoId1",
                principalTable: "CarroLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
