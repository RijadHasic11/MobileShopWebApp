using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Servis
    {

        public int Id { get; set; }
        public DateTime DatumPrimanja { get; set; }
        public string OpisServisa { get; set; }

        [ForeignKey(nameof(Klijent))]
        public int? KlijentId { get; set; }
        public Klijent Klijent { get; set; }

        [ForeignKey(nameof(Artikal))]
        public int? ArtikalId { get; set; }
        public Artikal Artikal { get; set; }

    }
}
