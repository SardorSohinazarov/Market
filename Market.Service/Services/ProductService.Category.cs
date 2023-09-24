using Azure.Core;
using Market.Data.IRepositories;
using Market.Domain.Configurations;
using Market.Domain.Entities.Products;
using Market.Service.Exceptions;
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
            var category = await _productCategoryRepository.GetAsync(expression);
            if (category is null)
                throw new MarketException(404, "Product category not found");

            return category;
        }

        public async Task<List<ProductCategory>> GetCategoryWithProductsAsync(PaginationParams @params, Expression<Func<ProductCategory, bool>> expression = null)
        {
            var pagenedList = _productCategoryRepository.GetAll(expression,"Products", tracking: false).ToPagedList(@params);

            return await pagenedList.ToListAsync();
        }

        public async Task<ProductCategory> UpdateCategoryAsync(long id, string dto)
        {
            var productCategory = await _productCategoryRepository.GetAsync(x => x.Id == id);
            if(productCategory is null) 
                throw new MarketException(404,"Category not found");

            productCategory.Name = dto;
            productCategory.UpdatedAt = DateTime.UtcNow;

            await _productCategoryRepository.SaveChangesAsync();

            return productCategory;
        }

        public async Task<bool> DeleteCategoryAsync(Expression<Func<ProductCategory, bool>> expression)
        {
            var productCategory = await _productCategoryRepository.GetAsync(expression);
            if (productCategory is null)
                throw new MarketException(404, "Category not found");

            await _productCategoryRepository.DeleteAsync(expression);
            await _productCategoryRepository.SaveChangesAsync();

            return false;
        }
    }
}
