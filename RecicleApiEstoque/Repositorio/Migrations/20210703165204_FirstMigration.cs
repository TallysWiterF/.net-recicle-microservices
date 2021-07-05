using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTOQUE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTIDADE = table.Column<decimal>(type: "numeric(38,17)", maxLength: 100, nullable: false),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    TIPOQUANTIDADE = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTOQUE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ITEM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDESTOQUE = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    IDDISTRIBUIDOR = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TIPOMATERIAL = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITEM_ESTOQUE_IDESTOQUE",
                        column: x => x.IDESTOQUE,
                        principalTable: "ESTOQUE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_IDDISTRIBUIDOR",
                table: "ITEM",
                column: "IDDISTRIBUIDOR");

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_IDESTOQUE",
                table: "ITEM",
                column: "IDESTOQUE",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITEM");

            migrationBuilder.DropTable(
                name: "ESTOQUE");
        }
    }
}
