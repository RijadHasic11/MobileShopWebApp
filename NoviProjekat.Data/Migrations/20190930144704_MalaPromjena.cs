using Microsoft.EntityFrameworkCore.Migrations;

namespace NoviProjekat.Data.Migrations
{
    public partial class MalaPromjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_Prodavac_ProdavacId",
                table: "Obavijest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Obavijesti",
                table: "Obavijesti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Obavijest",
                table: "Obavijest");

            migrationBuilder.RenameTable(
                name: "Obavijesti",
                newName: "ObavijestAdmin");

            migrationBuilder.RenameTable(
                name: "Obavijest",
                newName: "ObavijestProdavac");

            migrationBuilder.RenameIndex(
                name: "IX_Obavijest_ProdavacId",
                table: "ObavijestProdavac",
                newName: "IX_ObavijestProdavac_ProdavacId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObavijestAdmin",
                table: "ObavijestAdmin",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObavijestProdavac",
                table: "ObavijestProdavac",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObavijestProdavac_Prodavac_ProdavacId",
                table: "ObavijestProdavac",
                column: "ProdavacId",
                principalTable: "Prodavac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObavijestProdavac_Prodavac_ProdavacId",
                table: "ObavijestProdavac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObavijestProdavac",
                table: "ObavijestProdavac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObavijestAdmin",
                table: "ObavijestAdmin");

            migrationBuilder.RenameTable(
                name: "ObavijestProdavac",
                newName: "Obavijest");

            migrationBuilder.RenameTable(
                name: "ObavijestAdmin",
                newName: "Obavijesti");

            migrationBuilder.RenameIndex(
                name: "IX_ObavijestProdavac_ProdavacId",
                table: "Obavijest",
                newName: "IX_Obavijest_ProdavacId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Obavijest",
                table: "Obavijest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Obavijesti",
                table: "Obavijesti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_Prodavac_ProdavacId",
                table: "Obavijest",
                column: "ProdavacId",
                principalTable: "Prodavac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
