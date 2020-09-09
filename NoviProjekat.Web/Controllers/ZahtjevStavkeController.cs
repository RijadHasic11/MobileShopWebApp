using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Web.Helper;
using NoviProjekat.Web.ViewModels;

namespace NoviProjekat.Web.Controllers
{

    [Autorizacija(prodavac: true, klijenti: true, serviser: false, admin: false)]
    public class ZahtjevStavkeController : Controller
    {
        private MyContext _context;

        public ZahtjevStavkeController(MyContext context)
        {
            _context = context;
        }
        //[Autorizacija(prodavac: true, klijenti: true, serviser: false,admin:false)]
       
        public IActionResult Index(int ZahtjevId)
        {

            ZahtjevStavkeIndexVM model = new ZahtjevStavkeIndexVM
            {

                ZahtjevId = ZahtjevId,
                rows = _context.StavkeZahtjev.Where(x => x.ZahtjevId == ZahtjevId).Select(w => new ZahtjevStavkeIndexVM.Row
                {
                    Id = w.Id,
                    Prodavac = w.Prodavac.Osoba.Ime,
                    Odgovor = w.Odgovor

                }).ToList()

                

            };

            return PartialView("Index", model);
        }
        //[Autorizacija(prodavac: true, klijenti: true, serviser: false,admin:false)]
        public IActionResult Odgovori(int ZahtjevId)
        {
            ZahtjevStavkeDodajVM model = new ZahtjevStavkeDodajVM
            {
                ZahtjevId = ZahtjevId,
                prodavaci = _context.Prodavac.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Osoba.Ime
                })

                


            };

           
            
               return PartialView("Odgovori", model);
            
          
        }
        //[Autorizacija(prodavac: true, klijenti: true, serviser: false,admin:false)]
        public IActionResult Obrisi(int Id)
        {
            StavkeZahtjev x = _context.StavkeZahtjev.Find(Id);
            int ZahtjevId = (int)x.ZahtjevId;

            _context.StavkeZahtjev.Remove(x);
            _context.SaveChanges();

            return Redirect("/ZahtjevStavke/Index?ZahtjevId=" + ZahtjevId);
        }
        //[Autorizacija(prodavac: true, klijenti: true, serviser: false,admin:false)]
        public IActionResult Uredi(int Id)
        {
            StavkeZahtjev x = _context.StavkeZahtjev.Find(Id);
            ZahtjevStavkeDodajVM model = new ZahtjevStavkeDodajVM
            {
                Id = Id,
                ZahtjevId = (int)x.ZahtjevId,
                Odgovor = x.Odgovor,
                prodavaci = _context.Prodavac.Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.Osoba.Ime
                }).ToList()
            };

            return PartialView("Odgovori", model);
        }
        public IActionResult Snimi(int Id, int ZahtjevId, int ProdavacId, string Odgovor)
        {
            StavkeZahtjev x;
            if (Id == 0)
            {
                x = new StavkeZahtjev();
                _context.StavkeZahtjev.Add(x);
            }
            else
            {
                x = _context.StavkeZahtjev.Find(Id);
            }
            x.ZahtjevId = ZahtjevId;
            x.ProdavacId = ProdavacId;
            x.Odgovor = Odgovor;

            _context.SaveChanges();

            return Redirect("/ZahtjevStavke/Index?ZahtjevId=" + ZahtjevId);
        }
    }

}