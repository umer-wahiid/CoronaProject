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

        //public IActionResult Index()
        //{
        //    return View(_context.Products.ToList());
        //}
        //i just copy and pasted the funtion...to understand this code...you'll have to watch the recording of today's class(18/5/2023  STEP:16)
        public async Task<IActionResult> Index(string categorySlug = "" , string productPrice = "")
        {
            ViewBag.CategorySLug = categorySlug;
            ViewBag.ProductPrice = productPrice;
            if (categorySlug == "" && productPrice == "")
            {
                return View(await _context.Products.OrderByDescending(p => p.ProductId).ToListAsync());
            }
            else if(categorySlug != "" && productPrice == "")
            {
                Category category = await _context.Categories.Where(c => c.slug == categorySlug).FirstOrDefaultAsync();
                if (category == null) return RedirectToAction("Index");
                var ProductsByCategory = _context.Products.Where(p => p.CategoryId == category.CategoryId);
                return View(await ProductsByCategory.OrderByDescending(p => p.ProductId).ToListAsync());
            }
            else if(categorySlug == "" && productPrice != "")
            {
                var ProductsByPrice = _context.Products.Where(p => p.Price > (Int64.Parse(productPrice)-500) && p.Price <= Int64.Parse(productPrice));
                return View(await ProductsByPrice.OrderByDescending(p => p.ProductId).ToListAsync());
            }
            else
            {
                return View(await _context.Products.OrderByDescending(p => p.ProductId).ToListAsync());
            }
        }




		public async Task<IActionResult> Products(string categorySlug = "", string productPrice = "")

		{
			ViewBag.CategorySLug = categorySlug;
			ViewBag.ProductPrice = productPrice;
			if (categorySlug == "" && productPrice == "")
			{
				var Pro = await _context.Products.OrderByDescending(p => p.ProductId).ToListAsync();
				var Cat = _context.Categories.ToList();
				var ViewModel = new CombinedModels
				{
					ProData = Pro.ToList(),
					CatData = Cat.ToList()
				};
				return View(ViewModel);
			}
			else if (categorySlug != "" && productPrice == "")
			{
				Category category = await _context.Categories.Where(c => c.slug == categorySlug).FirstOrDefaultAsync();
				if (category == null) return RedirectToAction("Index");
				var ProductsByCategory = _context.Products.Where(p => p.CategoryId == category.CategoryId);
				var Pro = await ProductsByCategory.OrderByDescending(p => p.ProductId).ToListAsync();
				var Cat = _context.Categories.ToList();
				var ViewModel = new CombinedModels
				{
					ProData = Pro.ToList(),
					CatData = Cat.ToList()
				};
				return View(ViewModel);
			}
			else if (categorySlug == "" && productPrice != "")
			{
				var ProductsByPrice = _context.Products.Where(p => p.Price > (Int64.Parse(productPrice) - 500) && p.Price <= Int64.Parse(productPrice));
				var Pro = await ProductsByPrice.OrderByDescending(p => p.ProductId).ToListAsync();
				var Cat = _context.Categories.ToList();
				var ViewModel = new CombinedModels
				{
					ProData = Pro.ToList(),
					CatData = Cat.ToList()
				};
				return View(ViewModel);
			}
			else
			{
				return View(await _context.Products.OrderByDescending(p => p.ProductId).ToListAsync());
			}
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