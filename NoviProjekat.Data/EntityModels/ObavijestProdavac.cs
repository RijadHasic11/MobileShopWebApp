using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class ObavijestProdavac
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        [ForeignKey(nameof(Prodavac))]
        public int? ProdavacId { get; set; }
        public Prodavac Prodavac { get; set; }
    }
}
