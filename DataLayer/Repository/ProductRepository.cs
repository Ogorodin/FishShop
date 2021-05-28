using Dapper;
using DataLayer.Entity;
using Domain.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DataLayer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionSting = "server=localhost;port=3306;database=the_fish_shop_db;uid=root;password=admin;";

        public IEnumerable<Product> GetProducts()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionSting))
            {
                connection.Open();
                var sql = "SELECT * FROM product";
                return connection.Query<Product>(sql);
            }
        }
        public Product GetProductById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionSting))
            {
                try
                {
                    connection.Open();
                    var parameters = new
                    {
                        Id = id
                    };
                    var sql = "SELECT * FROM Product WHERE Id = @Id";
                    var result = connection.QueryFirst<Product>(sql, parameters);
                    return result;
                }
                catch (DataLayerException exc)
                {
                    throw new DataLayerException("Exception thrown in API.DataLayer.ProductRepository.GetProductById", exc);
                }
            }
        }

        public bool AddProduct(Product product)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionSting))
            {
                try
                {
                    connection.Open();
                    var parameters = new
                    {
                        Title = product.title,
                        Description = product.description,
                        Type = product.the_type
                    };
                    var sql = "INSERT INTO product (title, description, the_type) VALUES (@Title, @Description, @Type)";
                    connection.Execute(sql, parameters);
                    return true;
                }
                catch (DataLayerException exc)
                {
                    throw new DataLayerException("Exception thrown in API.DataLayer.ProductRepository.AddProduct", exc);
                }
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionSting))
            {
                try
                {
                    connection.Open();
                    var parameters = new
                    {
                        Id = product.Id,
                        Title = product.title,
                        Description = product.description,
                        TheType = product.the_type
                    };

                    var sql = "UPDATE Product SET Title = @Title, Description = @Description, The_type = @TheType WHERE id = @Id";
                    connection.Execute(sql, parameters);

                    return true;
                }
                catch (DataLayerException exc)
                {
                    throw new DataLayerException("Exception thrown in API.DataLayer.ProductRepository.UpdateProduct", exc);
                }
            }
        }

        public bool DeleteProductById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionSting))
            {
                try
                {
                    connection.Open();
                    var parameters = new
                    {
                        Id = id
                    };
                    var sql = "DELETE FROM Product WHERE Id = @Id";
                    connection.Execute(sql, parameters);
                    return true;
                }
                catch (DataLayerException exc)
                {
                    throw new DataLayerException("Exception thrown in API.DataLayer.ProductRepository.DeleteProduct", exc);
                }
            }
        }
    }
}


