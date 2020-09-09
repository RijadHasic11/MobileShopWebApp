using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class NarudzbaStavke
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }

        [ForeignKey(nameof(Narudzba))]
        public int? NarudzbaId { get; set; }
        public Narudzba Narudzba { get; set; }

        [ForeignKey(nameof(Artikal))]
        public int? ArtikalId { get; set; }
        public Artikal Artikal { get; set; }


        public float UkupnaCijena { get; set; }
    }
}
