using DataLayer.Entity;
using DataLayer.Repository;
using Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.GetProducts", exc);
            }
            return _productRepository.GetProducts();
        }

        public IEnumerable<object> GetProductsWithStockData()
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.GetProducts", exc);
            }
            return _productRepository.GetProductsWithStockData();
        }

        public object GetProductById(int id)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.GetProductById", exc);
            }
            return _productRepository.GetProductById(id);
        }

        public bool AddProduct(Product product, double price, int qty, DateTime priceDate)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
                _productRepository.AddProduct(product, price, qty, priceDate);
                return true;
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.AddProduct", exc);
            }
        }

        public bool UpdateProduct(Product product, double price, int qty, DateTime priceDate)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
                _productRepository.UpdateProduct(product, price, qty, priceDate);
                return true;
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.UpdateProduct", exc);
            }
        }
        public bool DeleteProductById(int id)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
                _productRepository.DeleteProductById(id);
                return true;
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.DeleteProduct", exc);
            }
        }
    }
}
