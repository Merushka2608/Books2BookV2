using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;
using System.Net;

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
        public  IEnumerable<TblBook> businessBooks { get; set; } 
        public  IEnumerable<TblBook> fictionBooks { get; set; }
        public void OnGet()
        {
             codingBooks = from book in _context.TblBooks
                              where book.Category == "Coding"
                              select book;

            businessBooks = from book in _context.TblBooks
                          where book.Category == "Business"
                          select book;
            fictionBooks = from book in _context.TblBooks
                            where book.Category == "Fiction"
                            select book;

        
         

        }
    }
}