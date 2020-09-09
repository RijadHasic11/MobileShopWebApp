using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using NoviProjekat.Web.Helper;

namespace NoviProjekat.Controllers
{
    [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
    public class ProizvodjaciController : Controller
    {
        private readonly MyContext _context;

        public ProizvodjaciController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Prikazi()
        {
            var model = _context.Proizvodjac.ToList();
            return View(model);
        }


        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj([Bind("Id,Naziv,Slika")] Proizvodjac proizvodjac, IFormFile Slika)
        {
            if (ModelState.IsValid)
            {

                using (var ms = new MemoryStream())
                {
                    Slika.CopyTo(ms);
                    proizvodjac.Slika = ms.ToArray();
                }

                _context.Add(proizvodjac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Prikazi));
            }
            return View(proizvodjac);
        }

        public async Task<IActionResult> Promijeni(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjac.FindAsync(id);
            if (proizvodjac == null)
            {
                return NotFound();
            }
            return View(proizvodjac);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Promijeni(int id, [Bind("Id,Naziv")] Proizvodjac proizvodjac, IFormFile Slika)
        {
            if (id != proizvodjac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        Slika.CopyTo(ms);
                        proizvodjac.Slika = ms.ToArray();
                    }
                    _context.Update(proizvodjac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodjacExists(proizvodjac.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Prikazi));
            }
            return View(proizvodjac);
        }

        public async Task<IActionResult> Izbrisi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjac
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Izbrisi(int id)
        {
            var proizvodjac = await _context.Proizvodjac.FindAsync(id);
            _context.Proizvodjac.Remove(proizvodjac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Prikazi));
        }

        private bool ProizvodjacExists(int id)
        {
            return _context.Proizvodjac.Any(e => e.Id == id);
        }
    }
}