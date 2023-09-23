using Market.Data.DbContexts;
using Market.Data.IRepositories;
using Market.Domain.Entities.Products;

namespace Market.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MarketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
