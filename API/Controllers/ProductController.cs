using API.Services;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        // get all with stock data
        [HttpGet]
        [Route("stock")]
        public IEnumerable<object> GetProductsWithStockData()
        {
            return _productService.GetProductsWithStockData();
        }

        // get by ID
        [HttpGet]
        [Route("{id}")]
        public object GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        // add product
        [HttpPost]
        public bool AddProduct(Product product, double price, int qty, DateTime priceDate)
        {
            return _productService.AddProduct(product, price, qty, priceDate);
        }

        // update product
        [HttpPut]
        [Route("{id}")]
        public bool UpdateProduct(Product product, double price, int qty, DateTime priceDate)
        {
            return _productService.UpdateProduct(product, price, qty, priceDate);
        }

        // delete product
        [HttpDelete]
        [Route("{id}")]
        public bool DeleteProductById(int id)
        {
            return _productService.DeleteProductById(id);
        }

    }
}
