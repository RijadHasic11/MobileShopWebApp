using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class NabavkaStavkeDodajVM
    {

        public IEnumerable<SelectListItem> artikli;
        public int NabavkaId { get; set; }
        public int ArtikalId { get; set; }
        public int Kolicina { get; set; }
        public int Id { get; set; }



    }
}
