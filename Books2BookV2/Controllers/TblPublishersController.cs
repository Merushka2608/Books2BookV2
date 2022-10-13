using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books2Book.Models;

namespace Books2Book.Controllers
{
    public class TblPublishersController : Controller
    {
        private readonly Book2BookContext _context;

        public TblPublishersController(Book2BookContext context)
        {
            _context = context;
        }

        // GET: TblPublishers
        public async Task<IActionResult> Index()
        {
              return _context.TblPublishers != null ? 
                          View(await _context.TblPublishers.ToListAsync()) :
                          Problem("Entity set 'Book2BookContext.TblPublishers'  is null.");
        }

        // GET: TblPublishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblPublishers == null)
            {
                return NotFound();
            }

            var tblPublisher = await _context.TblPublishers
                .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (tblPublisher == null)
            {
                return NotFound();
            }

            return View(tblPublisher);
        }

        // GET: TblPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName")] TblPublisher tblPublisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPublisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPublisher);
        }

        // GET: TblPublishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblPublishers == null)
            {
                return NotFound();
            }

            var tblPublisher = await _context.TblPublishers.FindAsync(id);
            if (tblPublisher == null)
            {
                return NotFound();
            }
            return View(tblPublisher);
        }

        // POST: TblPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublisherId,PublisherName")] TblPublisher tblPublisher)
        {
            if (id != tblPublisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPublisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPublisherExists(tblPublisher.PublisherId))
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
            return View(tblPublisher);
        }

        // GET: TblPublishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblPublishers == null)
            {
                return NotFound();
            }

            var tblPublisher = await _context.TblPublishers
                .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (tblPublisher == null)
            {
                return NotFound();
            }

            return View(tblPublisher);
        }

        // POST: TblPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblPublishers == null)
            {
                return Problem("Entity set 'Book2BookContext.TblPublishers'  is null.");
            }
            var tblPublisher = await _context.TblPublishers.FindAsync(id);
            if (tblPublisher != null)
            {
                _context.TblPublishers.Remove(tblPublisher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPublisherExists(int id)
        {
          return (_context.TblPublishers?.Any(e => e.PublisherId == id)).GetValueOrDefault();
        }
    }
}
