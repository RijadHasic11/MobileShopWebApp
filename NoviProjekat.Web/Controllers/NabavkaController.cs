using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoviProjekat.Data;
using NoviProjekat.Web.ViewModels;
using NoviProjekat.Data.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoviProjekat.Web.Helper;

namespace NoviProjekat.Web.Controllers
{
    [Autorizacija(prodavac: true, klijenti: false, serviser: false,admin:true)]
    public class NabavkaController : Controller
    {

        private MyContext _context;

        public NabavkaController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new NabavkaIndexVM
            {
                rows = _context.Nabavka.Select(x => new NabavkaIndexVM.Row
                {
                    Id = x.Id,
                    DatumNabavke = x.DatumNabavke.ToShortDateString(),
                    Prodavac = x.Prodavac.Osoba.Ime + " " +x.Prodavac.Osoba.Prezime
                }).ToList()
            };


            return View("Index", model);
        }

        public IActionResult Dodaj()
        {
            NabavkaDodajVM model = new NabavkaDodajVM();
            model.prodavaci = _context.Prodavac.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Osoba.Ime + " " + x.Osoba.Prezime

            }).ToList();


            return View("Dodaj", model);
        }
        public IActionResult Snimi(DateTime DatumNabavke, int ProdavacId)
        {
            Nabavka n1;

            n1 = new Nabavka();
            n1.DatumNabavke = DatumNabavke;
            n1.ProdavacID = ProdavacId;


            _context.Nabavka.Add(n1);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int NabavkaId)
        {
            Nabavka n1 = _context.Nabavka.Where(x => x.Id == NabavkaId).SingleOrDefault();
            _context.Nabavka.Remove(n1);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        public IActionResult Detalji(int nabavkaId)
        {

            
            Nabavka n1 = _context.Nabavka.Where(x => x.Id == nabavkaId).SingleOrDefault();
            Prodavac p = _context.Prodavac.Where(x => x.Id == n1.ProdavacID).Include(y => y.Osoba).SingleOrDefault();

            NabavkaDetaljiVM model = new NabavkaDetaljiVM();

            model.Prodavac =p.Osoba.Ime;
            model.DatumNabavke = n1.DatumNabavke.ToShortDateString();
            model.Id = n1.Id;
            model.BrojArtikala = _context.NabavkaStavke.Where(w => w.NabavkaId == nabavkaId).Count();




            return View("Detalji", model);
        }
    }
}