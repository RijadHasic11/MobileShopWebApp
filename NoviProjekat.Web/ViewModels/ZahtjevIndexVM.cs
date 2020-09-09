using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ZahtjevIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string DatumZahtjeva { get; set; }
            public bool Odgovoren { get; set; }
            public string Opis { get; set; }
            public int Prioritet { get; set; }
            public string Klijent { get; set; }
        }
    }
}