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
    public class TblPaymentsController : Controller
    {
        private readonly Book2BookContext _context;
        private List<TblBorrow> itemsToPayFor;

        public TblPaymentsController(Book2BookContext context)
        {
            _context = context;
        }

        // GET: TblPayments
        public async Task<IActionResult> Index()
        {
            var book2BookContext = _context.TblPayments.Include(t => t.Account);

            
            return View(await book2BookContext.ToListAsync());
        }

        // GET: TblPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblPayments == null)
            {
                return NotFound();
            }

            var tblPayment = await _context.TblPayments
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPayment == null)
            {
                return NotFound();
            }

            return View(tblPayment);
        }

        // GET: TblPayments/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.TblAccounts, "AccountId", "AccountId");
            return View();
        }

        // POST: TblPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,BookIds")] TblPayment tblPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.TblAccounts, "AccountId", "AccountId", tblPayment.AccountId);
            return View(tblPayment);
        }

        // GET: TblPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblPayments == null)
            {
                return NotFound();
            }

            var tblPayment = await _context.TblPayments.FindAsync(id);
            if (tblPayment == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.TblAccounts, "AccountId", "AccountId", tblPayment.AccountId);
            return View(tblPayment);
        }

        // POST: TblPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountId,BookIds")] TblPayment tblPayment)
        {
            if (id != tblPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPaymentExists(tblPayment.Id))
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
            ViewData["AccountId"] = new SelectList(_context.TblAccounts, "AccountId", "AccountId", tblPayment.AccountId);
            return View(tblPayment);
        }

        // GET: TblPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblPayments == null)
            {
                return NotFound();
            }

            var tblPayment = await _context.TblPayments
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPayment == null)
            {
                return NotFound();
            }

            return View(tblPayment);
        }

        // POST: TblPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblPayments == null)
            {
                return Problem("Entity set 'Book2BookContext.TblPayments'  is null.");
            }
            var tblPayment = await _context.TblPayments.FindAsync(id);
            if (tblPayment != null)
            {
                _context.TblPayments.Remove(tblPayment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPaymentExists(int id)
        {
          return _context.TblPayments.Any(e => e.Id == id);
        }
    }
}