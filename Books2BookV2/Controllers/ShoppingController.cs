using Books2BookV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly Book2BookContext _context;
        public ShoppingController(Book2BookContext context) { 
            _context = context;
        }

        // GET: ShoppingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShoppingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       

        // GET: ShoppingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
