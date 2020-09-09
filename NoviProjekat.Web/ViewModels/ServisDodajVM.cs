using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ServisDodajVM
    {
        public List<SelectListItem> klijenti { get; set; }
        public List<SelectListItem> artikli { get; set; }

        public int Id { get; set; }
        public DateTime DatumPrimanja { get; set; }
        public string Opis { get; set; }

    }
}
