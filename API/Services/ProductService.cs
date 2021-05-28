using DataLayer.Entity;
using DataLayer.Repository;
using Domain.Exceptions;
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

        public Product GetProductById(int id)
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

        public bool AddProduct(Product product)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
                _productRepository.AddProduct(product);
                return true;
            }
            catch (ProductServiceException exc)
            {
                throw new ProductServiceException("Exception caught in API.Services.ProductService.AddProduct", exc);
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                // IMAGIONARY IMPLEMENTATION THAT CAN CAUSE A PROBLEM...
                _productRepository.UpdateProduct(product);
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
