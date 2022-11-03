using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.IO;

namespace Books2BookV2.Pages
{
	public class SalesModel : PageModel
	{
		private readonly Book2BookContext _context;

		public SalesModel(Book2BookContext context)
		{
			_context = context;
		}

      /*  [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(IFormFile formFile)

        {

            try

            {

                string fileName = formFile.FileName;

                fileName = Path.GetFileName(fileName);

                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\salesImages", fileName);

                var stream = new FileStream(uploadpath, FileMode.Create);

                formFile.CopyToAsync(stream);

                ViewBag.FrontPicture = "File uploaded successfully.";

            }

            catch

            {

                ViewBag.FrontPicture = "Error while uploading the files.";

            }

            return View();

        }*/

    }

}