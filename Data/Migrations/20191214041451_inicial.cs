using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogo.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nacionalidade",
                columns: table => new
                {
                    NacionalidadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidade", x => x.NacionalidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    JogadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Idade = table.Column<int>(nullable: false),
                    NacionalidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.JogadorId);
                    table.ForeignKey(
                        name: "FK_Jogador_Nacionalidade_NacionalidadeId",
                        column: x => x.NacionalidadeId,
                        principalTable: "Nacionalidade",
                        principalColumn: "NacionalidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placar",
                columns: table => new
                {
                    PlacarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JogadorId = table.Column<int>(nullable: false),
                    Pontos = table.Column<decimal>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placar", x => x.PlacarId);
                    table.ForeignKey(
                        name: "FK_Placar_Jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogador",
                        principalColumn: "JogadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogador_NacionalidadeId",
                table: "Jogador",
                column: "NacionalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Placar_JogadorId",
                table: "Placar",
                column: "JogadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Placar");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Nacionalidade");
        }
    }
}
