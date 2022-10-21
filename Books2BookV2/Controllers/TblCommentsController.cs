using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;

namespace Books2BookV2.Controllers
{
    public class TblCommentsController : Controller
    {
        private readonly Book2BookContext _context;

        public TblCommentsController(Book2BookContext context)
        {
            _context = context;
        }

        // GET: TblComments
        public async Task<IActionResult> Index()
        {
            var book2BookContext = _context.TblComments.Include(t => t.User);
            return View(await book2BookContext.ToListAsync());
        }

        // GET: TblComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblComments == null)
            {
                return NotFound();
            }

            var tblComment = await _context.TblComments
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (tblComment == null)
            {
                return NotFound();
            }

            return View(tblComment);
        }

        // GET: TblComments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId");
            return View();
        }

        // POST: TblComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Comment,BookId,UserId")] TblComment tblComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblComment.UserId);
            return View(tblComment);
        }

        // GET: TblComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblComments == null)
            {
                return NotFound();
            }

            var tblComment = await _context.TblComments.FindAsync(id);
            if (tblComment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblComment.UserId);
            return View(tblComment);
        }

        // POST: TblComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,Comment,BookId,UserId")] TblComment tblComment)
        {
            if (id != tblComment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCommentExists(tblComment.CommentId))
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
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblComment.UserId);
            return View(tblComment);
        }

        // GET: TblComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblComments == null)
            {
                return NotFound();
            }

            var tblComment = await _context.TblComments
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (tblComment == null)
            {
                return NotFound();
            }

            return View(tblComment);
        }

        // POST: TblComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblComments == null)
            {
                return Problem("Entity set 'Book2BookContext.TblComments'  is null.");
            }
            var tblComment = await _context.TblComments.FindAsync(id);
            if (tblComment != null)
            {
                _context.TblComments.Remove(tblComment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCommentExists(int id)
        {
          return _context.TblComments.Any(e => e.CommentId == id);
        }
    }
}
