using Market.Domain.Configurations;
using Market.Domain.Entities.Products;
using System.Linq.Expressions;

namespace Market.Service.Interfaces
{
    public partial interface IProductService
    {
        Task<List<ProductCategory>> GetAllCategoriesAsync(PaginationParams @params, Expression<Func<ProductCategory, bool>> expression = null);
        Task<List<ProductCategory>> GetCategoryWithProductsAsync(PaginationParams @params, Expression<Func<ProductCategory, bool>> expression = null);
        Task<ProductCategory> GetCategoryAsync(Expression<Func<ProductCategory, bool>> expression = null);
        Task<ProductCategory> AddCategoryAsync(string category);
        Task<ProductCategory> UpdateCategoryAsync(long id, string dto);
        Task<bool> DeleteCategoryAsync(Expression<Func<ProductCategory, bool>> expression);
    }
}
