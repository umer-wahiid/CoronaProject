using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECProject.Models
{
    public class CategoriesViewComponent:ViewComponent
    {
        public ECDbContext _context;

        public CategoriesViewComponent(ECDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Categories.ToListAsync());
        }
    }
}
