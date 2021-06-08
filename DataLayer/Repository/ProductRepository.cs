using Dapper;
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
        private readonly string _connectionString = "server=localhost;port=3306;database=the_fish_shop_db;uid=root;password=admin;";

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var sql = "SELECT * FROM product";
                    var result = await connection.QueryAsync<List<Product>>(sql);
                    return (List<Product>)result; ///////////// ?????????????????

                }
            }
            catch (Exception exc)
            {
                return null;
                // throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public async Task<List<object>> GetProductsWithStockDataAsync()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "get_products_with_stock_data";
                    var result = await connection.QueryAsync<List<object>>(procedure, commandType: CommandType.StoredProcedure);
                    return (List<object>)result;
                }
            }
            catch (Exception exc)
            {
                return null;
                //   throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public async Task<object> GetProductByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "get_single_product_with_stock_data_by_id";
                    var parameters = new
                    {
                        Id = id
                    };

                    var result = await connection.QueryFirstOrDefaultAsync<Product>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception exc)
            {
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public async Task<bool> AddProductAsync(Product product, double price, int quantity, DateTime priceDate)
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
                        price,
                        quantity,
                        price_date = priceDate
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

        public async Task<bool> UpdateProductAsync(Product product, double price, int qty, DateTime priceDate)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var parameters = new
                    {
                        productId = product.Id,
                        title = product.title,
                        description = product.description,
                        p_type = product.the_type,
                        price,
                        quantity = qty,
                        product_date = priceDate
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
                return false;
                // throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }
    }
}


