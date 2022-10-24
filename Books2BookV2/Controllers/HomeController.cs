using Microsoft.AspNetCore.Mvc;

namespace Books2BookV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
