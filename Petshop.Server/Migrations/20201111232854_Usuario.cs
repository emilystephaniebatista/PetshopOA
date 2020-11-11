using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petshop.Server.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorizacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CadastrarAnimal = table.Column<int>(nullable: false),
                    EditarAnimal = table.Column<int>(nullable: false),
                    ExcluirAnimal = table.Column<int>(nullable: false),
                    VerAnimal = table.Column<int>(nullable: false),
                    CadastrarPetshop = table.Column<int>(nullable: false),
                    CadastrarServico = table.Column<int>(nullable: false),
                    CadastrarContraatos = table.Column<int>(nullable: false),
                    CadastrarFuncionario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorizacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    AutorizacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Autorizacao_AutorizacaoId",
                        column: x => x.AutorizacaoId,
                        principalTable: "Autorizacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_AutorizacaoId",
                table: "Usuario",
                column: "AutorizacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Autorizacao");
        }
    }
}
