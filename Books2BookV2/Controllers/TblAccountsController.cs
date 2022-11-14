﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;
using Microsoft.AspNetCore.Identity;

namespace Books2BookV2.Controllers
{
    public class TblAccountsController : Controller
    {
        private readonly Book2BookContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TblAccountsController(Book2BookContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
      


        // GET: TblAccounts
        public async Task<IActionResult> Index()
        {
            var book2BookContext = _context.TblAccounts.Include(t => t.UserNameNavigation);
            return View(await book2BookContext.ToListAsync());
        }

        // GET: TblAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblAccounts == null)
            {
                return NotFound();
            }

            var tblAccount = await _context.TblAccounts
                .Include(t => t.UserNameNavigation)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (tblAccount == null)
            {
                return NotFound();
            }

            return View(tblAccount);
        }

        // GET: TblAccounts/Create
        public IActionResult Create()
        {
            ViewData["UserName"] = new SelectList(_context.AspNetUsers, "UserName", "Id");
            return View();
        }

        // POST: TblAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Bank,AccountNumber,UserName")] TblAccount tblAccount)
        {

            if (ModelState.IsValid)
            {
                _context.Add(tblAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserName"] = new SelectList(_context.AspNetUsers, "UserName", "Id", tblAccount.UserName);
            return View(tblAccount);
        }

        // GET: TblAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblAccounts == null)
            {
                return NotFound();
            }

            var tblAccount = await _context.TblAccounts.FindAsync(id);
            if (tblAccount == null)
            {
                return NotFound();
            }
            ViewData["UserName"] = new SelectList(_context.AspNetUsers, "UserName", "Id", tblAccount.UserName);
            return View(tblAccount);
        }

        // POST: TblAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Bank,AccountNumber,UserName")] TblAccount tblAccount)
        {
            if (id != tblAccount.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAccountExists(tblAccount.AccountId))
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
            ViewData["UserName"] = new SelectList(_context.AspNetUsers, "UserName", "Id", tblAccount.UserName);
            return View(tblAccount);
        }

        // GET: TblAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblAccounts == null)
            {
                return NotFound();
            }

            var tblAccount = await _context.TblAccounts
                .Include(t => t.UserNameNavigation)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (tblAccount == null)
            {
                return NotFound();
            }

            return View(tblAccount);
        }

        // POST: TblAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblAccounts == null)
            {
                return Problem("Entity set 'Book2BookContext.TblAccounts'  is null.");
            }
            var tblAccount = await _context.TblAccounts.FindAsync(id);
            if (tblAccount != null)
            {
                _context.TblAccounts.Remove(tblAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAccountExists(int id)
        {
          return _context.TblAccounts.Any(e => e.AccountId == id);
        }
    }
}
