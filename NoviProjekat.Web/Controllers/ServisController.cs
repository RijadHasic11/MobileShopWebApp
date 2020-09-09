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

    public class ServisController : Controller
    {
        private MyContext _context;
        public ServisController(MyContext context)
        {
            _context = context;
        }

        [Autorizacija(prodavac: true, klijenti: true, serviser: true, admin: false)]
        public IActionResult Index()
        {
            ServisIndexVM model = new ServisIndexVM
            {
                rows = _context.Servis.Select(x => new ServisIndexVM.Row
                {
                    Id = x.Id,
                    DatumPrimanja = x.DatumPrimanja.ToShortDateString(),
                    Klijent = x.Klijent.Osoba.Ime,
                    Artikal = x.Artikal.Naziv,
                    Opis = x.OpisServisa

                }).ToList()
            };

            return View("Index", model);
        }
        [Autorizacija(prodavac: false, klijenti: true, serviser: false,admin:false)]
        public IActionResult Obrisi(int Id)
        {
            Servis s1 = _context.Servis.Find(Id);

            _context.Servis.Remove(s1);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Autorizacija(prodavac: false, klijenti: true, serviser: false,admin:false)]
        public IActionResult Dodaj()
        {
            ServisDodajVM model = new ServisDodajVM();

            Pripremi(model);

            return View("Dodaj", model);
        }
        public void Pripremi(ServisDodajVM model)
        {
            model.klijenti = _context.Klijent.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Osoba.Ime

            }).ToList();

            model.artikli = _context.Artikal.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv

            }).ToList();
        }
        public IActionResult Snimi(int Id, DateTime DatumPrimanja, string Opis, int KlijentId, int ArtikalId)
        {
            Servis s1 = new Servis();
            s1.Id = Id;
            s1.DatumPrimanja = DatumPrimanja;
            s1.OpisServisa = Opis;
            s1.KlijentId = KlijentId;
            s1.ArtikalId = ArtikalId;

            _context.Servis.Add(s1);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Detalji(int ServisId)
        {
            Servis s1 = _context.Servis.Where(x => x.Id == ServisId).Include(w => w.Klijent).Include(y => y.Artikal).SingleOrDefault();

            float UCijena = 0;
            List<ServisStavke> ss1 = _context.ServisStavke.Where(x => x.ServisId == ServisId).ToList();
            foreach (ServisStavke z in ss1)
            {
                UCijena += z.Cijena;

            }
            DateTime DatumSlanja = DateTime.Now;
            if (_context.ServisStavke.Where(x => x.ServisId == ServisId).Count() > 0)
            {
                ServisStavke ss2 = _context.ServisStavke.Where(x => x.ServisId == ServisId).LastOrDefault();
                DatumSlanja = ss2.DatumZavrsetkaPosla;
            }
            Klijent k = _context.Klijent.Where(x => x.Id == s1.KlijentId).Include(z => z.Osoba).SingleOrDefault();

            ServisDetaljiVM model = new ServisDetaljiVM
            {
                Id = ServisId,
                Opis = s1.OpisServisa,
                DatumPrimanja = s1.DatumPrimanja.ToShortDateString(),
                Klijent = k.Osoba.Ime,
                Artikal = s1.Artikal.Naziv,
                UkupnaCijena = UCijena,
                DatumSlanja = DatumSlanja

            };


            return View("Detalji", model);
        }
    }
}