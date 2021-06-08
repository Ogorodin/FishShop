using DataLayer.Entity;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IUserService
    {
        public Task<object> GetSafuUserInfoByIdAsync(int id);
        public Task<UserInfo> GetUserInfoByIdAsync(int id);
        public Task<bool> AddUserAsync(string firstName, string lastName, string address, string username, string password, string email, string role);
        public Task<bool> UpdateUserInfoAsync(int userId, string firstName, string lastName, string address, string username, string password, string email);
        public Task<bool> DeleteUserByIdAsync(int id);
    }
}
