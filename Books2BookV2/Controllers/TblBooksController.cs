using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Books2BookV2.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Books2BookV2.Controllers
{


	public class TblBooksController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;

		private readonly Book2BookContext _context;

		public TblBooksController(Book2BookContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}


		public async Task<IActionResult> Index(string searchString, string sortBy, string filterBy)
		{
			//  ViewBag.SortCategoryParameter = string.IsNullOrEmpty(sortBy) ? "Title desc":"";

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

			var books = from m in _context.TblBooks
						select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				books = books.Where(s => s.Title!.Contains(searchString) || s.Isbn!.Contains(searchString));
			}

			if (!String.IsNullOrEmpty(filterBy))
			{
				if (filterBy != "All")
				{
					books = books.Where(s => s.Category!.Contains(filterBy));
				}


			}

			return View(await books.ToListAsync());
		}


		// GET: TblBooks
		/*      public async Task<IActionResult> Index()
              {
                    return View(await _context.TblBooks.ToListAsync());
              }*/



		public TblBook GetBookById(int id)
		{
			return _context.TblBooks.FirstOrDefault(s => s.BookId == id);
		}


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
		//
		[HttpPost]
		public ActionResult AddReview(String rating)
		{
			string rate = rating.ToString();
			Response.WriteAsync(rate);
			return View();
		}
		//


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



        public ActionResult ViewPdfVersion(int BookId)
        {

            DateTime DateBorrow = DateTime.Now;

            string userId = User.Identity.Name;
            var userType = (from b in _context.AspNetUsers
                           where b.UserName == userId
                           select b.SubscriptionType).FirstOrDefault();

            if(userType.Equals("premium"))
            {
                TempData["BookString"] = (from b in _context.TblBooks
                                     where b.BookId == BookId
                                     select b.Pdflink).FirstOrDefault();
                return View("ViewPdf");
            }
            else
            {
                ViewBag.Message = "Message Sent";
                return View("NotAllowed", "TblBooksController");
            }

            return RedirectToAction("Index", "TblBooks");

        }


        public IActionResult NotAllowed()
        {
            return View();
        }

        public ActionResult BorrowBook(int BookId)
        {

			DateTime DateBorrow = DateTime.Now;

			string userId = User.Identity.Name;
			var user = _userManager.FindByNameAsync(userId);
			bool isPaid = false;
			TblBorrow borrow = new TblBorrow(BookId, userId, DateBorrow, isPaid);

			//gets all the books where the user has not paid for as yet
			var booksToPayFor = from b in _context.TblBorrows
								where (b.BookId == BookId && b.UserName == userId)
								select b;
			List<TblBorrow> itemsToPayFor = booksToPayFor.ToList<TblBorrow>();


			_context.TblBorrows.AddAsync(borrow);
			_context.SaveChangesAsync();

			return RedirectToAction("Index", "TblBooks");

		}



		public ActionResult SaveRating(double BookRating, int id)
		{
			var tblBook = _context.TblBooks.Find(id);
			if (tblBook == null)
			{
				return NotFound();
			}

			if (tblBook.AverageRating == null) 
			{
				tblBook.AverageRating = 0;
			}

			tblBook.NumberOfTimesRated += 1;
			tblBook.RatingTotal += (float)BookRating;
			tblBook.AverageRating = (float)(tblBook.RatingTotal/tblBook.NumberOfTimesRated);

			//double total = (float)(tblBook.NumberOfTimesBorrowed * tblBook.AverageRating);
			//total += total + BookRating;

			//tblBook.NumberOfTimesBorrowed += 1;
			//tblBook.AverageRating = (float)(total / tblBook.NumberOfTimesBorrowed);
			_context.Update(tblBook);
			_context.SaveChangesAsync();

			return RedirectToAction("Index", "TblBooks");


		}



	}
}
