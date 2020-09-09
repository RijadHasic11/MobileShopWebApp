using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class NabavkaIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int Id { get; set; }

            public string DatumNabavke { get; set; }
        
            public string Prodavac { get; set; }

        }
    }
}