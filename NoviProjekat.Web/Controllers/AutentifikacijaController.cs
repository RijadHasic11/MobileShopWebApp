using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Web.Helper;
using NoviProjekat.Web.ViewModels;
using Google.Authenticator;

namespace NoviProjekat.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly MyContext _context;
        private const string key = "Wer12@!234jW";
        

        public AutentifikacijaController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = true

            });
        }
        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnik = _context.KorisnickiNalog.SingleOrDefault(x => x.KorisnickoIme == input.username && x.Lozinka == input.password);

            if (korisnik == null)
            {
                ViewData["error_poruka"] = "Pogresan username ili password";
                return View("Index", input);
            }
            else
            {
                HttpContext.SetLogiraniKorisnik(korisnik);

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                string UniqueKey = korisnik.KorisnickoIme + key;
                ViewData["UniqueKey"] = UniqueKey;
                var SetupInfo = tfa.GenerateSetupCode(korisnik.KorisnickoIme, UniqueKey, 300, 300);
                ViewBag.BarCodeImage = SetupInfo.QrCodeSetupImageUrl;


                return View("Login");
                
            }
        }
        public IActionResult TwoWayAuthentication(string passcode,string uniquekey)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            bool isValid = tfa.ValidateTwoFactorPIN(uniquekey, passcode);

            if (isValid==true)
            {
                
                return RedirectToAction("Index", "Home");

                
            }
            else
            {

                return RedirectToAction("Index");
            }
        }


        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}