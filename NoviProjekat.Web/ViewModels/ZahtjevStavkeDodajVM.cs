using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ZahtjevStavkeDodajVM
    {
        public int Id { get; set; }
        public string Odgovor { get; set; }
        public int ZahtjevId { get; set; }
        public int ProdavacId { get; set; }
        public IEnumerable<SelectListItem> prodavaci { get; set; }
    }
}
