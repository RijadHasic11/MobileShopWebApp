using Microsoft.EntityFrameworkCore.Migrations;

namespace NoviProjekat.Data.Migrations
{
    public partial class MigracijaNova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Artikal_ArtikalId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_ArtikalId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "ArtikalId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Narudzba");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtikalId",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Kolicina",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_ArtikalId",
                table: "Narudzba",
                column: "ArtikalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Artikal_ArtikalId",
                table: "Narudzba",
                column: "ArtikalId",
                principalTable: "Artikal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
