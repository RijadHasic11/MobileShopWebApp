using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.ViewModels
{
    public class LoginVM
    {
        [StringLength(100, ErrorMessage = "Korisnicko ime mora zadrzavati minimalno 3 karaktera", MinimumLength = 3)]
        public string username { get; set; }
        [StringLength(100, ErrorMessage = "Password mora zadrzavati minimalno 4 karaktera", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool ZapamtiPassword { get; set; }
    }
}

