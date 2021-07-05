using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class DistribuidorEnderecoPropriedadeNavegacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "DISTRIBUIDOR",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DISTRIBUIDOR_EnderecoId",
                table: "DISTRIBUIDOR",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DISTRIBUIDOR_ENDERECO_EnderecoId",
                table: "DISTRIBUIDOR",
                column: "EnderecoId",
                principalTable: "ENDERECO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DISTRIBUIDOR_ENDERECO_EnderecoId",
                table: "DISTRIBUIDOR");

            migrationBuilder.DropIndex(
                name: "IX_DISTRIBUIDOR_EnderecoId",
                table: "DISTRIBUIDOR");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "DISTRIBUIDOR");
        }
    }
}
