using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class NabavkaStavke
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Nabavka))]
        public int? NabavkaId { get; set; }
        public Nabavka Nabavka { get; set; }

        public int Kolicina { get; set; }

        [ForeignKey(nameof(Artikal))]
        public int? ArtikalId { get; set; }
        public Artikal Artikal { get; set; }
    }
}
