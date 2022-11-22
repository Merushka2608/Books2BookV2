using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Books2BookV2.Controllers
{
	public class TblPaymentsController : Controller
	{
		private readonly Book2BookContext _context;

		public TblPaymentsController(Book2BookContext context)
		{
			_context = context;
		}

		[Authorize]
		// GET: TblPayments
		public async Task<IActionResult> Index()
		{

			if (TempData["priceTotal"] == null)
			{
                

                    return RedirectToAction("NoPurchases", "TblPayments");

            }

            //here we get the total price
            double temp = double.Parse((string)TempData["priceTotal"]);
			var user = User.Identity.Name;
			var AccountNumber = (from b in _context.AspNetUsers
								 where b.UserName == user
								 select b.AccountNumber).Single();

			TblPayment tblPayment = new TblPayment(user, AccountNumber, DateTime.Now, temp);
			var booksPaid = TempData["unPaid"];

			//sets all the unpaid book values to paid
			(from b in _context.TblBorrows
			 where b.IsPaid == false && b.UserName == user
			 select b).ToList().ForEach(x => x.IsPaid = true);

			_context.Add(tblPayment);
			await _context.SaveChangesAsync();
			return RedirectToAction("Successful", "TblPayments");
		}

		// GET: TblPayments/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.TblPayments == null)
			{
				return NotFound();
			}

			var tblPayment = await _context.TblPayments
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
			return View();
		}

		public IActionResult Successful()
		{
			return View();
		}


        public IActionResult NoPurchases()
        {
            return View();
        }

        // POST: TblPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,UserName,DatePaid")] TblPayment tblPayment)
		{
			if (ModelState.IsValid)
			{
				_context.Add(tblPayment);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(tblPayment);
		}

		public IActionResult MakePayment()
		{

			return View();
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
			return View(tblPayment);
		}




		// POST: TblPayments/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,DatePaid")] TblPayment tblPayment)
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
