using API.Services;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataLayer.DAOs;

namespace API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSafuUserInfoByIdAsync(int id)
        {
            var result = await _userService.GetSafuUserInfoByIdAsync(id);
            if (result != null)
            {
                return StatusCode(200, result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("info/{id}")]
        public async Task<IActionResult> GetUserInfoByIdAsync(int id)
        {
            var result = await _userService.GetUserInfoByIdAsync(id);
            if (result != null)
            {
                return StatusCode(200, result);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserDAOFull userDAO)
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

            if (await _userService.AddUserAsync(user, info))
            {
                return Ok();
            }
            else return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInfoAsync([FromBody] UserDAOFull userDAO)
        {
            User user = new User
            {
                Id = userDAO.Id,
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

            if (await _userService.UpdateUserInfoAsync(user, info))
            {
                return Ok();
            }
            else return StatusCode(404);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUserByIdAsync(int id)
        {
            if (await _userService.DeleteUserByIdAsync(id))
            {
                return Ok();
            }
            else return StatusCode(404);
        }
    }
}
