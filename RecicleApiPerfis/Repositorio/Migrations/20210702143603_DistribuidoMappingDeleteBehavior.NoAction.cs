using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class DistribuidoMappingDeleteBehaviorNoAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DISTRIBUIDOR_ENDERECO_IDENDERECO",
                table: "DISTRIBUIDOR");

            migrationBuilder.AddForeignKey(
                name: "FK_DISTRIBUIDOR_ENDERECO_IDENDERECO",
                table: "DISTRIBUIDOR",
                column: "IDENDERECO",
                principalTable: "ENDERECO",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DISTRIBUIDOR_ENDERECO_IDENDERECO",
                table: "DISTRIBUIDOR");

            migrationBuilder.AddForeignKey(
                name: "FK_DISTRIBUIDOR_ENDERECO_IDENDERECO",
                table: "DISTRIBUIDOR",
                column: "IDENDERECO",
                principalTable: "ENDERECO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
