using System;
using System.Collections.Generic;
using System.Text;

namespace NoviProjekat.Data.EntityModels
{
    public class ObavijestAdmin
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Text { get; set; }
        public byte[] Slika { get; set; }
    }
}
