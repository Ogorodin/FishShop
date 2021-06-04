using API.Services;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public object GetSafuUserInfoById(int id)
        {
            return _userService.GetSafuUserInfoById(id);
        }

        [HttpGet]
        [Route("info/{id}")]
        public UserInfo GetUserInfoById(int id)
        {
            return _userService.GetUserInfoById(id);
        }

        [HttpPost]
        public bool AddUser(string firstName, string lastName, string address, string username, string password, string email, string role)
        {
            return _userService.AddUser(firstName, lastName, address, username, password, email, role);
        }

        [HttpPut]
        public bool UpdateUserInfo(int userId, UserInfo userInfo)
        {
            return _userService.UpdateUserInfo(userId, userInfo);
        }
        [HttpDelete]
        [Route("{id}")]
        public bool DeleteUserById(int id)
        {
            return _userService.DeleteUserById(id);
        }
    }
}
