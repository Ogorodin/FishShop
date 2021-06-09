using Dapper;
using DataLayer.DAOs;
using DataLayer.Entity;
using Domain.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserDAO> GetSafuUserInfoByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {

                    connection.Open();
                    var storedProcedure = "get_user_data_safe";
                    var parameters = new { id };
                    var results = await connection.QueryAsync<UserDAO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                    if (results.First() == null)
                    {
                        return null;
                    }

                    return results.First();
                }
            }
            catch (Exception exc)
            {
                // --- no user with requested ID found ----> redirect user
                return null;
                //  throw new DataLayerException("DataLayerException caught in DataLayer.Repository.UserRepository", exc);
            }
        }

        public async Task<UserInfo> GetUserInfoByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var parameters = new { id };
                    var procedure = "get_user_info_by_user_id";
                    var result = await connection.QueryAsync<UserInfo>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    if (result == null || result.First() == null)
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


        public async Task<bool> AddUserAsync(User user, UserInfo userInfo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "insert_user_with_details";
                    var parameters = new
                    {
                        userInfo.FirstName,
                        userInfo.LastName,
                        userInfo.Address,
                        user.Username,
                        user.Password,
                        user.Email,
                        user.Role
                    };
                    await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception exc)
            {
                // --- no user with requested ID found ----> redirect user
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.UserRepository", exc);
            }
        }

        public async Task<bool> UpdateUserInfoAsync(User user, UserInfo userInfo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "update_user_info_by_user_id";
                    var parameters = new
                    {
                        userInfo.FirstName,
                        userInfo.LastName,
                        userInfo.Address,
                        user.Username,
                        user.Password,
                        user.Email,
                        user.Role
                    };
                    await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception exc)
            {
                // --- no user with requested ID found ----> redirect user
                throw new DataLayerException("DataLayerException caught in DataLayer.Repository.UserRepository", exc);
            }
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var procedure = "delete_user_by_id";
                    var parameters = new { id };
                    await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
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
