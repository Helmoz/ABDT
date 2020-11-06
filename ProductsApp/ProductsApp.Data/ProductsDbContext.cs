using Microsoft.EntityFrameworkCore;
using ProductsApp.Core.Entities;

namespace ProductsApp.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }

        public ProductsDbContext() { }

        public DbSet<Product> Products { get; set; }

        public DbSet<UserSession> UserSessions { get; set; }
    }
}