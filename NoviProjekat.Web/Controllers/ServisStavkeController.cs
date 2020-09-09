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
    [Autorizacija(prodavac: false, klijenti: true, serviser: true, admin: false)]
    public class ServisStavkeController : Controller
    {
        private MyContext _context;

        public ServisStavkeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index(int ServisId)
        {
            ServisStavkeIndexVM model = new ServisStavkeIndexVM();
            model.ServisId = ServisId;

            model.rows = _context.ServisStavke.Where(x => x.ServisId == ServisId).Select(y => new ServisStavkeIndexVM.Row
            {
                Id = y.Id,
                Cijena = y.Cijena,
                DatumZavrsetkaPosla = y.DatumZavrsetkaPosla,
                Opis = y.OpisRada,
                Serviser = y.Serviser.Osoba.Ime

            }).ToList();


            return PartialView("Index", model);
        }
        //[Autorizacija(prodavac: false, klijenti: false, serviser: true,admin:false)]
        public IActionResult Uradi(int ServisId)
        {
            ServisStavkeUradiVM model = new ServisStavkeUradiVM();
            model.ServisId = ServisId;
            model.serviseri = _context.Serviser.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Osoba.Ime

            }).ToList();


            return PartialView("Uradi", model);
        }
        public IActionResult Snimi(int ServisId, int Id, string Opis, DateTime DatumZavrsetkaPosla, int ServiserId, float Cijena)
        {
            ServisStavke ss;
            if (Id != 0)
            {
                ss = _context.ServisStavke.Find(Id);

            }
            else
            {
                ss = new ServisStavke();
                _context.ServisStavke.Add(ss);

            }
            ss.Id = Id;
            ss.OpisRada = Opis;
            ss.ServiserId = ServiserId;
            ss.ServisId = ServisId;
            ss.DatumZavrsetkaPosla = DatumZavrsetkaPosla;
            ss.Cijena = Cijena;

            _context.SaveChanges();

            return Redirect("/ServisStavke/Index?ServisId=" + ServisId);
        }
        //[Autorizacija(prodavac: false, klijenti: false, serviser: true,admin:false)]
        public IActionResult Obrisi(int Id)
        {
            ServisStavke ss = _context.ServisStavke.Find(Id);
            int ServisId = (int)ss.ServisId;
            _context.ServisStavke.Remove(ss);
            _context.SaveChanges();

            return Redirect("/ServisStavke/Index?ServisId=" + ServisId);
        }
        //[Autorizacija(prodavac: false, klijenti: false, serviser: true,admin:false)]
        public IActionResult Uredi(int Id)
        {
            ServisStavke ss = _context.ServisStavke.Find(Id);

            ServisStavkeUradiVM model = new ServisStavkeUradiVM();
            model.ServiserId = (int)ss.ServiserId;
            model.ServisId = (int)ss.ServisId;
            model.Opis = ss.OpisRada;
            model.Id = Id;
            model.DatumZavrsetkaPosla = ss.DatumZavrsetkaPosla;
            model.Cijena = ss.Cijena;
            model.serviseri = _context.Serviser.Select(x => new SelectListItem
            {

                Value = x.Id.ToString(),
                Text = x.Osoba.Ime

            }).ToList();

            return PartialView("Uradi", model);
        }
    }
}