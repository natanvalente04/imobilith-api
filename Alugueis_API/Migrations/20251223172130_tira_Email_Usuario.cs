using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alugueis_API.Migrations
{
    /// <inheritdoc />
    public partial class tira_Email_Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
