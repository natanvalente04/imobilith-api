using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alugueis_API.Migrations
{
    /// <inheritdoc />
    public partial class foreignKey_Pessoa_Locatario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locatarios_Pessoas_PessoaCodPessoa",
                table: "Locatarios");

            migrationBuilder.DropIndex(
                name: "IX_Locatarios_PessoaCodPessoa",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "PessoaCodPessoa",
                table: "Locatarios");

            migrationBuilder.AddColumn<int>(
                name: "CodLocatario",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locatarios_CodPessoa",
                table: "Locatarios",
                column: "CodPessoa",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locatarios_Pessoas_CodPessoa",
                table: "Locatarios",
                column: "CodPessoa",
                principalTable: "Pessoas",
                principalColumn: "CodPessoa",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locatarios_Pessoas_CodPessoa",
                table: "Locatarios");

            migrationBuilder.DropIndex(
                name: "IX_Locatarios_CodPessoa",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "CodLocatario",
                table: "Pessoas");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Locatarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaCodPessoa",
                table: "Locatarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locatarios_PessoaCodPessoa",
                table: "Locatarios",
                column: "PessoaCodPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Locatarios_Pessoas_PessoaCodPessoa",
                table: "Locatarios",
                column: "PessoaCodPessoa",
                principalTable: "Pessoas",
                principalColumn: "CodPessoa");
        }
    }
}
