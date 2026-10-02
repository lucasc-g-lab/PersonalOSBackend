using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalOSBackend.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financeiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Partilhado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refeicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiaDaSemana = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    PratoPrincipal = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    GrupoMuscular = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DuracaoMinutos = table.Column<int>(type: "INTEGER", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasPartilhadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FinanceiroId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeDaPessoa = table.Column<string>(type: "TEXT", nullable: false),
                    ValorParte = table.Column<decimal>(type: "TEXT", nullable: false),
                    EstaPago = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPartilhadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasPartilhadas_Financeiros_FinanceiroId",
                        column: x => x.FinanceiroId,
                        principalTable: "Financeiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasPartilhadas_FinanceiroId",
                table: "ContasPartilhadas",
                column: "FinanceiroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasPartilhadas");

            migrationBuilder.DropTable(
                name: "Refeicoes");

            migrationBuilder.DropTable(
                name: "Treinos");

            migrationBuilder.DropTable(
                name: "Financeiros");
        }
    }
}
