using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DV_MvcApp.Data;
using DV_MvcApp.Models;

namespace DV_MvcApp.Controllers
{
    public class DV_AuthorController : Controller
    {
        private readonly DV_Context _context;

        public DV_AuthorController(DV_Context context)
        {
            _context = context;
        }

        // GET: DV_Author
        public async Task<IActionResult> Index()
        {
            return View(await _context.DV_Authors.ToListAsync());
        }

        // GET: DV_Author/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dV_Author = await _context.DV_Authors
                .FirstOrDefaultAsync(m => m.DV_AuthorId == id);
            if (dV_Author == null)
            {
                return NotFound();
            }

            return View(dV_Author);
        }

        // GET: DV_Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DV_Author/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DV_AuthorId,DV_FirstName,DV_LastName")] DV_Author dV_Author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dV_Author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dV_Author);
        }

        // GET: DV_Author/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dV_Author = await _context.DV_Authors.FindAsync(id);
            if (dV_Author == null)
            {
                return NotFound();
            }
            return View(dV_Author);
        }

        // POST: DV_Author/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DV_AuthorId,DV_FirstName,DV_LastName")] DV_Author dV_Author)
        {
            if (id != dV_Author.DV_AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dV_Author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DV_AuthorExists(dV_Author.DV_AuthorId))
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
            return View(dV_Author);
        }

        // GET: DV_Author/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dV_Author = await _context.DV_Authors
                .FirstOrDefaultAsync(m => m.DV_AuthorId == id);
            if (dV_Author == null)
            {
                return NotFound();
            }

            return View(dV_Author);
        }

        // POST: DV_Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dV_Author = await _context.DV_Authors.FindAsync(id);
            if (dV_Author != null)
            {
                _context.DV_Authors.Remove(dV_Author);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DV_AuthorExists(int id)
        {
            return _context.DV_Authors.Any(e => e.DV_AuthorId == id);
        }
    }
}
