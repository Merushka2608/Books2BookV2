using Books2BookV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Pages
{
    public class Shopping : PageModel
    {
        private readonly ILogger<Shopping> _logger;
        private readonly Book2BookContext _context;
        public IEnumerable<TblBorrow> itemsToPayFor { get; set; }

        public Shopping(ILogger<Shopping> logger, Book2BookContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

            string userId = User.Identity.Name;

            //gets all the books where the user has not paid for as yet
            var booksToPayFor = from b in _context.TblBorrows
                                where (b.IsPaid == false)
                                select b;

            itemsToPayFor = booksToPayFor.ToList<TblBorrow>();
        }
    }
}