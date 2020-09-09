using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Artikal
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string OpisArtikla { get; set; }
        public float Cijena { get; set; }


        [ForeignKey(nameof(Model))]
        public int? ModelId { get; set; }
        public Model Model { get; set; }

        [ForeignKey(nameof(Skladiste))]
        public int? SkladisteId { get; set; }
        public Skladiste Skladiste { get; set; }

        public int StanjeNaSkladistu { get; set; }

        public string Boja { get; set; }
        public byte[] Slika { set; get; }
        public bool Novo { get; set; }
    }
}
