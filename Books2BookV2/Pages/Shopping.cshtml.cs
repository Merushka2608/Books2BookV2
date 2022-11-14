using Books2BookV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Books2BookV2.Pages
{
    public class Shopping : PageModel
    {
        public Shopping(ILogger<Shopping> logger, Book2BookContext context)
        {
            _logger = logger;
            _context = context;
        }

        private readonly ILogger<Shopping> _logger;
        private readonly Book2BookContext _context;
        public IQueryable<TblBook> bookTitles;
        

        public List<double> prices = new List<double>();
       
      
        
        

     
        public void OnGet()
        {
            string userId = User.Identity.Name;


            bookTitles = from b in _context.TblBooks
                         join c in _context.TblBorrows
                         on b.BookId equals c.BookId
                         where (c.IsPaid == false && userId == c.UserName)
                         select b;


            foreach (var i in bookTitles)
            {
                if (i.Condition.Equals("A"))
                {
                    prices.Add(150);
                }
                else if (i.Condition.Equals("B"))
                {
                    prices.Add(100);
                }
                else if (i.Condition.Equals("C"))
                {
                    prices.Add(50);
                }
            }

            double sum = prices.Sum();
            TempData["priceTotal"] = JsonConvert.SerializeObject(sum);

        }



    }
}