using DataLayer.Entity;
using DataLayer.Repository;
using Domain.Exceptions;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> GetSafuUserInfoByIdAsync(int id)
        {
            try
            {
                return await _repository.GetSafuUserInfoByIdAsync(id);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public async Task<UserInfo> GetUserInfoByIdAsync(int id)
        {
            try
            {
                return await _repository.GetUserInfoByIdAsync(id);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public async Task<bool> AddUserAsync(string firstName, string lastName, string address, string username, string password, string email, string role)
        {
            try
            {
                return await _repository.AddUserAsync(firstName, lastName, address, username, password, email, role);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public async Task<bool> UpdateUserInfoAsync(int userId, string firstName, string lastName, string address, string username, string password, string email)
        {
            try
            {
                return await _repository.UpdateUserInfoAsync(userId, firstName, lastName, address, username, password, email);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            try
            {
                return await _repository.DeleteUserByIdAsync(id);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }



    }
}
