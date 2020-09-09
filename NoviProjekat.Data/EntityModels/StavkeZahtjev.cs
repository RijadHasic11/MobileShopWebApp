using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class StavkeZahtjev
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Zahtjev))]
        public int? ZahtjevId { get; set; }
        public Zahtjev Zahtjev { get; set; }

        [ForeignKey(nameof(Prodavac))]
        public int? ProdavacId { get; set; }
        public Prodavac Prodavac { get; set; }

        public string Odgovor { get; set; }
    }
}
