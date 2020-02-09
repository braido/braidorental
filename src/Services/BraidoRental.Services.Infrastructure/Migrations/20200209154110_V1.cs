using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BraidoRental.Services.Infrastructure.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarroFaturamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    CarroLocacaoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    ValorTotalLocacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroFaturamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarroFaturamento_CarroLocacao_CarroLocacaoId",
                        column: x => x.CarroLocacaoId,
                        principalTable: "CarroLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroFaturamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroFaturamento_CarroLocacaoId",
                table: "CarroFaturamento",
                column: "CarroLocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarroFaturamento_ClienteId",
                table: "CarroFaturamento",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroFaturamento");
        }
    }
}
