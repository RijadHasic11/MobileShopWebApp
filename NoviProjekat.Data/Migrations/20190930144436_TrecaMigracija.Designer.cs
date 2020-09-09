﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoviProjekat.Data;

namespace NoviProjekat.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190930144436_TrecaMigracija")]
    partial class TrecaMigracija
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Artikal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boja");

                    b.Property<float>("Cijena");

                    b.Property<int?>("ModelId");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Novo");

                    b.Property<string>("OpisArtikla");

                    b.Property<int?>("SkladisteId");

                    b.Property<byte[]>("Slika");

                    b.Property<int>("StanjeNaSkladistu");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Artikal");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KantonId");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("KantonId");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Kanton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Kanton");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Klijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<int?>("OsobaId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("OsobaId");

                    b.ToTable("Klijent");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<int>("ProizvodjacId");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodjacId");

                    b.ToTable("Modeli");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Nabavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumNabavke");

                    b.Property<float>("Kolicina");

                    b.Property<int?>("ProdavacID");

                    b.HasKey("Id");

                    b.HasIndex("ProdavacID");

                    b.ToTable("Nabavka");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.NabavkaStavke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtikalId");

                    b.Property<int?>("NabavkaId");

                    b.HasKey("Id");

                    b.HasIndex("ArtikalId");

                    b.HasIndex("NabavkaId");

                    b.ToTable("NabavkaStavke");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtikalId");

                    b.Property<DateTime>("DatumNarudzbe");

                    b.Property<int?>("KlijentId");

                    b.Property<float>("Kolicina");

                    b.Property<bool>("Odobrena");

                    b.HasKey("Id");

                    b.HasIndex("ArtikalId");

                    b.HasIndex("KlijentId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.ObavijestAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naslov");

                    b.Property<byte[]>("Slika");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Obavijesti");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.ObavijestProdavac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis");

                    b.Property<int?>("ProdavacId");

                    b.HasKey("Id");

                    b.HasIndex("ProdavacId");

                    b.ToTable("Obavijest");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Osobe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("BrojTelefona");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email");

                    b.Property<int>("GradId");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<int?>("SpolId");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.HasIndex("SpolId");

                    b.ToTable("Osobe");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Prodavac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<int?>("OsobaId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("OsobaId");

                    b.ToTable("Prodavac");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<byte[]>("Slika");

                    b.HasKey("Id");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Servis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtikalId");

                    b.Property<DateTime>("DatumPrimanja");

                    b.Property<int?>("KlijentId");

                    b.Property<string>("OpisServisa");

                    b.HasKey("Id");

                    b.HasIndex("ArtikalId");

                    b.HasIndex("KlijentId");

                    b.ToTable("Servis");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Serviser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<int>("GodineIskustva");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<int?>("OsobaId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("OsobaId");

                    b.ToTable("Serviser");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.ServisStavke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cijena");

                    b.Property<DateTime>("DatumZavrsetkaPosla");

                    b.Property<string>("OpisRada");

                    b.Property<int?>("ServisId");

                    b.Property<int?>("ServiserId");

                    b.HasKey("Id");

                    b.HasIndex("ServisId");

                    b.HasIndex("ServiserId");

                    b.ToTable("ServisStavke");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Skladiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Skladiste");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Spol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("Spol");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.StavkeZahtjev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Odgovor");

                    b.Property<int?>("ProdavacId");

                    b.Property<int?>("ZahtjevId");

                    b.HasKey("Id");

                    b.HasIndex("ProdavacId");

                    b.HasIndex("ZahtjevId");

                    b.ToTable("StavkeZahtjev");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Zahtjev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumZahtjeva");

                    b.Property<int?>("KlijentId");

                    b.Property<bool>("Odgovoren");

                    b.Property<string>("Opis");

                    b.Property<int>("Prioritet");

                    b.HasKey("Id");

                    b.HasIndex("KlijentId");

                    b.ToTable("Zahtjev");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Artikal", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Grad", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Kanton", "Kanton")
                        .WithMany()
                        .HasForeignKey("KantonId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Klijent", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Osobe", "Osoba")
                        .WithMany()
                        .HasForeignKey("OsobaId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Model", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Proizvodjac", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Nabavka", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Prodavac", "Prodavac")
                        .WithMany()
                        .HasForeignKey("ProdavacID");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.NabavkaStavke", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Artikal", "Artikal")
                        .WithMany()
                        .HasForeignKey("ArtikalId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Nabavka", "Nabavka")
                        .WithMany()
                        .HasForeignKey("NabavkaId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Narudzba", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Artikal", "Artikal")
                        .WithMany()
                        .HasForeignKey("ArtikalId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.ObavijestProdavac", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Prodavac", "Prodavac")
                        .WithMany()
                        .HasForeignKey("ProdavacId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Osobe", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NoviProjekat.Data.EntityModels.Spol", "Spol")
                        .WithMany()
                        .HasForeignKey("SpolId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Prodavac", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Osobe", "Osoba")
                        .WithMany()
                        .HasForeignKey("OsobaId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Servis", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Artikal", "Artikal")
                        .WithMany()
                        .HasForeignKey("ArtikalId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Serviser", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Osobe", "Osoba")
                        .WithMany()
                        .HasForeignKey("OsobaId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.ServisStavke", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Servis", "Servis")
                        .WithMany()
                        .HasForeignKey("ServisId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Serviser", "Serviser")
                        .WithMany()
                        .HasForeignKey("ServiserId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.StavkeZahtjev", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Prodavac", "Prodavac")
                        .WithMany()
                        .HasForeignKey("ProdavacId");

                    b.HasOne("NoviProjekat.Data.EntityModels.Zahtjev", "Zahtjev")
                        .WithMany()
                        .HasForeignKey("ZahtjevId");
                });

            modelBuilder.Entity("NoviProjekat.Data.EntityModels.Zahtjev", b =>
                {
                    b.HasOne("NoviProjekat.Data.EntityModels.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId");
                });
#pragma warning restore 612, 618
        }
    }
}
