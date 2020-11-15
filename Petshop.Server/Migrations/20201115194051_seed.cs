using Microsoft.EntityFrameworkCore.Migrations;

namespace Petshop.Server.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autorizacao",
                columns: new[] { "Id", "CadastrarAnimal", "CadastrarContraatos", "CadastrarFuncionario", "CadastrarPetshop", "CadastrarServico", "EditarAnimal", "ExcluirAnimal", "VerAnimal" },
                values: new object[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "AutorizacaoId", "Email", "Senha" },
                values: new object[] { 1, 1, "emily@teste.com.br", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autorizacao",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
