using Market.Data.DbContexts;
using Market.Data.IRepositories;

namespace Market.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketDbContext _dbContext;

        public UnitOfWork(MarketDbContext dbContext)
        {
            _dbContext = dbContext;

            Products = new ProductRepository(_dbContext);
            ProductCategories = new ProductCategoryRepository(_dbContext);
        }

        //DbSet
        public IProductRepository Products { get; }
        public IProductCategoryRepository ProductCategories { get; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
