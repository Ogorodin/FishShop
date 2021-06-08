using API.Services;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService service)
        {
            _productService = service;
        }

        // get all
        [HttpGet]
        public async Task<List<Product>> GetProductAsyncs()
        {
            return await _productService.GetProductsAsync();
        }

        // get all with stock data
        [HttpGet]
        [Route("stock")]
        public async Task<List<object>> GetProductsWithStockDataAsync()
        {
            return await _productService.GetProductsWithStockDataAsync() as List<object>;
        }

        // get by ID
        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetProductByIdAsync(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        // add product
        [HttpPost]
        public async Task<bool> AddProductAsync(Product product, double price, int qty, DateTime priceDate)
        {
            return await _productService.AddProductAsync(product, price, qty, priceDate);
        }

        // update product
        [HttpPut]
        [Route("{id}")]
        public async Task<bool> UpdateProductAsync(Product product, double price, int qty, DateTime priceDate)
        {
            return await _productService.UpdateProductAsync(product, price, qty, priceDate);
        }

        // delete product
        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            return await _productService.DeleteProductByIdAsync(id);
        }

    }
}
