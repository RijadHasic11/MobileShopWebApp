using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        [ForeignKey(nameof(Kanton))]
        public int? KantonId { get; set; }
        public Kanton Kanton { get; set; }

    }
}
