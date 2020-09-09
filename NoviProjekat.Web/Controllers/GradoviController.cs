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

namespace NoviProjekat.Web.Controllers
{
    [Autorizacija(prodavac: false, klijenti: false, serviser: false, admin: true)]
    public class GradoviController : Controller
    {
        private readonly MyContext _context;

        public GradoviController(MyContext context)
        {
            _context = context;
        }


        public IActionResult Dodaj()
        {
            ViewData["KantonLista"] = new SelectList(_context.Kanton, "Id", "Naziv");
            return View();
        }
        public IActionResult Prikazi()
        {
            var model = _context.Grad.Include(x => x.Kanton).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj([Bind("Id,Naziv,KantonId")] Grad grad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Prikazi));
            }
            ViewData["KantonId"] = new SelectList(_context.Kanton, "Id", "Id", grad.KantonId);
            return View(grad);
        }
        public async Task<IActionResult> Promijeni(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grad = await _context.Grad.FindAsync(id);
            if (grad == null)
            {
                return NotFound();
            }
            ViewData["KantonId"] = new SelectList(_context.Kanton, "Id", "Id", grad.KantonId);
            ViewData["Kantoni"] = new SelectList(_context.Kanton, "Id", "Naziv");
            return View(grad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Promijeni(int id, [Bind("Id,Naziv,KantonId")] Grad grad)
        {
            if (id != grad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradExists(grad.Id))
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
            ViewData["KantonId"] = new SelectList(_context.Kanton, "Id", "Id", grad.KantonId);
            return View(grad);
        }

        // GET: Gradovi/Delete/5
        public async Task<IActionResult> Izbrisi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grad = await _context.Grad
                .Include(g => g.Kanton)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grad == null)
            {
                return NotFound();
            }

            return View(grad);
        }

        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Izbrisi(int id)
        {
            var grad = await _context.Grad.FindAsync(id);
            _context.Grad.Remove(grad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Prikazi));
        }

        private bool GradExists(int id)
        {
            return _context.Grad.Any(e => e.Id == id);
        }
    }
}