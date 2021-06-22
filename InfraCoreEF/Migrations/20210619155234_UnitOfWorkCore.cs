﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraCoreEF.Migrations
{
    public partial class UnitOfWorkCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Blog",
            //    columns: table => new
            //    {
            //        BlogId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Url = table.Column<string>(type: "varchar(14)", nullable: true),
            //        Name = table.Column<string>(type: "varchar(14)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Blog", x => x.BlogId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Posts",
            //    columns: table => new
            //    {
            //        PostId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        BlogId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Posts", x => x.PostId);
            //        table.ForeignKey(
            //            name: "FK_Posts_Blog_BlogId",
            //            column: x => x.BlogId,
            //            principalTable: "Blog",
            //            principalColumn: "BlogId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Posts_BlogId",
            //    table: "Posts",
            //    column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
