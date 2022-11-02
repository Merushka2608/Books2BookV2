using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Books2BookV2.Controllers
{
    public class StatsDetailsController : Controller
    {
        private readonly Book2BookContext _context;

        public StatsDetailsController(Book2BookContext context)
        {
            _context = context;
        }

        // GET: StatsDetails
        public async Task<IActionResult> Index()
        {
            //counts
            int numbBooksFiction = (from book in _context.TblBooks
                                    where book.Category == "Fiction"
                                    select book).Count();
            int numCodingBooks = (from book in _context.TblBooks
                                  where book.Category == "Coding"
                                  select book).Count();
            int numBusinessBooks = (from book in _context.TblBooks
                                    where book.Category == "Business"
                                    select book).Count();

            //times borrowed

            int sumTimesBorrowedCoding = _context.TblBooks
            .Where(b => b.Category == "Coding")
            .Sum(b => b.NumberOfTimesBorrowed);  

            int sumTimesBorrowedFiction = _context.TblBooks
            .Where(b => b.Category == "Fiction")
            .Sum(b => b.NumberOfTimesBorrowed);  
            
            int sumTimesBorrowedBusiness = _context.TblBooks
            .Where(b => b.Category == "Business")
            .Sum(b => b.NumberOfTimesBorrowed);




            var details = new List<StatsDetails>
            {
                new StatsDetails(){Id = 1, Name= "Ficton" , total = numbBooksFiction, numTimesBorrowed = sumTimesBorrowedFiction},
                new StatsDetails(){Id = 2, Name= "Coding" , total = numCodingBooks, numTimesBorrowed = sumTimesBorrowedCoding},
                new StatsDetails(){Id = 3, Name= "Business" , total = numBusinessBooks, numTimesBorrowed = sumTimesBorrowedBusiness}

            };

            //int sum = 10;


            return View(details);
        }

        // GET: StatsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatsDetails == null)
            {
                return NotFound();
            }

            var statsDetails = await _context.StatsDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statsDetails == null)
            {
                return NotFound();
            }

            return View(statsDetails);
        }

        // GET: StatsDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatsDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,total")] StatsDetails statsDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statsDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statsDetails);
        }

        // GET: StatsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatsDetails == null)
            {
                return NotFound();
            }

            var statsDetails = await _context.StatsDetails.FindAsync(id);
            if (statsDetails == null)
            {
                return NotFound();
            }
            return View(statsDetails);
        }

        // POST: StatsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,total")] StatsDetails statsDetails)
        {
            if (id != statsDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statsDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatsDetailsExists(statsDetails.Id))
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
            return View(statsDetails);
        }

        // GET: StatsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatsDetails == null)
            {
                return NotFound();
            }

            var statsDetails = await _context.StatsDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statsDetails == null)
            {
                return NotFound();
            }

            return View(statsDetails);
        }

        // POST: StatsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatsDetails == null)
            {
                return Problem("Entity set 'Book2BookContext.StatsDetails'  is null.");
            }
            var statsDetails = await _context.StatsDetails.FindAsync(id);
            if (statsDetails != null)
            {
                _context.StatsDetails.Remove(statsDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatsDetailsExists(int id)
        {
          return _context.StatsDetails.Any(e => e.Id == id);
        }
    }
}
