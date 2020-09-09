IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921150705_Proba1')
BEGIN
    CREATE TABLE [Kanton] (
        [Id] int NOT NULL IDENTITY,
        [Naziv] nvarchar(max) NULL,
        CONSTRAINT [PK_Kanton] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921150705_Proba1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190921150705_Proba1', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [Grad] (
        [Id] int NOT NULL IDENTITY,
        [Naziv] nvarchar(max) NULL,
        [KantonId] int NULL,
        CONSTRAINT [PK_Grad] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Grad_Kanton_KantonId] FOREIGN KEY ([KantonId]) REFERENCES [Kanton] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [KorisnickiNalog] (
        [Id] int NOT NULL IDENTITY,
        [KorisnickoIme] nvarchar(max) NULL,
        [Lozinka] nvarchar(max) NULL,
        CONSTRAINT [PK_KorisnickiNalog] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [Proizvodjac] (
        [Id] int NOT NULL IDENTITY,
        [Naziv] nvarchar(max) NULL,
        CONSTRAINT [PK_Proizvodjac] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [Skladiste] (
        [Id] int NOT NULL IDENTITY,
        [Naziv] nvarchar(max) NULL,
        CONSTRAINT [PK_Skladiste] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [Spol] (
        [Id] int NOT NULL IDENTITY,
        [Opis] nvarchar(max) NULL,
        CONSTRAINT [PK_Spol] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [Modeli] (
        [Id] int NOT NULL IDENTITY,
        [Naziv] nvarchar(max) NULL,
        [ProizvodjacId] int NOT NULL,
        CONSTRAINT [PK_Modeli] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Modeli_Proizvodjac_ProizvodjacId] FOREIGN KEY ([ProizvodjacId]) REFERENCES [Proizvodjac] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [Osobe] (
        [Id] int NOT NULL IDENTITY,
        [Ime] nvarchar(max) NULL,
        [Prezime] nvarchar(max) NULL,
        [DatumRodjenja] datetime2 NOT NULL,
        [GradId] int NOT NULL,
        [SpolId] int NULL,
        [BrojTelefona] nvarchar(max) NULL,
        [Adresa] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        CONSTRAINT [PK_Osobe] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Osobe_Grad_GradId] FOREIGN KEY ([GradId]) REFERENCES [Grad] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Osobe_Spol_SpolId] FOREIGN KEY ([SpolId]) REFERENCES [Spol] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [Artikal] (
        [Id] int NOT NULL IDENTITY,
        [Naziv] nvarchar(max) NULL,
        [Opis] nvarchar(max) NULL,
        [Cijena] real NOT NULL,
        [ModelId] int NULL,
        [SkladisteId] int NULL,
        [StanjeNaSkladistu] int NOT NULL,
        CONSTRAINT [PK_Artikal] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Artikal_Modeli_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [Modeli] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Artikal_Skladiste_SkladisteId] FOREIGN KEY ([SkladisteId]) REFERENCES [Skladiste] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE TABLE [Klijent] (
        [Id] int NOT NULL IDENTITY,
        [OsobaId] int NULL,
        [KorisnickiNalogId] int NULL,
        CONSTRAINT [PK_Klijent] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Klijent_KorisnickiNalog_KorisnickiNalogId] FOREIGN KEY ([KorisnickiNalogId]) REFERENCES [KorisnickiNalog] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Klijent_Osobe_OsobaId] FOREIGN KEY ([OsobaId]) REFERENCES [Osobe] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE INDEX [IX_Artikal_ModelId] ON [Artikal] ([ModelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE INDEX [IX_Artikal_SkladisteId] ON [Artikal] ([SkladisteId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE INDEX [IX_Grad_KantonId] ON [Grad] ([KantonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE INDEX [IX_Klijent_KorisnickiNalogId] ON [Klijent] ([KorisnickiNalogId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE INDEX [IX_Klijent_OsobaId] ON [Klijent] ([OsobaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE INDEX [IX_Modeli_ProizvodjacId] ON [Modeli] ([ProizvodjacId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE INDEX [IX_Osobe_GradId] ON [Osobe] ([GradId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    CREATE INDEX [IX_Osobe_SpolId] ON [Osobe] ([SpolId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921153043_PrvaMigracija')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190921153043_PrvaMigracija', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    EXEC sp_rename N'[Artikal].[Opis]', N'OpisArtikla', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [Narudzba] (
        [Id] int NOT NULL IDENTITY,
        [DatumNarudzbe] datetime2 NOT NULL,
        [Kolicina] real NOT NULL,
        [Odobrena] bit NOT NULL,
        [KlijentId] int NULL,
        [ArtikalId] int NULL,
        CONSTRAINT [PK_Narudzba] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Narudzba_Artikal_ArtikalId] FOREIGN KEY ([ArtikalId]) REFERENCES [Artikal] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Narudzba_Klijent_KlijentId] FOREIGN KEY ([KlijentId]) REFERENCES [Klijent] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [Prodavac] (
        [Id] int NOT NULL IDENTITY,
        [DatumZaposlenja] datetime2 NOT NULL,
        [OsobaId] int NULL,
        [KorisnickiNalogId] int NULL,
        CONSTRAINT [PK_Prodavac] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Prodavac_KorisnickiNalog_KorisnickiNalogId] FOREIGN KEY ([KorisnickiNalogId]) REFERENCES [KorisnickiNalog] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Prodavac_Osobe_OsobaId] FOREIGN KEY ([OsobaId]) REFERENCES [Osobe] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [Servis] (
        [Id] int NOT NULL IDENTITY,
        [DatumPrimanja] datetime2 NOT NULL,
        [OpisServisa] nvarchar(max) NULL,
        [KlijentId] int NULL,
        [ArtikalId] int NULL,
        CONSTRAINT [PK_Servis] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Servis_Artikal_ArtikalId] FOREIGN KEY ([ArtikalId]) REFERENCES [Artikal] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Servis_Klijent_KlijentId] FOREIGN KEY ([KlijentId]) REFERENCES [Klijent] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [Serviser] (
        [Id] int NOT NULL IDENTITY,
        [GodineIskustva] int NOT NULL,
        [DatumZaposlenja] datetime2 NOT NULL,
        [OsobaId] int NULL,
        [KorisnickiNalogId] int NULL,
        CONSTRAINT [PK_Serviser] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Serviser_KorisnickiNalog_KorisnickiNalogId] FOREIGN KEY ([KorisnickiNalogId]) REFERENCES [KorisnickiNalog] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Serviser_Osobe_OsobaId] FOREIGN KEY ([OsobaId]) REFERENCES [Osobe] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [Zahtjev] (
        [Id] int NOT NULL IDENTITY,
        [DatumZahtjeva] datetime2 NOT NULL,
        [Odgovoren] bit NOT NULL,
        [Opis] nvarchar(max) NULL,
        [Prioritet] int NOT NULL,
        [KlijentId] int NULL,
        CONSTRAINT [PK_Zahtjev] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Zahtjev_Klijent_KlijentId] FOREIGN KEY ([KlijentId]) REFERENCES [Klijent] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [Nabavka] (
        [Id] int NOT NULL IDENTITY,
        [DatumNabavke] datetime2 NOT NULL,
        [Kolicina] real NOT NULL,
        [ProdavacID] int NULL,
        CONSTRAINT [PK_Nabavka] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Nabavka_Prodavac_ProdavacID] FOREIGN KEY ([ProdavacID]) REFERENCES [Prodavac] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [Obavijest] (
        [Id] int NOT NULL IDENTITY,
        [Opis] nvarchar(max) NULL,
        [ProdavacId] int NULL,
        CONSTRAINT [PK_Obavijest] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Obavijest_Prodavac_ProdavacId] FOREIGN KEY ([ProdavacId]) REFERENCES [Prodavac] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [ServisStavke] (
        [Id] int NOT NULL IDENTITY,
        [OpisRada] nvarchar(max) NULL,
        [DatumZavrsetkaPosla] datetime2 NOT NULL,
        [Cijena] real NOT NULL,
        [ServiserId] int NULL,
        [ServisId] int NULL,
        CONSTRAINT [PK_ServisStavke] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ServisStavke_Servis_ServisId] FOREIGN KEY ([ServisId]) REFERENCES [Servis] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ServisStavke_Serviser_ServiserId] FOREIGN KEY ([ServiserId]) REFERENCES [Serviser] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [StavkeZahtjev] (
        [Id] int NOT NULL IDENTITY,
        [ZahtjevId] int NULL,
        [ProdavacId] int NULL,
        [Odgovor] nvarchar(max) NULL,
        CONSTRAINT [PK_StavkeZahtjev] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_StavkeZahtjev_Prodavac_ProdavacId] FOREIGN KEY ([ProdavacId]) REFERENCES [Prodavac] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_StavkeZahtjev_Zahtjev_ZahtjevId] FOREIGN KEY ([ZahtjevId]) REFERENCES [Zahtjev] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE TABLE [NabavkaStavke] (
        [Id] int NOT NULL IDENTITY,
        [NabavkaId] int NULL,
        [ArtikalId] int NULL,
        CONSTRAINT [PK_NabavkaStavke] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_NabavkaStavke_Artikal_ArtikalId] FOREIGN KEY ([ArtikalId]) REFERENCES [Artikal] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_NabavkaStavke_Nabavka_NabavkaId] FOREIGN KEY ([NabavkaId]) REFERENCES [Nabavka] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Nabavka_ProdavacID] ON [Nabavka] ([ProdavacID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_NabavkaStavke_ArtikalId] ON [NabavkaStavke] ([ArtikalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_NabavkaStavke_NabavkaId] ON [NabavkaStavke] ([NabavkaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Narudzba_ArtikalId] ON [Narudzba] ([ArtikalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Narudzba_KlijentId] ON [Narudzba] ([KlijentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Obavijest_ProdavacId] ON [Obavijest] ([ProdavacId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Prodavac_KorisnickiNalogId] ON [Prodavac] ([KorisnickiNalogId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Prodavac_OsobaId] ON [Prodavac] ([OsobaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Servis_ArtikalId] ON [Servis] ([ArtikalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Servis_KlijentId] ON [Servis] ([KlijentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Serviser_KorisnickiNalogId] ON [Serviser] ([KorisnickiNalogId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Serviser_OsobaId] ON [Serviser] ([OsobaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_ServisStavke_ServisId] ON [ServisStavke] ([ServisId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_ServisStavke_ServiserId] ON [ServisStavke] ([ServiserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_StavkeZahtjev_ProdavacId] ON [StavkeZahtjev] ([ProdavacId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_StavkeZahtjev_ZahtjevId] ON [StavkeZahtjev] ([ZahtjevId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    CREATE INDEX [IX_Zahtjev_KlijentId] ON [Zahtjev] ([KlijentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921160310_DrugaMigracija')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190921160310_DrugaMigracija', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144436_TrecaMigracija')
BEGIN
    ALTER TABLE [Proizvodjac] ADD [Slika] varbinary(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144436_TrecaMigracija')
BEGIN
    ALTER TABLE [Artikal] ADD [Boja] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144436_TrecaMigracija')
BEGIN
    ALTER TABLE [Artikal] ADD [Novo] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144436_TrecaMigracija')
BEGIN
    ALTER TABLE [Artikal] ADD [Slika] varbinary(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144436_TrecaMigracija')
BEGIN
    CREATE TABLE [Obavijesti] (
        [Id] int NOT NULL IDENTITY,
        [Naslov] nvarchar(max) NULL,
        [Text] nvarchar(max) NULL,
        [Slika] varbinary(max) NULL,
        CONSTRAINT [PK_Obavijesti] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144436_TrecaMigracija')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190930144436_TrecaMigracija', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    ALTER TABLE [Obavijest] DROP CONSTRAINT [FK_Obavijest_Prodavac_ProdavacId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    ALTER TABLE [Obavijesti] DROP CONSTRAINT [PK_Obavijesti];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    ALTER TABLE [Obavijest] DROP CONSTRAINT [PK_Obavijest];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    EXEC sp_rename N'[Obavijesti]', N'ObavijestAdmin';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    EXEC sp_rename N'[Obavijest]', N'ObavijestProdavac';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    EXEC sp_rename N'[ObavijestProdavac].[IX_Obavijest_ProdavacId]', N'IX_ObavijestProdavac_ProdavacId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    ALTER TABLE [ObavijestAdmin] ADD CONSTRAINT [PK_ObavijestAdmin] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    ALTER TABLE [ObavijestProdavac] ADD CONSTRAINT [PK_ObavijestProdavac] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    ALTER TABLE [ObavijestProdavac] ADD CONSTRAINT [FK_ObavijestProdavac_Prodavac_ProdavacId] FOREIGN KEY ([ProdavacId]) REFERENCES [Prodavac] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190930144704_MalaPromjena')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190930144704_MalaPromjena', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131343_MigracijaNova')
BEGIN
    ALTER TABLE [Narudzba] DROP CONSTRAINT [FK_Narudzba_Artikal_ArtikalId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131343_MigracijaNova')
BEGIN
    DROP INDEX [IX_Narudzba_ArtikalId] ON [Narudzba];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131343_MigracijaNova')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Narudzba]') AND [c].[name] = N'ArtikalId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Narudzba] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Narudzba] DROP COLUMN [ArtikalId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131343_MigracijaNova')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Narudzba]') AND [c].[name] = N'Kolicina');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Narudzba] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Narudzba] DROP COLUMN [Kolicina];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131343_MigracijaNova')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191027131343_MigracijaNova', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131653_MigracijaNova1')
BEGIN
    CREATE TABLE [Admin] (
        [Id] int NOT NULL IDENTITY,
        [DatumZaposlenja] datetime2 NOT NULL,
        [OsobaId] int NULL,
        [KorisnickiNalogId] int NULL,
        CONSTRAINT [PK_Admin] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Admin_KorisnickiNalog_KorisnickiNalogId] FOREIGN KEY ([KorisnickiNalogId]) REFERENCES [KorisnickiNalog] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Admin_Osobe_OsobaId] FOREIGN KEY ([OsobaId]) REFERENCES [Osobe] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131653_MigracijaNova1')
BEGIN
    CREATE TABLE [NarudzbaStavke] (
        [Id] int NOT NULL IDENTITY,
        [Kolicina] int NOT NULL,
        [NarudzbaId] int NULL,
        [ArtikalId] int NULL,
        [UkupnaCijena] real NOT NULL,
        CONSTRAINT [PK_NarudzbaStavke] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_NarudzbaStavke_Artikal_ArtikalId] FOREIGN KEY ([ArtikalId]) REFERENCES [Artikal] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_NarudzbaStavke_Narudzba_NarudzbaId] FOREIGN KEY ([NarudzbaId]) REFERENCES [Narudzba] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131653_MigracijaNova1')
BEGIN
    CREATE INDEX [IX_Admin_KorisnickiNalogId] ON [Admin] ([KorisnickiNalogId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131653_MigracijaNova1')
BEGIN
    CREATE INDEX [IX_Admin_OsobaId] ON [Admin] ([OsobaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131653_MigracijaNova1')
BEGIN
    CREATE INDEX [IX_NarudzbaStavke_ArtikalId] ON [NarudzbaStavke] ([ArtikalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131653_MigracijaNova1')
BEGIN
    CREATE INDEX [IX_NarudzbaStavke_NarudzbaId] ON [NarudzbaStavke] ([NarudzbaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027131653_MigracijaNova1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191027131653_MigracijaNova1', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027144626_MigracijaNova2')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Nabavka]') AND [c].[name] = N'Kolicina');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Nabavka] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Nabavka] DROP COLUMN [Kolicina];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027144626_MigracijaNova2')
BEGIN
    ALTER TABLE [NabavkaStavke] ADD [Kolicina] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191027144626_MigracijaNova2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191027144626_MigracijaNova2', N'2.1.11-servicing-32099');
END;

GO

