using DataLayer.Entity;
using static DataLayer.Entity.User;

namespace DataLayer.DAOs
{
    public class UserDAOFull : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ERole Role { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
