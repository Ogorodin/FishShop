using DataLayer.Entity;
using DataLayer.Repository;
using Domain.Exceptions;

namespace API.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public object GetSafuUserInfoById(int id)
        {
            try
            {
                return _repository.GetSafuUserInfoById(id);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public UserInfo GetUserInfoById(int id)
        {
            try
            {
                return _repository.GetUserInfoById(id);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public bool AddUser(string firstName, string lastName, string address, string username, string password, string email, string role)
        {
            try
            {
                return _repository.AddUser(firstName, lastName, address, username, password, email, role);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public bool UpdateUserInfo(int userId, UserInfo userInfo)
        {
            try
            {
                return _repository.UpdateUserInfo(userId, userInfo);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }

        public bool DeleteUserById(int id)
        {
            try
            {
                return _repository.DeleteUserById(id);
            }
            catch (UserServiceException exc)
            {
                throw new UserServiceException("Exception caught in API.Services.UserService", exc);
            }
        }



    }
}
