using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECProject.Models
{
    public class ProductsViewComponent : ViewComponent
    {
        public ECDbContext _context;

        public ProductsViewComponent(ECDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Products.ToListAsync());
        }
    }
}
