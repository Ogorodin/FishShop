using DataLayer.Entity;

namespace API.Services
{
    public interface IUserService
    {
        public object GetSafuUserInfoById(int id);
        public UserInfo GetUserInfoById(int id);
        public bool AddUser(string firstName, string lastName, string address, string username, string password, string email, string role);
        public bool UpdateUserInfo(int userId, UserInfo userInfo);
        public bool DeleteUserById(int id);
    }
}
