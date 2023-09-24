﻿using AutoMapper;
using Market.Data.IRepositories;
using Market.Domain.Configurations;
using Market.Domain.Entities.Products;
using Market.Service.DTOs;
using Market.Service.Exceptions;
using Market.Service.Helpers;
using Market.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Market.Service.Services
{
    public partial class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> AddAsync(ProductForCreationDto dto)
        {
            var mappedProduct = _mapper.Map<Product>(dto);
            var product = await _unitOfWork.Products.AddAsync(mappedProduct);

            await _unitOfWork.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            var product = await _unitOfWork.Products.GetAsync(expression);
            if(product is null)
            {
                return false;
            }

            await _unitOfWork.Products.DeleteAsync(expression);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null)
        {
            var pagedList = _unitOfWork.Products.GetAll(expression, tracking: false).ToPagedList(@params);

            return await pagedList.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoriesAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null)
        {
            var pagedList = _unitOfWork.Products.GetAll(expression, "Category", false).ToPagedList(@params);

            return await pagedList.ToListAsync();
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> expression = null)
        {
            return await _unitOfWork.Products.GetAsync(expression);
        }

        public async Task<Product> UpdateAsync(long id, ProductForCreationDto dto)
        {
            var product = await _unitOfWork.Products.GetAsync(x => x.Id == id);
            if(product is null)
                throw new MarketException(404,"Product not found");

            var mappedProduct = _mapper.Map(dto,product);
            var updatedProduct = await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return updatedProduct;
        }
    }
}
