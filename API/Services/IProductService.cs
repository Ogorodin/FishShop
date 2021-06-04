using DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace API.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProducts();

        public IEnumerable<object> GetProductsWithStockData();

        public object GetProductById(int id);

        public bool AddProduct(Product product, double price, int qty, DateTime priceDate);

        public bool UpdateProduct(Product product, double price, int qty, DateTime priceDate);

        public bool DeleteProductById(int id);

    }
}
