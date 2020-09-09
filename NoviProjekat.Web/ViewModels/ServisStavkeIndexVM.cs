using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ServisStavkeIndexVM
    {
        public List<Row> rows { get; set; }
        public int ServisId { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Serviser { get; set; }
            public string Opis { get; set; }
            public float Cijena { get; set; }
            public DateTime DatumZavrsetkaPosla { get; set; }


        }
    }
}
