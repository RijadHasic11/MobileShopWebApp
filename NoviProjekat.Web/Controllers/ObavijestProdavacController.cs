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

    public class ObavijestProdavacController : Controller
    {
        private MyContext _context;

        public ObavijestProdavacController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<ObavijestProdavac> obavijesti = _context.ObavijestProdavac.Include(x => x.Prodavac).ToList();

            ObavijestIndexVM model = new ObavijestIndexVM() { _obavijesti = new List<JednaObavijest>() };
            foreach(var item in obavijesti)
            {
                Prodavac p = _context.Prodavac.Where(x => x.Id == item.ProdavacId).Include(z => z.Osoba).SingleOrDefault();
                JednaObavijest nova = new JednaObavijest();
                nova.Id = item.Id;
                nova.Prodavac = p.Osoba.Ime + " " + p.Osoba.Prezime;
                nova.Opis = item.Opis;

                model._obavijesti.Add(nova);
                   
            }

            return View(model);
        }
        [Autorizacija(prodavac: true, klijenti: false, serviser: false,admin:false)]
        public IActionResult Dodaj()
        {
            ObavijestDodajVM model = new ObavijestDodajVM();

            model.prodavac = _context.Prodavac.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Osoba.Ime + " " + x.Osoba.Prezime
            })
            .ToList();


            ViewData["podaci"] = model;

            return View();
        }
        [Autorizacija(prodavac: true, klijenti: false, serviser: false,admin:false)]
        public IActionResult Obrisi(int Id)
        {
            ObavijestProdavac o1 = _context.ObavijestProdavac.Find(Id);
            _context.ObavijestProdavac.Remove(o1);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Autorizacija(prodavac: true, klijenti: false, serviser: false,admin:false)]
        public IActionResult Uredi(int Id)
        {

            ObavijestProdavac o1 = _context.ObavijestProdavac.Find(Id);


            ObavijestDodajVM model = new ObavijestDodajVM();

            model.prodavac = _context.Prodavac.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Osoba.Ime
            })
            .ToList();


            ViewData["obavijest"] = o1;
            ViewData["podaci"] = model;

            return View();

        }
        public IActionResult Snimi(string Opis, int ProdavacId, int Id)
        {
            ObavijestProdavac o1;
            if (Id == 0)
            {
                o1 = new ObavijestProdavac();
                _context.ObavijestProdavac.Add(o1);
            }
            else
            {
                o1 = _context.ObavijestProdavac.Find(Id);

            }

            o1.Opis = Opis;
            o1.ProdavacId = ProdavacId;
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}