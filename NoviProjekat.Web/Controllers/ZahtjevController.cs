using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Web.Helper;
using NoviProjekat.Web.ViewModels;

namespace NoviProjekat.Web.Controllers
{

   
    public class ZahtjevController : Controller
    {
        private MyContext _context;

        public ZahtjevController(MyContext context)
        {
            _context = context;
        }
        [Autorizacija(prodavac: true, klijenti: true, serviser: false, admin: false)]
        public IActionResult Index()
        {
            var model = new ZahtjevIndexVM
            {
                rows = _context.Zahtjev.Select(x => new ZahtjevIndexVM.Row
                {
                    Id = x.Id,
                    DatumZahtjeva = x.DatumZahtjeva.ToShortDateString(),
                    Prioritet = x.Prioritet,
                    Odgovoren = x.Odgovoren,
                    Klijent = x.Klijent.Osoba.Ime + " " + x.Klijent.Osoba.Prezime,
                    Opis = x.Opis

                }).ToList()
            };


            return View("Index", model);
        }
        [Autorizacija(prodavac: false, klijenti: true, serviser: false, admin: false)]
        public IActionResult Dodaj()
        {
            var model = new ZahtjevDodajVM();
            Pripremi(model);

            return View("Dodaj", model);
        }
        public void Pripremi(ZahtjevDodajVM model)
        {
            model.klijenti = _context.Klijent.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Osoba.Ime + " " + x.Osoba.Prezime


            }).ToList();


        }
        [Autorizacija(prodavac: false, klijenti: true, serviser: false, admin: false)]
        public IActionResult Obrisi(int Id)
        {
            Zahtjev x = _context.Zahtjev.Find(Id);
            _context.Zahtjev.Remove(x);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Snimi(ZahtjevDodajVM input, int KlijentId)
        {
            if (!ModelState.IsValid)
            {
                Pripremi(input);
                return View("Dodaj", input);
            }

            Zahtjev x = new Zahtjev();
            x.DatumZahtjeva = input.DatumZahtjeva;
            x.Opis = input.Opis;
            x.Prioritet = input.Prioritet;
            x.Odgovoren = false;
            x.KlijentId = KlijentId;


            _context.Zahtjev.Add(x);
            _context.SaveChanges();



            return RedirectToAction("Index");
        }
        [Autorizacija(prodavac: true, klijenti: true, serviser: false, admin: false)]
        public IActionResult Detalji(int ZahtjevId)
        {
            Zahtjev z1 = _context.Zahtjev.Where(x => x.Id == ZahtjevId).Include(w => w.Klijent).SingleOrDefault();
            ZahtjevDetaljiVM model = new ZahtjevDetaljiVM();
            Klijent k = _context.Klijent.Where(x => x.Id == z1.KlijentId).Include(z => z.Osoba).SingleOrDefault();

            model.Id = ZahtjevId;
            model.DatumZahtjeva = z1.DatumZahtjeva.ToShortDateString();
            model.Opis = z1.Opis;
            model.Prioritet = z1.Prioritet;
            model.Klijent = k.Osoba.Ime + " " + k.Osoba.Prezime;
            model.BrojOdgovora = _context.StavkeZahtjev.Where(x => x.ZahtjevId == ZahtjevId).Count();
            if (model.BrojOdgovora > 0)
            {
                z1.Odgovoren = true;

            }
            model.Odgovoren = z1.Odgovoren;




            return View("Detalji", model);
        }
    }
}