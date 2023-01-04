using ExAjaxUseage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExAjaxUseage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetNames()
        {
            var names = new string[3]
            {
                "Clara",
                "Marc",
                "Judy"
            };
            return new JsonResult(Ok(names));
        }

        [HttpPost]
        public JsonResult PostName(string name)
        {
            // TODO: write name in db
            return new JsonResult(Ok(name));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}