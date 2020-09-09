using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ZahtjevStavkeIndexVM
    {
        public int ZahtjevId { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Prodavac { get; set; }
            public string Odgovor { get; set; }
        }


    }
}
