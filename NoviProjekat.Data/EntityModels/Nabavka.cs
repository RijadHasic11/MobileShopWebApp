using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Nabavka
    {
        public int Id { get; set; }
        public DateTime DatumNabavke { get; set; }
        

        [ForeignKey(nameof(Prodavac))]
        public int? ProdavacID { get; set; }
        public Prodavac Prodavac { get; set; }

    }
}
