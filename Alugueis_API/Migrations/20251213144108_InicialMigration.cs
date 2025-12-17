using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alugueis_API.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    CodPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePessoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.CodPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Predios",
                columns: table => new
                {
                    CodPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtdAndares = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePredio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predios", x => x.CodPredio);
                });

            migrationBuilder.CreateTable(
                name: "TiposDespesa",
                columns: table => new
                {
                    CodTipoDespesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoDespesa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compartilhado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDespesa", x => x.CodTipoDespesa);
                });

            migrationBuilder.CreateTable(
                name: "Locatarios",
                columns: table => new
                {
                    CodLocatario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    TemPet = table.Column<int>(type: "int", nullable: false),
                    CodPessoa = table.Column<int>(type: "int", nullable: false),
                    QtdDependentes = table.Column<int>(type: "int", nullable: false),
                    PessoaCodPessoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatarios", x => x.CodLocatario);
                    table.ForeignKey(
                        name: "FK_Locatarios_Pessoas_PessoaCodPessoa",
                        column: x => x.PessoaCodPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "CodPessoa");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPessoa = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    SenhaHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SenhaSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Pessoas_CodPessoa",
                        column: x => x.CodPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "CodPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aptos",
                columns: table => new
                {
                    CodApto = table.Column<int>(type: "int", nullable: false),
                    CodPredio = table.Column<int>(type: "int", nullable: false),
                    Andar = table.Column<int>(type: "int", nullable: false),
                    QtdQuartos = table.Column<int>(type: "int", nullable: false),
                    QtdBanheiros = table.Column<int>(type: "int", nullable: false),
                    MetrosQuadrados = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aptos", x => x.CodApto);
                    table.ForeignKey(
                        name: "FK_Aptos_Predios_CodPredio",
                        column: x => x.CodPredio,
                        principalTable: "Predios",
                        principalColumn: "CodPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    CodDespesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodTipoDespesa = table.Column<int>(type: "int", nullable: false),
                    VrlTotalDespesa = table.Column<float>(type: "real", nullable: false),
                    DataDespesa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompetenciaMes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.CodDespesa);
                    table.ForeignKey(
                        name: "FK_Despesas_TiposDespesa_CodTipoDespesa",
                        column: x => x.CodTipoDespesa,
                        principalTable: "TiposDespesa",
                        principalColumn: "CodTipoDespesa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    CodLocacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodApto = table.Column<int>(type: "int", nullable: false),
                    codLocatario = table.Column<int>(type: "int", nullable: false),
                    VlrAluguel = table.Column<float>(type: "real", nullable: false),
                    VlrCausao = table.Column<float>(type: "real", nullable: false),
                    DataIncio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.CodLocacao);
                    table.ForeignKey(
                        name: "FK_Locacoes_Aptos_CodApto",
                        column: x => x.CodApto,
                        principalTable: "Aptos",
                        principalColumn: "CodApto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locacoes_Locatarios_codLocatario",
                        column: x => x.codLocatario,
                        principalTable: "Locatarios",
                        principalColumn: "CodLocatario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespesaRateios",
                columns: table => new
                {
                    CodDespesa = table.Column<int>(type: "int", nullable: false),
                    CodApto = table.Column<int>(type: "int", nullable: false),
                    VlrRateio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesaRateios", x => new { x.CodDespesa, x.CodApto });
                    table.ForeignKey(
                        name: "FK_DespesaRateios_Aptos_CodApto",
                        column: x => x.CodApto,
                        principalTable: "Aptos",
                        principalColumn: "CodApto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DespesaRateios_Despesas_CodDespesa",
                        column: x => x.CodDespesa,
                        principalTable: "Despesas",
                        principalColumn: "CodDespesa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aptos_CodPredio",
                table: "Aptos",
                column: "CodPredio");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaRateios_CodApto",
                table: "DespesaRateios",
                column: "CodApto");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CodTipoDespesa",
                table: "Despesas",
                column: "CodTipoDespesa");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_CodApto",
                table: "Locacoes",
                column: "CodApto");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_codLocatario",
                table: "Locacoes",
                column: "codLocatario");

            migrationBuilder.CreateIndex(
                name: "IX_Locatarios_PessoaCodPessoa",
                table: "Locatarios",
                column: "PessoaCodPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CodPessoa",
                table: "Usuarios",
                column: "CodPessoa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesaRateios");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Aptos");

            migrationBuilder.DropTable(
                name: "Locatarios");

            migrationBuilder.DropTable(
                name: "TiposDespesa");

            migrationBuilder.DropTable(
                name: "Predios");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
