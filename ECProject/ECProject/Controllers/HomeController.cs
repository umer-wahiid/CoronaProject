using ECProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public IActionResult Products()
        {
            var Pro = _context.Products.ToList();
            var Cat = _context.Categories.ToList();

            var ViewModel = new CombinedModels
            {
                ProData = Pro.ToList(),
                CatData = Cat.ToList()
            };

			return View(ViewModel);
        }


        public async Task<IActionResult> Details(int? id)
        {
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.ProductId == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
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