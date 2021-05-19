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
    public class SluzbasController : Controller
    {
        private readonly WorkShop2Context _context;

        public SluzbasController(WorkShop2Context context)
        {
            _context = context;
        }

        // GET: Sluzbas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sluzba.ToListAsync());
        }

        // GET: Sluzbas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sluzba = await _context.Sluzba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sluzba == null)
            {
                return NotFound();
            }

            return View(sluzba);
        }

        // GET: Sluzbas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sluzbas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Sluzba sluzba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sluzba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sluzba);
        }

        // GET: Sluzbas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sluzba = await _context.Sluzba.FindAsync(id);
            if (sluzba == null)
            {
                return NotFound();
            }
            return View(sluzba);
        }

        // POST: Sluzbas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Sluzba sluzba)
        {
            if (id != sluzba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sluzba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SluzbaExists(sluzba.Id))
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
            return View(sluzba);
        }

        // GET: Sluzbas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sluzba = await _context.Sluzba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sluzba == null)
            {
                return NotFound();
            }

            return View(sluzba);
        }

        // POST: Sluzbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sluzba = await _context.Sluzba.FindAsync(id);
            _context.Sluzba.Remove(sluzba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SluzbaExists(int id)
        {
            return _context.Sluzba.Any(e => e.Id == id);
        }
    }
}
