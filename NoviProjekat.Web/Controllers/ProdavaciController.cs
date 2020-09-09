using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Web.Helper;

namespace NoviProjekat.Controllers
{
    [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
    public class ProdavaciController : Controller
    {
        private MyContext _context;


        public ProdavaciController(MyContext c)
        {
            _context = c;
        }

        public IActionResult Prikazi()
        {

            var model = _context.Prodavac.Include(x => x.Osoba).Include(x => x.Osoba.Grad).ToList();
            return View(model);
        }
        public IActionResult Dodaj()
        {
           
            ViewData["GradLista"] = new SelectList(_context.Grad, "Id", "Naziv");

            return View();
        }
        public ActionResult Izbrisi(int id)
        {

            var model = _context.Prodavac.Where(x => x.Id == id).SingleOrDefault();

            if (_context.StavkeZahtjev.Where(x => x.ProdavacId == id) == null)
            {

                if (model != null)
                {
                    _context.Remove(model);
                    _context.SaveChanges();
                }
            }
            //return "Uspjesno obrisano. Kliknite na back pa F5 za reload sajta.";
            return RedirectToAction(nameof(Prikazi));
        }
        public IActionResult DodajForm()
        {

            var list = _context.Prodavac.Include(x => x.Osoba).Include(x => x.Osoba.Grad).ToList();
            ViewBag.listaGradova = new SelectList(_context.Grad, "Id", "Naziv");
            
            ViewData["UposlenikKljuc"] = list;
            return View("DodajForm");
        }

        public IActionResult DodajSave(string Ime, string Prezime, DateTime DatumRodjenja, string adresa, string brojTelefona, string email, int gradId, DateTime datumZaposlenja)
        {
            Osobe o = new Osobe();
            o.Adresa = adresa;
            o.BrojTelefona = brojTelefona;
            o.Email = email;
            o.DatumRodjenja = DatumRodjenja;
            o.GradId = gradId;
            o.Ime = Ime;
            o.Prezime = Prezime;
            

            Prodavac p = new Prodavac();


            p.DatumZaposlenja = datumZaposlenja;
            p.KorisnickiNalogId = 2;
            p.Osoba = o;


            _context.Osobe.Add(o);

            _context.Prodavac.Add(p);
            _context.SaveChanges();

            return Redirect("/Prodavaci/Prikazi");
        }


        public ActionResult Promijeni(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //Osobe ovo_treba_editovati = _context.Osobe.Where(x => x.Id == id).SingleOrDefault();

            //if (ovo_treba_editovati == null)
            //    return View("Error");

            var o = _context.Prodavac.Include(x => x.Osoba).Include(x => x.Osoba.Grad).SingleOrDefault(x => x.Id == id);


            
            ViewData["GradLista"] = new SelectList(_context.Grad, "Id", "Naziv");

            return View(o);

        }
        public IActionResult EditSave(int ID, string Ime, string Prezime, DateTime DatumRodjenja, string adresa, string brojTelefona, string email, int gradId, DateTime datumZaposlenja)
        {
            var o = _context.Prodavac.Where(x => x.Id == ID).Include(x => x.Osoba).Include(x => x.Osoba.Grad).SingleOrDefault();
            o.Osoba.GradId = gradId;
            o.Osoba.Ime = Ime;
            o.Osoba.Prezime = Prezime;
            o.Osoba.Adresa = adresa;
            o.Osoba.BrojTelefona = brojTelefona;
            o.Osoba.DatumRodjenja = DatumRodjenja;
            o.Osoba.Email = email;
            o.DatumZaposlenja = datumZaposlenja;


            _context.Update(o);

            return Redirect("/Prodavaci/Prikazi");
        }
    }
}
