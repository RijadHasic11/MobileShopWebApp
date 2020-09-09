using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Model
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        [ForeignKey(nameof(Proizvodjac))]
        public int ProizvodjacId { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
    }
}
