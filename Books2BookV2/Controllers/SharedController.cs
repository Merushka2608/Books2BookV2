using Books2BookV2.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace Books2BookV2.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
      public bool LeaveComment(TblComment tblComment)
        {
            Book2BookContext context = new Book2BookContext();

            context.TblComments.Add(tblComment);

            return context.SaveChanges() > 0;
        }

    }
}
