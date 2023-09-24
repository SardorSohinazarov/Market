namespace Market.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProductCategoryRepository ProductCategories { get; }
        IProductRepository Products { get; }

        Task SaveChangesAsync();
    }
}
