using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ServisDetaljiVM
    {
        public int Id { get; set; }
        public string DatumPrimanja { get; set; }
        public string Opis { get; set; }
        public string Klijent { get; set; }
        public string Artikal { get; set; }
        public float UkupnaCijena { get; set; }
        public DateTime DatumSlanja { get; set; }
    }
}
