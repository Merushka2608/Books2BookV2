using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books2BookV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Controllers
{
    public class TblAuthorsController : Controller
    {
        private readonly Book2BookContext _context;

        public TblAuthorsController(Book2BookContext context)
        {
            _context = context;
        }

        // GET: TblAuthors
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAuthors.ToListAsync());
        }

        // GET: TblAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblAuthors == null)
            {
                return NotFound();
            }

            var tblAuthor = await _context.TblAuthors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (tblAuthor == null)
            {
                return NotFound();
            }

            return View(tblAuthor);
        }

        // GET: TblAuthors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorName")] TblAuthor tblAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAuthor);
        }

        // GET: TblAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblAuthors == null)
            {
                return NotFound();
            }

            var tblAuthor = await _context.TblAuthors.FindAsync(id);
            if (tblAuthor == null)
            {
                return NotFound();
            }
            return View(tblAuthor);
        }

        // POST: TblAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName")] TblAuthor tblAuthor)
        {
            if (id != tblAuthor.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAuthorExists(tblAuthor.AuthorId))
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
            return View(tblAuthor);
        }

        // GET: TblAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblAuthors == null)
            {
                return NotFound();
            }

            var tblAuthor = await _context.TblAuthors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (tblAuthor == null)
            {
                return NotFound();
            }

            return View(tblAuthor);
        }

        // POST: TblAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblAuthors == null)
            {
                return Problem("Entity set 'Book2BookContext.TblAuthors'  is null.");
            }
            var tblAuthor = await _context.TblAuthors.FindAsync(id);
            if (tblAuthor != null)
            {
                _context.TblAuthors.Remove(tblAuthor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAuthorExists(int id)
        {
            return _context.TblAuthors.Any(e => e.AuthorId == id);
        }
    }
}
