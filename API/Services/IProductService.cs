using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<IEnumerable<object>> GetProductsWithStockDataAsync();
        public Task<object> GetProductByIdAsync(int id);
        public Task<bool> AddProductAsync(Product product, double price, int qty, DateTime priceDate);
        public Task<bool> UpdateProductAsync(Product product, double price, int qty, DateTime priceDate);
        public Task<bool> DeleteProductByIdAsync(int id);
    }
}
