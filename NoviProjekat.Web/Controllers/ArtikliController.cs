using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Web.Helper;

namespace Artikli.Web.Controllers
{
    
    public class ArtikliController : Controller
    {
        private readonly MyContext _context;

        public ArtikliController(MyContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Prikazi()
        {
            var myContext = _context.Artikal.Include(m => m.Model);
            return View(await myContext.ToListAsync());
        }

        public async Task<IActionResult> Katalog()
        {
            var myContext = _context.Artikal.Include(m => m.Model).Include(x => x.Model.Proizvodjac);
            return View(await myContext.ToListAsync());
        }

        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
        public async Task<IActionResult> Detalji(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobitel = await _context.Artikal
                .Include(m => m.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobitel == null)
            {
                return NotFound();
            }

            return View(mobitel);
        }
        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]

        public IActionResult Dodaj()
        {
            ViewData["ModelId"] = new SelectList(_context.Modeli, "Id", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj([Bind("Id,Naziv,ModelId,Boja,Cijena,Slika,Novo,OpisArtikla")] Artikal mobitel, IFormFile Slika)
        {
            if (ModelState.IsValid)
            {
                using (var ms = new MemoryStream())
                {
                    Slika.CopyTo(ms);
                    mobitel.Slika = ms.ToArray();
                }

                _context.Add(mobitel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Prikazi));
            }
            ViewData["ModelId"] = new SelectList(_context.Modeli, "Id", "Id", mobitel.ModelId);
            return View(mobitel);
        }

        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
        public async Task<IActionResult> Promijeni(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobitel = await _context.Artikal.FindAsync(id);
            if (mobitel == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.Modeli, "Id", "Id", mobitel.ModelId);
            return View(mobitel);
        }

        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Promijeni(int id, [Bind("Id,Naziv,ModelId,Boja,Cijena,Slika,Novo,OpisArtikla")] Artikal mobitel, IFormFile Slika)
        {
            if (id != mobitel.Id)
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
                        mobitel.Slika = ms.ToArray();
                    }
                    _context.Update(mobitel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobitelExists(mobitel.Id))
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
            ViewData["ModelId"] = new SelectList(_context.Modeli, "Id", "Id", mobitel.ModelId);
            return View(mobitel);
        }

        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
        public async Task<IActionResult> Izbrisi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobitel = await _context.Artikal
                .Include(m => m.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobitel == null)
            {
                return NotFound();
            }

            return View(mobitel);
        }
        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]

        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Izbrisi(int id)
        {
            var mobitel = await _context.Artikal.FindAsync(id);
            _context.Artikal.Remove(mobitel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Prikazi));
        }

        private bool MobitelExists(int id)
        {
            return _context.Artikal.Any(e => e.Id == id);
        }
    }
}