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
    public class ModelMobitelaController : Controller
    {
        private readonly MyContext _context;

        public ModelMobitelaController(MyContext context)
        {
            _context = context;
        }

        // GET: ModelMobitela
        public async Task<IActionResult> Prikazi()
        {
            var myContext = _context.Modeli.Include(m => m.Proizvodjac);
            return View(await myContext.ToListAsync());
        }


        public IActionResult Dodaj()
        {
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "Id", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj([Bind("Id,Naziv,ProizvodjacId")] Model modelMobitela)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelMobitela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Prikazi));
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "Id", "Id", modelMobitela.ProizvodjacId);
            return View(modelMobitela);
        }
        public async Task<IActionResult> Promijeni(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelMobitela = await _context.Modeli.FindAsync(id);
            if (modelMobitela == null)
            {
                return NotFound();
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "Id", "Naziv", modelMobitela.ProizvodjacId);
            return View(modelMobitela);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Promijeni(int id, [Bind("Id,Naziv,ProizvodjacId")] Model modelMobitela)
        {
            if (id != modelMobitela.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelMobitela);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelMobitelaExists(modelMobitela.Id))
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
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "Id", "Id", modelMobitela.ProizvodjacId);
            return View(modelMobitela);
        }

        public async Task<IActionResult> Izbrisi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelMobitela = await _context.Modeli
                .Include(m => m.Proizvodjac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelMobitela == null)
            {
                return NotFound();
            }

            return View(modelMobitela);
        }

        // POST: ModelMobitela/Delete/5
        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Izbrisi(int id)
        {
            var modelMobitela = await _context.Modeli.FindAsync(id);
            _context.Modeli.Remove(modelMobitela);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Prikazi));
        }

        private bool ModelMobitelaExists(int id)
        {
            return _context.Modeli.Any(e => e.Id == id);
        }
    }
}
