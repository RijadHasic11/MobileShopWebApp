using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoviProjekat.Data.Migrations
{
    public partial class TrecaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Slika",
                table: "Proizvodjac",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Boja",
                table: "Artikal",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Novo",
                table: "Artikal",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "Slika",
                table: "Artikal",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Obavijesti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naslov = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijesti", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obavijesti");

            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Proizvodjac");

            migrationBuilder.DropColumn(
                name: "Boja",
                table: "Artikal");

            migrationBuilder.DropColumn(
                name: "Novo",
                table: "Artikal");

            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Artikal");
        }
    }
}
