using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class User : BaseEntity
    {
        public enum ERole
        {
            ROLE_ADMIN, ROLE_CUSTOMER, ROLE_EMPLOYEE
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ERole Role { get; set; }

        public UserInfo Info { get; set; }

        public List<Order> OrderList { get; set; }

        public User() { }

        public User(string username, string password, string email, ERole role)
        {
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }
    }
}