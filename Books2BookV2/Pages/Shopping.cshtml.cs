using Books2BookV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Books2BookV2.Pages
{
    public class Shopping : PageModel
    {
        private readonly ILogger<Shopping> _logger;
        private readonly Book2BookContext _context;
        public IQueryable<TblBook> bookTitles;

        public IEnumerable<TblBorrow> itemsToPayFor { get; set; }
        public List<string> bookNames { get; set; }
        public IEnumerable<int> listOfIds { get; set; }
        
        

        public Shopping(ILogger<Shopping> logger, Book2BookContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

            string userId = User.Identity.Name;

           
             bookTitles = from b in _context.TblBooks
                                       join c in _context.TblBorrows
                                       on b.BookId equals c.BookId
                                       where (c.IsPaid == false && userId == c.UserName)
                                       select b;
         
        }
    }
}