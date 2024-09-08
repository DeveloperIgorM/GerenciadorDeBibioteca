using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeBibioteca.Models;

namespace GerenciadorDeBibioteca.Controllers
{
    public class FaculdadeController : Controller
    {
        private readonly BancoDeDados _context;

        public FaculdadeController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: Faculdade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Faculdades.ToListAsync());
        }

        // GET: Faculdade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faculdade == null)
            {
                return NotFound();
            }

            return View(faculdade);
        }

        // GET: Faculdade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculdade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Email,Data_cadastro")] Faculdade faculdade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculdade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faculdade);
        }

        // GET: Faculdade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdades.FindAsync(id);
            if (faculdade == null)
            {
                return NotFound();
            }
            return View(faculdade);
        }

        // POST: Faculdade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Email,Data_cadastro")] Faculdade faculdade)
        {
            if (id != faculdade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculdade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaculdadeExists(faculdade.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(faculdade);
        }

        // GET: Faculdade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faculdade == null)
            {
                return NotFound();
            }

            return View(faculdade);
        }

        // POST: Faculdade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faculdade = await _context.Faculdades.FindAsync(id);
            if (faculdade != null)
            {
                _context.Faculdades.Remove(faculdade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaculdadeExists(int id)
        {
            return _context.Faculdades.Any(e => e.Id == id);
        }
    }
}
