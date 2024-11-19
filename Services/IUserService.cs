using BusinessObjects;
using System.Collections.Generic;

namespace Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        bool Register(User user);

        void UpdateProfile(User user);
        List<User> GetAllUsers();
        User GetUserById(string userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string userId);

        public User getLoginAccount();
    }
}
