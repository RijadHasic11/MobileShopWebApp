using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Web.Helper;
using NoviProjekat.Web.ViewModels;

namespace NoviProjekat.Web.Controllers
{
    [Autorizacija(prodavac: true, klijenti: false, serviser: false,admin:true)]
    public class NabavkaStavkeController : Controller
    {
        private MyContext _context;

        public NabavkaStavkeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index(int NabavkaId)
        {
            NabavkaStavkeIndexVM model = new NabavkaStavkeIndexVM
            {
                NabavkaId = NabavkaId,
                rows = _context.NabavkaStavke.Where(x => x.NabavkaId == NabavkaId)
                .Select(s => new NabavkaStavkeIndexVM.Row
                {
                    Id = s.Id,
                    Artikal = s.Artikal.Naziv,
                    Kolicina=s.Kolicina,
                    UkupnaCijena = s.Kolicina * s.Artikal.Cijena


                }).ToList()

            };


            return PartialView(model);
        }
        public IActionResult Dodaj(int NabavkaId)
        {
            NabavkaStavkeDodajVM model = new NabavkaStavkeDodajVM
            {
                NabavkaId = NabavkaId,
                ArtikalId = 0,
                artikli = _context.Artikal.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv

                }).ToList()
            };

            return PartialView("Dodaj", model);
        }
        public IActionResult Obrisi(int Id)
        {
            NabavkaStavke ns = _context.NabavkaStavke.Find(Id);
            int t = (int)ns.NabavkaId;

            _context.NabavkaStavke.Remove(ns);
            _context.SaveChanges();

            return Redirect("/NabavkaStavke/Index?NabavkaId=" + t);
        }
        public IActionResult Uredi(int Id)
        {
            NabavkaStavke x = _context.NabavkaStavke.Find(Id);

            NabavkaStavkeDodajVM model = new NabavkaStavkeDodajVM
            {
                Id = Id,
                NabavkaId = (int)x.NabavkaId,
                ArtikalId = (int)x.ArtikalId,
                Kolicina=x.Kolicina,
                artikli = _context.Artikal.Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.Naziv

                }).ToList()
            };

            return PartialView("Dodaj", model);
        }
        public IActionResult Snimi(int NabavkaId, int Id, int ArtikalId,int Kolicina)
        {
            NabavkaStavke x;

            if (Id == 0)
            {
                x = new NabavkaStavke();
                _context.NabavkaStavke.Add(x);
            }
            else
            {
                x = _context.NabavkaStavke.Find(Id);
            }

            x.NabavkaId = NabavkaId;
            x.ArtikalId = ArtikalId;
            x.Kolicina = Kolicina;

            _context.SaveChanges();

            return Redirect("/NabavkaStavke/Index?NabavkaId=" + NabavkaId);

        }
    }
}