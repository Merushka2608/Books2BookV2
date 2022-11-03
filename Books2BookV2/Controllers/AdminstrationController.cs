using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Books2BookV2.Controllers
{
    public class AdminstrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminstrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
