using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class ObavijestIndexVM
    {
        public List<JednaObavijest> _obavijesti { get; set; }
    }
    public class JednaObavijest
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string Prodavac { get; set; }
    }
}
