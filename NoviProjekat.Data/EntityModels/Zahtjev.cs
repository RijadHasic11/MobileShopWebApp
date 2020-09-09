using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Zahtjev
    {
        public int Id { get; set; }
        public DateTime DatumZahtjeva { get; set; }
        public bool Odgovoren { get; set; }
        public string Opis { get; set; }
        public int Prioritet { get; set; }

        [ForeignKey(nameof(Klijent))]
        public int? KlijentId { get; set; }
        public Klijent Klijent { get; set; }
    }
}
