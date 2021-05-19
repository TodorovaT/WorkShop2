using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkShop2.Models;

namespace WorkShop2.Controllers
{
    public class MoiPredmetiStudsController : Controller
    {
        private readonly WorkShop2Context _context;

        public MoiPredmetiStudsController(WorkShop2Context context)
        {
            _context = context;
        }

        // GET: MoiPredmetiStuds
        public async Task<IActionResult> Index()
        {
            return View(await _context.MoiPredmetiStud.ToListAsync());
        }

        // GET: MoiPredmetiStuds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moiPredmetiStud = await _context.MoiPredmetiStud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moiPredmetiStud == null)
            {
                return NotFound();
            }

            return View(moiPredmetiStud);
        }

        // GET: MoiPredmetiStuds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoiPredmetiStuds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] MoiPredmetiStud moiPredmetiStud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moiPredmetiStud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moiPredmetiStud);
        }

        // GET: MoiPredmetiStuds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moiPredmetiStud = await _context.MoiPredmetiStud.FindAsync(id);
            if (moiPredmetiStud == null)
            {
                return NotFound();
            }
            return View(moiPredmetiStud);
        }

        // POST: MoiPredmetiStuds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] MoiPredmetiStud moiPredmetiStud)
        {
            if (id != moiPredmetiStud.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moiPredmetiStud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoiPredmetiStudExists(moiPredmetiStud.Id))
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
            return View(moiPredmetiStud);
        }

        // GET: MoiPredmetiStuds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moiPredmetiStud = await _context.MoiPredmetiStud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moiPredmetiStud == null)
            {
                return NotFound();
            }

            return View(moiPredmetiStud);
        }

        // POST: MoiPredmetiStuds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moiPredmetiStud = await _context.MoiPredmetiStud.FindAsync(id);
            _context.MoiPredmetiStud.Remove(moiPredmetiStud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoiPredmetiStudExists(int id)
        {
            return _context.MoiPredmetiStud.Any(e => e.Id == id);
        }
    }
}
