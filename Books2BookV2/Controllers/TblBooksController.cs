﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;

namespace Books2BookV2.Controllers
{
    public class TblBooksController : Controller
    {
        private readonly Book2BookContext _context;

        public TblBooksController(Book2BookContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string sortBy, string filterBy)
        {
            //  ViewBag.SortCategoryParameter = string.IsNullOrEmpty(sortBy) ? "Title desc":"";

            var books = from m in _context.TblBooks
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString) || s.Isbn!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(filterBy))
            {
                books = books.Where(s => s.Category!.Contains(filterBy));
            }

            return View(await books.ToListAsync());
        }


        // GET: TblBooks
        /*      public async Task<IActionResult> Index()
              {
                    return View(await _context.TblBooks.ToListAsync());
              }*/

        // GET: TblBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblBooks == null)
            {
                return NotFound();
            }

            var tblBook = await _context.TblBooks
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tblBook == null)
            {
                return NotFound();
            }

            return View(tblBook);
        }

        // GET: TblBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Isbn,Title,Category,InStock,Edition,Pages,Condition,NumberOfTimesBorrowed,Description,AverageRating,DatePublished,AuthorId")] TblBook tblBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBook);
        }

        // GET: TblBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblBooks == null)
            {
                return NotFound();
            }

            var tblBook = await _context.TblBooks.FindAsync(id);
            if (tblBook == null)
            {
                return NotFound();
            }
            return View(tblBook);
        }

        // POST: TblBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Isbn,Title,Category,InStock,Edition,Pages,Condition,NumberOfTimesBorrowed,Description,AverageRating,DatePublished,AuthorId")] TblBook tblBook)
        {
            if (id != tblBook.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBookExists(tblBook.BookId))
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
            return View(tblBook);
        }

        // GET: TblBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblBooks == null)
            {
                return NotFound();
            }

            var tblBook = await _context.TblBooks
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tblBook == null)
            {
                return NotFound();
            }

            return View(tblBook);
        }

        // POST: TblBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblBooks == null)
            {
                return Problem("Entity set 'Book2BookContext.TblBooks'  is null.");
            }
            var tblBook = await _context.TblBooks.FindAsync(id);
            if (tblBook != null)
            {
                _context.TblBooks.Remove(tblBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBookExists(int id)
        {
          return _context.TblBooks.Any(e => e.BookId == id);
        }
    }
}