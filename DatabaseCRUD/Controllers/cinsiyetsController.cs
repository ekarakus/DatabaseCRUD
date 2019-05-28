using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCRUD.Controllers
{
    public class cinsiyetsController : Controller
    {
        private readonly Db _context;

        public cinsiyetsController(Db context)
        {
            _context = context;
        }

        // GET: cinsiyets
        public async Task<IActionResult> Index()
        {
            return View(await _context.cinsiyetler.ToListAsync());
        }

        // GET: cinsiyets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.cinsiyetler
                .FirstOrDefaultAsync(m => m.cinsiyetId == id);
            if (cinsiyet == null)
            {
                return NotFound();
            }

            return View(cinsiyet);
        }

        // GET: cinsiyets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cinsiyets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cinsiyetId,cinsiyetAdi")] cinsiyet cinsiyet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinsiyet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinsiyet);
        }

        // GET: cinsiyets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.cinsiyetler.FindAsync(id);
            if (cinsiyet == null)
            {
                return NotFound();
            }
            return View(cinsiyet);
        }

        // POST: cinsiyets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cinsiyetId,cinsiyetAdi")] cinsiyet cinsiyet)
        {
            if (id != cinsiyet.cinsiyetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinsiyet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cinsiyetExists(cinsiyet.cinsiyetId))
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
            return View(cinsiyet);
        }

        // GET: cinsiyets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.cinsiyetler
                .FirstOrDefaultAsync(m => m.cinsiyetId == id);
            if (cinsiyet == null)
            {
                return NotFound();
            }

            return View(cinsiyet);
        }

        // POST: cinsiyets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinsiyet = await _context.cinsiyetler.FindAsync(id);
            _context.cinsiyetler.Remove(cinsiyet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cinsiyetExists(int id)
        {
            return _context.cinsiyetler.Any(e => e.cinsiyetId == id);
        }
    }
}
