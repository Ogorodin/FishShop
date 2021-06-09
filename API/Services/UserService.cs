using DataLayer.Entity;
using DataLayer.Repository;
using DataLayer.DAOs;
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

        public async Task<UserDAO> GetSafuUserInfoByIdAsync(int id)
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

        public async Task<bool> AddUserAsync(User user, UserInfo userInfo)
        {
            try
            {
                return await _repository.AddUserAsync(user, userInfo);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public async Task<bool> UpdateUserInfoAsync(User user, UserInfo userInfo)
        {
            try
            {
                return await _repository.UpdateUserInfoAsync(user, userInfo);
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
