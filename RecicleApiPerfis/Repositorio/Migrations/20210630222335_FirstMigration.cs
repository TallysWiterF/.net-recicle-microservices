using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COLETOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    IDUSER = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TELEFONE = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLETOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    RUA = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    CIDADE = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    BAIRRO = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DISTRIBUIDOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    IDUSER = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NUMERORESIDENCIA = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TELEFONE = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LATITUDE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LONGITUDE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IDENDERECO = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISTRIBUIDOR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DISTRIBUIDOR_ENDERECO_IDENDERECO",
                        column: x => x.IDENDERECO,
                        principalTable: "ENDERECO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COLETOR_IDUSER",
                table: "COLETOR",
                column: "IDUSER");

            migrationBuilder.CreateIndex(
                name: "IX_COLETOR_NOME",
                table: "COLETOR",
                column: "NOME");

            migrationBuilder.CreateIndex(
                name: "IX_DISTRIBUIDOR_IDENDERECO",
                table: "DISTRIBUIDOR",
                column: "IDENDERECO");

            migrationBuilder.CreateIndex(
                name: "IX_DISTRIBUIDOR_IDUSER",
                table: "DISTRIBUIDOR",
                column: "IDUSER");

            migrationBuilder.CreateIndex(
                name: "IX_DISTRIBUIDOR_NOME",
                table: "DISTRIBUIDOR",
                column: "NOME");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_CEP",
                table: "ENDERECO",
                column: "CEP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COLETOR");

            migrationBuilder.DropTable(
                name: "DISTRIBUIDOR");

            migrationBuilder.DropTable(
                name: "ENDERECO");
        }
    }
}
