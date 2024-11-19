using BusinessObjects;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POD_Booking_PRN_Wpf
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserService userService;
     
        public RegisterWindow()
        {
            InitializeComponent();
            var context = new PodBookingSystemContext();
            var userRepository = new UserRepository();
            userService = new UserService();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string fullname = FullNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string phone = PhoneTextBox.Text;
            string username = UserTextBox.Text;

            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(username))
            {
                ErrorMessage.Text = "All Field must not be empty";
                return;
            }

            var newUser = new User
            {
                UseridId = Guid.NewGuid().ToString(),
                RoleId = "1", 
                Name = fullname,
                Email = email,
                Password = password,
                Phone = phone,
                Username = username
            };

            bool isRegistered = userService.Register(newUser);
            try
            {
        
                if (isRegistered)
                {
                    MessageBox.Show("Registration successful! You can now log in.");
                }
                else
                {
                    ErrorMessage.Text = "Registration failed. Please try again.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "An error occurred during registration: " + ex.Message;
            }
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}

