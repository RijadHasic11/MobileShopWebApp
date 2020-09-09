using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ServisStavkeUradiVM
    {
        public IEnumerable<SelectListItem> serviseri { get; set; }
        public int Id { get; set; }
        public int ServisId { get; set; }
        public string Opis { get; set; }
        public DateTime DatumZavrsetkaPosla { get; set; }
        public int ServiserId { get; set; }
        public float Cijena { get; set; }

    }
}
