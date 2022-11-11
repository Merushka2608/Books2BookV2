using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books2BookV2.Controllers
{
    public class PdfViewer : Controller
    {
        // GET: PdfViewer
        public ActionResult Index()
        {
            return View();
        }

        // GET: PdfViewer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PdfViewer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PdfViewer/Create
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

        // GET: PdfViewer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PdfViewer/Edit/5
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

        // GET: PdfViewer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PdfViewer/Delete/5
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
