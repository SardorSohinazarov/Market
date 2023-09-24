using Market.Domain.Entities.Common;
using Market.Domain.Entities.Products;

namespace Market.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<ProductCategory> ProductCategories { get; }
        IRepository<Attachment> Attachments { get; }

        Task SaveChangesAsync();
    }
}
