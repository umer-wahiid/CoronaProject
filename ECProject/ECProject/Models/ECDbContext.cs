using Microsoft.EntityFrameworkCore;

namespace ECProject.Models
{
    public class ECDbContext:DbContext
    {
        public ECDbContext(DbContextOptions<ECDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
