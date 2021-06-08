using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<List<object>> GetProductsWithStockDataAsync();
        public Task<object> GetProductByIdAsync(int id);
        public Task<bool> AddProductAsync(Product product, double price, int qty, DateTime priceDate);
        public Task<bool> UpdateProductAsync(Product product, double price, int qty, DateTime priceDate);
        public Task<bool> DeleteProductByIdAsync(int id);
    }
}
