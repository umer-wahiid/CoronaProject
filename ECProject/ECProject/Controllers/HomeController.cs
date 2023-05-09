using ECProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECProject.Controllers
{
    public class HomeController : Controller
    {
        ECDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ECDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
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