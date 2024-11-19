using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private readonly UserDAO _userDAO;
        private PodBookingSystemContext context;
        public static User loginUser;

        public UserRepository() // Receives context from outside
        {
            
            _userDAO = new UserDAO();
        }

        public void AddUser(User user)
        {
            _userDAO.AddUser(user);
        }

        public User getLoginAccount()
        {
            if (loginUser != null)
            {
                return loginUser;
            }

            return null;

        }
        public User Authenticate(string email, string password)
        {
            context = new();
            var account = context.Users
                           .FirstOrDefault(u => u.Email == email && u.Password == password);
            loginUser = new User();
            if (account != null)
            {
                loginUser = account;
            }

            return account;

        }

        public void DeleteUser(string userId)
        {
            _userDAO.DeleteUser(userId);
        }

        public List<User> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        public User GetUserById(string userId)
        {
            return _userDAO.GetUserById(userId);
        }

        public bool Register(User user)
        {
            return _userDAO.Register(user);
        }

        public void UpdateUser(User user)
        {
            _userDAO.UpdateUser(user);
        }

        public void UpdateProfile(User user)
        {
            _userDAO.UpdateProfile(user);
        }
    }
}
