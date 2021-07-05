using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AGENDAMENTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    IDITEM = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    IDCOLETOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HORACOLETA = table.Column<int>(type: "integer", nullable: false),
                    MINUTOCOLETA = table.Column<int>(type: "integer", nullable: false),
                    DIADASEMANACOLETA = table.Column<string>(type: "varchar(10)", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDAMENTO", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDAMENTO");
        }
    }
}
