using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Serviser
    {
        public int Id { get; set; }
        public int GodineIskustva { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumZaposlenja { get; set; }

        [ForeignKey(nameof(Osobe))]
        public int? OsobaId { get; set; }
        public Osobe Osoba { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int? KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }


    }
}
