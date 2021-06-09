using DataLayer.DAOs;
using DataLayer.Entity;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IUserRepository
    {
        public Task<UserDAO> GetSafuUserInfoByIdAsync(int id);
        public Task<UserInfo> GetUserInfoByIdAsync(int id);
        public Task<bool> AddUserAsync(User user, UserInfo userInfo);
        public Task<bool> UpdateUserInfoAsync(User user, UserInfo userInfo);
        public Task<bool> DeleteUserByIdAsync(int id);

    }
}
