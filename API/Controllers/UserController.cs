using API.Services;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<object> GetSafuUserInfoByIdAsync(int id)
        {
            var result = await _userService.GetSafuUserInfoByIdAsync(id);
            if (result != null)
            {
                return result;
            }
            return _userService.GetSafuUserInfoByIdAsync(id);
        }

        [HttpGet]
        [Route("info/{id}")]
        public async Task<UserInfo> GetUserInfoByIdAsync(int id)
        {
            return await _userService.GetUserInfoByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddUserAsync(string firstName, string lastName, string address, string username, string password, string email, string role)
        {
            return await _userService.AddUserAsync(firstName, lastName, address, username, password, email, role);
        }

        [HttpPut]
        public async Task<bool> UpdateUserInfoAsync(int userId, string firstName, string lastName, string address, string username, string password, string email)
        {
            return await _userService.UpdateUserInfoAsync(userId, firstName, lastName, address, username, password, email);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            return await _userService.DeleteUserByIdAsync(id);
        }
    }
}
