using System;
using System.Collections.Generic;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class Proizvodjac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
    }

}
