using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoviProjekat.Data.Migrations
{
    public partial class DrugaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opis",
                table: "Artikal",
                newName: "OpisArtikla");

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumNarudzbe = table.Column<DateTime>(nullable: false),
                    Kolicina = table.Column<float>(nullable: false),
                    Odobrena = table.Column<bool>(nullable: false),
                    KlijentId = table.Column<int>(nullable: true),
                    ArtikalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Artikal_ArtikalId",
                        column: x => x.ArtikalId,
                        principalTable: "Artikal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzba_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prodavac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumZaposlenja = table.Column<DateTime>(nullable: false),
                    OsobaId = table.Column<int>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodavac_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prodavac_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPrimanja = table.Column<DateTime>(nullable: false),
                    OpisServisa = table.Column<string>(nullable: true),
                    KlijentId = table.Column<int>(nullable: true),
                    ArtikalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servis_Artikal_ArtikalId",
                        column: x => x.ArtikalId,
                        principalTable: "Artikal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servis_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Serviser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GodineIskustva = table.Column<int>(nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(nullable: false),
                    OsobaId = table.Column<int>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serviser_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Serviser_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumZahtjeva = table.Column<DateTime>(nullable: false),
                    Odgovoren = table.Column<bool>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Prioritet = table.Column<int>(nullable: false),
                    KlijentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nabavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumNabavke = table.Column<DateTime>(nullable: false),
                    Kolicina = table.Column<float>(nullable: false),
                    ProdavacID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nabavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nabavka_Prodavac_ProdavacID",
                        column: x => x.ProdavacID,
                        principalTable: "Prodavac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    ProdavacId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obavijest_Prodavac_ProdavacId",
                        column: x => x.ProdavacId,
                        principalTable: "Prodavac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServisStavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpisRada = table.Column<string>(nullable: true),
                    DatumZavrsetkaPosla = table.Column<DateTime>(nullable: false),
                    Cijena = table.Column<float>(nullable: false),
                    ServiserId = table.Column<int>(nullable: true),
                    ServisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServisStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServisStavke_Servis_ServisId",
                        column: x => x.ServisId,
                        principalTable: "Servis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServisStavke_Serviser_ServiserId",
                        column: x => x.ServiserId,
                        principalTable: "Serviser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StavkeZahtjev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZahtjevId = table.Column<int>(nullable: true),
                    ProdavacId = table.Column<int>(nullable: true),
                    Odgovor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeZahtjev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkeZahtjev_Prodavac_ProdavacId",
                        column: x => x.ProdavacId,
                        principalTable: "Prodavac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StavkeZahtjev_Zahtjev_ZahtjevId",
                        column: x => x.ZahtjevId,
                        principalTable: "Zahtjev",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NabavkaStavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NabavkaId = table.Column<int>(nullable: true),
                    ArtikalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavkaStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabavkaStavke_Artikal_ArtikalId",
                        column: x => x.ArtikalId,
                        principalTable: "Artikal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NabavkaStavke_Nabavka_NabavkaId",
                        column: x => x.NabavkaId,
                        principalTable: "Nabavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_ProdavacID",
                table: "Nabavka",
                column: "ProdavacID");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavke_ArtikalId",
                table: "NabavkaStavke",
                column: "ArtikalId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavke_NabavkaId",
                table: "NabavkaStavke",
                column: "NabavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_ArtikalId",
                table: "Narudzba",
                column: "ArtikalId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KlijentId",
                table: "Narudzba",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_ProdavacId",
                table: "Obavijest",
                column: "ProdavacId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavac_KorisnickiNalogId",
                table: "Prodavac",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavac_OsobaId",
                table: "Prodavac",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_ArtikalId",
                table: "Servis",
                column: "ArtikalId");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_KlijentId",
                table: "Servis",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Serviser_KorisnickiNalogId",
                table: "Serviser",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Serviser_OsobaId",
                table: "Serviser",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisStavke_ServisId",
                table: "ServisStavke",
                column: "ServisId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisStavke_ServiserId",
                table: "ServisStavke",
                column: "ServiserId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeZahtjev_ProdavacId",
                table: "StavkeZahtjev",
                column: "ProdavacId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeZahtjev_ZahtjevId",
                table: "StavkeZahtjev",
                column: "ZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_KlijentId",
                table: "Zahtjev",
                column: "KlijentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NabavkaStavke");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "ServisStavke");

            migrationBuilder.DropTable(
                name: "StavkeZahtjev");

            migrationBuilder.DropTable(
                name: "Nabavka");

            migrationBuilder.DropTable(
                name: "Servis");

            migrationBuilder.DropTable(
                name: "Serviser");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "Prodavac");

            migrationBuilder.RenameColumn(
                name: "OpisArtikla",
                table: "Artikal",
                newName: "Opis");
        }
    }
}
