using BusinessObjects;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class UserDAO
    {
        private PodBookingSystemContext _context;
        public User loginUser;

        //public UserDAO()
        //{
        //    _context = new();
        //}

        // Authenticate user by email and password
        //public User Authenticate(string email, string password)
        //{
        //    _context = new();
        //    var account = _context.Users
        //                   .FirstOrDefault(u => u.Email == email && u.Password == password);
        //    loginUser = new User();
        //    if (account != null) 
        //    {
        //        loginUser = account;
        //    }

        //    return account;

        //}

        //public User getLoginAccount()
        //{
        //    if (loginUser != null)
        //    {
        //        return loginUser;
        //    }

        //    return null;

        //}

        // Register a new user
        public bool Register(User user)
        {
            _context = new();
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Update user profile (without modifying sensitive fields like Password)
        public void UpdateProfile(User user)
        {
            _context = new();

            var existingUser = _context.Users.FirstOrDefault(u => u.UseridId == user.UseridId);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Phone = user.Phone;
                existingUser.Username = user.Username;
                // Do not update sensitive fields like Email and Password
                _context.SaveChanges();
            }
        }

        // Get all users
        public List<User> GetAllUsers()
        {
            _context = new();

            return _context.Users.ToList();
        }

        // Get user by ID
        public User GetUserById(string userId)
        {
            _context = new();

            return _context.Users.FirstOrDefault(u => u.UseridId == userId);
        }

        // Add a new user
        public void AddUser(User user)
        {
            _context = new();

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Update user details
        public void UpdateUser(User user)
        {
            _context = new();

            var existingUser = _context.Users.FirstOrDefault(u => u.UseridId == user.UseridId);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.Password = user.Password;
                existingUser.Username = user.Username;
                existingUser.RoleId = user.RoleId;
                _context.SaveChanges();
            }
        }

        // Delete user by ID
        public void DeleteUser(string userId)
        {
            _context = new();
            var user = _context.Users.FirstOrDefault(u => u.UseridId == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
