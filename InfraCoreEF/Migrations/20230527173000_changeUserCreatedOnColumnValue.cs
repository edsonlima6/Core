using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraCoreEF.Migrations
{
    /// <inheritdoc />
    public partial class changeUserCreatedOnColumnValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedON",
                table: "User",
                type: "datetime",
                nullable: false,
                defaultValueSql: "Getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 27, 18, 23, 52, 156, DateTimeKind.Local).AddTicks(6784));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedON",
                table: "User",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 18, 23, 52, 156, DateTimeKind.Local).AddTicks(6784),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "Getdate()");
        }
    }
}
