using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraCoreEF.Migrations
{
    /// <inheritdoc />
    public partial class firstdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(180)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    ServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentInstallments = table.Column<int>(type: "int", nullable: false),
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedON = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
