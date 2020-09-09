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
    public class ServiseriController : Controller
    {
        private MyContext _context;


        public ServiseriController(MyContext c)
        {
            _context = c;
        }

        public IActionResult Prikazi()
        {

            var model = _context.Serviser.Include(x => x.Osoba).Include(x => x.Osoba.Grad).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
           
            ViewData["GradLista"] = new SelectList(_context.Grad, "Id", "Naziv");

            return View();
        }
        public ActionResult Delete(int id)
        {
            var model = _context.Serviser.Where(x => x.Id == id).SingleOrDefault();
            if (model != null)
            {
                _context.Remove(model);
                _context.SaveChanges();
            }
            //return "Uspjesno obrisano. Kliknite na back pa F5 za reload sajta.";
            return RedirectToAction(nameof(Prikazi));
        }
        public IActionResult DodajForm()
        {

            var list = _context.Serviser.Include(x => x.Osoba).Include(x => x.Osoba.Grad).ToList();
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
            Serviser s = new Serviser();


            s.DatumZaposlenja = datumZaposlenja;
            s.KorisnickiNalogId = 4;
            s.Osoba = o;


            _context.Osobe.Add(o);

            _context.Serviser.Add(s);
            _context.SaveChanges();

            return Redirect("/Serviseri/Prikazi");
        }


        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //Osobe ovo_treba_editovati = _context.Osobe.Where(x => x.Id == id).SingleOrDefault();

            //if (ovo_treba_editovati == null)
            //    return View("Error");

            var o = _context.Serviser.Include(x => x.Osoba).Include(x => x.Osoba.Grad).SingleOrDefault(x => x.Id == id);


            
            ViewData["GradLista"] = new SelectList(_context.Grad, "Id", "Naziv");

            return View(o);

        }
        public IActionResult EditSave(int ID, string Ime, string Prezime, DateTime DatumRodjenja, string adresa, string brojTelefona, string email, int gradId, DateTime datumZaposlenja)
        {
            var o = _context.Serviser.Where(x => x.Id == ID).Include(x => x.Osoba).Include(x => x.Osoba.Grad).SingleOrDefault();
            o.Osoba.GradId = gradId;
            o.Osoba.Ime = Ime;
            o.Osoba.Prezime = Prezime;
            o.Osoba.Adresa = adresa;
            o.Osoba.BrojTelefona = brojTelefona;
            o.Osoba.DatumRodjenja = DatumRodjenja;
            o.Osoba.Email = email;
            
            o.DatumZaposlenja = datumZaposlenja;


            _context.SaveChanges();

            return Redirect("/Serviseri/Prikazi");
        }
    }
}
