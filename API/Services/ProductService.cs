using DataLayer.DAOs;
using DataLayer.Entity;
using DataLayer.Repository;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<IEnumerable<ProductStockDAO>> GetProductsWithStockDataAsync()
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.GetProducts", exc);
            }
            return await _productRepository.GetProductsWithStockDataAsync();
        }

        public async Task<ProductStockDAO> GetProductByIdAsync(int id)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.GetProductById", exc);
            }
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<bool> AddProductAsync(Product product, Stock stock)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
                await _productRepository.AddProductAsync(product, stock);
                return true;
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.AddProduct", exc);
            }
        }

        public async Task<bool> UpdateProductAsync(Product product, Stock stock)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
                await _productRepository.UpdateProductAsync(product, stock);
                return true;
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.UpdateProduct", exc);
            }
        }
        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
                await _productRepository.DeleteProductByIdAsync(id);
                return true;
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.DeleteProduct", exc);
            }
        }
    }
}
