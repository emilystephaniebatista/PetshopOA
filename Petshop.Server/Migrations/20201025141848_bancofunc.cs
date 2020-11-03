using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petshop.Server.Migrations
{
    public partial class bancofunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetshopId",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Numeroidentificacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PetshopId",
                table: "Clientes",
                column: "PetshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Petshops_PetshopId",
                table: "Clientes",
                column: "PetshopId",
                principalTable: "Petshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Petshops_PetshopId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PetshopId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PetshopId",
                table: "Clientes");
        }
    }
}
