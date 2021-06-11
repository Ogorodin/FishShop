using DataLayer.DAOs;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IProductRepository
    {
        public Task<List<ProductStockDAO>> GetProductsWithStockDataAsync();
        public Task<ProductStockDAO> GetProductByIdAsync(int id);
        public Task<bool> AddProductAsync(Product product, Stock stock);
        public Task<bool> UpdateProductAsync(Product product, Stock stock);
        public Task<bool> DeleteProductByIdAsync(int id);
    }
}
