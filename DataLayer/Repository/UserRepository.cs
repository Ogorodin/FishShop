using Dapper;
using DataLayer.Entity;
using Domain.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace DataLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=the_fish_shop_db;uid=root;password=admin;";

        public object GetSafuUserInfoById(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {

                    connection.Open();
                    var storedProcedure = "get_user_data_safe";
                    var parameters = new { id };
                    var results = connection.Query<object>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();
                    if (results.Count == 0)
                    {
                        return null;
                    }
                    return results.First();
                }
            }
            catch (Exception exc)
            {
                // --- no user with requested ID found ----> redirect user
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.UserRepository", exc);
            }
        }

        public UserInfo GetUserInfoById(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {

                    connection.Open();
                    var parameters = new { id };
                    var procedure = "get_user_info_by_user_id";
                    var result = connection.Query<UserInfo>(procedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                    if (result == null || result.Count == 0)
                    {
                        return null;
                    }
                    return result.First();
                }
            }
            catch (Exception exc)
            {
                // --- no user with requested ID found ----> redirect user
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.UserRepository", exc);
            }
        }


        public bool AddUser(string firstName, string lastName, string address, string username, string password, string email, string role)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {

                    connection.Open();
                    var procedure = "insert_user_with_details";
                    var parameters = new
                    {
                        firstName,
                        lastName,
                        address,
                        username,
                        password,
                        email,
                        role
                    };
                    connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception exc)
            {
                // --- no user with requested ID found ----> redirect user
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.UserRepository", exc);
            }
        }

        public bool UpdateUserInfo(int userId, string firstName, string lastName, string address, string username, string password, string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "update_user_info_by_user_id";
                    var parameters = new
                    {
                        userId,
                        firstName,
                        lastName,
                        address,
                        username,
                        password,
                        email
                    };
                    connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception exc)
            {
                // --- no user with requested ID found ----> redirect user
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.UserRepository", exc);
            }
        }

        public bool DeleteUserById(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {

                    connection.Open();
                    var procedure = "delete_user_by_id";
                    var parameters = new { id };
                    connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception exc)
            {
                // --- no user with requested ID found ----> redirect user
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.UserRepository", exc);
            }
        }
    }
}
