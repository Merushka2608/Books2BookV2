using Books2BookV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Books2BookV2.Controllers
{
	public class TblSellBook : Controller
	{

		private readonly UserManager<IdentityUser> _userManager;

		private readonly Book2BookContext _context;

		public TblSellBook(Book2BookContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
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
        public async Task<IActionResult> Create([Bind("ID, BookTitle, FrontPicture,BackPicture")] TblSellBook tblSellBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSellBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSellBook);
        }

    }
}
