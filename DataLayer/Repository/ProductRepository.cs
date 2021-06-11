using Dapper;
using DataLayer.DAOs;
using DataLayer.Entity;
using Domain.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ProductStockDAO>> GetProductsWithStockDataAsync()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "get_products_with_stock_data";
                    var result = await connection.QueryAsync<ProductStockDAO>(procedure, commandType: CommandType.StoredProcedure);
                    return result as List<ProductStockDAO>;
                }
            }
            catch (Exception exc)
            {
                // return null;
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public async Task<ProductStockDAO> GetProductByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "get_single_product_with_stock_data_by_id";
                    var parameters = new { id };

                    var result = await connection.QueryFirstOrDefaultAsync<ProductStockDAO>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception exc)
            {
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public async Task<bool> AddProductAsync(Product product, Stock stock)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "insert_product_with_stock_data";
                    var parameters = new
                    {
                        product.title,
                        product.description,
                        productType = product.the_type,
                        stock.Price,
                        stock.Quantity,
                        stock.PriceDate
                    };
                    await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception exc)
            {
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public async Task<bool> UpdateProductAsync(Product product, Stock stock)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var parameters = new
                    {
                        product.Id,
                        product.title,
                        product.description,
                        product.the_type,
                        stock.Price,
                        stock.Quantity,
                        stock.PriceDate
                    };

                    var procedure = "update_product";
                    await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception exc)
            {
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {

                    connection.Open();
                    var procedure = "delete_product_with_stock_data_by_id";
                    var parameters = new
                    {
                        Id = id
                    };

                    await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception exc)
            {
                // return false;
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }
    }
}


