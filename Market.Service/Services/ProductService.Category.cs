using Market.Data.IRepositories;
using Market.Domain.Configurations;
using Market.Domain.Entities.Products;
using Market.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Market.Service.Services
{
    public partial class ProductService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public async Task<ProductCategory> AddCategoryAsync(string category)
        {
            var result = await _productCategoryRepository.AddAsync(new ProductCategory() { Name = category });

            await _productCategoryRepository.SaveChangesAsync();

            return result;
        }

        public async Task<List<ProductCategory>> GetAllCategoriesAsync(PaginationParams @params, Expression<Func<ProductCategory, bool>> expression = null)
        {
            var pagenedList = _productCategoryRepository.GetAll(expression, tracking: false).ToPagedList(@params);

            return await pagenedList.ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryAsync(Expression<Func<ProductCategory, bool>> expression = null)
        {
            return await _productCategoryRepository.GetAsync(expression);
        }

        public async Task<List<ProductCategory>> GetCategoryWithProductsAsync(PaginationParams @params, Expression<Func<ProductCategory, bool>> expression = null)
        {
            var pagenedList = _productCategoryRepository.GetAll(expression,"Products", tracking: false).ToPagedList(@params);

            return await pagenedList.ToListAsync();
        }

        public async Task<ProductCategory> UpdateCategoryAsync(long id, string dto)
        {
            var productCategory = await _productCategoryRepository.GetAsync(x => x.Id == id);
            if(productCategory is not null) 
            {
                productCategory.Name = dto;
                productCategory.UpdatedAt = DateTime.UtcNow;

                await _productCategoryRepository.SaveChangesAsync();
            }

            return productCategory;
        }

        public async Task<bool> DeleteCategoryAsync(Expression<Func<ProductCategory, bool>> expression)
        {
            var productCategory = await _productCategoryRepository.GetAsync(expression);
            if (productCategory is not null)
            {
                await _productCategoryRepository.DeleteAsync(expression);
                await _productCategoryRepository.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
