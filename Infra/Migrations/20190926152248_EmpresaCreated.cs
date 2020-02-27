using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class EmpresaCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Empresa",
            //     columns: table => new
            //     {
            //         idRazaoSocial = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //         sRazaoSocial = table.Column<string>(type: "varchar(400)", nullable: true),
            //         dtCadastro = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
            //         nDiaCobranca = table.Column<int>(nullable: false),
            //         sCnpjCpf = table.Column<string>(nullable: true),
            //         sEndereco = table.Column<string>(nullable: true),
            //         sCidade = table.Column<string>(nullable: true),
            //         sEstado = table.Column<string>(nullable: true),
            //         nContato = table.Column<string>(nullable: true),
            //         sCep = table.Column<string>(nullable: true),
            //         sCorrente = table.Column<bool>(nullable: false),
            //         nQtdeParcelas = table.Column<int>(nullable: false),
            //         nValorAproximado = table.Column<decimal>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Empresa", x => x.idRazaoSocial);
            //     });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
