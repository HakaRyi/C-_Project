using BusinessObjects;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public User Authenticate(string email, string password)
        {
            return _userRepository.Authenticate(email, password);
        }

        public void DeleteUser(string userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(string userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public bool Register(User user)
        {
            return _userRepository.Register(user); // Calls Register from the repository
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void UpdateProfile(User user)
        {
            _userRepository.UpdateProfile(user);
        }

        public User getLoginAccount()
        {
            return _userRepository.getLoginAccount();
        }
    }
}
