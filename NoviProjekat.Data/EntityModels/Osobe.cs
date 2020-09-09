using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Osobe
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }

        [ForeignKey(nameof(Spol))]
        public int? SpolId { get; set; }
        public Spol Spol { get; set; }

        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }


    }
}
