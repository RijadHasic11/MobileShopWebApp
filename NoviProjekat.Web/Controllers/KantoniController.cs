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

namespace NoviProjekat.Controllers
{
    [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
    public class KantoniController : Controller
    {
        private readonly MyContext _context;

        public KantoniController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Prikazi()
        {
            var model = _context.Kanton.ToList();
            return View(model);
        }
        public async Task<IActionResult> Detalji(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanton = await _context.Kanton
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kanton == null)
            {
                return NotFound();
            }

            return View(kanton);
        }

        public IActionResult Dodaj()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj([Bind("Id,Naziv")] Kanton kanton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Prikazi));
            }

            var model = _context.Kanton.ToList();
            return View("Prikazi", model);
        }

        public async Task<IActionResult> Promijeni(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanton = await _context.Kanton.FindAsync(id);
            if (kanton == null)
            {
                return NotFound();
            }
            return View(kanton);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Promijeni(int id, [Bind("Id,Naziv")] Kanton kanton)
        {
            if (id != kanton.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kanton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KantonExists(kanton.Id))
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
            return View(kanton);
        }

        public async Task<IActionResult> Izbrisi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanton = await _context.Kanton
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kanton == null)
            {
                return NotFound();
            }

            return View(kanton);
        }

        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Izbrisi(int id)
        {
            var kanton = await _context.Kanton.FindAsync(id);
            _context.Kanton.Remove(kanton);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Prikazi));
        }

        private bool KantonExists(int id)
        {
            return _context.Kanton.Any(e => e.Id == id);
        }
    }
}
