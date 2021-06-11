using API.Services;
using DataLayer.DAOs;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
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

        // get all with stock data
        [HttpGet]
        [Route("stock")]
        public async Task<IActionResult> GetProductsWithStockDataAsync()
        {
            var list = await _productService.GetProductsWithStockDataAsync() as List<ProductStockDAO>;
            if (list != null)
            {
                return Ok(list);
            }
            else return NotFound();
        }

        // get by ID
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            else return NotFound();
        }

        // add product
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductStockDAO productDao)
        {
            Product product = new Product
            {
                title = productDao.Title,
                description = productDao.Description,
                the_type = productDao.ProductType
            };
            Stock stock = new Stock
            {
                Price = productDao.Price,
                Quantity = productDao.Quantity,
                PriceDate = productDao.PriceDate
            };

            if (await _productService.AddProductAsync(product, stock))
            {
                return Ok();
            }
            else return StatusCode(500);
        }

        // update product
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductStockDAO productDao)
        {
            Product product = new Product
            {
                Id = productDao.Id,
                title = productDao.Title,
                description = productDao.Description,
                the_type = productDao.ProductType
            };
            Stock stock = new Stock
            {
                Price = productDao.Price,
                Quantity = productDao.Quantity,
                PriceDate = productDao.PriceDate
            };
            if (await _productService.UpdateProductAsync(product, stock))
            {
                return Ok();
            }
            return NotFound();
        }

        // delete product
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProductByIdAsync(int id)
        {
            if (await _productService.DeleteProductByIdAsync(id))
            {
                return Ok();
            }
            else return NotFound();
        }

    }
}
