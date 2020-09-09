using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class NabavkaStavkeIndexVM
    {

        public int NabavkaId { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Artikal { get; set; }
            public float UkupnaCijena { get; set; }
            public int Kolicina { get; set; }

        }
    }
}
