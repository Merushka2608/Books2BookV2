using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books2BookV2.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Books2BookV2.Controllers
{
    public class TblImagesController : Controller
    {
        private readonly Book2BookContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TblImagesController(Book2BookContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: TblImages
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblImages.ToListAsync());
        }

        // GET: TblImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblImages == null)
            {
                return NotFound();
            }

            var tblImage = await _context.TblImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblImage == null)
            {
                return NotFound();
            }

            return View(tblImage);
        }

        // GET: TblImages/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }


        [Authorize]
        // POST: TblImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Image,Isbn,Author,DescriptionOfBook")] TblImage tblImage,string filename)
        {
           
            int count = _context.TblImages.Count();
            

            //store as url 


            if (ModelState.IsValid)
            {
                tblImage.Id = count + 1;
                byte[] image = Convert.FromBase64String(tblImage.Image.Split(',')[1]);
                string newName = Guid.NewGuid().ToString() + $"{Path.GetExtension(filename)}";
                string path = $"/booksToSell/{newName}";
                System.IO.File.WriteAllBytes($"{_webHostEnvironment.WebRootPath}/" +path, image);
                tblImage.Image = path;
                _context.Add(tblImage);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("Success", "TblImages");
            }
            //return RedirectToAction("Success", "TblImages");
            return View(tblImage);
        }

        // GET: TblImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblImages == null)
            {
                return NotFound();
            }

            var tblImage = await _context.TblImages.FindAsync(id);
            if (tblImage == null)
            {
                return NotFound();
            }
            return View(tblImage);
        }

        // POST: TblImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Image,Isbn,Author,DescriptionOfBook")] TblImage tblImage)
        {
            if (id != tblImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblImageExists(tblImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblImage);
        }

        // GET: TblImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblImages == null)
            {
                return NotFound();
            }

            var tblImage = await _context.TblImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblImage == null)
            {
                return NotFound();
            }

            return View(tblImage);
        }

        // POST: TblImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblImages == null)
            {
                return Problem("Entity set 'Book2BookContext.TblImages'  is null.");
            }
            var tblImage = await _context.TblImages.FindAsync(id);
            if (tblImage != null)
            {
                _context.TblImages.Remove(tblImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblImageExists(int id)
        {
          return _context.TblImages.Any(e => e.Id == id);
        }
    }
}
