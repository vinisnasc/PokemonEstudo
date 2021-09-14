using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketMonster.Data.Migrations
{
    public partial class TabelaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treinadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ginasios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GymLiderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ginasios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ginasios_Treinadores_GymLiderId",
                        column: x => x.GymLiderId,
                        principalTable: "Treinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistroPokedex = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreinadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemon_Treinadores_TreinadorId",
                        column: x => x.TreinadorId,
                        principalTable: "Treinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTreinadores",
                columns: table => new
                {
                    IdPokemon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTreinador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTreinadores", x => new { x.IdPokemon, x.IdTreinador });
                    table.ForeignKey(
                        name: "FK_PokemonTreinadores_Pokemon_IdPokemon",
                        column: x => x.IdPokemon,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonTreinadores_Treinadores_IdTreinador",
                        column: x => x.IdTreinador,
                        principalTable: "Treinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ginasios_GymLiderId",
                table: "Ginasios",
                column: "GymLiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_TreinadorId",
                table: "Pokemon",
                column: "TreinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTreinadores_IdTreinador",
                table: "PokemonTreinadores",
                column: "IdTreinador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ginasios");

            migrationBuilder.DropTable(
                name: "PokemonTreinadores");

            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "Treinadores");
        }
    }
}
