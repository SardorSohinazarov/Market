using Market.Data.DbContexts;
using Market.Data.IRepositories;
using Market.Domain.Entities.Common;
using Market.Domain.Entities.Products;

namespace Market.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketDbContext _dbContext;

        public UnitOfWork(MarketDbContext dbContext)
        {
            _dbContext = dbContext;

            Products = new Repository<Product>(_dbContext);
            ProductCategories = new Repository<ProductCategory>(_dbContext);
            Attachments = new Repository<Attachment>(_dbContext);
        }

        public IRepository<Product> Products { get; }
        public IRepository<ProductCategory> ProductCategories {  get; }
        public IRepository<Attachment> Attachments { get; }

        //DbSet

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
