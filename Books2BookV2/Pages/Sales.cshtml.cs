using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;

namespace Books2BookV2.Pages
{
    public class SalesModel : PageModel
    {
        private readonly Book2BookContext _context;

        public SalesModel(Book2BookContext context)
        {
            _context = context;
        }

    }
}