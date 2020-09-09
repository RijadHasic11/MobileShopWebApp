using Microsoft.AspNetCore.Mvc.Rendering;
using NoviProjekat.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class NabavkaDodajVM
    {
        public List<SelectListItem> prodavaci { get; set; }

    }
}
