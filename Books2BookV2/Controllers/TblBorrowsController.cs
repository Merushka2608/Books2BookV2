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
    public class TblBorrowsController : Controller
    {
        private readonly Book2BookContext _context;

        public TblBorrowsController(Book2BookContext context)
        {
            _context = context;
        }

        // GET: TblBorrows
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblBorrows.ToListAsync());
        }

        // GET: TblBorrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblBorrows == null)
            {
                return NotFound();
            }

            var tblBorrow = await _context.TblBorrows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblBorrow == null)
            {
                return NotFound();
            }

            return View(tblBorrow);
        }

        // GET: TblBorrows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblBorrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,UserName,DateToBorrow,IsPaid")] TblBorrow tblBorrow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBorrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBorrow);
        }

        // GET: TblBorrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblBorrows == null)
            {
                return NotFound();
            }

            var tblBorrow = await _context.TblBorrows.FindAsync(id);
            if (tblBorrow == null)
            {
                return NotFound();
            }
            return View(tblBorrow);
        }

        // POST: TblBorrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,UserName,DateToBorrow,IsPaid")] TblBorrow tblBorrow)
        {
            if (id != tblBorrow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBorrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBorrowExists(tblBorrow.Id))
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
            return View(tblBorrow);
        }

        // GET: TblBorrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblBorrows == null)
            {
                return NotFound();
            }

            var tblBorrow = await _context.TblBorrows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblBorrow == null)
            {
                return NotFound();
            }

            return View(tblBorrow);
        }

        // POST: TblBorrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblBorrows == null)
            {
                return Problem("Entity set 'Book2BookContext.TblBorrows'  is null.");
            }
            var tblBorrow = await _context.TblBorrows.FindAsync(id);
            if (tblBorrow != null)
            {
                _context.TblBorrows.Remove(tblBorrow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBorrowExists(int id)
        {
          return _context.TblBorrows.Any(e => e.Id == id);
        }


        [HttpPost]
        public ActionResult remove(int bookid)
        {
            string userId = User.Identity.Name;

            var book = (from b in _context.TblBorrows
                        where (b.BookId == bookid  && b.UserName == userId)
                        select b).FirstOrDefault();

            _context.TblBorrows.Remove(book);
            _context.SaveChanges();

            return Redirect("~/Shopping");
        }
    }
}
