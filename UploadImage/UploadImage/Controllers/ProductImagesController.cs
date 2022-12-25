using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UploadImage.Data;
using UploadImage.Models;
using UploadImage.ViewModel;

namespace UploadImage.Controllers
{
    public class ProductImagesController : Controller
    {
        private readonly UploadImageContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductImagesController(UploadImageContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: ProductImages
        public async Task<IActionResult> Index()
        {
              return _context.ProductImage != null ? 
                          View(await _context.ProductImage.ToListAsync()) :
                          Problem("Entity set 'UploadImageContext.ProductImage'  is null.");
        }

        // GET: ProductImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductImage == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // GET: ProductImages/Create
        public IActionResult Create()
        {
            ProImages vm = new ProImages();
            ViewBag.images = new SelectList(_context.Product.ToList(), "Id", "Title");
            return View(vm);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProImages vm)
        {
            foreach (var item in vm.Images)
            {
                string stringFileName = UploadFile(item);
                var productImage = new ProductImage
                {
                    ImageUrl = stringFileName,
                    Product = vm.Product
                };
                _context.ProductImage.Add(productImage);
            }   
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile file)
        {
            string fileName = null;
            if(file != null)
            {
                string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }    
            }
            return fileName;
        }


        // GET: ProductImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductImage == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage.FindAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }
            return View(productImage);
        }

        // POST: ProductImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl")] ProductImage productImage)
        {
            if (id != productImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductImageExists(productImage.Id))
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
            return View(productImage);
        }

        // GET: ProductImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductImage == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // POST: ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductImage == null)
            {
                return Problem("Entity set 'UploadImageContext.ProductImage'  is null.");
            }
            var productImage = await _context.ProductImage.FindAsync(id);
            if (productImage != null)
            {
                _context.ProductImage.Remove(productImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductImageExists(int id)
        {
          return (_context.ProductImage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
