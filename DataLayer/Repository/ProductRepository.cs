using Dapper;
using DataLayer.Entity;
using Domain.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataLayer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=the_fish_shop_db;uid=root;password=admin;";

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var sql = "SELECT * FROM product";
                    return connection.Query<Product>(sql);
                }
            }
            catch (Exception exc)
            {
                return null;
                // throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public IEnumerable<object> GetProductsWithStockData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "get_products_with_stock_data";
                    return connection.Query<object>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                return null;
                //   throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public object GetProductById(int id)
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

                    var result = connection.QueryFirstOrDefault<Product>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception exc)
            {
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public bool AddProduct(Product product, double price, int quantity, DateTime priceDate)
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
                    connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception exc)
            {
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public bool UpdateProduct(Product product, double price, int qty, DateTime priceDate)
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
                    connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception exc)
            {
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.ProductRepository", exc);
            }
        }

        public bool DeleteProductById(int id)
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

                    connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
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


