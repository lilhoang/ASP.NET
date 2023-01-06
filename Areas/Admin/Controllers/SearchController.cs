using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Models;

namespace OnlineBookLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly OnlineBookLibraryDataContext _context;

        public SearchController(OnlineBookLibraryDataContext context)
        {
            _context = context;
        }

        //GET: Search/FindProduct
        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
            List<Book> Is = new List<Book>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            Is = _context.Books.AsNoTracking()
                                .Include(a => a.Genre)
                                .Where(x => x.Title.Contains(keyword))
                                .OrderByDescending(x => x.Title)
                                .Take(10)
                                .ToList();
            if (Is == null)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            else
            {
                return PartialView("ListProductsSearchPartial", Is);

            }
        }


    }
}
