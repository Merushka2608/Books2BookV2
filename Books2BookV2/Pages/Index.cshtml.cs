using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;

namespace Books2BookV2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Book2BookContext _context;

        public IndexModel(Book2BookContext context)
        {
            _context = context;
        }

        public  IEnumerable<TblBook> codingBooks { get; set; } 
        public void OnGet()
        {
             codingBooks = from book in _context.TblBooks
                              where book.Category == "Coding"
                              select book;
        }
    }
}