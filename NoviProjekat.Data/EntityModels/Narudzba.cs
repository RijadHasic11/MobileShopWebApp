using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Narudzba
    {
        public int Id { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public bool Odobrena { get; set; }

        [ForeignKey(nameof(Klijent))]
        public int? KlijentId { get; set; }
        public Klijent Klijent { get; set; }

    }
}
