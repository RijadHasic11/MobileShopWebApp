using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ServisIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int Id { get; set; }
            public string DatumPrimanja { get; set; }
            public string Klijent { get; set; }
            public string Artikal { get; set; }
            public string Opis { get; set; }

        }
    }
}
