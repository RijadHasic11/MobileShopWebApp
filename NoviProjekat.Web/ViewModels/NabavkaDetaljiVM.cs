using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class NabavkaDetaljiVM
    {
        public int Id { get; set; }
        
        public string DatumNabavke { get; set; }
        
        public string Prodavac { get; set; }
        public int BrojArtikala { get; set; }
    }
}