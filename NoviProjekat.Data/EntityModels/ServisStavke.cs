using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class ServisStavke
    {
        public int Id { get; set; }
        public string OpisRada { get; set; }
        public DateTime DatumZavrsetkaPosla { get; set; }
        public float Cijena { get; set; }

        [ForeignKey(nameof(Serviser))]
        public int? ServiserId { get; set; }
        public Serviser Serviser { get; set; }

        [ForeignKey(nameof(Servis))]
        public int? ServisId { get; set; }
        public Servis Servis { get; set; }


    }
}
