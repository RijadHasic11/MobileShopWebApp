using Microsoft.EntityFrameworkCore;
using NoviProjekat.Data.EntityModels;
using System;

namespace NoviProjekat.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> x) : base(x)
        {

        }
      
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
        public DbSet<Artikal> Artikal { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Kanton> Kanton { get; set; }
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<Nabavka> Nabavka { get; set; }
        public DbSet<NabavkaStavke> NabavkaStavke { get; set; }
        public DbSet<Model> Modeli { get; set; }
        public DbSet<Osobe> Osobe { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<ObavijestProdavac> ObavijestProdavac { get; set; }
        public DbSet<ObavijestAdmin> ObavijestAdmin { get; set; }
        public DbSet<Prodavac> Prodavac { get; set; }
        public DbSet<Skladiste> Skladiste { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
        public DbSet<Spol> Spol { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        public DbSet<StavkeZahtjev> StavkeZahtjev { get; set; }
        public DbSet<Serviser> Serviser { get; set; }
        public DbSet<Servis> Servis { get; set; }
        public DbSet<ServisStavke> ServisStavke { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
       
        public DbSet<Admin> Admin { get; set; }
        public DbSet<NarudzbaStavke> NarudzbaStavke { get; set; }
    }
}
