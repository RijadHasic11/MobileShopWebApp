using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;



namespace NoviProjekat.Web.ViewModels
{
    public class ZahtjevDodajVM
    {
        public List<SelectListItem> klijenti { get; set; }

        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumZahtjeva { get; set; }
        [Required]
        [StringLength(50), MinLength(10)]
        public string Opis { get; set; }
        [Required]
        [Range(1, 5)]
        public int Prioritet { get; set; }


    }
}
