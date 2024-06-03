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
    public class DV_BookController : Controller
    {
        private readonly DV_Context _context;

        public DV_BookController(DV_Context context)
        {
            _context = context;
        }

        // GET: DV_Book
        public async Task<IActionResult> Index()
        {
            var dV_Context = _context.DV_Books.Include(d => d.DV_Author);
            return View(await dV_Context.ToListAsync());
        }

        // GET: DV_Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dV_Book = await _context.DV_Books
                .Include(d => d.DV_Author)
                .FirstOrDefaultAsync(m => m.DV_BookId == id);
            if (dV_Book == null)
            {
                return NotFound();
            }

            return View(dV_Book);
        }

        // GET: DV_Book/Create
        public IActionResult Create()
        {
            ViewData["DV_AuthorId"] = new SelectList(_context.DV_Authors, "DV_AuthorId", "DV_AuthorId");
            return View();
        }

        // POST: DV_Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DV_BookId,DV_Title,DV_AuthorId")] DV_Book dV_Book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dV_Book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DV_AuthorId"] = new SelectList(_context.DV_Authors, "DV_AuthorId", "DV_AuthorId", dV_Book.DV_AuthorId);
            return View(dV_Book);
        }

        // GET: DV_Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dV_Book = await _context.DV_Books.FindAsync(id);
            if (dV_Book == null)
            {
                return NotFound();
            }
            ViewData["DV_AuthorId"] = new SelectList(_context.DV_Authors, "DV_AuthorId", "DV_AuthorId", dV_Book.DV_AuthorId);
            return View(dV_Book);
        }

        // POST: DV_Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DV_BookId,DV_Title,DV_AuthorId")] DV_Book dV_Book)
        {
            if (id != dV_Book.DV_BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dV_Book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DV_BookExists(dV_Book.DV_BookId))
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
            ViewData["DV_AuthorId"] = new SelectList(_context.DV_Authors, "DV_AuthorId", "DV_AuthorId", dV_Book.DV_AuthorId);
            return View(dV_Book);
        }

        // GET: DV_Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dV_Book = await _context.DV_Books
                .Include(d => d.DV_Author)
                .FirstOrDefaultAsync(m => m.DV_BookId == id);
            if (dV_Book == null)
            {
                return NotFound();
            }

            return View(dV_Book);
        }

        // POST: DV_Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dV_Book = await _context.DV_Books.FindAsync(id);
            if (dV_Book != null)
            {
                _context.DV_Books.Remove(dV_Book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DV_BookExists(int id)
        {
            return _context.DV_Books.Any(e => e.DV_BookId == id);
        }
    }
}
