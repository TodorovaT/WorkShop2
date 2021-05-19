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
    public class MoiPredmetiProfsController : Controller
    {
        private readonly WorkShop2Context _context;

        public MoiPredmetiProfsController(WorkShop2Context context)
        {
            _context = context;
        }

        // GET: MoiPredmetiProfs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MoiPredmetiProf.ToListAsync());
        }

        // GET: MoiPredmetiProfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moiPredmetiProf = await _context.MoiPredmetiProf
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moiPredmetiProf == null)
            {
                return NotFound();
            }

            return View(moiPredmetiProf);
        }

        // GET: MoiPredmetiProfs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoiPredmetiProfs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] MoiPredmetiProf moiPredmetiProf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moiPredmetiProf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moiPredmetiProf);
        }

        // GET: MoiPredmetiProfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moiPredmetiProf = await _context.MoiPredmetiProf.FindAsync(id);
            if (moiPredmetiProf == null)
            {
                return NotFound();
            }
            return View(moiPredmetiProf);
        }

        // POST: MoiPredmetiProfs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] MoiPredmetiProf moiPredmetiProf)
        {
            if (id != moiPredmetiProf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moiPredmetiProf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoiPredmetiProfExists(moiPredmetiProf.Id))
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
            return View(moiPredmetiProf);
        }

        // GET: MoiPredmetiProfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moiPredmetiProf = await _context.MoiPredmetiProf
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moiPredmetiProf == null)
            {
                return NotFound();
            }

            return View(moiPredmetiProf);
        }

        // POST: MoiPredmetiProfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moiPredmetiProf = await _context.MoiPredmetiProf.FindAsync(id);
            _context.MoiPredmetiProf.Remove(moiPredmetiProf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoiPredmetiProfExists(int id)
        {
            return _context.MoiPredmetiProf.Any(e => e.Id == id);
        }
    }
}
