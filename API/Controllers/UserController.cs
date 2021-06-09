using API.Services;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataLayer.DAOs;

namespace API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController
    {
        private IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserDAO> GetSafuUserInfoByIdAsync(int id)
        {
            return await _userService.GetSafuUserInfoByIdAsync(id);
        }

        [HttpGet]
        [Route("info/{id}")]
        public async Task<UserInfo> GetUserInfoByIdAsync(int id)
        {
            return await _userService.GetUserInfoByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddUserAsync([FromBody] UserDAOFull userDAO)
        {
            User user = new User
            {
                Username = userDAO.Username,
                Password = userDAO.Password,
                Role = userDAO.Role,
                Email = userDAO.Email
            };

            UserInfo info = new UserInfo
            {
                FirstName = userDAO.FirstName,
                LastName = userDAO.LastName,
                Address = userDAO.Address
            };

            return await _userService.AddUserAsync(user, info);
        }

        [HttpPut]
        public async Task<bool> UpdateUserInfoAsync([FromBody] UserDAOFull userDAO)
        {
            User user = new User
            {
                Username = userDAO.Username,
                Password = userDAO.Password,
                Role = userDAO.Role,
                Email = userDAO.Email
            };

            UserInfo info = new UserInfo
            {
                FirstName = userDAO.FirstName,
                LastName = userDAO.LastName,
                Address = userDAO.Address
            };
            return await _userService.UpdateUserInfoAsync(user, info);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            return await _userService.DeleteUserByIdAsync(id);
        }
    }
}
