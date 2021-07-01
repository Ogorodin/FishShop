using DataLayer.Entity;
using DataLayer.Repository;
using DataLayer.DAOs;
using Domain.Exceptions;
using System.Threading.Tasks;
using Domain.Models;

namespace API.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IMailService _mailService;

        public UserService(IUserRepository repository, IMailService mailService)
        {
            _repository = repository;
            _mailService = mailService;
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
            // if repo returns it means that a new user is added to the DB. If it is an employee
            // notify the admin(s) by sending them an email with a message
            bool repoDidReturn = await _repository.AddUserAsync(user, userInfo);
            try
            {
                // new service for the producer and a new project for the consumer
                if (user.Role == User.ERole.ROLE_EMPLOYEE)
                {
                    // this is where we send the email to the admin
                    await _mailService.SendEmailAsync(new MailRequest
                    {
                        // throwaway email created for testing purposes
                        ToEmail = "the.test.4dm1n@gmail.com",
                        Subject = $"New employee added to db",
                        Body = $"New employee added." +
                            $"Details:" +
                            $"FirstName:{userInfo.FirstName}" +
                            $"LastName:{userInfo.LastName}" +
                            $"Email:{user.Email}"
                    });
                }
                return repoDidReturn;
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
