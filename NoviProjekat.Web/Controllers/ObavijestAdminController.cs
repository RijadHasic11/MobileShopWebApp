using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Web.Helper;

namespace NoviProjekat.Web.Controllers
{
    
    public class ObavijestAdminController : Controller
    {
        private readonly MyContext _context;

        public ObavijestAdminController(MyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Prikazi()
        {
            return View(await _context.ObavijestAdmin.ToListAsync());
        }

        public async Task<IActionResult> Detalji(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.ObavijestAdmin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obavijest == null)
            {
                return NotFound();
            }

            return View(obavijest);
        }
        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SnimiDodavanje([Bind("Id,Naslov,Text,Slika")] ObavijestAdmin obavijest, IFormFile Slika)
        {
            //if (ModelState.IsValid)
            
                using (var ms = new MemoryStream())
                {
                    Slika.CopyTo(ms);
                    obavijest.Slika = ms.ToArray();
                }
                _context.Add(obavijest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Prikazi));
            
            //return View("Dodaj",obavijest);
        }

        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
        public async Task<IActionResult> Promijeni(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.ObavijestAdmin.FindAsync(id);
            if (obavijest == null)
            {
                return NotFound();
            }
            return View(obavijest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SnimiPromjenu(int id, [Bind("Id,Naslov,Text,Slika")] ObavijestAdmin obavijest, IFormFile Slika)
        {
            if (id != obavijest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var ms = new MemoryStream())
                {
                    Slika.CopyTo(ms);
                    obavijest.Slika = ms.ToArray();
                }
                try
                {
                    _context.Update(obavijest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObavijestExists(obavijest.Id))
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
            return View(obavijest);
        }
        [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
        public async Task<IActionResult> Izbrisi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.ObavijestAdmin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obavijest == null)
            {
                return NotFound();
            }

            return View(obavijest);
        }

        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Izbrisi(int id)
        {
            var obavijest = await _context.ObavijestAdmin.FindAsync(id);
            _context.ObavijestAdmin.Remove(obavijest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Prikazi));
        }

        private bool ObavijestExists(int id)
        {
            return _context.ObavijestAdmin.Any(e => e.Id == id);
        }
    }
}