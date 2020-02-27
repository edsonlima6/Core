using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Cliente",
            //     columns: table => new
            //     {
            //         IdCliente = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //         RazaoSocial = table.Column<string>(type: "varchar(250)", nullable: true),
            //         InscricaoEstadual = table.Column<string>(type: "varchar(14)", nullable: true),
            //         DataNascimento = table.Column<DateTime>(nullable: true),
            //         CpfCnpj = table.Column<string>(type: "varchar(12)", nullable: true),
            //         Rg = table.Column<string>(type: "varchar(12)", nullable: true),
            //         DataCadastro = table.Column<DateTime>(nullable: false),
            //         DataAlteracao = table.Column<DateTime>(nullable: true),
            //         Genero = table.Column<int>(nullable: true),
            //         EstadoCivil = table.Column<int>(nullable: false),
            //         Ativo = table.Column<int>(nullable: false),
            //         Codclie = table.Column<string>(nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Cliente", x => x.IdCliente);
            //     });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
