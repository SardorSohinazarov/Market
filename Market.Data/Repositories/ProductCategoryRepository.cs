using Market.Data.DbContexts;
using Market.Data.IRepositories;
using Market.Domain.Entities.Products;

namespace Market.Data.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(MarketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
