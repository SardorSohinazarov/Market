using Market.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.DbContexts
{
    public class MarketDbContext:DbContext 
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
